using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogueWebapi.Common;
using ProductCatalogueWebapi.Entities;

namespace ProductCatalogueWebapi.Operations.ProductOperations.CreateProduct
{
    public class CreateProductCommand
    {
        public CreateProductModel Model { get; set; }
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateProductCommand(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var product = _dbContext.Products.SingleOrDefault(x=>x.Title == Model.Title);

            if(product is not null)
            {
                throw new InvalidOperationException("Ürün stokta mevcut!"); 
            }
            product = _mapper.Map<Product>(Model);


            
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public class CreateProductModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public double Price { get; set; }
        }
    }
}