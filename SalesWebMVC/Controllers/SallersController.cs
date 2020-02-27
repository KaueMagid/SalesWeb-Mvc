using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModel;

namespace SalesWebMVC.Controllers
{
    public class SallersController : Controller
    {
        private readonly SallerService _sallerservice;
        private readonly DepartamentService _departamentService;

        public SallersController(SallerService salleService, DepartamentService departamentService)
        {
            _sallerservice = salleService;
            _departamentService = departamentService;
        }

        public IActionResult Index()
        {
            var list = _sallerservice.FindAll();
            return View(list);
        }
        
        public IActionResult Create()
        {
            var departaments = _departamentService.FindAll();
            var sallerViewModel = new SallerFormViewModel { Departaments = departaments };
            return View(sallerViewModel);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sallerservice.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sallerservice.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sallerservice.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            List<Departament> departaments = _departamentService.FindAll();
            var sallerViewModel = new SallerFormViewModel { Departaments = departaments,Saller = obj };
            return View(sallerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Saller saller)
        {
            _sallerservice.Insert(saller);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sallerservice.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Saller saller)
        {
            if (id != saller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sallerservice.Update(saller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }

        }
    }
}