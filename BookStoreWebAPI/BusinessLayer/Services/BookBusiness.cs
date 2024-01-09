using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using ModelLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepo bookRepo;

        public BookBusiness(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }


        public BookModel AddBook(BookModel book)
        {
            return  this.bookRepo.AddBook(book);
        }

        public string UploadImage(int bookId, IFormFile img)
        {
            return this.bookRepo.UploadImage(bookId, img);
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            return this.bookRepo.GetAllBooks();
        }

        public IEnumerable<BookModel> GetBooksByAuthorName(string authorName)
        {
            return this.bookRepo.GetBooksByAuthorName(authorName);
        }

        public string InsertOrUpdateBook(BookModel book)
        {
            return this.bookRepo.InsertOrUpdateBook(book);
        }

        public string UpdateBook(BookModel book)
        {
            return bookRepo.UpdateBook(book);
        }

        public string DeleteBook(int id)
        {
            return bookRepo.DeleteBook(id);
        }
    }
}
