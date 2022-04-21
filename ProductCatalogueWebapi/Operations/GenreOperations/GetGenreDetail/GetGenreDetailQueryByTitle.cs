using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogueWebapi.Common;

namespace ProductCatalogueWebapi.Operations.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQueryByTitle
    {
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        public string Title { get; set; }
        public GetGenreDetailQueryByTitle(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModelByTitle Handle()
        {
            var genre = _dbContext.Genres.Where(x=>x.Title == Title).SingleOrDefault();

            GenreDetailViewModelByTitle vm = _mapper.Map<GenreDetailViewModelByTitle>(genre);
            if(genre is null)
            {
                throw new InvalidOperationException("Tür bulunamadı");
            }
            
            return vm;
        }
    }

    public class GenreDetailViewModelByTitle
    {
      public int Id { get; set; }
      public string Title { get; set; }
    }
}