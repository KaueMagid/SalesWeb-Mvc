using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class SallersController : Controller
    {
        private readonly SallerService _sallerservice;

        public SallersController(SallerService service)
        {
            _sallerservice = service;
        }

        public IActionResult Index()
        {
            var list = _sallerservice.FindAll();
            return View(list);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Saller saller)
        {
            _sallerservice.Insert(saller);
            return RedirectToAction(nameof(Index));
        }
    }
}