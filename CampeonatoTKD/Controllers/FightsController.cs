using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CampeonatoTKD.Services;

namespace CampeonatoTKD.Controllers
{
    public class FightsController : Controller
    {
        private readonly FightsService _fightsService;

        public FightsController(FightsService fightsService)
        {
            _fightsService = fightsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _fightsService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _fightsService.FindByFindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}