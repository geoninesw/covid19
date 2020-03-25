using Covid19.EntityModel;
using Covid19.Models;
using Covid19.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Controllers
{
    public class Covid19HealthCheck2Controller : Controller
    {
        CovidHealthCheckBOModel model;
        SelectListModel listModel;
        IConfiguration configuration;


        public Covid19HealthCheck2Controller(Covid19Context context, IConfiguration pconfiguration)
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

            var updatedAlgoDate = configuration["GlobalVariable:UpdatedAlgorithmDate"];
            var updatedSituation = configuration["GlobalVariable:UpdatedSituation"];

            ViewBag.UpdatedAlgoDate = updatedAlgoDate;
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
                var resultAlgorithm = model.GetAlgorithmResult(ViewModel);

                return Json(new { 
                    success = true, 
                    summaryResult = result, 
                    riskLevel = resultAlgorithm.risk_level, 
                    specAction = resultAlgorithm.spec_action,
                    isTravelIn14Days = resultAlgorithm.is_travel_in_14_days
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
