using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer
{
    public class UserModel
    {

        public int UserId { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        [RegularExpression(@"^[A-Z][a-z]{1,}(\s[A-Z][a-z]{2,})*$", ErrorMessage = "Full Name is not valid")]
        public string FullName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9_.]*@gmail[.]com$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password is not valid")]
        public string Pwd { get; set; }
        [Required]
        [RegularExpression(@"^(0|91)?[6-9][0-9]{9}$", ErrorMessage = "Mobile Number is not valid")]
        public long MobNo { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        
    }
}
