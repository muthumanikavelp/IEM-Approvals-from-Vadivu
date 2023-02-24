using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace IEMMOB.Common
{
    public class CmnFunctions
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        DataTable dt;
      //  ErrorLog objErrorLog = new ErrorLog();
        public void getconnection(string ConString)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConString;
                con.Open();
            }
        }


        
        public int GetLoginUserGid()
        {
            try
            {
                int UserGid = 0;
                //UserGid = Convert.ToInt32(HttpContext.Current.Session["employee_gid"]);
                return UserGid;
            }
            catch (Exception ex)
            {
                //objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                //Emp.SessionStatus = 0;
                //IEMDataModel objModel = new IEMDataModel();
                //objModel.insertloginattempt(Emp.IPAddress, Emp.empcodeST, "Session Expired", Emp.BrowserName);
                //objModel.UpdateLoginFlag(Emp.empgidST, 0);
                //HttpContext.Current.Response.RedirectToRoute("Default");
                throw ex;
            }

            // return 3;
        }

        //
        public string GetINRAmount(string Amount)
        {
            try
            {
                //decimal amoumnt = 0;
                //amoumnt = Convert.ToDecimal(Amount);
                //CultureInfo cuInfo = new CultureInfo("hi-IN");
                //string Isretrunstr;
                //Isretrunstr = (amoumnt.ToString("C", cuInfo)).Remove(0, 2).Trim();
                //return Isretrunstr;
                decimal amoumnt = 0;
                amoumnt = Convert.ToDecimal(Amount.Trim());
                CultureInfo cuInfo = new CultureInfo("hi-IN");
                string Isretrunstr;
                //Isretrunstr = (amoumnt.ToString("C", cuInfo)).Remove(0, 1).Trim();
                //12-04-18
                Isretrunstr = (amoumnt.ToString("C", cuInfo)).Trim();
                var charstoremove = new string[] { "₹", " ", "रु", "$" };
                foreach (var c in charstoremove)
                {
                    Isretrunstr = Isretrunstr.Replace(c, string.Empty).Trim();
                }
                //12-04-18
                return Isretrunstr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //
        public string GetDocType(string Doctype)
        {
            try
            {
                string Status = string.Empty;
                if (Doctype.ToString() == "1")
                {
                    Status = "ECRegular";
                }
                else if (Doctype.ToString() == "2")
                {
                    Status = "ECLocal";
                }
                else if (Doctype.Contains("3"))
                {
                    Status = "ECTravel";
                }
                else if (Doctype.Contains("4"))
                {
                    Status = "EcfSupplier";
                }
                else if (Doctype.Contains("5"))
                {
                    Status = "EcfSupplierDSA";
                }
                else if (Doctype.Contains("8"))
                {
                    Status = "ECRegular";
                }
                else if (Doctype.Contains("6") || Doctype.Contains("7"))
                {
                    Status = "Arf";
                }
                else if (Doctype.ToString() == "11")
                {
                    Status = "Insurance";
                }
                else if (Doctype.ToString() == "12")
                {
                    Status = "Insuranceadvance";
                }
                return Status;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DateTime convertoDateTime(string inputdate)
        {
            try
            {
                string lsInputDate = inputdate;
                string convertdate = string.Empty;
                DateTime outputDate = Convert.ToDateTime(lsInputDate.ToString());
                string format = "dd/MMM/yyyy";
                convertdate = outputDate.ToString(format);
                outputDate = Convert.ToDateTime(convertdate);
                return outputDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GetQueueStatusHistry(string Queue)
        {
            try
            {
                string Status = string.Empty;

                if (Queue == "0")
                {
                    Status = "Raiser";
                    return Status;
                }
                else if (Queue == "64")
                {
                    Status = "Hold Release";
                    return Status;
                }
                else if (Queue == "16")
                {
                    Status = "Hold";
                    return Status;
                }
                else if (Queue == "1")
                {
                    Status = "Approved";
                    return Status;
                }
                else if (Queue == "32")
                {
                    Status = "Inprocess";
                    return Status;
                }
                else if (Queue == "2")
                {
                    Status = "Rejected";
                    return Status;
                }
                else if (Queue == "10" || Queue == "20")
                {
                    Status = "Rejected";
                    return Status;
                }
                else if (Queue == "4")
                {
                    Status = "Cancelled";
                    return Status;
                }
                else if (Queue == "7")
                {
                    Status = "Concurrent Approved Rejected";
                    return Status;
                }
                else if (Queue == "8")
                {
                    //Status = "Concurrent Approval soughted";
                    Status = "Sent for Concurrent approval";
                    return Status;
                }
                else if (Queue == "9")
                {
                    Status = "Concurrent Approved";
                    return Status;
                }
                else if (Queue == "11")
                {
                    Status = "Concurrent Not Applicable";
                    return Status;
                }
                return Status;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
