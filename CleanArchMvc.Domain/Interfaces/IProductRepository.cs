using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Getproducts();
        Task<Product> GetByIdAsync(int? id);
        Task<Product> GetProductCategoryAsync(int? id);

        Task<Product> Create(Product produtc);
        Task<Product> Update(Product product);
        Task<Product> Remove(Product product);
    }
}
