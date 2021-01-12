using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Entities;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void CreateBook(Book book)
        {
            _bookRepository.CreateBook(book);
        }

        public Book DeleteBook(int bookId)
        {
            return _bookRepository.DeleteBook(bookId);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.Books;
        }

        public Book GetBook(int bookId)
        {
            return _bookRepository.GetBook(bookId);
        }

        public Book UpdateBook(Book book)
        {
            return _bookRepository.UpdateBook(book);
        }
    }
}