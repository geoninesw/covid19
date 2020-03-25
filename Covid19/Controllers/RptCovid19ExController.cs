using System;
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
    public class RptCovid19ExController : Controller
    {
        RptCovid19ExBOModel model;
        SelectListModel listModel;
        IConfiguration configuration;
        private const string ENC_KEY = "b14ca5898a4e4133bbce2ea2315a1915";


        public RptCovid19ExController(Covid19Context context, IConfiguration pconfiguration)
        {
            model = new RptCovid19ExBOModel(context);
            listModel = new SelectListModel(context);

            configuration = pconfiguration;
        }

        // GET: RptCovid19Ex
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("Index");
            }

            EmployeeViewModel viewModel = new EmployeeViewModel();
            viewModel.PERSON_ID = id;
            viewModel.REPORT_DT = DateTime.Now;
            viewModel.NATIONALITY = 251; // ไทย

            ViewBag.ListModel = listModel;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(EmployeeViewModel ViewModel)
        {
            try
            {
                model.Register(ViewModel);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public ActionResult Intro(string id)
        {
            ViewBag.PERSON_ID = id;
            return View();
        }

        [HttpPost]
        public ActionResult IntroUpdate(string id)
        {
            try
            {
                model.Create(id);
                return Json(new { success = true, date = DateTimeUtils.ConvertDateTimeToString(DateTime.Now, "dd/MM/yyyy", "th") });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public ActionResult Form(string id)
        {
            RptCovid19ExViewModel viewModel = new RptCovid19ExViewModel();

            viewModel = model.Find(id);

            var emp = model.GetProfileByID(id);
            viewModel.FULLNAME = emp != null ? emp.FULLNAME : string.Empty;

            ViewBag.ListModel = listModel;

            var updatedSituation = configuration["GlobalVariable:UpdatedSituation"];
            ViewBag.UpdatedSituation = updatedSituation;

            var symtomList = model.GetSymtoms();
            ViewBag.SymtomList = symtomList;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(RptCovid19ExViewModel ViewModel)
        {
            try
            {
                model.Create(ViewModel);
                return Json(new { success = true, covidID = ViewModel.PERSON_ID, date = DateTimeUtils.ConvertDateTimeToString(DateTime.Now, "dd/MM/yyyy", "th") });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public ActionResult FormDaily(string id)
        {
            RptCovid19ExViewModel viewModel = new RptCovid19ExViewModel();
            viewModel.PERSON_ID = id;

            var emp = model.GetProfileByID(id);
            viewModel.FULLNAME = emp != null ? emp.FULLNAME : string.Empty;

            ViewBag.ListModel = listModel;

            var updatedSituation = configuration["GlobalVariable:UpdatedSituation"];
            ViewBag.UpdatedSituation = updatedSituation;

            var symtomList = model.GetSymtoms();
            ViewBag.SymtomList = symtomList;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormDaily(RptCovid19ExViewModel ViewModel)
        {
            try
            {
                model.CreateDaily(ViewModel);
                return Json(new { success = true, covidID = ViewModel.PERSON_ID, date = DateTimeUtils.ConvertDateTimeToString(DateTime.Now, "dd/MM/yyyy", "th") });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        public ActionResult History(string id)
        {
            return View(model.Find(id));
        }

        [HttpPost]
        public ActionResult GetEmpProfile(string id)
        {
            var result = model.GetProfileByID(id);
            if (result != null)
            {
                return Json(new { success = true, data = result });
            }
            else
            {
                return Json(new { success = false, msg = "ไม่พบข้อมูล" });
            }
        }

    }
}