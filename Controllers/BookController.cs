using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    //[Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository BookRepository)
        {
            _bookRepository = BookRepository;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetBookById(int id)
        {
            var books = await _bookRepository.GetBookById(id);
            return Ok(books);
        }

        [HttpPost("AddBook")]
        [Authorize]
        public async Task<IActionResult> AddBook([FromBody]BookModel bookModel)
        {
            //var result = await _bookRepository.AddBookAsync(bookModel);
            //return CreatedAtAction(nameof(GetBookById), new { id = result, Controller = "books" }, result);
            
            var books = await _bookRepository.AddBookAsync(bookModel);
            return Ok(books);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id, [FromBody]BookModel bookModel)
        {
            
            var result = await _bookRepository.UpdateBook(id, bookModel);
            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task< IActionResult> Delete([FromRoute] int id)
        {
            var delete= await _bookRepository.DeleteBook(id);
            if (delete == true)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
