using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogueWebapi.Common;

namespace ProductCatalogueWebapi.Operations.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly ProjectDbContext _context;
        public int GenreId { get; set; }
        public DeleteGenreCommand(ProjectDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=>x.Id == GenreId);
            
            // Öyle bir id'ye sahip bir ürün yoksa InvalidOperationException() fonksiyonu ile hata döner, varsa ürünü siler ve bunu bildirir.
            if(genre is null)
            {
                throw new InvalidOperationException("Tür id'si bulunamadı!");
            }
            else
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
            // return Ok("Ürün başarıyla silindi!");
            System.Console.WriteLine("Tür başarıyla silindi!");
        }
    }
}