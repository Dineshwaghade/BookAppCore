using CoreAppBook.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoreAppBook.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel model);
        Task SignOutAsync();

    }
}