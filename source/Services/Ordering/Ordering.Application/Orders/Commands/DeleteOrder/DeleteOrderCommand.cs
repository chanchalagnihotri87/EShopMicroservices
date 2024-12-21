using FluentValidation;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public record DeleteOrderCommand(Guid orderId):ICommand<DeleteOrderResult>;

public record DeleteOrderResult(bool IsSuccess);

public class DeleteCommandValidator : AbstractValidator<DeleteOrderCommand> {

    public DeleteCommandValidator()
    {
        RuleFor(x => x.orderId).NotEmpty().WithMessage("OrderId is required");
    }
}
