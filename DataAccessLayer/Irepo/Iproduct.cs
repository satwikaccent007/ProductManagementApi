using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Models;
namespace DataAccessLayer.Irepo
{
    public interface Iproduct
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<bool> AddProduct(Product product);
        Task<bool> EditProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
