using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SallersController : Controller
    {
        private readonly SallerService _service;

        public SallersController(SallerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var list = _service.FindAll();
            return View(list);
        }
    }
}