using System;
using System.Collections.Generic;
using FlixOne.API.Models;

namespace FlixOne.API.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product">Product model</param>
        void Add(Product product);
        /// <summary>
        /// Product Listing
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetAll();
        /// <summary>
        /// Get Product by its unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetBy(Guid id);
        /// <summary>
        /// Remove a specific Product
        /// </summary>
        /// <param name="id"></param>
        void Remove(Guid id);
        /// <summary>
        /// Update an existing product
        /// </summary>
        /// <param name="product"></param>
        void Update(Product product);
    }
}