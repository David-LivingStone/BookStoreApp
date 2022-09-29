using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public   interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookById(int id);
        Task<BookModel> AddBookAsync(BookModel bookModel);
        Task<int> UpdateBook(int id, BookModel BookModel);
        Task<bool> DeleteBook(int id);
    }
}
