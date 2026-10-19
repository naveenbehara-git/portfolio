using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolio.Model.DTOs
{
    public class RegisterResponse
    {
        public string accessToken { get; set; }
        public Guid userId { get; set; }
    }
}
