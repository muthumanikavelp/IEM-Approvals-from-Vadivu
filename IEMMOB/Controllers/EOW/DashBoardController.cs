using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IEMMOB.Helper;
using IEMMOB_DataModel.Common;
using IEMMOB_DataModel.EOW;
using IEMMOB_Model.EOW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static IEMMOB_Model.EOW.EOW_Employee;

namespace IEMMOB.Controllers.EOW
{
    [Route("api/EOW/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        CmnFunctions objCmnFunctions = new CmnFunctions();
        LocalConveyanceNewController locals = new LocalConveyanceNewController();
        proLib plib = new proLib();
        dbLib db = new dbLib();
        EOW_DataModel objModel = new EOW_DataModel();
        #region Declaration
        DataTable dt = new DataTable();
        #endregion

        private readonly IOptions<EOW_Supplierinvoice> appSettings;
        string ConString;
        private IConfiguration _configuration;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        public DashBoardController(IOptions<EOW_Supplierinvoice> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.sqlcon;
            _configuration = configuration;
        }
        [HttpGet("GetName")]
        public string getname()
        {
            return "Vadivukkarasi";
        }

        [HttpPost("EOWDetails")]
        public List<EOW_Employee.EOW_EmployeeeExpense> Viewdata(string QueueGid, string EcfGid, string invoiceGid, string EcfType)
        {
            string requesttype = "";
            string Centralautit = "";
            EOW_Employee.EOW_EmployeeeExpense eowemp = new EOW_Employee.EOW_EmployeeeExpense();
            List<EOW_Employee.EOW_EmployeeeExpense> objobjMExpense = new List<EOW_Employee.EOW_EmployeeeExpense>();
            this.ConString = _configuration.GetSection("ConnectionString")["ConnectionString"].ToString();
            // this.ConString = objModel.getRightConStringEOW(this.appSettings.Value);
            string confirmsupplier = objModel.selectsupplierinvoice(QueueGid.ToString(), "A", ConString).ToString();
            string viewapp = objModel.selectsupplierinvoicestatus(QueueGid.ToString(), "A", ConString).ToString();
            string centralteam = objModel.selectsupplierinvoicestatuscen(QueueGid.ToString(), "A", ConString).ToString();
            string cemtm = objModel.selectcemtam(QueueGid.ToString(), centralteam, ConString);
            if (confirmsupplier == "4" || confirmsupplier == "11")
            {
                EOW_Supplierinvoice seowemp = new EOW_Supplierinvoice();
                List<EOW_Supplierinvoice> sobjobjMExpense = new List<EOW_Supplierinvoice>();
                if (centralteam == "C" || centralteam == "R")
                {
                    sobjobjMExpense = objModel.SelectViewdatasupplier(QueueGid, "checkview", ConString).ToList();
                }
                else
                {
                    sobjobjMExpense = objModel.SelectViewdatasupplier(QueueGid, "A", ConString).ToList();
                }
                seowemp.ecfno = sobjobjMExpense[0].ecfno.ToString();
                seowemp.ECF_Amount = objCmnFunctions.GetINRAmount(sobjobjMExpense[0].ECF_Amount.ToString());
                seowemp.ECF_Date = sobjobjMExpense[0].ECF_Date.ToString();
                seowemp.raisermodeId = sobjobjMExpense[0].raisermodeId.ToString();
                if (sobjobjMExpense[0].ecfstatus == "262144" || sobjobjMExpense[0].ecfstatus == "524288")
                {
                    Centralautit = "C";
                }
                else
                {
                    Centralautit = "S";
                }
                seowemp.Grade = sobjobjMExpense[0].Grade.ToString();
                seowemp.Raiser_Code = sobjobjMExpense[0].Raiser_Code.ToString();
                seowemp.Raiser_Name = sobjobjMExpense[0].Raiser_Name.ToString();
                seowemp.ecfdescription = sobjobjMExpense[0].ecfdescription.ToString();
                seowemp.amort = sobjobjMExpense[0].amort.ToString();
                seowemp.amortdec = sobjobjMExpense[0].amortdec.ToString();
                seowemp.from = sobjobjMExpense[0].from.ToString();
                seowemp.to = sobjobjMExpense[0].to.ToString();
                seowemp.Suppliergid = sobjobjMExpense[0].Suppliergid.ToString();
                seowemp.Suppliercode = sobjobjMExpense[0].Suppliercode.ToString();
                seowemp.Suppliername = sobjobjMExpense[0].Suppliername.ToString();
                seowemp.CurrencyName = sobjobjMExpense[0].CurrencyName.ToString();
                seowemp.Exrate = sobjobjMExpense[0].Exrate.ToString();
                seowemp.Currencyamount = sobjobjMExpense[0].Currencyamount.ToString();
                seowemp.DocName = Convert.ToString(sobjobjMExpense[0].DocName);
                seowemp.ecf_Paymode = sobjobjMExpense[0].ecf_Paymode.ToString();
                sobjobjMExpense.Add(seowemp);
                if (sobjobjMExpense[0].Doctypeid == 1 || sobjobjMExpense[0].Doctypeid == 2 || sobjobjMExpense[0].Doctypeid == 3 || sobjobjMExpense[0].Doctypeid == 8)
                {
                    requesttype = "EMPLOYEE CLAIMS";
                }
                else if (sobjobjMExpense[0].Doctypeid == 6 || sobjobjMExpense[0].Doctypeid == 7 || sobjobjMExpense[0].Doctypeid == 9)
                {
                    requesttype = "ADVANCE REQUEST";
                }
                else if (sobjobjMExpense[0].Doctypeid == 4 || sobjobjMExpense[0].Doctypeid == 5 || sobjobjMExpense[0].Doctypeid == 10)
                {
                    requesttype = "SUPPLIER INVOICE";
                }
            }
            else
            {
                Centralautit = "S";
                confirmsupplier = objModel.selectsupplierinvoice(QueueGid.ToString(), "A", ConString).ToString();
                if (confirmsupplier == "6" || confirmsupplier == "7" || confirmsupplier == "12")
                {

                    objobjMExpense = objModel.SelectViewdata(QueueGid, "AL", ConString).ToList();
                }
                if (confirmsupplier == "2" || confirmsupplier == "5")
                {

                    objobjMExpense = objModel.SelectViewdata(QueueGid, "AL", ConString).ToList();
                }
                else if (confirmsupplier != "2" && confirmsupplier != "5" && confirmsupplier != "6" && confirmsupplier != "7" && confirmsupplier != "12")
                {

                    objobjMExpense = objModel.SelectViewdata(QueueGid, "A", ConString).ToList();
                }

                eowemp.ecfno = objobjMExpense[0].ecfno.ToString();
                eowemp.ECF_Amount = objCmnFunctions.GetINRAmount(objobjMExpense[0].ECF_Amount.ToString());
                eowemp.ecfdelmatamt = objobjMExpense[0].ecfdelmatamt.ToString();
                eowemp.ClaimMonth = locals.getconverttomonthtodateto(objobjMExpense[0].ClaimMonth.ToString());
                eowemp.ECF_Date = objobjMExpense[0].ECF_Date.ToString();
                eowemp.Grade = objobjMExpense[0].Grade.ToString();
                eowemp.Raiser_Code = objobjMExpense[0].Raiser_Code.ToString();
                eowemp.Raiser_Name = objobjMExpense[0].Raiser_Name.ToString();
                eowemp.ecfdescription = objobjMExpense[0].ecfdescription.ToString();
                eowemp.SubCategoryName = objobjMExpense[0].SubCategoryName.ToString();
                eowemp.ecf_paymode = objobjMExpense[0].ecf_paymode.ToString();
                if (eowemp.SubCategoryName == "E")
                {
                    eowemp.arftype = "Employee";
                    eowemp.arfempsupcode = objobjMExpense[0].Raiser_Code.ToString();
                    eowemp.arfempsupname = objobjMExpense[0].Raiser_Name.ToString();
                }
                if (eowemp.SubCategoryName == "P")
                {
                    eowemp.arftype = "Petty Cash";
                    eowemp.arfempsupcode = objobjMExpense[0].arfempsupcode.ToString();
                    eowemp.arfempsupname = objobjMExpense[0].arfempsupname.ToString();
                }
                if (eowemp.SubCategoryName == "S" || eowemp.SubCategoryName == "I")
                {
                    eowemp.arftype = "Supplier";
                    if (objobjMExpense[0].arfempsupcode != null)
                    {
                        eowemp.arfempsupcode = objobjMExpense[0].arfempsupcode.ToString();
                    }
                    if (objobjMExpense[0].arfempsupname != null)
                    {
                        eowemp.arfempsupname = objobjMExpense[0].arfempsupname.ToString();
                    }
                }
                if (objobjMExpense[0].Doctypeid == 1 || objobjMExpense[0].Doctypeid == 2 || objobjMExpense[0].Doctypeid == 3 || objobjMExpense[0].Doctypeid == 8)
                {
                    requesttype = "EMPLOYEE CLAIMS";
                }
                else if (objobjMExpense[0].Doctypeid == 6 || objobjMExpense[0].Doctypeid == 7 || objobjMExpense[0].Doctypeid == 9)
                {
                    requesttype = "ADVANCE REQUEST";
                }
                else if (objobjMExpense[0].Doctypeid == 4 || objobjMExpense[0].Doctypeid == 5 || objobjMExpense[0].Doctypeid == 10)
                {
                    requesttype = "SUPPLIER INVOICE";
                }
            }


            eowemp.Ecfdeclaratonnote = objModel.GetDecnote(confirmsupplier.ToString(), "A", ConString).ToString();

            //Get invoice Details
            List<GetInvoicedetails> invoicedtllst = new List<GetInvoicedetails>();
            invoicedtllst = objModel.LoadInvoiceHeaderDetails(EcfGid, invoiceGid, ConString);

            eowemp.Invoice = invoicedtllst;

            //Get Attachment
            List<EOW_File> objeowfile = new List<EOW_File>();
            objeowfile = objModel.GetEmployeeeAttachment(EcfGid, ConString);
            eowemp.Attachement = objeowfile;

            //Get Audit Trail
            List<ApproverHistry> Apphistory = new List<ApproverHistry>();
            Apphistory = objModel.GetecfappHistory(EcfGid, invoiceGid, ConString);
            eowemp.Audit_Trail = Apphistory;

            //Get Travel Mode Details

            List<EOW_TravelClaim> Gettraveldtls = new List<EOW_TravelClaim>();

            Gettraveldtls = objModel.GetTravelModedata(EcfGid, invoiceGid, EcfType, ConString);
            eowemp.TravelDetails = Gettraveldtls;

            //Get Payment Details
            List<EOW_Payment> pytdtls = new List<EOW_Payment>();
            pytdtls = objModel.GetEmployeeePayment(EcfGid, invoiceGid, ConString);
            eowemp.PaymentDetails = pytdtls;

            //Get RCM
            List<EOW_RCMEntries> RcmDtls = new List<EOW_RCMEntries>();
            RcmDtls = objModel.GetRCMdetls(invoiceGid, ConString);
            eowemp.GetRcm = RcmDtls;

            //Get GST
            List<EOW_TravelClaim> getgstdtls = new List<EOW_TravelClaim>();
            getgstdtls = objModel.Getgstdetls(EcfGid, invoiceGid, EcfType, ConString);
            eowemp.GetGst = getgstdtls;

            objobjMExpense.Add(eowemp);

            return objobjMExpense;
        }

        //Approve
        [HttpPost("Approve")]

        public string _Viewsubmit(Approve ObjApprove)

        {
            Approve ObjApprover = new Approve();
            List<Approve> ObjApprovelist = new List<Approve>();
            string Result = "";
            string Ecfdesignation = Convert.ToString(_configuration.GetSection("AppSettings")["Ecfdesignation"].ToString());
            int EMPdelmattype = Convert.ToInt32(_configuration.GetSection("AppSettings")["EMPdelmattype"].ToString());
            int SUPdelmattype = Convert.ToInt32(_configuration.GetSection("AppSettings")["SUPdelmattype"].ToString());
            int EcfInprocess = Convert.ToInt32(_configuration.GetSection("AppSettings")["EcfInprocess"].ToString());
            int EcfApproved = Convert.ToInt32(_configuration.GetSection("AppSettings")["EcfApproved"].ToString());
            int ecfHold = Convert.ToInt32(_configuration.GetSection("AppSettings")["EcfHold"].ToString());
            int EcfConcurrentApproval = Convert.ToInt32(_configuration.GetSection("AppSettings")["EcfConcurrentApproval"].ToString());
            int EcfRejected = Convert.ToInt32(_configuration.GetSection("AppSettings")["EcfRejected"].ToString());
            int centralckeckerreject = Convert.ToInt32(_configuration.GetSection("AppSettings")["EcfCenraiserreject"].ToString());
            int centralmaker = Convert.ToInt32(_configuration.GetSection("AppSettings")["Centralmaker"].ToString());
            try
            {
                this.ConString = _configuration.GetSection("ConnectionString")["ConnectionString"].ToString();
                Result = objModel.Insertapprovedaction(ObjApprove,
                    Ecfdesignation, EMPdelmattype, SUPdelmattype, EcfInprocess, EcfApproved, ecfHold,
                  EcfConcurrentApproval, EcfRejected, centralckeckerreject, centralmaker,
                   ConString);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Concurrent login to approve
        [HttpPost("ApproveAction")]
        public string _Viewsubmitcon(Approveraction EmployeeeExpense)
        {

            Approveraction objmdl = new Approveraction();
            string Result = "";
            string EcfConcurrentApprovalreject = Convert.ToString(_configuration.GetSection("AppSettings")["EcfConcurrentApprovalreject"].ToString());
            string EcfApproved = Convert.ToString(_configuration.GetSection("AppSettings")["EcfInprocess"].ToString());
            string EcfConcurrentApproval = Convert.ToString(_configuration.GetSection("AppSettings")["EcfConcurrentApproval"].ToString());
            string EcfRejected = Convert.ToString(_configuration.GetSection("AppSettings")["EcfRejected"].ToString());
            string EcfConcurrentApprovalnotapp = Convert.ToString(_configuration.GetSection("AppSettings")["EcfConcurrentApprovalnotapp"].ToString());
            string EcfConcurrentApprovalappred = Convert.ToString(_configuration.GetSection("AppSettings")["EcfConcurrentApprovalappred"].ToString());
            try
            {
                this.ConString = _configuration.GetSection("ConnectionString")["ConnectionString"].ToString();
                Result = objModel.Insertapprovedactioncon(EmployeeeExpense, EcfConcurrentApprovalreject, EcfApproved, EcfConcurrentApproval, EcfRejected, EcfConcurrentApprovalnotapp, EcfConcurrentApprovalappred, ConString);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
