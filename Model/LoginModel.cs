using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Model
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        
        public string Password { get; set; }

        [Required]
        public string SecretKey { get; set; }
    }
}
