using Microsoft.AspNetCore.Http;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBookBusiness
    {
        public BookModel AddBook(BookModel book);
        public string UploadImage(int bookId, IFormFile img);
        public IEnumerable<BookModel> GetAllBooks();
        public string UpdateBook(BookModel book);
        public string DeleteBook(int id);
        public IEnumerable<BookModel> GetBooksByAuthorName(string authorName);
        public string InsertOrUpdateBook(BookModel book);
    }
}
