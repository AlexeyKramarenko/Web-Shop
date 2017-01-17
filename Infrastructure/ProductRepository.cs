using WebShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using WebShop.DAL.POCO;
using Infrastructure;
using ApplicationCore.DomainModel;

namespace WebShop.DAL
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public List<Product> GetProducts(int materialId, string sortByDiameter, string sortByPrice, int maximumRows, int currentPageNumber, out double pageCount)
        {
            var queryList = new List<string>();

            IQueryable<Product> db_products = db.Products.Include("Material");

            if (materialId > 0)
                db_products = db_products.Where(a => a.MaterialID == materialId);


            db_products = db_products.OrderBy("Diameter " + sortByDiameter)
                                     .OrderBy("PricePerMeter " + sortByPrice);

            int rowsCount = db_products.Count();

            pageCount = Math.Ceiling((double)rowsCount / maximumRows);

            List<Product> products = db_products.Skip(maximumRows * (currentPageNumber - 1))
                                                .Take(maximumRows)
                                                .Select(a => new
                                                {
                                                    ProductID = a.ProductID,
                                                    PricePerMeter = a.PricePerMeter,
                                                    SKU = a.SKU,
                                                    Name = a.Name,
                                                    ThumbImgPath = a.ThumbImgPath,
                                                    Material = a.Material,
                                                    Diameter = a.Diameter
                                                }).AsEnumerable()
                                                .Select(a => new Product
                                                {
                                                    ProductID = a.ProductID,
                                                    PricePerMeter = a.PricePerMeter,
                                                    SKU = a.SKU,
                                                    Name = a.Name,
                                                    ThumbImgPath = a.ThumbImgPath,
                                                    Material = a.Material,
                                                    Diameter = a.Diameter
                                                })
                                                .ToList();
            return products;
        }
        public void AddProduct(Product product)
        {
            db.Products.Add(product);
        }
        public Product GetProductByID(int productId)
        {
            return db.Products.Find(productId);
        }
        public void RemoveProduct(int productId)
        {
            Product product = db.Products.Find(productId);
            if (product != null)
                db.Products.Remove(product);
        }
        public void UpdateProduct(Product product)
        {
            Product p = db.Products.Find(product.ProductID);
            if (p != null)
            {
                p.Description = product.Description;
                p.Diameter = product.Diameter;
                p.MaterialID = product.MaterialID;
                p.Name = product.Name;
                p.PricePerMeter = product.PricePerMeter;
                p.SKU = product.SKU;
            }
        }

        public List<Material> GetMaterials()
        {
            return db.Materials.ToList();
        }
       

        public int GetMaterialIDByName(string materialName)
        {
            var material = db.Materials.FirstOrDefault(a => a.MaterialName == materialName);
            if (material != null)
                return material.MaterialID;
            return -1;
        }
        public List<Product> GetProducts(int? materialId)
        {
            IQueryable<Product> products = null;
            if (materialId != 0)
                products = db.Products.Where(a => a.MaterialID == materialId);
            else
                products = db.Products;

            var _products = products.Select(a => new
            {
                ProductID = a.ProductID,
                Name = a.Name,
                ThumbImgPath = a.ThumbImgPath,
                Material = a.Material,
            }).AsEnumerable()
                                                  .Select(a => new Product
                                                  {
                                                      ProductID = a.ProductID,
                                                      Name = a.Name,
                                                      ThumbImgPath = a.ThumbImgPath,
                                                      Material = a.Material,
                                                  })
                                                  .ToList();
            return _products;
        }

        public string GetThumbnailImage(int productID)
        {
            Product product = db.Products.Find(productID);
            if (product != null)
                return product.ThumbImgPath;
            return null;
        }
    }
}
