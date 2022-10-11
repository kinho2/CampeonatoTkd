using System.Diagnostics;
using CampeonatoTKD.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using CampeonatoTKD.Models;
using CampeonatoTKD.Services;
using CampeonatoTKD.Services.Exceptions;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace CampeonatoTKD.Controllers
{
    public class AthleteController : Controller
    {

        private readonly AthleteService _atletaService;
        private readonly CategoryService _categoryService;

        public AthleteController(AthleteService atletaService, CategoryService categoriaService)
        {
            _atletaService = atletaService;
            _categoryService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _atletaService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var categorias = await _categoryService.FindAllAsync();
            var viewModel = new AthleteFormViewModel { Category = categorias };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Athlete athlete)
        {
            if (!ModelState.IsValid)
            {
                var categorias = await _categoryService.FindAllAsync();
                var viewModel = new AthleteFormViewModel { Athlete = athlete, Category = categorias };
                return View(viewModel);
            }

            await _atletaService.InsertAsync(athlete);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _atletaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _atletaService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _atletaService.FindByIdAsync(id.Value);
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
            var obj = await _atletaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Category> categories = await _categoryService.FindAllAsync();
            AthleteFormViewModel viewModel = new AthleteFormViewModel { Athlete = obj, Category = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Athlete athlete)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.FindAllAsync();
                var viewModel = new AthleteFormViewModel { Athlete = athlete, Category = categories };
                return View(viewModel);
            }

            if (id != athlete.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch " });
            }
            try
            {
                await _atletaService.UpdateAsync(athlete);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationExeption e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public IActionResult Error(string message)
        {
            var viewModel = new CampeonatoTKD.Models.ViewModel.ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
