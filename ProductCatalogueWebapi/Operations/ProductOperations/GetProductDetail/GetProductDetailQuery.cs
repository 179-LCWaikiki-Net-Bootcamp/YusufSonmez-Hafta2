using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogueWebapi.Common;

namespace ProductCatalogueWebapi.Operations.ProductOperations.GetProductDetail
{
    public class GetProductDetailQuery
    {
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        public int ProductId { get; set; }
        public GetProductDetailQuery(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ProductDetailViewModel Handle()
        {
            var product = _dbContext.Products.Include(x=>x.Genre).Where(x=>x.Id == ProductId).SingleOrDefault();

            if(product is null)
            {
                throw new InvalidOperationException("Ürün bulunamadı");
            }
            ProductDetailViewModel vm = _mapper.Map<ProductDetailViewModel>(product); 
            
            return vm;
        }
    }

    public class ProductDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
    }
}