using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer
{
    public class UserLoginModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9_.]*@gmail[.]com$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,15}$", ErrorMessage = "Password is not valid")]
        public string Pwd { get; set; }

    }
}
