using Microsoft.AspNetCore.Mvc;
using SolutionDynamicPage.Infra.Domain.DTO;
using SolutionDynamicPage.Infra.Domain.IServices;
using SolutionDynamicPage.Web.Models;
using System.Diagnostics;

namespace SolutionDynamicPage.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISiteProfileService _service;
        public HomeController(ISiteProfileService service)
        {
            _service = service;

        }

        public async Task<IActionResult> ChangePublication(int id)
        {

            await _service.CleanPublished();
            await _service.SetIsPublished(id);

           
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Index()
        {

            var profile = await _service.GetPublished();
            
            return View(profile);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}