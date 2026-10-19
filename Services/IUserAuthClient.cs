using MyPortfolio.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Services
{
    public interface IUserAuthClient
    {
        public Task<LoginResponse> Login(LoginRequest request);
        public Task<RegisterResponse> AddUser(LoginRequest request);
    }
}
