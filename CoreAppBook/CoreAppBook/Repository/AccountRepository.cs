using CoreAppBook.Models;
using CoreAppBook.Services;
using Microsoft.AspNetCore.Identity;
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

        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
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
            return result;
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
            var userid =  _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userid);
            return await _userManager.ChangePasswordAsync(user,model.CurrentPassword,model.NewPassword);
        }
    }
}
