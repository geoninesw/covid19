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

    public class CovidHealthCheckBOModel
    {
        Covid19Context context;
        public CovidHealthCheckBOModel(Covid19Context pcontext)
        {
            context = pcontext;
        }


        public string Create(CovidHealthCheckViewModel ViewModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    //create new row
                    var newRow = new COVID_HEALTHCHECK();
                    newRow.TRAVEL_IN_14_DAYS_FLAG = ViewModel.TRAVEL_IN_14_DAYS_FLAG;
                    newRow.TRAVEL_IN_14_DAYS_COUNTRY = ViewModel.TRAVEL_IN_14_DAYS_COUNTRY;
                    newRow.CLOSE_TO_FOREIGNER_FLAG = ViewModel.CLOSE_TO_FOREIGNER_FLAG;
                    newRow.OCCUPATION_ID = ViewModel.OCCUPATION_ID;
                    newRow.CLOSE_TO_PATIENT_FLAG = ViewModel.CLOSE_TO_PATIENT_FLAG;
                    newRow.TRAVEL_IN_14_DAYS_OTHER_FLAG = ViewModel.TRAVEL_IN_14_DAYS_OTHER_FLAG;
                    newRow.TRAVEL_IN_14_DAYS_COUNTRY_OTHER = ViewModel.TRAVEL_IN_14_DAYS_COUNTRY_OTHER;
                    newRow.MEDICAL_STAFF_FLAG = ViewModel.MEDICAL_STAFF_FLAG;
                    newRow.AGE = ViewModel.AGE;
                    newRow.AMPHUR_ID = ViewModel.AMPHUR_ID;
                    newRow.FRIENT_HAS_FLU_FLAG = ViewModel.FRIENT_HAS_FLU_FLAG;
                    newRow.LOCATION_TYPE_ID = ViewModel.LOCATION_TYPE_ID;
                    newRow.CREATED_DT = DateTime.Now;
                    context.COVID_HEALTHCHECK.Add(newRow);
                    context.SaveChanges();

                    if (ViewModel.SYMTOMS != null && ViewModel.SYMTOMS.Count() > 0)
                    {
                        foreach (var st in ViewModel.SYMTOMS)
                        {
                            var c = new COVID_HEALTHCHECK_SYMTOMS();
                            c.REPORTER_ID = newRow.ID;
                            c.SYMTOMS_ID = st;
                            context.COVID_HEALTHCHECK_SYMTOMS.Add(c);
                            context.SaveChanges();
                        }
                    }

                    dbContextTransaction.Commit();

                    //summaryResult
                    // 1. check symtoms
                    if (ViewModel.SYMTOMS != null && ViewModel.SYMTOMS.Count() > 0)
                    {
                        if (ViewModel.SYMTOMS.Count() > 1 && ViewModel.SYMTOMS.Contains(1))
                        {
                            return "3";
                        }
                        else
                        {
                            return "2";
                        }
                    }

                    // 2. check country
                    if (ViewModel.TRAVEL_IN_14_DAYS_COUNTRY.HasValue)
                    {
                        var watchout = context.LUT_COUNTRY.Find(ViewModel.TRAVEL_IN_14_DAYS_COUNTRY.Value);
                        return watchout.WATCH_OUT_FLAG.Value == true ? "3" : "1";
                    }

                    // 3. check support info
                    if (ViewModel.TRAVEL_IN_14_DAYS_FLAG == false && ViewModel.CLOSE_TO_FOREIGNER_FLAG == false
                        && ViewModel.CLOSE_TO_PATIENT_FLAG == false && ViewModel.TRAVEL_IN_14_DAYS_OTHER_FLAG == false
                        && ViewModel.MEDICAL_STAFF_FLAG == false)
                    {
                        return "1";
                    }
                    else
                    {
                        return "2";
                    }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public CovidHealthCheckAlgorithmViewModel GetAlgorithmResult(CovidHealthCheckViewModel ViewModel)
        {
            try
            {
                var modelParam = new CovidHealthCheckAlgorithmViewModel
                {
                    fever = ViewModel.SYMTOMS != null && ViewModel.SYMTOMS.Any(o => o == 1) ? 1 : 0,
                    one_uri_symp = ViewModel.SYMTOMS != null && ViewModel.SYMTOMS.Count() > 0 && ViewModel.SYMTOMS.Any(o => o != 1) ? 1 : 0,
                    travel_risk_country = ViewModel.TRAVEL_IN_14_DAYS_FLAG == true ? 1 : 0,
                    int_contact = ViewModel.CLOSE_TO_FOREIGNER_FLAG == true ? 1 : 0,
                    covid19_contact = ViewModel.CLOSE_TO_PATIENT_FLAG == true ? 1 : 0,
                    close_risk_country = ViewModel.TRAVEL_IN_14_DAYS_OTHER_FLAG == true ? 1 : 0,
                    med_prof = ViewModel.MEDICAL_STAFF_FLAG == true ? 1 : 0,
                    close_con = ViewModel.FRIENT_HAS_FLU_FLAG == true ? 1 : 0,

                };

                var result = context.LUT_HEALTHCHECK_ALGORITHM
                    .Where(o =>
                        o.FEVER == modelParam.fever
                        && o.ONE_URI_SYMP == modelParam.one_uri_symp
                        && o.TRAVEL_RISK_COUNTRY == modelParam.travel_risk_country
                        && o.INT_CONTACT == modelParam.int_contact
                        && o.COVID19_CONTACT == modelParam.covid19_contact
                        && o.CLOSE_RISK_COUNTRY == modelParam.close_risk_country
                        && o.MED_PROF == modelParam.med_prof
                        && o.CLOSE_CON == modelParam.close_con)
                    .FirstOrDefault();

                if (result != null)
                {
                    return new CovidHealthCheckAlgorithmViewModel
                    {
                        risk_level = (int)result.RISK_LEVEL,
                        gen_action = result.GEN_ACTION,
                        spec_action = result.SPEC_ACTION,
                        is_travel_in_14_days = ViewModel.TRAVEL_IN_14_DAYS_FLAG == true
                    };
                } 
                else
                {
                    return new CovidHealthCheckAlgorithmViewModel { is_travel_in_14_days = ViewModel.TRAVEL_IN_14_DAYS_FLAG == true };
                }
                    
            }
            catch
            {
                return new CovidHealthCheckAlgorithmViewModel { is_travel_in_14_days = ViewModel.TRAVEL_IN_14_DAYS_FLAG == true };
            }
        }
    }
}
