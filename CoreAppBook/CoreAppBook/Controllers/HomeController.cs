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
    public class HomeController:Controller
    {
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View(); 
        }
        public async Task<ViewResult> AboutUs()
        {
            UserEmailOptions options = new UserEmailOptions()
            {
                ToEmails = new List<string> { "facebookphp470@gmail.com" }

            };
            await _emailService.SendTestEmail(options);
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
