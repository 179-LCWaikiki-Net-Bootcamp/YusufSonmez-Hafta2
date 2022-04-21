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
    public class GetGenreDetailQuery
    {
        private readonly ProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        public GetGenreDetailQuery(ProjectDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _dbContext.Genres.Where(x=>x.Id == GenreId).SingleOrDefault();

            if(genre is null)
            {
                throw new InvalidOperationException("Tür bulunamadı");
            }
            GenreDetailViewModel vm = _mapper.Map<GenreDetailViewModel>(genre);

            return vm;
        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}