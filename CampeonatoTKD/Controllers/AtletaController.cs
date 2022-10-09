using System.Diagnostics;
using CampeonatoTKD.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using CampeonatoTKD.Models;
using CampeonatoTKD.Services;
using CampeonatoTKD.Services.Exceptions;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace SalesWebMvc.Controllers
{
    public class AtletaController : Controller
    {

        private readonly AtletaService _atletaService;
        private readonly CategoryService _categoryService;

        public AtletaController(AtletaService atletaService, CategoryService categoriaService)
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
            var viewModel = new AtletaFormViewModel { Category = categorias };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Atleta atleta)
        {
            if (!ModelState.IsValid)
            {
                var categorias = await _categoryService.FindAllAsync();
                var viewModel = new AtletaFormViewModel { Atleta = atleta, Category = categorias };
                return View(viewModel);
            }

            await _atletaService.InsertAsync(atleta);
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
            AtletaFormViewModel viewModel = new AtletaFormViewModel { Atleta = obj, Category = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Atleta atleta)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.FindAllAsync();
                var viewModel = new AtletaFormViewModel { Atleta = atleta, Category = categories };
                return View(viewModel);
            }

            if (id != atleta.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch " });
            }
            try
            {
                await _atletaService.UpdateAsync(atleta);
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
