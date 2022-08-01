using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookManagement.API.DTOs;
using BookManagement.Domain.Aggregates.ProductAggregate;
using BookManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookItemController : ControllerBase
    {
        private readonly IRepository<Book_items> bookitemRepository;
        public BookItemController(IRepository<Book_items> bookitemRepository)
        {
            this.bookitemRepository = bookitemRepository;
        }
        [HttpPost]
        [ProducesResponseType(201)]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBooks(BookItemsDTO dto)
        {
            var food_item = new Book_items(dto.Book_name, dto.Book_type, dto.Book_price);
            bookitemRepository.Add(food_item);
            await bookitemRepository.SaveAsync();
            return StatusCode(201);

        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<BookItemsDTO>))]
        //[Authorize(Roles =  "Admin, Customer")]
        public IActionResult GetBooks()
        {
            var book_items= bookitemRepository.Get();
            var dtos = from book_item in book_items
                       select new BookItemsDTO
                       {
                           Id = book_item.Id,
                           Book_name = book_item.Book_name,
                           Book_type = book_item.Book_type,
                           Book_price = book_item.Book_price
                       };
            return Ok(dtos);

        }
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(BookItemsDTO))]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetBooksId(long id)
        {
            var book_item = bookitemRepository.GetById(id);
            if (book_item == null)
                return NotFound();
            return Ok(book_item);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200,Type=(typeof(BookItemsDTO)))]
        //[Authorize(Roles="Admin")]
        public async Task<IActionResult>UpdateBooks(long id,[FromBody]BookItemsDTO dto)
        {
            var book_item = bookitemRepository.GetById(id);
            if (book_item == null)
                return NotFound();

            book_item.Book_name = dto.Book_name;
            book_item.Book_type = dto.Book_type;
            book_item.Book_price = dto.Book_price;
            bookitemRepository.Update(book_item);
            await bookitemRepository.SaveAsync();
            return Ok(book_item);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        //[Authorize(Roles="Admin")]

        public async Task<IActionResult>DeleteBooks(long id)
        {
            var food_item = bookitemRepository.GetById(id);
            if (food_item == null)
                return NotFound();
            bookitemRepository.Remove(food_item);
            await bookitemRepository.SaveAsync();
            return StatusCode(204);
        }
       
    }
}
