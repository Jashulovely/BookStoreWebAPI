using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public ICartBusiness cartBusiness;

        public CartController(ICartBusiness cartBusiness)
        {
            this.cartBusiness = cartBusiness;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToCart")]
        public IActionResult AddToCart(int bookId)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var result = cartBusiness.AddToCart(userId, bookId);
            Console.WriteLine(result);
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Added To Cart Successfully..........." });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Adding To Cart is Failed................." });
            }
        }




        [Authorize]
        [HttpGet]
        [Route("CartItemsList")]
        public IActionResult CartItemsList()
        {
            List<CartModel> allItems = (List<CartModel>)cartBusiness.GetAllCartItems();
            if (allItems != null)
            {
                return Ok(new ResponseModel<List<CartModel>> { Status = true, Message = "All Cart Items..........", Data = allItems });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Cart Items not exists............" });
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteCartItem")]
        public IActionResult DeleteCartItem(int id)
        {
            var result = cartBusiness.DeleteCartItem(id);
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Cart Item deleted successfully.............." });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Cart Item deletion failed." });
            }
        }


        [Authorize]
        [HttpDelete]
        [Route("DeleteCartItems")]
        public IActionResult DeleteCartItems()
        {
            var result = cartBusiness.DeleteCartItems();
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "All cart Items deleted successfully.............." });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "All cart Items deletion failed............." });
            }
        }
    }
}
