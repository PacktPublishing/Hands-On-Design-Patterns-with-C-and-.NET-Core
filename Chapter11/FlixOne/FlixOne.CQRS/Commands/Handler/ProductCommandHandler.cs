using System;
using FlixOne.CQRS.Commands.Command;
using FlixOne.CQRS.Domain.Entity;

namespace FlixOne.CQRS.Commands.Handler
{
    public class ProductCommandHandler:ICommandHandler<SaveProductCommand,CommandResponse>
    {
        //save or update
        private readonly SaveProductCommand _saveProductCommand;
        public ProductCommandHandler(SaveProductCommand saveProductCommand)
        {
            _saveProductCommand = saveProductCommand;
        }
        public CommandResponse Execute()
        {
            var response = new CommandResponse();
            try
            {
                //call repository
            }
            catch (Exception ex)
            {
                //log error
                response.Id = Guid.NewGuid();
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }
    }

    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, CommandResponse>
    {
        private readonly DeleteProductCommand _deleteProductCommand;

        public DeleteProductCommandHandler(DeleteProductCommand deleteProductCommand)
        {
            _deleteProductCommand = deleteProductCommand;
        }

        public CommandResponse Execute()
        {
            var response = new CommandResponse();
            try
            {
                //call repository
            }
            catch (Exception ex)
            {
                //log error
                response.Id = Guid.NewGuid();
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
