using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.Collections.Generic;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IBookBusiness bookBusiness;

        public BookController(IBookBusiness bookBusiness)
        {
            this.bookBusiness = bookBusiness;
        }


        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook(BookModel model)
        {
            var result = bookBusiness.AddBook(model);   
            if (result != null)
            {
                return Ok(new ResponseModel<BookModel> { Status = true, Message = "Added Book Successfully...........", Data = model});
            }
            else
            {
             return BadRequest(new ResponseModel<string> { Status = false, Message = "Adding Book Failed................." });
            }
        }


        [HttpPut]
        [Route("AddBookImage")]
        public IActionResult AddBookImage(int bookId, IFormFile img)
        {
            var result = bookBusiness.UploadImage(bookId, img);
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Added Book Image Successfully..........."});
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Adding Book Image Failed................." });
            }
        }


        [HttpGet]
        [Route("BooksList")]
        public IActionResult BooksList()
        {
            List<BookModel> allBooks = (List<BookModel>)bookBusiness.GetAllBooks();
            if (allBooks != null)
            {
                return Ok(new ResponseModel<List<BookModel>> { Status = true, Message = "All Books", Data = allBooks });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Books not exists." });
            }
        }

        [HttpGet]
        [Route("AuthorBookList")]
        public IActionResult AuthorBookList(string authorName)
        {
            List<BookModel> allBooks = (List<BookModel>)bookBusiness.GetBooksByAuthorName(authorName);
            if (allBooks != null)
            {
                return Ok(new ResponseModel<List<BookModel>> { Status = true, Message = "All Books", Data = allBooks });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Books not exists." });
            }
        }


        [HttpPut]
        [Route("InsertOrUpdateBook")]
        public IActionResult InsertOrUpdateBook(BookModel model)
        {
            var result = bookBusiness.InsertOrUpdateBook(model);

            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Book is Inserted or Updated successfully............." });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Book Insertion or Updation failed.............." });
            }
        }


        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult UpdateBook(BookModel model)
        {
            var result = bookBusiness.UpdateBook(model);

            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Book Updated successfully." });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Book Updation failed." });
            }
        }


        [HttpDelete]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(int id)
        {
            var result = bookBusiness.DeleteBook(id);
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Book deleted successfully." });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Book deletion failed." });
            }
        }
    }
}
