using Microsoft.AspNetCore.Mvc;
using SolutionDynamicPage.Infra.Domain.DTO;
using SolutionDynamicPage.Infra.Domain.Entities;
using SolutionDynamicPage.Infra.Domain.IServices;
using SolutionDynamicPage.Web.Models;
using System.Diagnostics;

namespace SolutionDynamicPage.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;

        }


        [Route("Admin")]
        public IActionResult Login()
        {




            return View();

        }

        [HttpPost]
        public IActionResult ValidLogin(UserDTO user)
        {
            if (ModelState.IsValid)
            {


                var loginList = _service.FindAll();
                UserDTO result = loginList.FirstOrDefault();

                if (result.login == user.login && result.password == user.password)
                {
                    return RedirectToAction("ListProfile", "SiteProfile");

                }
                else
                {

                    TempData["Login Incorreto"] = "Usuário Inválido";
                    return RedirectToAction("Login", "User");
                }

            }
            else
            {
                return RedirectToAction("Login", "User", user);

            }


        } 


    }
}