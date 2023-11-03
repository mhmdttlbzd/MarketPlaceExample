using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Identity.Contract
{
    public interface IAuthenticationAppService
    {
        Task<SignInResult> Login(string username, string password);
    }
}
