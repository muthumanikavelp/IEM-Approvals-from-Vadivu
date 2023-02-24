using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMMOB_DataModel.Common
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
               
                return UserGid;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }

            // return 3;
        }

        //
        public string GetINRAmount(string Amount)
        {
            try
            { 
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


        public string GetSubDocType(string Doctype)
        {
            try
            {
                string Status = string.Empty;
                if (Doctype.Equals("1"))
                {
                    Status = "REGULAR";
                }
                else if (Doctype.Equals("2"))
                {
                    Status = "LOCALCOVEYANCE";
                }
                else if (Doctype.Equals("3"))
                {
                    Status = "TRAVEL";
                }
                else if (Doctype.Equals("4"))
                {
                    Status = "SUPPLIERINVOICE";
                }
                else if (Doctype.Equals("5"))
                {
                    Status = "SUPPLIERINVOICEDSA";
                }
                else if (Doctype.Equals("6"))
                {
                    Status = "ADVANCEREQUISITIONEMPLOYEE";
                }
                else if (Doctype.Equals("7"))
                {
                    Status = "ADVANCEREQUISITIONSUPPLIER";
                }
                else if (Doctype.Equals("8"))
                {
                    Status = "PETTYCASH";
                }
                else if (Doctype.ToString() == "11")
                {
                    Status = "INSURANCE";
                }
                else if (Doctype.ToString() == "12")
                {
                    Status = "INSURANCEADVANCE";
                }
                return Status;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string Getreplacesinglequotes(string inpustring)
        {
            try
            {
                string Isretrunstr;
                Isretrunstr = inpustring.Replace("'", "''");
                return Isretrunstr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetQueueStatus(string Queue)
        {
            try
            {
                string Status = string.Empty;
                if (Queue.Contains("D"))
                {
                    Status = "Draft";
                }
                else if (Queue.Contains("A"))
                {
                    Status = "Pending Approval";
                }
                else if (Queue.Contains("R"))
                {
                    Status = "Rejected";
                }
                else if (Queue.Contains("C"))
                {
                    Status = "Concurrent Approval";
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
