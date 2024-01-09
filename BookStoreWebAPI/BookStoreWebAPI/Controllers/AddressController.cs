using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.Linq;
using System;
using System.Collections.Generic;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public IAddressBusiness addressBusiness;

        public AddressController(IAddressBusiness addressBusiness)
        {
            this.addressBusiness = addressBusiness;
        }

        [Authorize]
        [HttpPost]
        [Route("AddAddress")]
        public IActionResult AddAddress(AddressModel model)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var result = addressBusiness.AddAddress(userId, model);
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Address Added Successfully..........." });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Adding Address is Failed................." });
            }
        }


        [Authorize]
        [HttpGet]
        [Route("AddressesList")]
        public IActionResult AddressesList()
        {
            List<AddressModel> allAddresses = (List<AddressModel>)addressBusiness.GetAllAddresses();
            if (allAddresses != null)
            {
                return Ok(new ResponseModel<List<AddressModel>> { Status = true, Message = "All Addresses..........", Data = allAddresses });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Addresses not exists............" });
            }
        }


        [Authorize]
        [HttpDelete]
        [Route("DeleteAddress")]
        public IActionResult DeleteAddress(int id)
        {
            var result = addressBusiness.DeleteAddress(id);
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Address deleted successfully.............." });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Address deletion failed." });
            }
        }


        [Authorize]
        [HttpPost]
        [Route("UpdateAddress")]
        public IActionResult UpdateAddress(AddressModel model)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);

            var result = addressBusiness.UpdateAddress(userId, model);
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Address Updated Successfully..........." });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Updating Address is Failed................." });
            }
        }
    }
}
