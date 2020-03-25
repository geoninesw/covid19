using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this IHtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

        public static string ViewDateFormat(this IHtmlHelper html, Nullable<DateTime> value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("th-TH"));
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ViewFullDateFormat(this IHtmlHelper html, Nullable<DateTime> value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString("d MMMM yyyy", new System.Globalization.CultureInfo("th-TH"));
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
