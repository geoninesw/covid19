using Covid19.Core.Filters;
using Covid19.EntityModel;
using Covid19.Models;
using Covid19.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19.Controllers
{
    [AuthorizedUserAttribute]
    [Route("RptCovidTravel")]
    public class RptCovidTravelController : Controller
    {
        RptCovid19ExBOModel model;

        public RptCovidTravelController(Covid19Context context)
        {
            model = new RptCovid19ExBOModel(context);
        }

        // GET: RptCovidTravel
        [Route("{id}")]
        public ActionResult Index(string id)
        {
            RptCovidTravelSearchViewModel condition = new RptCovidTravelSearchViewModel();
            condition.HAS_FLU = id;
            return View(condition);
        }

        [HttpPost]
        public ActionResult Search(RptCovidTravelSearchViewModel condition)
        {
            try
            {
                return Json(model.Search(condition));
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [Route("Detail/{person_id}")]
        public ActionResult Detail(string person_id)
        {
            return View(model.Find(person_id));
        }
    }
}