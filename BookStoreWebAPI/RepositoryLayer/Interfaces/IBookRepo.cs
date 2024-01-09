using Microsoft.AspNetCore.Http;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IBookRepo
    {
        public BookModel AddBook(BookModel book);
        public IEnumerable<BookModel> GetAllBooks();
        public string UpdateBook(BookModel book);
        public string DeleteBook(int id);
        public string UploadImage(int bookId, IFormFile img);
        public IEnumerable<BookModel> GetBooksByAuthorName(string authorName);
        public string InsertOrUpdateBook(BookModel book);
    }
}
