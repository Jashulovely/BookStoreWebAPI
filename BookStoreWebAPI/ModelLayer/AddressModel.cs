using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer
{
    public class AddressModel
    {
        public int AdrId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Customer Name is required")]
        //[RegularExpression(@"^[A-Z][a-z]{1,}(\s[A-Z][a-z]{2,})*$", ErrorMessage = "Customer Name is not valid")]
        public string CustName { get; set; }
        [Required]
        //[RegularExpression(@"^(0|91)?[6-9][0-9]{9}$", ErrorMessage = "Mobile Number is not valid")]
        public long CustMobNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
    }
}
