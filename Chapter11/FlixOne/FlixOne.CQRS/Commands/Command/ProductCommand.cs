using System;
using FlixOne.CQRS.Domain.Entity;

namespace FlixOne.CQRS.Commands.Command
{
    public class SaveProductCommand : ICommand<CommandResponse>
    {
        public SaveProductCommand(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }

    public class DeleteProductCommand : ICommand<CommandResponse>
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}