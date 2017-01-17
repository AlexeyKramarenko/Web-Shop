using ApplicationCore.DomainModel;
using WebShop.DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShop.DAL.Interfaces
{
    public interface IProductRepository : IDisposable
    {
        List<Product> GetProducts(int? materialId);
        List<Product> GetProducts(int materialId, string sortByDiameter, string sortByPrice, int maximumRows, int currentPageNumber, out double pageCount);
        Product GetProductByID(int productId);
        void AddProduct(Product product);
        void RemoveProduct(int productId);
        void UpdateProduct(Product product);
        List<Material> GetMaterials();
        int Save();
        int GetMaterialIDByName(string material);
        string GetThumbnailImage(int productID);
    }
}
