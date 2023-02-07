using Microsoft.AspNetCore.Mvc;
using SolutionDynamicPage.Infra.Domain.DTO;
using SolutionDynamicPage.Infra.Domain.Entities;
using SolutionDynamicPage.Infra.Domain.IServices;
using System.IO;

namespace SolutionDynamicPage.Web.Controllers
{
    public class SiteProfileController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //ILogger<HomeController> logger
        private readonly ISiteProfileService _service;
        string _pathName;
        public SiteProfileController(ISiteProfileService service, IWebHostEnvironment webSystem)
        {
            _service = service;
            _pathName = webSystem.WebRootPath;


        }
        //[Route("SiteList")]
        public IActionResult ListProfile()
        {
            var listSite = _service.FindAll();
            return View(listSite);
        }

        public async Task<IActionResult> PreviewPage(int id)
        {
            SiteProfileDTO siteProfileDTO = await  _service.FindById(id);
            return View(siteProfileDTO);
        }

     


        public async Task<IActionResult> Delete(int id)
        {
            var siteProfileD = await _service.FindById(id);
            //Terminar o delete e fazer o edit// trabalhar no css para melhorar a estética

            return View(siteProfileD);
        }

        public async Task<IActionResult> DeleteIsConfirmed(int id)
        {
            await _service.Delete(id);

            return RedirectToAction("ListProfile");
        }


        public IActionResult Create()
        {
            //Fazer validações do tamanho do texto (Is.Valid)

            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(SiteProfileDTO newSite, IFormFile imageLogo, IFormFile imageBanner)
        {
            //if (ModelState.IsValid)
           // {
                //Salvando a imagem da logo
                Stream stream;
                string path = _pathName + "\\img\\";
                string newImageBannerName = imageBanner.FileName;
                string newImageLogoName = imageLogo.FileName;
            


                stream = System.IO.File.Create(path + newImageBannerName);
                await imageBanner.CopyToAsync(stream);
                newSite.imageBanner = newImageBannerName;
                stream.Close();

                stream = System.IO.File.Create(path + newImageLogoName);
                await imageLogo.CopyToAsync(stream);
                newSite.imageLogo = newImageLogoName;
                stream.Close();

                newSite.imageDescription = "Sem Imagem";
                //Passando a string da imagem para o novo objeto
                _service.Save(newSite);

                return View("PreviewPage", newSite);
        

        }


        public async Task<IActionResult> Edit(int id)
        {
            var siteProfileD = await _service.FindById(id);

            return View(siteProfileD);
        }

        [HttpPost]
        public async Task<IActionResult> EditIsConfirmed(SiteProfileDTO editSiteProfile, IFormFile imageLogo, IFormFile imageBanner)
        {
            
                if (imageLogo != null)
                {

                //Salvando a imagem da logo
                string path = _pathName + "\\img\\";
                string newImageLogoName = imageLogo.FileName;
                var stream = System.IO.File.Create(path + newImageLogoName);
                await imageLogo.CopyToAsync(stream);
                editSiteProfile.imageLogo = newImageLogoName;
                stream.Close();

                }
            
                if(imageBanner != null)
                
                {

                //Salvando a imagem do banner
                string path = _pathName + "\\img\\";
                string newImageBannerName = imageBanner.FileName;
                var stream = System.IO.File.Create(path + newImageBannerName);
                await imageBanner.CopyToAsync(stream);
                editSiteProfile.imageBanner = newImageBannerName;
                stream.Close();


                }





            await _service.Save(editSiteProfile);

            
            return View("PreviewPage", editSiteProfile);
        }




    }
}
