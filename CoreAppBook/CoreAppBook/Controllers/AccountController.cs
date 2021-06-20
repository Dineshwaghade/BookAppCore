using CoreAppBook.Models;
using CoreAppBook.Repository;
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

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
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
    }
}
