using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Core
{
    public class DateTimeUtils
    {
        public static string ConvertTimeToString(TimeSpan? time, string format)
        {
            if (time.HasValue)
            {
                return time.Value.ToString(format);
            }
            else
            {
                return "";
            }
        }

        public static string ConvertDateTimeToString(DateTime? date, string format, string local)
        {
            if (date.HasValue)
            {
                return date.Value.ToString(format, new CultureInfo(local));
            }
            else
            {
                return "";
            }
        }

        public static string ConvertDateTimeToString(DateTime date, string format, string local)
        {
            return date.ToString(format, new CultureInfo(local));
        }

        public static DateTime? ConvertDateTimeToDateTimeThai(DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.AddYears(543);
            }
            else
            {
                return null;
            }
        }

        public static DateTime? ConvertStringToDateTime(string date, string format, string local)
        {
            return DateTime.ParseExact(date, format, new CultureInfo(local));
        }

        public static DateTime ConvertDateTimeToDateTimeThai(DateTime date)
        {
            return date.AddYears(543);
        }

        public static DateTime? AddDays(DateTime? date)
        {
            //ใช้สำหรับพวก date between ในส่วนของ dateTo
            if (date.HasValue)
            {
                DateTime dt = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, 23, 59, 59);
                return dt;
            }
            else
            {
                return null;
            }
        }

        public static string GetDateRangeString(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null && endDate == null)
            {
                return "ไม่ระบุ";
            }
            else if (startDate == null || endDate == null)
            {
                if (startDate == null)
                {
                    return "ถึงวันที่ " + ConvertDateTimeToString(endDate, "dd MMMM yyyy", "th-TH");
                }
                else
                {
                    return "ตั้งแต่วันที่ " + ConvertDateTimeToString(startDate, "dd MMMM yyyy", "th-TH");
                }
            }
            else
            {
                return ConvertDateTimeToString(startDate, "dd MMMM yyyy", "th-TH") + " - " + ConvertDateTimeToString(endDate, "dd MMMM yyyy", "th-TH");
            }
        }

        public static string GetMonthRangeString(DateTime? startDate, DateTime? endDate)   // from Fiber2, 
        {
            if (startDate == null && endDate == null)
            {
                return "ไม่ระบุ";
            }
            else if (startDate == null || endDate == null)
            {
                if (startDate == null)
                {
                    return "ถึงเดือน " + ConvertDateTimeToString(endDate, "MMMM yyyy", "th-TH");
                }
                else
                {
                    return "ตั้งแต่เดือน " + ConvertDateTimeToString(startDate, "MMMM yyyy", "th-TH");
                }
            }
            else
            {
                return ConvertDateTimeToString(startDate, "MMMM yyyy", "th-TH") + " - " + ConvertDateTimeToString(endDate, "MMMM yyyy", "th-TH");
            }
        }

        public static DateTime? AddTime(DateTime? date, string timeStr)  // from Infraction
        {
            //ใช้สำหรับเพิ่มเวลา
            if (date.HasValue)
            {
                // notice time
                if (!string.IsNullOrWhiteSpace(timeStr))
                {
                    string[] time = timeStr.Split(new string[1] { ":" }, StringSplitOptions.None);
                    date = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, Int16.Parse(time[0]), Int16.Parse(time[1]), 00);
                }
                return date;
            }
            else
            {
                return null;
            }
        }

        public static DateTime? CombineDateTime(DateTime date, string time) // from Streetlight 2
        {
            if (date != null)
            {
                if (!string.IsNullOrWhiteSpace(time))
                {
                    string[] tmp = time.Split(new string[1] { ":" }, StringSplitOptions.None);
                    date = new DateTime(date.Year, date.Month, date.Day, Int16.Parse(tmp[0]), Int16.Parse(tmp[1]), 00);
                    return date;
                }
                return date.Date;
            }
            return null;
        }

        public static string GetMonthLabel(int? month) // from Planning
        {
            DateTime? dt = null;
            var cultureTH = new CultureInfo("th-TH");
            if (month.HasValue)
            {
                dt = new DateTime(1, month.Value, 1);
                return dt.Value.ToString("MMMM", cultureTH);
            }
            return "";
        }

        /// <summary>  
        /// For calculating only age  
        /// </summary>  
        /// <param name="dateOfBirth">Date of birth</param>  
        /// <returns> age e.g. 26</returns>  
        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        //ไม่นับเสาร์ อาทิตย์
        public static int? GetDayRange(DateTime startDate, DateTime endDate)
        {
            int? num = 0;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {

                if (date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday)
                {
                    num++;
                }
            }

            return num;
        }

        public static DateTime GetLastDayOfYear(DateTime date)
        {
            return new DateTime(date.Year, 12, 31);
        }

        public static int? GetRPTMonthDiff(DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue && endDate.HasValue)
            {
                return (((endDate.Value.Year - startDate.Value.Year) * 12) + endDate.Value.Month - startDate.Value.Month) + 1;
            }
            else
            {
                return null;
            }

        }
    }
}
