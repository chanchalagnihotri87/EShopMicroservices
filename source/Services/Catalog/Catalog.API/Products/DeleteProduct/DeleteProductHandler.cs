
namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandValidation : AbstractValidator<DeleteProductCommand> {

    public DeleteProductCommandValidation()
    {
        RuleFor(v => v.Id).NotEmpty().WithMessage("Product ID is required");
    }
}

internal class DeleteProductHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product == null)
        {
            throw new ProductNotFoundException(command.Id);
        }

        session.Delete(product);

        await session.SaveChangesAsync();

        return new DeleteProductResult(true);
    }
}
