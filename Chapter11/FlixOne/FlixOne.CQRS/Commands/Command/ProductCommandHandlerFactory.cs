using FlixOne.CQRS.Commands.Handler;
using FlixOne.CQRS.Domain.Entity;

namespace FlixOne.CQRS.Commands.Command
{
    public static class ProductCommandHandlerFactory
    {
        public static ICommandHandler<SaveProductCommand, CommandResponse> Build(SaveProductCommand saveProductCommand)
        {
            return new ProductCommandHandler(saveProductCommand);
        }

        public static ICommandHandler<DeleteProductCommand, CommandResponse> Build(
            DeleteProductCommand deleteProductCommand)
        {
            return new DeleteProductCommandHandler(deleteProductCommand);
        }
    }
}