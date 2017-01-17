using AutoMapper;
using WebShop.DAL.Interfaces;
using WebShop.DAL.POCO;
using WebShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebShop.WebApi
{
    public class ProductsController : ApiController
    {
        IProductRepository productRepository;
        IMapper mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IHttpActionResult GetProducts(int materialId, string sortByDiameter, string sortByPrice, int maximumRows, int currentPageNumber)
        {
            double pageCount;
            IEnumerable<Product> products = productRepository.GetProducts( materialId,  sortByDiameter,  sortByPrice,  maximumRows,  currentPageNumber, out pageCount);
            IEnumerable<ProductItemViewModel> model = mapper.Map<IEnumerable<Product>, IEnumerable<ProductItemViewModel>>(products);
            for(int i = 0;i<model.Count();i++)          
                model.ElementAt(i).ThumbImgPath = model.ElementAt(i).ThumbImgPath.Replace("~", ""); 

            return Ok(new { pageCount, currentPageNumber, model });
        }
    }
}
