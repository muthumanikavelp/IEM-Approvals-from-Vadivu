using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEMMOB_DataModel.Common;
//using IEMMOB.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IEMMOB.Controllers.EOW
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalConveyanceNewController : ControllerBase
    {
        CmnFunctions objCmnFunctions = new CmnFunctions();

        public string getconverttomonthtodateto(string months)
        {
            DateTime convrtdate = new DateTime();
            convrtdate = objCmnFunctions.convertoDateTime(months);
            string monthyear = "";
            string year = "";
            string month = "";

            year = convrtdate.Year.ToString();
            month = convrtdate.Month.ToString();

            if (month.ToString() != "0")
            {
                if (month.ToString() == "1")
                {
                    monthyear = "January-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "2")
                {
                    monthyear = "February-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "3")
                {
                    monthyear = "March-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "4")
                {
                    monthyear = "April-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "5")
                {
                    monthyear = "May-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "6")
                {
                    monthyear = "June-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "7")
                {
                    monthyear = "July-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "8")
                {
                    monthyear = "August-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "9")
                {
                    monthyear = "September-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "10")
                {
                    monthyear = "October-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "11")
                {
                    monthyear = "November-" + year;
                    return monthyear;
                }
                else if (month.ToString() == "12")
                {
                    monthyear = "December-" + year;
                    return monthyear;
                }
                else
                {
                    monthyear = "January-" + year;
                    return monthyear;
                }
            }
            return monthyear;
        }
    }
}
