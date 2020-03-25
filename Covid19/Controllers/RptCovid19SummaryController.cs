using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Core;
using Covid19.Core.Filters;
using Covid19.EntityModel;
using Covid19.Models;
using Covid19.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Covid19.Controllers
{
    [AuthorizedUserAttribute]
    public class RptCovid19SummaryController : Controller
    {
        RptCovid19ExBOModel model;
        SelectListModel listModel;

        public RptCovid19SummaryController(Covid19Context context)
        {
            model = new RptCovid19ExBOModel(context);
            listModel = new SelectListModel(context);
        }

        // GET: RptCovid19Summary
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCovid19Daily(string startDt, string endDt)
        {
            var sdt = DateTimeUtils.ConvertStringToDateTime(startDt, "dd/MM/yyyy", "en-US");
            var edt = DateTimeUtils.ConvertStringToDateTime(endDt, "dd/MM/yyyy", "en-US");

            return Json(new { success = true, data = model.RPT_COVID19_DAILY( 2, sdt, edt) });

        }

        [HttpPost]
        public ActionResult GetCovid19DailyCountry( string startDt, string endDt)
        {
            var sdt = DateTimeUtils.ConvertStringToDateTime(startDt, "dd/MM/yyyy", "en-US");
            var edt = DateTimeUtils.ConvertStringToDateTime(endDt, "dd/MM/yyyy", "en-US");

            return Json(new { success = true, data = model.RPT_COVID19_DAILY_COUNTRY( 2, sdt, edt) });

        }


        [HttpPost]
        public ActionResult GetCovid19DailyFlu( string startDt, string endDt)
        {
            var sdt = DateTimeUtils.ConvertStringToDateTime(startDt, "dd/MM/yyyy", "en-US");
            var edt = DateTimeUtils.ConvertStringToDateTime(endDt, "dd/MM/yyyy", "en-US");

            return Json(new { success = true, data = model.RPT_COVID19_DAILY_FLU( 2, sdt, edt) });

        }

        [HttpPost]
        public ActionResult GetCovid19DailySymtom( string startDt, string endDt)
        {
            var sdt = DateTimeUtils.ConvertStringToDateTime(startDt, "dd/MM/yyyy", "en-US");
            var edt = DateTimeUtils.ConvertStringToDateTime(endDt, "dd/MM/yyyy", "en-US");

            return Json(new { success = true, data = model.RPT_COVID19_DAILY_SYMTOM(2, sdt, edt) });

        }

    }
}