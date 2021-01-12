using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Repositories
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext() : base("BookStore")
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}