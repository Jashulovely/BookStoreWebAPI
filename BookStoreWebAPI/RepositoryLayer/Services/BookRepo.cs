using Microsoft.Extensions.Configuration;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using RepositoryLayer.Interfaces;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace RepositoryLayer.Services
{
    public class BookRepo : IBookRepo
    {
        private readonly IConfiguration configuration;

        public BookRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public BookModel AddBook(BookModel book)
        {
            if (book != null)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                {
                    SqlCommand cmd = new SqlCommand("uspAddBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookName", book.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", book.AuthorName);
                    cmd.Parameters.AddWithValue("@BookDetails", book.BookDetails);
                    cmd.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                    cmd.Parameters.AddWithValue("@BookRating", book.BookRating);
                    cmd.Parameters.AddWithValue("@BookQuantity", book.BookQuantity);
                    cmd.Parameters.AddWithValue("@BookImage", book.BookImage);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return book;
            }
            else
            {
                return null;
            }
        }


        public string UploadImage(int bookId, IFormFile img)
        {
            if (bookId <= 0 || img == null || img.Length == 0)
            {
                return "Invalid book ID or empty image file.";
            }

            try
            {
                Account acc = new Account(
                    this.configuration["CloudinarySettings:CloudName"],
                    this.configuration["CloudinarySettings:ApiKey"],
                    this.configuration["CloudinarySettings:ApiSecret"]);

                Cloudinary cloudinary = new Cloudinary(acc);

                using (var stream = img.OpenReadStream())
                {
                    var ulP = new ImageUploadParams()
                    {
                        File = new FileDescription(img.FileName, stream),
                    };

                    var uploadResult = cloudinary.Upload(ulP);
                    string imagepath = uploadResult.Url.ToString();

                    if (!string.IsNullOrEmpty(imagepath))
                    {
                        using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                        {
                            SqlCommand cmd = new SqlCommand("uspUploadImage", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@BookId", bookId);
                            cmd.Parameters.AddWithValue("@BookImage", imagepath);

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        return "Image Uploaded Successfully";
                    }
                    else
                    {
                        return "Failed to upload image to Cloudinary.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return "An error occurred while uploading the image: " + ex.Message;
            }
        }


        public IEnumerable<BookModel> GetAllBooks()
        {
            List<BookModel> lstBooks = new List<BookModel>();

            using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
            {
                SqlCommand cmd = new SqlCommand("uspBooksList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    BookModel book = new BookModel();

                    book.BookId = rdr.GetInt32("BookId");
                    book.BookName = rdr["BookName"].ToString();
                    book.AuthorName = rdr["AuthorName"].ToString();
                    book.BookDetails = rdr["BookDetails"].ToString();
                    book.BookPrice =  Convert.ToSingle(rdr["BookPrice"]);
                    book.BookRating = Convert.ToSingle(rdr["BookRating"]);
                    book.BookQuantity = rdr.GetInt32("BookQuantity");
                    book.BookImage = rdr["BookImage"].ToString();
                    lstBooks.Add(book);
                }
                con.Close();
            }
            return lstBooks;
        }


        public IEnumerable<BookModel> GetBooksByAuthorName(string authorName)
        {
            if (authorName != null)
            {
                List<BookModel> lstBooks = new List<BookModel>();

                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                {
                    SqlCommand cmd = new SqlCommand("uspSearchByBookAuthorName", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AuthorName", authorName);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        BookModel book = new BookModel();

                        book.BookId = rdr.GetInt32("BookId");
                        book.BookName = rdr["BookName"].ToString();
                        book.AuthorName = rdr["AuthorName"].ToString();
                        book.BookDetails = rdr["BookDetails"].ToString();
                        book.BookPrice = Convert.ToSingle(rdr["BookPrice"]);
                        book.BookRating = Convert.ToSingle(rdr["BookRating"]);
                        book.BookQuantity = rdr.GetInt32("BookQuantity");
                        book.BookImage = rdr["BookImage"].ToString();
                        lstBooks.Add(book);
                    }
                    con.Close();
                }
                return lstBooks;
            }
            else
            {
                return null;
            }
        }




        public string UpdateBook(BookModel book)
        {
            if (book != null)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId", book.BookId);
                    cmd.Parameters.AddWithValue("@BookName", book.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", book.AuthorName);
                    cmd.Parameters.AddWithValue("@BookDetails", book.BookDetails);
                    cmd.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                    cmd.Parameters.AddWithValue("@BookRating", book.BookRating);
                    cmd.Parameters.AddWithValue("@BookQuantity", book.BookQuantity);
                    cmd.Parameters.AddWithValue("@BookImage", book.BookImage);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Book is Updated Successfully..........";
            }
            else
            {
                return null;
            }
        }



        public string InsertOrUpdateBook(BookModel book)
        {
            if (book != null)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                {
                    SqlCommand cmd = new SqlCommand("uspCheckIdToUpdateOrInsert", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId", book.BookId);
                    cmd.Parameters.AddWithValue("@BookName", book.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", book.AuthorName);
                    cmd.Parameters.AddWithValue("@BookDetails", book.BookDetails);
                    cmd.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                    cmd.Parameters.AddWithValue("@BookRating", book.BookRating);
                    cmd.Parameters.AddWithValue("@BookQuantity", book.BookQuantity);
                    cmd.Parameters.AddWithValue("@BookImage", book.BookImage);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Book is Inserted Or Updated Successfully..........";
            }
            else
            {
                return null;
            }
        }


        public string DeleteBook(int id)
        {
            if (id >= 1)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                {
                    SqlCommand cmd = new SqlCommand("uspDeleteBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Book Is Deleted Successfully......................";
            }
            else
            {
                return null;
            }
        }
    }
}
