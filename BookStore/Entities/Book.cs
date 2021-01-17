using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Entities
{
    public class Book
    {
        public Book()
        {
        }

        public Book(int iD, string title, string description, string author, decimal price)
        {
            ID = iD;
            Title = title;
            Description = description;
            Author = author;
            Price = price;
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }
}