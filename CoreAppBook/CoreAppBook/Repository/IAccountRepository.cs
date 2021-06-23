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
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task GenerateForgotPasswordToken(ApplicationUser user);
        Task<bool> ResetPassword(ResetPasswordModel model);

    }
}