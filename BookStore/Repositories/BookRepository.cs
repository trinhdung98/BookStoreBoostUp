using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookStore.Entities;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreDbContext context;
        public BookRepository()
        {
            context = new BookStoreDbContext();
        }

        public void CreateBook(Book book)
        {
            Book oldBook = context.Books.Where(x => x.ID == book.ID).FirstOrDefault();
            if (oldBook == null)
            {
                context.Books.Add(book);
            }
            else
            {
                oldBook.Author = book.Author;
                oldBook.Description = book.Description;
                oldBook.Price = book.Price;
                oldBook.Title = book.Title;
            }
            context.SaveChanges();
        }

        public Book DeleteBook(int bookId)
        {
            Book oldBook = context.Books.Where(x => x.ID == bookId).SingleOrDefault();
            if (oldBook != null)
            {
                context.Books.Remove(oldBook);
                context.SaveChanges();
            }
            return oldBook;
        }

        public Book GetBook(int bookId)
        {
            Book oldBook = context.Books.Where(x => x.ID == bookId).SingleOrDefault();
            return oldBook; 
        }

        public IQueryable<Book> GetBooks()
        {
            IQueryable<Book> books = context.Set<Book>();
            return books;
        }

        public Book UpdateBook(Book book)
        {
            Book oldBook = context.Books.Where(x => x.ID == book.ID).SingleOrDefault();
            if (oldBook != null)
            {
                context.Books.Remove(oldBook);
                context.Books.Add(book);
                context.SaveChanges();
            }
            return book;
        }
    }
}