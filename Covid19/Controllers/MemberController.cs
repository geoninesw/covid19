using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.EntityModel;
using Covid19.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Covid19.Controllers
{
    public class MemberController : Controller
    {
        AuthUserBOModel model;

        public MemberController(Covid19Context context)
        {
            model = new AuthUserBOModel(context);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]string username, [FromForm]string password)
        {
            var isAuthUser = model.IsAuthorizedUser(username, password);

            HttpContext.Session.SetInt32("IS_AUTHORIZED_USER", 0);
            if (isAuthUser)
            {
                HttpContext.Session.SetInt32("IS_AUTHORIZED_USER", 1);

                return RedirectToAction("Index", "RptCovid19Summary");
            }
            else
            {
                TempData["LOGIN_FAILED"] = "Y";
                return RedirectToAction("Login", "Member");
            }
        }
    }
}