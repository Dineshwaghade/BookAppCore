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
        public IActionResult Index()
        {
            return View(); 
        }
        public async Task<ViewResult> AboutUs()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
