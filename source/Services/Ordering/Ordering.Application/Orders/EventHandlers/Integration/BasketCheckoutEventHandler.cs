using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger) : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event Handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateOrderCommand(context.Message);

        await sender.Send(command);
    }

    public CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {

        var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine, message.Country, message.State, message.ZipCode);
        var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);

        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(
            Id: orderId,
            CustomerId: message.CustomerId,
            OrderName: message.UserName,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymentDto,
            status: Ordering.Domain.Enums.OrderStatus.Pending,
            OrderItems: [
                new OrderItemDto(orderId, new Guid("12c87792-ec65-4de2-86e7-033c54691aab"), 2,500),
                new OrderItemDto(orderId, new Guid("349dc8dc-990f-48e0-a37b-e6f2b60b9d7d"), 1, 400)
                ]
            );


        return new CreateOrderCommand(orderDto);
    }
}
