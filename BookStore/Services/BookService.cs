using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStore.Entities;
using BookStore.Models;
using BookStore.Repositories;
using Ninject;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        [Inject]
        public IMapper Mapper { get; set; }

        private IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void CreateBook(BookViewModel bookVm)
        {
            _bookRepository.CreateBook(Mapper.Map<BookViewModel, Book>(bookVm));
        }

        public BookViewModel DeleteBook(int bookId)
        {
            return Mapper.Map<Book, BookViewModel>(_bookRepository.DeleteBook(bookId));
        }

        public List<BookViewModel> GetAllBooks()
        {
            return _bookRepository.GetBooks().ProjectTo<BookViewModel>(
                new MapperConfiguration(cfg => cfg.CreateMap<Book, BookViewModel>())).ToList();
        }

        public BookViewModel GetBook(int bookId)
        {
            return Mapper.Map<Book, BookViewModel>(_bookRepository.GetBook(bookId));
        }

        public BookViewModel UpdateBook(BookViewModel bookVm)
        {
            Book book = _bookRepository.UpdateBook(Mapper.Map<BookViewModel, Book>(bookVm));
            return Mapper.Map<Book, BookViewModel>(book);
        }
    }
}