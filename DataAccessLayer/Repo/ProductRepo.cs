using DataAccessLayer.Irepo;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repo
{
    public class ProductRepo:Iproduct
    {
        private readonly ProductDbContext _db;
        public ProductRepo(ProductDbContext db)
        {
            _db = db;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = await _db.Products.ToListAsync();
            return products;
        }

        
        public async Task<Product> GetProduct(int id)
        {
            Product? product = await _db.Products.FindAsync(id);
            if (product == null) throw new Exception("product does not exist");
            return product;
        }

        public async Task<bool> AddProduct(Product product)
        {
            _db.Products.Add(product);
            int res = await _db.SaveChangesAsync();
            if (res == 0) throw new Exception("product can not be added try again");
            return true;
        }
        public async Task<bool> EditProduct(Product product)
        {
            _db.Products.Update(product);
            int res = await _db.SaveChangesAsync();
            if (res == 0) throw new Exception("product can not be updated try again");
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product product =await GetProduct(id);
            _db.Products.Remove(product);
            int res = await _db.SaveChangesAsync();
            if (res == 0) throw new Exception("product can not be deleted try again");
            return true;
        }
    }
}
