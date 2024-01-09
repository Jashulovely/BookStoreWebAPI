using BusinessLayer.Interfaces;
using ModelLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CartBusiness : ICartBusiness
    {
        private readonly ICartRepo cartRepo;

        public CartBusiness(ICartRepo cartRepo)
        {
            this.cartRepo = cartRepo;
        }

        public string AddToCart(int userId, int bookId)
        {
            return this.cartRepo.AddToCart(userId, bookId);
        }

        public IEnumerable<CartModel> GetAllCartItems()
        {
            return this.cartRepo.GetAllCartItems();
        }

        public string DeleteCartItem(int id)
        {
            return this.cartRepo.DeleteCartItem(id);
        }

        public string DeleteCartItems()
        {
            return this.cartRepo.DeleteCartItems();
        }
    }
}
