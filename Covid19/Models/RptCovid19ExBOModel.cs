using Covid19.Core;
using Covid19.EntityModel;
using Covid19.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Collections;
using Covid19.EntityModel.SPResults;
using System.Globalization;
using System.Linq;
namespace Covid19.Models
{

    public class RptCovid19ExBOModel
    {
        Covid19Context context;
        public RptCovid19ExBOModel(Covid19Context pcontext)
        {
            context = pcontext;
        }


        public IEnumerable<RptCovid19ExViewModel> Search(RptCovidTravelSearchViewModel condition)
        {
            var filteredData = context.RPT_COVID19EX.Select(o => o.PERSON_ID).Distinct()
                .SelectMany(key => context.RPT_COVID19EX.Join(context.EMPLOYEE, covid => covid.PERSON_ID, e => e.PERSON_ID, (covid, e) => new { covid, e })
                .Select(o => new { o.e.PERSON_ID, o.e.FULLNAME, o.covid.CREATED_DT, o.covid.HAS_FLU, o.covid.TRAVEL_FLAG })
                .Where(x => x.PERSON_ID == key).OrderByDescending(x => x.CREATED_DT).Take(1));

            //filter data
            if (!string.IsNullOrEmpty(condition.PERSON_ID))
            {
                filteredData = filteredData.Where(o => o.PERSON_ID.Contains(condition.PERSON_ID));
            }

            if (!string.IsNullOrEmpty(condition.NAME))
            {
                filteredData = filteredData.Where(o => o.FULLNAME.Contains(condition.NAME));
            }

            if (!string.IsNullOrEmpty(condition.HAS_FLU) && condition.HAS_FLU != "99")
            {
                filteredData = filteredData.Where(o => o.HAS_FLU == (condition.HAS_FLU == "1" ? "มีไข้" : "ไม่มีไข้"));
            }

            //แปลข้อมูลให้อยู่ในรูปแบบ json 
            var culture = new CultureInfo("th-TH");

            var query = filteredData.ToList().Select(o => new RptCovid19ExViewModel()
            {
                PERSON_ID = o.PERSON_ID,
                FULLNAME = o.FULLNAME,
                ReportDate = o.CREATED_DT.HasValue ? o.CREATED_DT.Value.ToString("dd/MM/yyyy HH:mm น.", culture) : "",
            });

            return query.ToList();

        }

        public RptCovid19ExViewModel Find(string id)
        {
            RptCovid19ExViewModel result = new RptCovid19ExViewModel();

            var emp = context.EMPLOYEE.Where(o => o.PERSON_ID == id).FirstOrDefault();
            result.PERSON_ID = id;
            result.FULLNAME = emp != null ? emp.FULLNAME : "-";
            result.ORGANIZATION = emp != null ? emp.ORGDESC : "-";
            result.JOBDESC = emp != null ? emp.JOBDESC : "-";

            int[] myArr = new int[0];
            var country = context.LUT_COUNTRY;
            var countryList = new List<string>();
            var countryList2 = new List<string>();
            var displayCountry = context.LUT_COUNTRY.Where(o => o.DISPLAY_FLAG == true);
            var query = context.RPT_COVID19EX.Where(o => o.PERSON_ID == id && o.REPORTER == 1).Include(o => o.RPT_COVID19EX_COUNTRY).OrderByDescending(o => o.CREATED_DT).FirstOrDefault();
            if (query != null)
            {
                if (query.REPORTER.HasValue)
                {
                    Array.Resize(ref myArr, myArr.Length + 1);
                    myArr[myArr.Length - 1] = query.REPORTER.Value;
                }

                if (query.RPT_COVID19EX_COUNTRY != null && query.RPT_COVID19EX_COUNTRY.Count() > 0)
                {
                    int i = 0;
                    result.COUNTRY = new int[query.RPT_COVID19EX_COUNTRY.Count()];
                    foreach (var item in query.RPT_COVID19EX_COUNTRY)
                    {

                        bool isDisplay = displayCountry.Where(o => o.ID == item.COUNTRY_ID).Count() > 0;

                        if (isDisplay)
                        {
                            result.COUNTRY[i] = item.COUNTRY_ID.Value;
                        }
                        else
                        {
                            result.COUNTRY[i] = 999;
                            result.COUNTRY_ID = item.COUNTRY_ID;
                        }

                        var c = country.Find(item.COUNTRY_ID).COUNTRY_NAMT;
                        countryList.Add(c);

                        i++;
                    }
                }

                result.ID = query.ID;
                result.ARRIVAL_DT = query.ARRIVAL_DT;
                result.ARRIVAL_FLIGHT = query.ARRIVAL_FLIGHT;
                result.DEPARTURE_DT = query.DEPARTURE_DT;
                result.DEPARTURE_FLIGHT = query.DEPARTURE_FLIGHT;

                result.ARRIVAL_DT_TXT = DateTimeUtils.ConvertDateTimeToString(query.ARRIVAL_DT, "d MMM yyyy", "th");
                result.DEPARTURE_DT_TXT = DateTimeUtils.ConvertDateTimeToString(query.DEPARTURE_DT, "d MMM yyyy", "th");
                result.COUNTRY_TXT = string.Join(", ", countryList);

                result.HISTORY = context.RPT_COVID19EX.Where(o => o.PERSON_ID == id && o.REPORTER == 1 && o.TRAVEL_FLAG == true).Include(i => i.RPT_COVID19EX_SYMTOMS).OrderBy(o => o.CREATED_DT).ToList().Select(o => new RptCovid19ExViewModel()
                {
                    REPORT_DT_TXT = DateTimeUtils.ConvertDateTimeToString(o.CREATED_DT, "d MMM yyyy", "th") + " เวลา " + DateTimeUtils.ConvertDateTimeToString(o.CREATED_DT, "HH:mm", "th") + " น.",
                    CLOSE_PATIENT_FLAG_TXT = o.CLOSE_PATIENT_FLAG.HasValue ? (o.CLOSE_PATIENT_FLAG == true ? "ใช่" + " (" + o.CLOSE_PATIENT_DETAIL + ")" : "ไม่ใช่") : string.Empty,
                    HAS_FLU = o.HAS_FLU == "มีไข้" ? o.HAS_FLU + " (" + o.TEMPERATURE + ")" : o.HAS_FLU,
                    SYMTOMS_TXT = string.Join(", ", o.RPT_COVID19EX_SYMTOMS.Join(context.LUT_COVID_SYMTOM, c => c.SYMTOMS_ID, lc => lc.ID, (c, lb) => new { c, lb }).Select(x => x.lb.ID != 98 ? x.lb.SYMTOM : x.c.SYMTOMS_OTHER).ToList())
                }).ToList();
            }

            var query2 = context.RPT_COVID19EX.Where(o => o.PERSON_ID == id && o.REPORTER == 2).Include(o => o.RPT_COVID19EX_COUNTRY).OrderByDescending(o => o.CREATED_DT).FirstOrDefault();
            if (query2 != null)
            {
                if (query2.REPORTER.HasValue)
                {
                    Array.Resize(ref myArr, myArr.Length + 1);
                    myArr[myArr.Length - 1] = query2.REPORTER.Value;
                }

                if (query2.RPT_COVID19EX_COUNTRY != null && query2.RPT_COVID19EX_COUNTRY.Count() > 0)
                {
                    int i = 0;
                    result.COUNTRY2 = new int[query2.RPT_COVID19EX_COUNTRY.Count()];
                    foreach (var item in query2.RPT_COVID19EX_COUNTRY)
                    {
                        bool isDisplay = displayCountry.Where(o => o.ID == item.COUNTRY_ID).Count() > 0;

                        if (isDisplay)
                        {
                            result.COUNTRY2[i] = item.COUNTRY_ID.Value;
                        }
                        else
                        {
                            result.COUNTRY2[i] = 999;
                            result.COUNTRY_ID2 = item.COUNTRY_ID;
                        }

                        var c = country.Find(item.COUNTRY_ID).COUNTRY_NAMT;
                        countryList2.Add(c);

                        i++;
                    }
                }

                result.ARRIVAL_DT2 = query2.ARRIVAL_DT;
                result.ARRIVAL_FLIGHT2 = query2.ARRIVAL_FLIGHT;
                result.DEPARTURE_DT2 = query2.DEPARTURE_DT;
                result.DEPARTURE_FLIGHT2 = query2.DEPARTURE_FLIGHT;
                result.COMPANION_NAME1 = query2.COMPANION_NAME1;
                result.COMPANION_NAME2 = query2.COMPANION_NAME2;
                result.COMPANION_NAME3 = query2.COMPANION_NAME3;
                result.COMPANION_RELATION1 = query2.COMPANION_RELATION1;
                result.COMPANION_RELATION2 = query2.COMPANION_RELATION2;
                result.COMPANION_RELATION3 = query2.COMPANION_RELATION3;

                result.ARRIVAL_DT_TXT2 = DateTimeUtils.ConvertDateTimeToString(query2.ARRIVAL_DT, "d MMM yyyy", "th");
                result.DEPARTURE_DT_TXT2 = DateTimeUtils.ConvertDateTimeToString(query2.DEPARTURE_DT, "d MMM yyyy", "th");
                result.COUNTRY_TXT2 = string.Join(", ", countryList2);
                result.HISTORY2 = context.RPT_COVID19EX.Where(o => o.PERSON_ID == id && o.REPORTER == 2 && o.TRAVEL_FLAG == true).Include(i => i.RPT_COVID19EX_SYMTOMS).OrderBy(o => o.CREATED_DT).ToList().Select(o => new RptCovid19ExViewModel()
                {
                    REPORT_DT_TXT = DateTimeUtils.ConvertDateTimeToString(o.CREATED_DT, "d MMM yyyy", "th") + " เวลา " + DateTimeUtils.ConvertDateTimeToString(o.CREATED_DT, "HH:mm", "th") + " น.",
                    CLOSE_PATIENT_FLAG_TXT = o.CLOSE_PATIENT_FLAG.HasValue ? (o.CLOSE_PATIENT_FLAG == true ? "ใช่" + " (" + o.CLOSE_PATIENT_DETAIL + ")" : "ไม่ใช่") : string.Empty,
                    HAS_FLU = o.HAS_FLU,
                    SYMTOMS_TXT = string.Join(", ", o.RPT_COVID19EX_SYMTOMS.Join(context.LUT_COVID_SYMTOM, c => c.SYMTOMS_ID, lc => lc.ID, (c, lb) => new { c, lb }).Select(x => x.lb.ID != 98 ? x.lb.SYMTOM : x.c.SYMTOMS_OTHER).ToList())
                }).ToList();

            }

            result.REPORTERS = new int[myArr.Length];
            result.REPORTERS = myArr;

            result.HISTORY_NO_TRAVEL = context.RPT_COVID19EX.Where(o => o.PERSON_ID == id && o.REPORTER == 1 && o.TRAVEL_FLAG == false).Include(i => i.RPT_COVID19EX_SYMTOMS).OrderBy(o => o.CREATED_DT).ToList().Select(o => new RptCovid19ExViewModel()
            {
                REPORT_DT_TXT = DateTimeUtils.ConvertDateTimeToString(o.CREATED_DT, "d MMM yyyy", "th") + " เวลา " + DateTimeUtils.ConvertDateTimeToString(o.CREATED_DT, "HH:mm", "th") + " น.",
                CLOSE_PATIENT_FLAG_TXT = o.CLOSE_PATIENT_FLAG.HasValue ? (o.CLOSE_PATIENT_FLAG == true ? "ใช่" + " (" + o.CLOSE_PATIENT_DETAIL + ")" : "ไม่ใช่") : string.Empty,
                HAS_FLU = o.HAS_FLU == "มีไข้" ? o.HAS_FLU + " (" + o.TEMPERATURE + ")" : o.HAS_FLU,
                SYMTOMS_TXT = string.Join(", ", o.RPT_COVID19EX_SYMTOMS.Join(context.LUT_COVID_SYMTOM, c => c.SYMTOMS_ID, lc => lc.ID, (c, lb) => new { c, lb }).Select(x => x.lb.ID != 98 ? x.lb.SYMTOM : x.c.SYMTOMS_OTHER).ToList()),
            }).ToList();

            return result;
        }

        public EMPLOYEE GetProfileByID(string id)
        {
            return context.EMPLOYEE.Where(o => o.PERSON_ID == id).FirstOrDefault();
        }

        public void Create(string id)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    //create new row
                    var newRow = new RPT_COVID19EX();
                    newRow.PERSON_ID = id;
                    newRow.REPORTER = 1;
                    newRow.CREATED_DT = DateTime.Now;
                    newRow.TRAVEL_FLAG = false;

                    context.RPT_COVID19EX.Add(newRow);
                    context.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Create(RptCovid19ExViewModel ViewModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    if (ViewModel.REPORTERS != null && ViewModel.REPORTERS.Count() > 0)
                    {
                        foreach (var item in ViewModel.REPORTERS)
                        {
                            //create new row
                            var newRow = new RPT_COVID19EX();
                            newRow.PERSON_ID = ViewModel.PERSON_ID;
                            newRow.REPORTER = item;
                            newRow.ARRIVAL_DT = item == 1 ? ViewModel.ARRIVAL_DT : ViewModel.ARRIVAL_DT2;
                            newRow.ARRIVAL_FLIGHT = item == 1 ? ViewModel.ARRIVAL_FLIGHT : ViewModel.ARRIVAL_FLIGHT2;
                            newRow.DEPARTURE_DT = item == 1 ? ViewModel.DEPARTURE_DT : ViewModel.DEPARTURE_DT2;
                            newRow.DEPARTURE_FLIGHT = item == 1 ? ViewModel.DEPARTURE_FLIGHT : ViewModel.DEPARTURE_FLIGHT2;

                            if(item == 1)
                            {
                                newRow.HAS_FLU = ViewModel.HAS_FLU == "1" ? "มีไข้" : "ไม่มีไข้";
                            }
                            else
                            {
                                newRow.HAS_FLU = ViewModel.HAS_FLU2 == "1" ? "มีไข้" : "ไม่มีไข้";
                            }

                            newRow.HAS_FLU_OTHER = ViewModel.HAS_FLU_OTHER == "1" ? "มีไข้" : "ไม่มีไข้";

                            if(item == 1)
                            {
                                newRow.CLOSE_PATIENT_FLAG = ViewModel.CLOSE_PATIENT_FLAG;
                                newRow.CLOSE_PATIENT_DETAIL = ViewModel.CLOSE_PATIENT_DETAIL;
                            }

                            newRow.TEMPERATURE = ViewModel.TEMPERATURE;
                            newRow.TEMPERATURE_OTHER = ViewModel.TEMPERATURE_OTHER;
                            newRow.TRAVEL_TOGETHER = ViewModel.TRAVEL_TOGETHER;
                            newRow.CREATED_DT = DateTime.Now;
                            newRow.TRAVEL_FLAG = true;
                            newRow.COMPANION_NAME1 = ViewModel.COMPANION_NAME1;
                            newRow.COMPANION_NAME2 = ViewModel.COMPANION_NAME2;
                            newRow.COMPANION_NAME3 = ViewModel.COMPANION_NAME3;
                            newRow.COMPANION_RELATION1 = ViewModel.COMPANION_RELATION1;
                            newRow.COMPANION_RELATION2 = ViewModel.COMPANION_RELATION2;
                            newRow.COMPANION_RELATION3 = ViewModel.COMPANION_RELATION3;
                            context.RPT_COVID19EX.Add(newRow);
                            context.SaveChanges();

                            if (item == 1)
                            {
                                if (ViewModel.COUNTRY != null && ViewModel.COUNTRY.Count() > 0)
                                {
                                    foreach (var ct in ViewModel.COUNTRY)
                                    {
                                        var c = new RPT_COVID19EX_COUNTRY();
                                        c.REPORTER_ID = newRow.ID;
                                        c.PERSON_TYPE_ID = 1;
                                        c.COUNTRY_ID = ct != 999 ? ct : ViewModel.COUNTRY_ID;
                                        context.RPT_COVID19EX_COUNTRY.Add(c);
                                        context.SaveChanges();
                                    }
                                }

                                if (ViewModel.SYMTOMS != null && ViewModel.SYMTOMS.Count() > 0)
                                {
                                    foreach (var st in ViewModel.SYMTOMS)
                                    {
                                        var c = new RPT_COVID19EX_SYMTOMS();
                                        c.REPORTER_ID = newRow.ID;
                                        c.PERSON_TYPE_ID = 1;
                                        c.SYMTOMS_ID = st;
                                        c.SYMTOMS_OTHER = st == 98 ? (!string.IsNullOrEmpty(ViewModel.SYMTOMS_OTHER_TEXT) ? ViewModel.SYMTOMS_OTHER_TEXT : null) : null;
                                        context.RPT_COVID19EX_SYMTOMS.Add(c);
                                        context.SaveChanges();
                                    }
                                }
                                if (ViewModel.SYMTOMS_OTHER != null && ViewModel.SYMTOMS_OTHER.Count() > 0)
                                {
                                    foreach (var sto in ViewModel.SYMTOMS_OTHER)
                                    {
                                        var c = new RPT_COVID19EX_SYMTOMS_OTHER();
                                        c.REPORTER_ID = newRow.ID;
                                        c.PERSON_TYPE_ID = 1;
                                        c.SYMTOMS_ID = sto;
                                        c.SYMTOMS_OTHER = sto == 98 ? (!string.IsNullOrEmpty(ViewModel.SYMTOMS_OTHER_TEXT_OTHER) ? ViewModel.SYMTOMS_OTHER_TEXT_OTHER : null) : null;
                                        context.RPT_COVID19EX_SYMTOMS_OTHER.Add(c);
                                        context.SaveChanges();
                                    }
                                }
                            }

                            if (item == 2)
                            {
                                if (ViewModel.COUNTRY2 != null && ViewModel.COUNTRY2.Count() > 0)
                                {
                                    foreach (var ct2 in ViewModel.COUNTRY2)
                                    {
                                        var c = new RPT_COVID19EX_COUNTRY();
                                        c.REPORTER_ID = newRow.ID;
                                        c.PERSON_TYPE_ID = 2;
                                        c.COUNTRY_ID = ct2 != 999 ? ct2 : ViewModel.COUNTRY_ID2;
                                        context.RPT_COVID19EX_COUNTRY.Add(c);
                                        context.SaveChanges();
                                    }
                                }

                                if (ViewModel.SYMTOMS2 != null && ViewModel.SYMTOMS2.Count() > 0)
                                {
                                    foreach (var st2 in ViewModel.SYMTOMS2)
                                    {
                                        var c = new RPT_COVID19EX_SYMTOMS();
                                        c.REPORTER_ID = newRow.ID;
                                        c.PERSON_TYPE_ID = 2;
                                        c.SYMTOMS_ID = st2;
                                        c.SYMTOMS_OTHER = st2 == 98 ? (!string.IsNullOrEmpty(ViewModel.SYMTOMS2_OTHER_TEXT) ? ViewModel.SYMTOMS2_OTHER_TEXT : null) : null;
                                        context.RPT_COVID19EX_SYMTOMS.Add(c);
                                        context.SaveChanges();
                                    }
                                }
                            }

                        }
                    }

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public EMPLOYEE Register(EmployeeViewModel ViewModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var row = context.EMPLOYEE.Find(ViewModel.PERSON_ID);

                    if (row == null)
                    {
                        var newRow = new EMPLOYEE();
                        newRow.PERSON_ID = ViewModel.PERSON_ID;
                        newRow.FIRSTNAME = ViewModel.FIRSTNAME;
                        newRow.LASTNAME = ViewModel.LASTNAME;
                        newRow.FULLNAME = ViewModel.FIRSTNAME + " " + ViewModel.LASTNAME;
                        newRow.BIRTHDATE = ViewModel.BIRTHDATE;
                        newRow.NATIONALITY = ViewModel.NATIONALITY;
                        newRow.JOBDESC = ViewModel.JOBDESC;
                        newRow.EMAIL = ViewModel.EMAIL;
                        newRow.TEL = ViewModel.TEL;
                        newRow.HOUSE_NO = ViewModel.HOUSE_NO;
                        newRow.MOO = ViewModel.MOO;
                        newRow.PROV_CODE = ViewModel.PROV_CODE;
                        newRow.AMP_CODE = ViewModel.AMP_CODE;
                        newRow.TAM_CODE = ViewModel.TAM_CODE;
                        newRow.JOURNEY_DESCR = ViewModel.JOURNEY_DESCR;
                        newRow.DEPARTURE_DT = ViewModel.DEPARTURE_DT;
                        newRow.ARRIVAL_DT = ViewModel.ARRIVAL_DT;
                        newRow.REPORT_DT = ViewModel.REPORT_DT;
                        newRow.RESPONSIBLE_BY = ViewModel.RESPONSIBLE_BY;
                        newRow.ORGDESC = ViewModel.ORGDESC;
                        newRow.JOBDESC = ViewModel.JOBDESC;
                        newRow.CREATED_DT = DateTime.Now;

                        context.EMPLOYEE.Add(newRow);
                        context.SaveChanges();
                        dbContextTransaction.Commit();

                        return newRow;
                    }
                    else
                    {
                        return row;
                    }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public IEnumerable RPT_COVID19_DAILY(int? type, DateTime? startDt, DateTime? endDt)
        {
            var reportDaily = context.RPT_COVID19_DAILY_RESULT
                                .FromSqlInterpolated($"RPT_COVID19_DAILY {type}, {startDt}, {endDt}")
                                .AsEnumerable()
                                .ToList();

            if (reportDaily != null && reportDaily.Count() > 0)
            {
                return reportDaily;
            }
            return Enumerable.Empty<RPT_COVID19_DAILY_RESULT>();
        }

        public IEnumerable RPT_COVID19_DAILY_COUNTRY(int? type, DateTime? startDt, DateTime? endDt)
        {
            var reportDaily = context.RPT_COVID19_DAILY_COUNTRY_RESULT
                                .FromSqlInterpolated($"RPT_COVID19_DAILY_COUNTRY {type}, {startDt}, {endDt}")
                                .AsEnumerable()
                                .ToList();

            if (reportDaily != null && reportDaily.Count() > 0)
            {
                List<RPT_COVID19_DAILY_COUNTRY_RESULT> lstTop10Result = new List<RPT_COVID19_DAILY_COUNTRY_RESULT>();
                List<int> allPersonId = reportDaily.Select(o => o.PERSON_TYPE_ID.Value).Distinct().ToList();
                var lstTop10 = allPersonId.Select(p => {
                    return reportDaily.Where(r => r.PERSON_TYPE_ID == p).OrderByDescending(r => r.AMOUNT).Take(10);
                });

                lstTop10Result = lstTop10.SelectMany(l => l).ToList();
                return lstTop10Result;

                //return reportDaily;
            }
            return Enumerable.Empty<RPT_COVID19_DAILY_COUNTRY_RESULT>();
        }

        public IEnumerable RPT_COVID19_DAILY_FLU(int? type, DateTime? startDt, DateTime? endDt)
        {
            var reportDaily = context.RPT_COVID19_DAILY_FLU_RESULT
                                .FromSqlInterpolated($"RPT_COVID19_DAILY_FLU {type}, {startDt}, {endDt}")
                                .AsEnumerable()
                                .ToList();

            if (reportDaily != null && reportDaily.Count() > 0)
            {
                return reportDaily;
            }
            return Enumerable.Empty<RPT_COVID19_DAILY_FLU_RESULT>();
        }

        public IEnumerable RPT_COVID19_DAILY_SYMTOM(int? type, DateTime? startDt, DateTime? endDt)
        {
            var reportDaily = context.RPT_COVID19_DAILY_SYMTOM_RESULT
                                .FromSqlInterpolated($"RPT_COVID19_DAILY_SYMTOM {type}, {startDt}, {endDt}")
                                .AsEnumerable()
                                .ToList();

            if (reportDaily != null && reportDaily.Count() > 0)
            {
                return reportDaily;
            }
            return Enumerable.Empty<RPT_COVID19_DAILY_SYMTOM_RESULT>();
        }

        public void CreateDaily2(RptCovid19ExViewModel ViewModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var query = context.RPT_COVID19EX.Where(o => o.PERSON_ID == ViewModel.PERSON_ID).Include(o => o.RPT_COVID19EX_COUNTRY).OrderByDescending(o => o.CREATED_DT).FirstOrDefault();
                    if (query != null)
                    {
                        //create new row
                        var newRow = new RPT_COVID19EX();
                        newRow.PERSON_ID = query.PERSON_ID;
                        newRow.REPORTER = query.REPORTER;
                        newRow.ARRIVAL_DT = query.ARRIVAL_DT;
                        newRow.ARRIVAL_FLIGHT = query.ARRIVAL_FLIGHT;
                        newRow.DEPARTURE_DT = query.DEPARTURE_DT;
                        newRow.DEPARTURE_FLIGHT = query.DEPARTURE_FLIGHT;
                        newRow.HAS_FLU = ViewModel.HAS_FLU == "1" ? "มีไข้" : "ไม่มีไข้";
                        newRow.CLOSE_PATIENT_FLAG = ViewModel.CLOSE_PATIENT_FLAG;
                        newRow.CLOSE_PATIENT_DETAIL = ViewModel.CLOSE_PATIENT_DETAIL;
                        newRow.HAS_FLU_OTHER = query.HAS_FLU_OTHER;
                        newRow.TEMPERATURE = ViewModel.TEMPERATURE;
                        newRow.TEMPERATURE_OTHER = query.TEMPERATURE_OTHER;
                        newRow.TRAVEL_TOGETHER = query.TRAVEL_TOGETHER;
                        newRow.CREATED_DT = DateTime.Now;
                        newRow.TRAVEL_FLAG = query.TRAVEL_FLAG;
                        newRow.COMPANION_NAME1 = query.COMPANION_NAME1;
                        newRow.COMPANION_NAME2 = query.COMPANION_NAME2;
                        newRow.COMPANION_NAME3 = query.COMPANION_NAME3;
                        newRow.COMPANION_RELATION1 = query.COMPANION_RELATION1;
                        newRow.COMPANION_RELATION2 = query.COMPANION_RELATION2;
                        newRow.COMPANION_RELATION3 = query.COMPANION_RELATION3;
                        context.RPT_COVID19EX.Add(newRow);
                        context.SaveChanges();

                        if (ViewModel.SYMTOMS != null && ViewModel.SYMTOMS.Count() > 0)
                        {
                            foreach (var st in ViewModel.SYMTOMS)
                            {
                                var c = new RPT_COVID19EX_SYMTOMS();
                                c.REPORTER_ID = newRow.ID;
                                c.PERSON_TYPE_ID = newRow.REPORTER;
                                c.SYMTOMS_ID = st;
                                c.SYMTOMS_OTHER = st == 98 ? (!string.IsNullOrEmpty(ViewModel.SYMTOMS_OTHER_TEXT) ? ViewModel.SYMTOMS_OTHER_TEXT : null) : null;
                                context.RPT_COVID19EX_SYMTOMS.Add(c);
                                context.SaveChanges();
                            }
                        }

                        if (query.RPT_COVID19EX_COUNTRY != null && query.RPT_COVID19EX_COUNTRY.Count() > 0)
                        {
                            foreach (var ct in query.RPT_COVID19EX_COUNTRY)
                            {
                                var c = new RPT_COVID19EX_COUNTRY();
                                c.REPORTER_ID = newRow.ID;
                                c.PERSON_TYPE_ID = newRow.REPORTER;
                                c.COUNTRY_ID = ct.COUNTRY_ID;
                                context.RPT_COVID19EX_COUNTRY.Add(c);
                                context.SaveChanges();
                            }
                        }
                    }

                    //var query2 = context.RPT_COVID19EX.Where(o => o.PERSON_ID == ViewModel.PERSON_ID && o.REPORTER == 1 && o.TRAVEL_FLAG == false).OrderByDescending(o => o.CREATED_DT).FirstOrDefault();
                    //if (query2 != null)
                    //{
                    //    //create new row
                    //    var newRow = new RPT_COVID19EX();
                    //    newRow.PERSON_ID = query2.PERSON_ID;
                    //    newRow.REPORTER = query2.REPORTER;
                    //    newRow.HAS_FLU = ViewModel.HAS_FLU == "1" ? "มีไข้" : "ไม่มีไข้";
                    //    newRow.CLOSE_PATIENT_FLAG = ViewModel.CLOSE_PATIENT_FLAG;
                    //    newRow.CLOSE_PATIENT_DETAIL = ViewModel.CLOSE_PATIENT_DETAIL;
                    //    newRow.TEMPERATURE = ViewModel.TEMPERATURE;
                    //    newRow.CREATED_DT = DateTime.Now;
                    //    newRow.TRAVEL_FLAG = query2.TRAVEL_FLAG;
                    //    context.RPT_COVID19EX.Add(newRow);
                    //    context.SaveChanges();

                    //    if (ViewModel.SYMTOMS != null && ViewModel.SYMTOMS.Count() > 0)
                    //    {
                    //        foreach (var st in ViewModel.SYMTOMS)
                    //        {
                    //            var c = new RPT_COVID19EX_SYMTOMS();
                    //            c.REPORTER_ID = newRow.ID;
                    //            c.PERSON_TYPE_ID = 1;
                    //            c.SYMTOMS_ID = st;
                    //            c.SYMTOMS_OTHER = st == 98 ? (!string.IsNullOrEmpty(ViewModel.SYMTOMS_OTHER_TEXT) ? ViewModel.SYMTOMS_OTHER_TEXT : null) : null;
                    //            context.RPT_COVID19EX_SYMTOMS.Add(c);
                    //            context.SaveChanges();
                    //        }
                    //    }
                    //}

                    if (query == null)
                    {
                        // สำหรับคนที่ไม่ได้ไปต่างประเทศ add by Jay 20Mar2020
                        var newRow = new RPT_COVID19EX();
                        newRow.PERSON_ID = ViewModel.PERSON_ID;
                        newRow.REPORTER = 1;
                        newRow.HAS_FLU = ViewModel.HAS_FLU == "1" ? "มีไข้" : "ไม่มีไข้";
                        newRow.CLOSE_PATIENT_FLAG = ViewModel.CLOSE_PATIENT_FLAG;
                        newRow.CLOSE_PATIENT_DETAIL = ViewModel.CLOSE_PATIENT_DETAIL;
                        newRow.TEMPERATURE = ViewModel.TEMPERATURE;
                        newRow.TRAVEL_FLAG = false;
                        newRow.CREATED_DT = DateTime.Now;

                        context.RPT_COVID19EX.Add(newRow);
                        context.SaveChanges();

                        if (ViewModel.SYMTOMS != null && ViewModel.SYMTOMS.Count() > 0)
                        {
                            foreach (var st in ViewModel.SYMTOMS)
                            {
                                var c = new RPT_COVID19EX_SYMTOMS();
                                c.REPORTER_ID = newRow.ID;
                                c.PERSON_TYPE_ID = 1;
                                c.SYMTOMS_ID = st;
                                c.SYMTOMS_OTHER = st == 98 ? (!string.IsNullOrEmpty(ViewModel.SYMTOMS_OTHER_TEXT) ? ViewModel.SYMTOMS_OTHER_TEXT : null) : null;
                                context.RPT_COVID19EX_SYMTOMS.Add(c);
                                context.SaveChanges();
                            }
                        }
                    }

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public void CreateDaily(RptCovid19ExViewModel ViewModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var query = context.RPT_COVID19EX
                            .Include(o => o.RPT_COVID19EX_COUNTRY)
                            .Where(o => o.PERSON_ID == ViewModel.PERSON_ID && o.REPORTER == 1)
                            .OrderByDescending(o => o.CREATED_DT)
                            .FirstOrDefault();

                    if(query != null && query.TRAVEL_FLAG.HasValue)
                    {
                        //create new row
                        var newRow = new RPT_COVID19EX();
                        newRow.PERSON_ID = query.PERSON_ID;
                        newRow.REPORTER = query.REPORTER;
                        newRow.HAS_FLU = ViewModel.HAS_FLU == "1" ? "มีไข้" : "ไม่มีไข้";
                        newRow.CLOSE_PATIENT_FLAG = ViewModel.CLOSE_PATIENT_FLAG;
                        newRow.CLOSE_PATIENT_DETAIL = ViewModel.CLOSE_PATIENT_DETAIL;
                        newRow.TEMPERATURE = ViewModel.TEMPERATURE;
                        newRow.CREATED_DT = DateTime.Now;
                        newRow.TRAVEL_FLAG = query.TRAVEL_FLAG;

                        if(query.TRAVEL_FLAG.Value)
                        {
                            newRow.ARRIVAL_DT = query.ARRIVAL_DT;
                            newRow.ARRIVAL_FLIGHT = query.ARRIVAL_FLIGHT;
                            newRow.DEPARTURE_DT = query.DEPARTURE_DT;
                            newRow.DEPARTURE_FLIGHT = query.DEPARTURE_FLIGHT;
                            newRow.HAS_FLU_OTHER = query.HAS_FLU_OTHER;
                            newRow.TEMPERATURE_OTHER = query.TEMPERATURE_OTHER;
                            newRow.TRAVEL_TOGETHER = query.TRAVEL_TOGETHER;
                            newRow.COMPANION_NAME1 = query.COMPANION_NAME1;
                            newRow.COMPANION_NAME2 = query.COMPANION_NAME2;
                            newRow.COMPANION_NAME3 = query.COMPANION_NAME3;
                            newRow.COMPANION_RELATION1 = query.COMPANION_RELATION1;
                            newRow.COMPANION_RELATION2 = query.COMPANION_RELATION2;
                            newRow.COMPANION_RELATION3 = query.COMPANION_RELATION3;
                        }

                        context.RPT_COVID19EX.Add(newRow);
                        context.SaveChanges();

                        if (ViewModel.SYMTOMS != null && ViewModel.SYMTOMS.Count() > 0)
                        {
                            foreach (var st in ViewModel.SYMTOMS)
                            {
                                var c = new RPT_COVID19EX_SYMTOMS();
                                c.REPORTER_ID = newRow.ID;
                                c.PERSON_TYPE_ID = 1;
                                c.SYMTOMS_ID = st;
                                c.SYMTOMS_OTHER = st == 98 ? (!string.IsNullOrEmpty(ViewModel.SYMTOMS_OTHER_TEXT) ? ViewModel.SYMTOMS_OTHER_TEXT : null) : null;
                                context.RPT_COVID19EX_SYMTOMS.Add(c);
                                context.SaveChanges();
                            }
                        }

                        if (query.RPT_COVID19EX_COUNTRY != null && query.RPT_COVID19EX_COUNTRY.Count() > 0)
                        {
                            foreach (var ct in query.RPT_COVID19EX_COUNTRY)
                            {
                                var c = new RPT_COVID19EX_COUNTRY();
                                c.REPORTER_ID = newRow.ID;
                                c.PERSON_TYPE_ID = 1;
                                c.COUNTRY_ID = ct.COUNTRY_ID;
                                context.RPT_COVID19EX_COUNTRY.Add(c);
                                context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        // สำหรับคนที่ไม่ได้ไปต่างประเทศ add by Jay 20Mar2020
                        var newRow = new RPT_COVID19EX();
                        newRow.PERSON_ID = ViewModel.PERSON_ID;
                        newRow.REPORTER = 1;
                        newRow.HAS_FLU = ViewModel.HAS_FLU == "1" ? "มีไข้" : "ไม่มีไข้";
                        newRow.CLOSE_PATIENT_FLAG = ViewModel.CLOSE_PATIENT_FLAG;
                        newRow.CLOSE_PATIENT_DETAIL = ViewModel.CLOSE_PATIENT_DETAIL;
                        newRow.TEMPERATURE = ViewModel.TEMPERATURE;
                        newRow.TRAVEL_FLAG = false;
                        newRow.CREATED_DT = DateTime.Now;

                        context.RPT_COVID19EX.Add(newRow);
                        context.SaveChanges();

                        if (ViewModel.SYMTOMS != null && ViewModel.SYMTOMS.Count() > 0)
                        {
                            foreach (var st in ViewModel.SYMTOMS)
                            {
                                var c = new RPT_COVID19EX_SYMTOMS();
                                c.REPORTER_ID = newRow.ID;
                                c.PERSON_TYPE_ID = 1;
                                c.SYMTOMS_ID = st;
                                c.SYMTOMS_OTHER = st == 98 ? (!string.IsNullOrEmpty(ViewModel.SYMTOMS_OTHER_TEXT) ? ViewModel.SYMTOMS_OTHER_TEXT : null) : null;
                                context.RPT_COVID19EX_SYMTOMS.Add(c);
                                context.SaveChanges();
                            }
                        }
                    }

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public IEnumerable<LUT_COVID_SYMTOM> GetSymtoms()
        {
            return context.LUT_COVID_SYMTOM.OrderBy(x => x.ORDER_DISPLAY);
        }
    }
}
