using Covid19.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class SelectListModel
    {

        Covid19Context context;
        public SelectListModel(Covid19Context pcontext)
        {
            context = pcontext;
        }

        public SelectList LUT_COUNTRY_ALL()
        {
            return new SelectList(context.LUT_COUNTRY.OrderBy(x => x.COUNTRY_NAMT).ToList(), "ID", "COUNTRY_NAMT");
        }

        public SelectList LUT_COUNTRY(bool display)
        {
            return new SelectList(context.LUT_COUNTRY.Where(o => o.DISPLAY_FLAG == display).OrderBy(x => x.COUNTRY_NAMT).ToList(), "ID", "COUNTRY_NAMT");
        }

        public SelectList LUT_COUNTRY_WATCHOUT()
        {
            return new SelectList(context.LUT_COUNTRY.Where(o => o.WATCH_OUT_FLAG == true).OrderBy(x => x.COUNTRY_NAMT).ToList(), "ID", "COUNTRY_NAMT");
        }

        public SelectList LUT_COVID_REPORTER()
        {
            return new SelectList(context.LUT_COVID_REPORTER.ToList(), "ID", "REPORTER");
        }

        public SelectList LUT_COVID_SYMTOM()
        {
            return new SelectList(context.LUT_COVID_SYMTOM.ToList(), "ID", "SYMTOM");
        }

        public SelectList LUT_COVID_RELATION()
        {
            return new SelectList(context.LUT_COVID_RELATION.ToList(), "DESCR", "DESCR");
        }


        public SelectList LUT_YESNO()
        {
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(new SelectListItem() { Value = "false", Text = "ไม่ใช่" });
            newList.Add(new SelectListItem() { Value = "true", Text = "ใช่" });
            return new SelectList(newList, "Value", "Text");
        }


        public SelectList LUT_HEALTH_SYMTOM()
        {
            return new SelectList(context.LUT_HEALTH_SYMTOM.ToList(), "ID", "SYMTOM");
        }

        public SelectList LUT_OCCUPATION()
        {
            return new SelectList(context.LUT_OCCUPATION.ToList(), "ID", "DESCR");
        }
        public SelectList LUT_LOCATION_TYPE()
        {
            return new SelectList(context.LUT_LOCATION_TYPE.ToList(), "ID", "DESCR");
        }

    }
}
