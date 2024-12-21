

using Microsoft.EntityFrameworkCore;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand commad, CancellationToken cancellationToken)
    {

        var orderId = OrderId.Of(commad.orderId);
        var order = await dbContext.Orders.FindAsync([orderId], cancellationToken);

        if (order == null)
        {
            throw new OrderNotFoundException(commad.orderId);
        }

        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(cancellationToken);


        return new DeleteOrderResult(true);
    }
}
