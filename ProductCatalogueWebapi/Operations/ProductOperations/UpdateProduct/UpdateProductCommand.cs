using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogueWebapi.Common;

namespace ProductCatalogueWebapi.Operations.ProductOperations.UpdateProduct
{
    public class UpdateProductCommand
    {
        private readonly ProjectDbContext _context;
        public int ProductId { get; set; }
        public UpdateProductModel Model { get; set; }
        public UpdateProductCommand(ProjectDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var product = _context.Products.SingleOrDefault(x=>x.Id == ProductId);
            // Eger degistirilmek istenen title zaten var mı diye kontrol etmek icin eklendi.
            var checkIfTitleExist = _context.Products.SingleOrDefault(x=>x.Title == Model.Title);

            // Öyle bir id'ye sahip bir ürün var ise günceller ve Ok() fonksiyonu ile bunu bildirir, yok ise BadRequest() ile hata mesajı döner.
            if(product is null)
            {
                throw new InvalidOperationException("Ürün bulunamadı!");
            }
            
           
                if(checkIfTitleExist is null)
                // Bir ürün başka bir ürün adına sahip olacak şekilde degiştirilirse "Ürün stokta mevcut!" hatasını döner. Aksi takdirde güncellemeyi yapacaktır.
                    {
                        product.Title = Model.Title != default ? Model.Title : product.Title;
                        product.Price = Model.Price != default ? Model.Price : product.Price;
                        _context.SaveChanges();
                        // return Ok("Ürün başarıyla güncellendi!");
                        System.Console.WriteLine("Ürün başarıyla güncellendi!");
                    }
                else
                    {
                        throw new InvalidOperationException("Ürün stokta mevcut!");
                    }
          
          
        }

        public class UpdateProductModel
        {
            public string Title { get; set; }
            public double Price { get; set; }
        }
    }
}