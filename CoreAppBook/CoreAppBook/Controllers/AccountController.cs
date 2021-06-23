using CoreAppBook.Models;
using CoreAppBook.Repository;
using CoreAppBook.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppBook.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository=null;
        private readonly IUserService _userService=null;
        private readonly IEmailService _emailService;

        public AccountController(IAccountRepository accountRepository, IUserService userService, IEmailService emailService)
        {
            _accountRepository = accountRepository;
            _userService = userService;
            _emailService = emailService;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(SignUpUserModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(model);
                if(!result.Succeeded)
                {
                    foreach(var ErrorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", ErrorMessage.Description);
                    }
                    return View(model);
                }
                ModelState.Clear();
            }
            return View();
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(SignInModel model,string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(model);
                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(model);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(model);
                if(result.Succeeded)
                {
                    ViewBag.isSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string uid, string token)
        {
            token = token.Replace(' ','+');
            if(!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                var result =await _accountRepository.ConfirmEmailAsync(uid, token);
                if(result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                }
            }
            return View();
        }
        [HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _accountRepository.GetUserByEmail(model.Email);
                if(user!=null)
                {
                    await _accountRepository.GenerateForgotPasswordToken(user);
                    ModelState.Clear();
                    model.EmailSent = true;
                }
            }
            return View(model);
        }
        [HttpGet("Reset-password")]
        public async Task<IActionResult> ResetPassword(string uid, string token)
        {
            ResetPasswordModel model = new ResetPasswordModel()
            {
                uid = uid,
                token = token
            };
            return View();
        }
        [HttpPost("Reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {

            if (ModelState.IsValid)
            {
                model.token= model.token.Replace(' ', '+');
                bool isReset= await _accountRepository.ResetPassword(model);
                if (isReset)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ViewBag.error = true;
                }
            }
            return View();
        }
        public async Task<IActionResult> Email(UserEmailOptions model)
        {
            UserEmailOptions options = new UserEmailOptions()
            {
                ToEmails = new List<string> { "facebookphp470@gmail.com" },
                Subject=model.Subject,
                Body=model.Body
                Placeholder = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{Username}}", "Dinesh" )
                }
            };
            await _emailService.SendTestEmail(options);
            return View();
        }
    }
}
