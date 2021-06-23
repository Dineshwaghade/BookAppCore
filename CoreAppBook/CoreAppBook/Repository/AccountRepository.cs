using CoreAppBook.Models;
using CoreAppBook.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppBook.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager = null;
        private readonly SignInManager<ApplicationUser> _signInManager=null;
        private readonly IUserService _userService=null;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IUserService userService,
            IConfiguration configuration,IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _configuration = configuration;
            _emailService = emailService;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName=userModel.FirstName,
                LastName=userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if(result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if(!string.IsNullOrEmpty(token))
                {
                    await SendEmailConfirmationEmail(user, token);
                }
            }
            return result;
        }
        public async Task GenerateForgotPasswordToken(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailForForResetPassword(user, token);
            }

        }
        public async Task<SignInResult> PasswordSignInAsync(SignInModel model)
        {
            var result=await _signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);
            return result;
        }
        public async Task SignOutAsync()
        {
             await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userid = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userid);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
        public async Task<IdentityResult> ConfirmEmailAsync(string uid,string token)
        {
            return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
        }
        private async Task SendEmailConfirmationEmail(ApplicationUser usr, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string link = _configuration.GetSection("Application:EmailConfirmation").Value;
            UserEmailOptions option = new UserEmailOptions()
            {
                ToEmails = new List<string> { usr.Email },
                Placeholder = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{Username}}",usr.FirstName),
                    new KeyValuePair<string, string>("{{Link}}",string.Format(appDomain+link,usr.Id,token))
                }
            };
            await _emailService.SendEmailForEmailConfirmation(option);
        }
        private async Task SendEmailForForResetPassword(ApplicationUser usr, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string link = _configuration.GetSection("Application:ResetPassword").Value;
            UserEmailOptions option = new UserEmailOptions()
            {
                ToEmails = new List<string> { usr.Email },
                Placeholder = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{Username}}",usr.FirstName),
                    new KeyValuePair<string, string>("{{Link}}",string.Format(appDomain+link,usr.Id,token))
                }
            };
            await _emailService.SendEmailForResetPassword(option);
        }
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            var user= await _userManager.FindByEmailAsync(email);
            return user;
        }
        public async Task<bool> ResetPassword(ResetPasswordModel model)
        {
            ApplicationUser user =await _userManager.FindByIdAsync(model.uid);
            IdentityResult result=await _userManager.ResetPasswordAsync(user, model.token, model.NewPassword);
            if(result.Succeeded)
            {
                return true;
            }
            return false;
        }

    }
}
