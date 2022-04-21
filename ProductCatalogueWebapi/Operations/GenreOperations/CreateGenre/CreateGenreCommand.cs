using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogueWebapi.Common;
using ProductCatalogueWebapi.Entities;

namespace ProductCatalogueWebapi.Operations.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateGenreCommand(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Title == Model.Title);

            // Tür mevcut degilse girilmişse(required) kaydet ve Ok("Tür başarıyla eklendi!") mesajı dön.
            if(genre is not null)
            {
            //    return BadRequest("Tür mevcut!");
            throw new InvalidOperationException("Tür mevcut!"); 
            }
            genre = _mapper.Map<Genre>(Model); 
            
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }

        public class CreateGenreModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
}