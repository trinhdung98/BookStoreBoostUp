using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        Book GetBook(int bookId);
        void CreateBook(Book book);
        Book DeleteBook(int bookId);
        Book UpdateBook(Book book);
    }
}
