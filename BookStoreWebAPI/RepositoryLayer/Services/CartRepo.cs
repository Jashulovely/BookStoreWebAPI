using Microsoft.Extensions.Configuration;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class CartRepo : ICartRepo
    {
        private readonly IConfiguration configuration;

        public CartRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string AddToCart(int userId, int bookId)
        {
            if (userId > 0 && bookId > 0)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                {
                    SqlCommand cmd = new SqlCommand("uspAddToCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Added to Cart Successfully..................";
            }
            else
            {
                return null;
            }
        }



        public IEnumerable<CartModel> GetAllCartItems()
        {
            List<CartModel> lstCart = new List<CartModel>();

            using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
            {
                SqlCommand cmd = new SqlCommand("uspCartList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    CartModel cart = new CartModel();

                    cart.CartId = rdr.GetInt32("CartId");
                    cart.UserId = rdr.GetInt32("UserId");
                    cart.BookId = rdr.GetInt32("BookId");
                    cart.BookName = rdr["BookName"].ToString();
                    cart.AuthorName = rdr["AuthorName"].ToString();
                    cart.BookPrice = Convert.ToSingle(rdr["BookPrice"]);
                    cart.BookQuantity = rdr.GetInt32("BookQuantity");
                    cart.BookImage = rdr["BookImage"].ToString();
                    lstCart.Add(cart);
                }
                con.Close();
            }
            return lstCart;
        }



        public string DeleteCartItem(int id)
        {
            if (id >= 1)
            {
                using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
                {
                    SqlCommand cmd = new SqlCommand("uspDeleteCartItem", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return "Cart Item Is Deleted Successfully......................";
            }
            else
            {
                return null;
            }
        }


        public string DeleteCartItems()
        {
            using (SqlConnection con = new SqlConnection(this.configuration["ConnectionStrings:BookStoreWebAPI"]))
            {
                SqlCommand cmd = new SqlCommand("uspDeleteCartItems", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return "Cart Item Is Deleted Successfully......................";
        }


    }
}
