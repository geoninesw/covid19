using Covid19.Core;
using Covid19.EntityModel;
using Covid19.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Collections;
using Covid19.EntityModel.SPResults;

namespace Covid19.Models
{

    public class DataBOModel
    {
        Covid19Context context;
        public DataBOModel(Covid19Context pcontext)
        {
            context = pcontext;
        }


        public IEnumerable LUT_PROVINCE()
        {
            IEnumerable result = null;
            try
            {
                var query = context.LUT_PROVINCE.GroupBy(x => new { x.PROV_CODE, x.PROV_NAMT, x.AMP_CODE, x.AMP_NAMT })
                            .Select(s => new
                            {
                                PROV_CODE = s.Key.PROV_CODE,
                                PROV_NAMT = s.Key.PROV_NAMT,
                                AMP_CODE = s.Key.AMP_CODE,
                                AMP_NAMT = s.Key.AMP_NAMT,
                                ID = s.Min(a => a.ID)
                            });


                //select new {a.ID, a.PROV_CODE, a.PROV_NAMT, a.AMP_CODE, a.AMP_NAMT, a.TAM_CODE, a.TAM_NAMT };

                var provList = (from a in query
                                select new { a.PROV_CODE, a.PROV_NAMT }).Distinct().OrderBy(x => x.PROV_NAMT).ToList();

                var ampList = (from a in query
                               select new {a.ID, a.PROV_CODE, a.AMP_CODE, a.AMP_NAMT }).Distinct().OrderBy(x => x.AMP_NAMT).ToList();

                //var tamList = (from a in query
                //               select new { a.PROV_CODE, a.AMP_CODE, a.TAM_CODE, a.TAM_NAMT }).Distinct();


                //var ampWithTam = from a in ampList
                //                 select new { a.PROV_CODE, a.AMP_CODE, a.AMP_NAMT, tams = tamList.Where(t => t.PROV_CODE == a.PROV_CODE && t.AMP_CODE == a.AMP_CODE) };

                var provWithAmp = from a in provList
                                  select new { a.PROV_CODE, a.PROV_NAMT, amps = ampList.Where(t => t.PROV_CODE == a.PROV_CODE) };

                result = provWithAmp.ToList();


            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        public IEnumerable LUT_AREA()
        {
            IEnumerable result = null;
            try
            {
                var query = from a in context.LUT_PROVINCE
                            select new { a.PROV_CODE, a.PROV_NAMT, a.AMP_CODE, a.AMP_NAMT, a.TAM_CODE, a.TAM_NAMT };


                var provList = (from a in query
                                select new { a.PROV_CODE, a.PROV_NAMT }).Distinct().OrderBy(x=>x.PROV_NAMT).ToList();

                var ampList = (from a in query
                               select new { a.PROV_CODE, a.AMP_CODE, a.AMP_NAMT }).Distinct().OrderBy(x => x.AMP_NAMT).ToList();

                var tamList = (from a in query
                               select new { a.PROV_CODE, a.AMP_CODE, a.TAM_CODE, a.TAM_NAMT }).Distinct().OrderBy(x => x.TAM_NAMT).ToList();



                var ampWithTam = from a in ampList
                                 select new { a.PROV_CODE, a.AMP_CODE, a.AMP_NAMT, tams = tamList.Where(t => t.PROV_CODE == a.PROV_CODE && t.AMP_CODE == a.AMP_CODE) };

                var provWithAmp = from a in provList
                                  select new { a.PROV_CODE, a.PROV_NAMT, amps = ampWithTam.Where(t => t.PROV_CODE == a.PROV_CODE) };


                result = provWithAmp.ToList();


            }
            catch (Exception ex)
            {

            }
            return result;
        }


    }
}
