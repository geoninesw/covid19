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

namespace Covid19.Controllers
{
    public class DataController : Controller
    {
        DataBOModel model;


        public DataController(Covid19Context context)
        {
            model = new DataBOModel(context);
        }

        [ResponseCache(Duration = 3600, VaryByHeader = "None")]
        [HttpGet]
        public JsonResult LUT_PROVINCE()
        {
            try
            {
                var jsonResult = Json(model.LUT_PROVINCE());

                return jsonResult;

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [ResponseCache(Duration = 3600, VaryByHeader = "None")]
        [HttpGet]
        public JsonResult LUT_AREA()
        {
            try
            {
                var jsonResult = Json(model.LUT_AREA());

                return jsonResult;

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

    }
}