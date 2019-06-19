using System;
using FlixOne.CQRS.Commands.Command;
using FlixOne.CQRS.Domain.Entity;
using FlixOne.DB.Persistence;
using Product = FlixOne.Common.Models.Product;

namespace FlixOne.CQRS.Commands.Handler
{
    public class ProductCommandHandler : ICommandHandler<SaveProductCommand, CommandResponse>
    {
        private readonly IProductRepository _productRepository;

        //save or update
        private readonly SaveProductCommand _saveProductCommand;

        public ProductCommandHandler(SaveProductCommand saveProductCommand)
        {
            _productRepository = new ProductRepository();
            _saveProductCommand = saveProductCommand;
        }

        public CommandResponse Execute()
        {
            var response = new CommandResponse();
            try
            {
                var product = _saveProductCommand.Product;
                var model = new Product
                {
                    Id = product.Id,
                    Description = product.Description,
                    Name = product.Name,
                    Image = product.Image,
                    Price = product.Price,
                     CategoryId = product.CategoryId
                };
                var existingProduct = _productRepository.GetBy(model.Id);
                if (existingProduct == null)
                {
                    model.Id = Guid.NewGuid();
                    _productRepository.Add(model);
                }
                else
                    _productRepository.Update(model);


                response.Id = model.Id;
                response.Message = "Product has saved";
                response.Success = true;
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
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(DeleteProductCommand deleteProductCommand)
        {
            _productRepository = new ProductRepository();
            _deleteProductCommand = deleteProductCommand;
        }

        public CommandResponse Execute()
        {
            var response = new CommandResponse();
            try
            {
                var existingProduct = _productRepository.GetBy(_deleteProductCommand.Id);
                if (existingProduct == null)
                {
                    response.Id = _deleteProductCommand.Id;
                    response.Success = false;
                    response.Message = $"Product with ID:{_deleteProductCommand.Id} does not exist.";
                }
                else
                {
                    _productRepository.Remove(_deleteProductCommand.Id);
                }
            }
            catch (Exception ex)
            {
                response.Id = Guid.NewGuid();
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}