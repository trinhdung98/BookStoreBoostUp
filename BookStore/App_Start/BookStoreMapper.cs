using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.App_Start
{
    public static class BookStoreMapper
    {
        static BookStoreMapper()
        {
            CreatingMapping();
        }

        public static IMapper Mapper { get; set; }

        public static IConfigurationProvider MapperConfiguration { get; set; }

        public static void CreatingMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            MapperConfiguration = config;
            Mapper = config.CreateMapper();
        }
    }
}