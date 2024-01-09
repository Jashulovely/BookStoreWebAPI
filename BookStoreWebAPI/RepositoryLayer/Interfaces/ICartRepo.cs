using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ICartRepo
    {
        public string AddToCart(int userId, int bookId);
        public IEnumerable<CartModel> GetAllCartItems();
        public string DeleteCartItem(int id);

        public string DeleteCartItems();
    }
}
