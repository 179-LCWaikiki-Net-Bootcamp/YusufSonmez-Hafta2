using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalogueWebapi.Operations.ProductOperations.GetProductDetail
{
    public class GetProductDetailQueryByTitle
    {
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        public string Title { get; set; }
        public GetProductDetailQueryByTitle(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ProductDetailViewModelByTitle Handle()
        {
            var product = _dbContext.Products.Include(x=>x.Genre).Where(x=>x.Title == Title).SingleOrDefault();

            ProductDetailViewModelByTitle vm = _mapper.Map<ProductDetailViewModelByTitle>(product);
            if(product is null)
            {
                throw new InvalidOperationException("Ürün bulunamadı");
            }            
            return vm;
        }
    }

    public class ProductDetailViewModelByTitle
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
    }
}