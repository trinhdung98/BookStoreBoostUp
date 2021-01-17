using BookStore.Entities;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IBookService
    {
        List<BookViewModel> GetAllBooks();
        BookViewModel GetBook(int bookId);
        void CreateBook(BookViewModel bookVm);
        BookViewModel DeleteBook(int bookId);
        BookViewModel UpdateBook(BookViewModel bookVm);
    }
}
