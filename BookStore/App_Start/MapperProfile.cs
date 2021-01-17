using AutoMapper;
using BookStore.Entities;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.App_Start
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel, Book>().ConstructUsing(x => 
                new Book(x.ID, x.Title, x.Description, x.Author, x.Price));
        }
    }
}