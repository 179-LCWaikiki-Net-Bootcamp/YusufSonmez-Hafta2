using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogueWebapi.Common;
using ProductCatalogueWebapi.Entities;

namespace ProductCatalogueWebapi.Operations.ProductOperations.GetProducts
{
    public class GetProductsQuery
    {
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProductsQuery(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ProductViewModel> Handle()
        {
            // var productList = _dbContext.Products.OrderBy(x=>x.Id).ToList<Product>();
            var productList = _dbContext.Products.Include(x=>x.Genre).OrderBy(x=>x.Id).ToList<Product>();
            List<ProductViewModel> vm = _mapper.Map<List<ProductViewModel>>(productList);//new List<ProductViewModel>();
            // foreach(var product in productList)
            // {
            //     vm.Add(new ProductViewModel(){
            //         Title = product.Title,
            //         Price = product.Price,
            //         Genre = ((GenreEnum)product.GenreId).ToString()
            //     });
            // }
            return vm; 
        }
    }

    public class ProductViewModel
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Genre { get; set; }
    }
}