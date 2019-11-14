using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using Catan.Models;
using Logic;
using Models;

namespace Catan.Controllers
{
    public class SettingsController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}