using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogueWebapi.Common;

namespace ProductCatalogueWebapi.Operations.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly ProjectDbContext _context;
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        public UpdateGenreCommand(ProjectDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=>x.Id == GenreId);
            // Eger degistirilmek istenen title zaten var mı diye kontrol etmek icin eklendi.
            var checkIfTitleExist = _context.Genres.SingleOrDefault(x=>x.Title == Model.Title);

            // Öyle bir id'ye sahip bir ürün var ise günceller ve Ok() fonksiyonu ile bunu bildirir, yok ise BadRequest() ile hata mesajı döner.
            if(genre is null)
            {
                throw new InvalidOperationException("Tür bulunamadı!");
            }
            
           
                if(checkIfTitleExist is null)
                // Bir ürün başka bir ürün adına sahip olacak şekilde degiştirilirse "Ürün stokta mevcut!" hatasını döner. Aksi takdirde güncellemeyi yapacaktır.
                    {
                        genre.Title = Model.Title != default ? Model.Title : genre.Title;
                        _context.SaveChanges();

                        System.Console.WriteLine("Tür başarıyla güncellendi!");
                    }
                else
                    {
                        throw new InvalidOperationException("Tür stokta mevcut!");
                    }
          
          
        }

        public class UpdateGenreModel
        {
            public string Title { get; set; }
        }
    }
}