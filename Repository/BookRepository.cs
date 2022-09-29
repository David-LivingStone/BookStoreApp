using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreDbContext  context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //METHOD 1
            //var records = await _context.Books.Select(a => new BookModel()
            //{
            //    Id = a.Id,
            //    Title = a.Title,
            //    Description = a.Description,
            //}).ToListAsync();

            //return records;

            //METHOD 2
            //    return await _context.Books.ToListAsync();

            //METHOD 3 (Using AutoMapper)

            var book = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(book);
        }

        public async Task <BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return _mapper.Map<BookModel>(book);

           // return await _context.Books.FindAsync(id);

        }

        public async Task <BookModel> AddBookAsync(BookModel bookModel)
        {
            bookModel.DateUploaded = DateTime.Now.ToString();
            bookModel.LastUpdated = DateTime.Now.ToString();
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<int> UpdateBook(int id, BookModel bookModel)
        {
            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook == null)
            {
                return 0;
            }
            bookModel.LastUpdated = DateTime.UtcNow.ToString();
            existingBook.Title = bookModel.Title != null ? bookModel.Title : existingBook.Title;
            existingBook.Description = bookModel.Description != null ? bookModel.Description : existingBook.Description;
            existingBook.ISBN = bookModel.ISBN != 0 ? bookModel.ISBN : existingBook.ISBN;
            existingBook.BookAuthor = bookModel.BookAuthor != null ? bookModel.BookAuthor : existingBook.BookAuthor;
            existingBook.Pages = bookModel.Pages != 0 ? bookModel.Pages : existingBook.Pages;
            existingBook.Price = bookModel.Price != 0 ? bookModel.Price : existingBook.Price;
            existingBook.quantity = bookModel.quantity != 0 ? bookModel.quantity : existingBook.quantity;
            existingBook.DatePublished = bookModel.DatePublished != null ? bookModel.DatePublished : existingBook.DatePublished;
            existingBook.DateUploaded = bookModel.DateUploaded != null ? bookModel.DateUploaded : existingBook.DateUploaded;
            existingBook.LastUpdated = bookModel.LastUpdated != null ? bookModel.LastUpdated : existingBook.LastUpdated;
            

            await _context.SaveChangesAsync();
            return 1;

        }
        
        public async Task<bool> DeleteBook(int id)
        {
            var del = await _context.Books.FindAsync(id);
            if (del != null)
            {
                _context.Books.Remove(del);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

            // ANOTHER REMOVE METHOD
            //var del = new Books() { Id = id };
            //_context.Books.Remove(del);
            //await _context.SaveChangesAsync();

            //Assuming the record you are about to remove doesnot have a primary key....like my Id, The code can can go like this;

            //var del = _context.Books.Where(x => x.Title == "").FirstOrDefault();
            //_context.Books.Remove(del);
            //await _context.SaveChangesAsync();
            //return id;
        }
    }
} 