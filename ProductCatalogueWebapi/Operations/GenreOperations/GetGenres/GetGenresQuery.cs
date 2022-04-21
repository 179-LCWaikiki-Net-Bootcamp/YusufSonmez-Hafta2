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

namespace ProductCatalogueWebapi.Operations.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGenresQuery(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {

            var genreList = _dbContext.Genres.ToList<Genre>();
            List<GenreViewModel> vm = _mapper.Map<List<GenreViewModel>>(genreList);

            return vm; 
        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}