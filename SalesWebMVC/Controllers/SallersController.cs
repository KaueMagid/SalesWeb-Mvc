using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModel;
using SalesWebMVC.Services.Exceptions;

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

        public async Task<IActionResult> Index()
        {
            var list = await _sallerservice.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departaments = await _departamentService.FindAllAsync();
            var sallerViewModel = new SallerFormViewModel { Departaments = departaments };
            return View(sallerViewModel);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sallerservice.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sallerservice.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sallerservice.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Departament> departaments = await _departamentService.FindAllAsync();
            var sallerViewModel = new SallerFormViewModel { Departaments = departaments, Saller = obj };
            return View(sallerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Saller saller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync();
                var viewModel = new SallerFormViewModel { Departaments = departaments, Saller = saller };
                return View(viewModel);
            }
            await _sallerservice.InsertAsync(saller);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sallerservice.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), e.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Saller saller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync();
                var viewModel = new SallerFormViewModel { Departaments = departaments, Saller = saller };
                return View(viewModel);
            }
            if (id != saller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _sallerservice.Update(saller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), e.Message);

            }

        }
        public IActionResult Error(string message)
        {
            var ViewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(ViewModel);
        }
    }
}