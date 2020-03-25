using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Core;
using Covid19.EntityModel;
using Covid19.Models;
using Covid19.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Covid19.Controllers
{
    public class Covid19HealthCheckController : Controller
    {
        CovidHealthCheckBOModel model;
        SelectListModel listModel;
        IConfiguration configuration;


        public Covid19HealthCheckController(Covid19Context context, IConfiguration pconfiguration)
        {
            model = new CovidHealthCheckBOModel(context);
            listModel = new SelectListModel(context);

            configuration = pconfiguration;
        }

        // GET: Covid19HealthCheckController

        public ActionResult Form()
        {
            CovidHealthCheckViewModel viewModel = new CovidHealthCheckViewModel();
            ViewBag.ListModel = listModel;

            var updatedSituation = configuration["GlobalVariable:UpdatedSituation"];
            ViewBag.UpdatedSituation = updatedSituation;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(CovidHealthCheckViewModel ViewModel)
        {
            try
            {
                string result = model.Create(ViewModel);
                return Json(new { success = true, summaryResult = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        

    }
}