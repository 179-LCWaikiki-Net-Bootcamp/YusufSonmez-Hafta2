using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogueWebapi.Common;

namespace ProductCatalogueWebapi.Operations.ProductOperations.DeleteProduct
{
    public class DeleteProductCommand
    {
        private readonly ProjectDbContext _context;
        public int ProductId { get; set; }
        public DeleteProductCommand(ProjectDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var product = _context.Products.SingleOrDefault(x=>x.Id == ProductId);
            
            // Öyle bir id'ye sahip bir ürün yoksa InvalidOperationException() fonksiyonu ile hata döner, varsa ürünü siler ve bunu bildirir.
            if(product is null)
            {
                throw new InvalidOperationException("Ürün id'si bulunamadı!");
            }
            else
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            // return Ok("Ürün başarıyla silindi!");
            System.Console.WriteLine("Ürün başarıyla silindi!");
        }
    }
}