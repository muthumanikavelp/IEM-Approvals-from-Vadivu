using System;
using System.Collections.Generic;
//using System.Web.Mvc;

namespace IEMMOB_Model.EOW
{
    public class EOW_Employee
    {

        public class EOW_Raisermode
        {
            public string raisermodeId { get; set; }
            public string raisermodeName { get; set; }
        }

        public class EOW_EmployeeeExpense
        {
            //EmployeeeBasic Model
            public Int32 supplierheader_ggid { get; set; }
            //public SelectList Raiser_Modedata { get; set; }
            public string Raiser_Code { get; set; }
            public string Raiser_Mode { get; set; }
            public string Raiser_Name { get; set; }
            public string ECF_Date { get; set; }
            public string Grade { get; set; }
            public string ECF_Amount { get; set; }
            public string ClaimMonth { get; set; }
            public string raisermodeId { get; set; }
            public string raisermodeName { get; set; }
            public string ecfremark { get; set; }
            public string noofperson { get; set; }

            public string ecfno { get; set; }
            //EmployeeeExpense Model 
            public int Exp_GID { get; set; }
            public int invoice_GID { get; set; }
            public int ecf_GID { get; set; }
            public int Queue_GID { get; set; }
            public int Doctypeid { get; set; }
            public string queueactionfor { get; set; }
            //public string Exp_NatureofExpenses { get; set; }
            //public string Exp_ExpenseCategory { get; set; }
            //public string Exp_SubCategory { get; set; }
            public string Exp_ClaimPeriodFrom { get; set; }
            public string Exp_ClaimPeriodTo { get; set; }
            public string Exp_ClaimMonth { get; set; }

            // public SelectList Exp_FCC { get; set; }
            public string Exp_FC { get; set; }
            // public SelectList Exp_CCC { get; set; }
            public string Exp_CC { get; set; }
            public string Exp_FCCC { get; set; }

            public string Exp_ProductCode { get; set; }
            public string Exp_OUCode { get; set; }
            public string Exp_Amount { get; set; }

            //  public SelectList ExpNatureofExpdata { get; set; }
            public int NatureofExpensesId { get; set; }
            public string NatureofExpensesName { get; set; }

            //  public SelectList ExpCatdata { get; set; }
            public int ExpenseCategoryId { get; set; }
            public string ExpenseCategoryName { get; set; }

            //  public SelectList ExpSubCatdata { get; set; }
            public int SubCategoryId { get; set; }
            public string SubCategoryName { get; set; }
            public string ecfdescription { get; set; }
            public string ecfdelmatamt { get; set; }

            public int ecf_raiser { get; set; }  // arf 
            public string ecf_raisername { get; set; }  // arf 

            //  public SelectList TravelModedata { get; set; }
            public int TravelModeId { get; set; }
            public string TravelModeName { get; set; }

            // public SelectList TravelClassdata { get; set; }
            public int TravelClassId { get; set; }
            public string TravelClassName { get; set; }

            // public SelectList Citydata { get; set; }
            public int TravelCityId { get; set; }
            public string TravelCityName { get; set; }

            // public SelectList Citydatato { get; set; }
            public int TravelCitytoId { get; set; }
            public string TravelCitytoName { get; set; }

            public string PlaceFrom { get; set; }
            public string PlaceTo { get; set; }
            public string Rate { get; set; }
            public string Distance { get; set; }
            public string NatureofExpenseslocal { get; set; }
            public string travelDescription { get; set; }


            public Int32 expsubcat_gid { get; set; }
            public Int32 expsubcat_expnature_gid { get; set; }
            public int selectedexpsubcat_expnature_gid { get; set; }
            public Int32 expsubcat_expcat_gid { get; set; }
            public string expsubcat_code { get; set; }
            public string expsubcat_name { get; set; }
            public string expsubcat_help { get; set; }
            public string expsubcat_active { get; set; }
            public Int32 expsubcat_insert_by { get; set; }
            public DateTime expsubcat_insert_date { get; set; }
            public Int32 expsubcat_update_by { get; set; }
            public DateTime expsubcat_update_date { get; set; }
            public string expsubcat_isremoved { get; set; }
            public int selectedexpcat_gid { get; set; }
            public Int32 expcat_gid { get; set; }
            public string expcat_name { get; set; }
            // public SelectList Getexpcat { get; set; }
            //  public SelectList GetexpcatById { get; set; }

            public Int32 expnature_gid { get; set; }
            public string expnature_name { get; set; }
            //  public SelectList Getexpnature { get; set; }
            //  public SelectList GetexpnatureById { get; set; }

            public string arftype { get; set; }
            public string arfempsupcode { get; set; }
            public string arfempsupname { get; set; }
            public int Hsnid { get; set; }
            // public SelectList HsncodeList { get; set; }
            public string HsnDescription { get; set; }
            public string RCMFlag { get; set; }
            public string ecf_paymode { get; set; }
            public string CygnetFlag { get; set; }
            //public decimal ecf_amount { get; set; }
            //EmployeeePayment Model 

            //public SelectList EmployeeePayment_PaymentModedata { get; set; }
            //public int PaymentModeId { get; set; }
            //public string PaymentModeName { get; set; }

            //public SelectList EmployeeePayment_RefNodata { get; set; }
            //public int RefNoId { get; set; }
            //public string RefNoName { get; set; }
            //public int Paymentmainid { get; set; }
            //public string EmployeeePayment_Beneficiary { get; set; }
            //public string EmployeeePayment_Description { get; set; }
            //public string EmployeeePayment_Amount { get; set; }

            //EmployeeeAttachment Model 

            //public SelectList EmployeeeAttachment_AttachmentTypedata { get; set; }
            //public int AttachmentTypeId { get; set; }
            //public string AttachmentTypeName { get; set; }

            //public string EmpFilesToBeUploaded { get; set; }
            //public HttpPostedFileBase EmpFilesToBeUploadeddata { get; set; }

            //public string EmployeeeAttachment_Filename { get; set; }
            //public string EmployeeeAttachment_Description { get; set; }
            //public string EmployeeeAttachment_AttachedDate { get; set; }
            //public string EmployeeeAttachment_Attachedby { get; set; }

            //vadivu add
            public string Ecfdeclaratonnote { get; set; }
            public List<GetInvoicedetails> Invoice { get; set; }
            public List<EOW_File> Attachement { get; set; }
            public List<ApproverHistry> Audit_Trail{get;set;}
            public List<EOW_TravelClaim> TravelDetails { get; set; }
            public List<EOW_Payment> PaymentDetails { get; set; }
            public List<EOW_RCMEntries> GetRcm { get; set; }
            public List<EOW_TravelClaim> GetGst { get; set; }
        }

        public class GetInvoicedetails
        {
            public string  InvoiceGid { get; set; }
            public string InvoiceDate { get; set; } 
            public string InvoiceNo { get; set; }
            public string InvoiceDescription { get; set; }
            public string InvoiceAmount { get; set; }
            public string PaymentNeting { get; set; }
            public string Isupdated { get; set; }
            public string Isverified { get; set; }
            public string ProviderLocation { get; set; }
            public string Receiverlocation { get; set; }
            public string Gstinvendor { get; set; }
            public string Gstinficcl { get; set; }
            public string ServiceMonth { get; set; }
            public string WotaxAmount { get; set; }
            public string GstCharged { get; set; }
            public string SupplierGid { get; set; }
            public string Suppliercode { get; set; }
            public string SupplierName { get; set; }
            public string Paymode { get; set; }
        }
        //Eow Attachment
        public class EOW_File
        {
            // public SelectList AttachmentTypeData { get; set; }
            public int AttachmentTypeId { get; set; }
            public string AttachmentTypeName { get; set; }
            public string AttachmentFilenamedata { get; set; }
            public int AttachmentFilenameId { get; set; }
            public string AttachmentFilename { get; set; }
            public string AttachmentDescription { get; set; }
            public string AttachmentDate { get; set; }
            public string AttachmentBy { get; set; }
            public int attachment_by { get; set; }
            public string Name { get; set; }
            public int Length { get; set; }
            public string Type { get; set; }

            public int FileId { get; set; }
            public string FileName { get; set; }
            public string FilePath { get; set; }
        }


        //EOW Approver History
        public class ApproverHistry
        {
            public int rowcount { get; set; }
            public string empcode { get; set; }
            public string empname { get; set; }
            public string actiontype { get; set; }
            public string status { get; set; }
            public string empdel { get; set; }
            public string empdesi { get; set; }
            public string statusdate { get; set; }
            public string remarks { get; set; }
        }

        //EOW Travel Details
        public class EOW_TravelClaim
        {
            //TravelClaim Basic Model

            // public SelectList Raiser_Modedata { get; set; }
            public string Raiser_Code { get; set; }
            public string Raiser_Mode { get; set; }
            public string Raiser_Name { get; set; }
            public string ECF_Date { get; set; }
            public string Grade { get; set; }
            public string ECF_Amount { get; set; }
            public string ClaimMonth { get; set; }

            public string raisermodeId { get; set; }
            public string raisermodeName { get; set; }

            //TravelClaim Mode Model 
            public int TravelMode_GID { get; set; }
            //public string TravelMode_NatureofExpenses { get; set; }
            //public string TravelMode_ExpenseCategory { get; set; }
            //public string TravelMode_SubCategory { get; set; }
            public string Branch { get; set; }
            public string PlaceFrom { get; set; }
            public string PlaceTo { get; set; }
            public string ClaimPeriodFrom { get; set; }
            public string ClaimPeriodTo { get; set; }
            public string Rate { get; set; }
            public string Distance { get; set; }
            //public string FC { get; set; }
            //public string CC { get; set; }
            public string ProductCode { get; set; }
            public string OUCode { get; set; }
            public string Amount { get; set; }
            public string AmountINR { get; set; }

            // public SelectList Exp_FCC { get; set; }
            public string FC { get; set; }
            //  public SelectList Exp_CCC { get; set; }
            public string CC { get; set; }
            public string Exp_FCCC { get; set; }
            public string travelDescription { get; set; }
            public string Traveltypes { get; set; }
            public string Travelclass { get; set; }

            // public SelectList ExpNatureofExpdata { get; set; }
            public int NatureofExpensesId { get; set; }
            public string NatureofExpensesName { get; set; }

            // public SelectList ExpCatdata { get; set; }
            public int ExpenseCategoryId { get; set; }
            public string ExpenseCategoryName { get; set; }

            // public SelectList ExpSubCatdata { get; set; }
            public int SubCategoryId { get; set; }
            public string SubCategoryName { get; set; }


            //  public SelectList TravelModedata { get; set; }
            public int TravelModeId { get; set; }
            public string TravelModeName { get; set; }

            // public SelectList TravelClassdata { get; set; }
            public int TravelClassId { get; set; }
            public string TravelClassName { get; set; }

            // public SelectList Citydata { get; set; }
            public int TravelCityId { get; set; }
            public string TravelCityName { get; set; }

            //  public SelectList Citydatato { get; set; }
            public int TravelCitytoId { get; set; }
            public string TravelCitytoName { get; set; }

            // public SelectList AssetCatList { get; set; }
            public int AssetCatId { get; set; }
            public string AssetCatName { get; set; }

            //  public SelectList AssetSubCatList { get; set; }
            public int AssetSubCatId { get; set; }
            public string AssetSubCatName { get; set; }

            public string ProdServCategory { get; set; }
            public string GLCode { get; set; }
            public string invoicepoitem_GID { get; set; }

            // public SelectList HsncodeList { get; set; }
            public int TravelHsnid { get; set; }
            public string TravelHsnCode { get; set; }
            public string TravelHsnDesc { get; set; }
            public string InvGid { get; set; }

            // Gst Add Details
            public string GstApplicable { get; set; }
            public string Hsncode { get; set; }
            public string HsnDesc { get; set; }
            public string Subtax { get; set; }
            public decimal TaxableAmt { get; set; }
            public decimal GstRate { get; set; }
            public decimal TaxAmt { get; set; }
            public int InvoiceTaxGid { get; set; }
            public int HsnId { get; set; }
            //Ramya Added
            public string RCMFlag { get; set; }
            public string CygnetFlag { get; set; }
        }

        //Payment 
        public class EOW_Payment
        {
           // public SelectList PaymentModedata { get; set; }
            public int PaymentModeId { get; set; }
            public string PaymentModeName { get; set; }

          //  public SelectList Refdata { get; set; }
            public int RefNoId { get; set; }
            public string RefNoName { get; set; }
            public int Paymentgid { get; set; }
            public string SplitPaymentAmt { get; set; }
            public string Beneficiary { get; set; }
            public string Description { get; set; }
            public string Beneficiarycardno { get; set; }
            public string PaymentAmount { get; set; }
            public string AmountINR { get; set; }
            public string Employeecode { get; set; }
            public string Employeename { get; set; }
            public string Exception { get; set; }
            public string Ifsccode { get; set; }
            //Ramya 01 Aug 2018 Start
            public string ECFID { get; set; }
            public string GLID { get; set; }
            //Ramya 01 Aug 2018 End

            //IEM_GST_Phase3_1
            public string DSASupplier_Gid { get; set; }
            public string DSAInvoice_Gid { get; set; }
            public string DSAInvoice_Amount { get; set; }
        }

        //Get RCM
        public class EOW_RCMEntries
        {
           // public SelectList RCMEnteries { get; set; }
            public string Expsubcat_Name { get; set; }
            public string HsnCode { get; set; }
            public string DebitRCM_Type { get; set; }
            public string Taxable_Amount { get; set; }
            public decimal debitrcm_rate { get; set; }
            public decimal debitrcm_amount { get; set; }
            public string debitrcm_inputcreditgl { get; set; }
            public string debitrcm_reversechargegl { get; set; }
            public decimal debitInputcreditRate { get; set; }
            public decimal debitInputcreditAmt { get; set; }
            public decimal Taxgst_InputCredit_Display_Rate { get; set; }
            public decimal Taxgst_RCM_Display_Rate { get; set; }
        }
        public class DashBoard
        {
            List<DashBoard> lstDashBoardMyReuest = new List<DashBoard>();
            List<DashBoard> lstDashBoardMyApp = new List<DashBoard>();
            List<DashBoard> lstDashBoardCtChkr = new List<DashBoard>();
            List<DashBoard> lstDashBoardCtMkr = new List<DashBoard>();

            public int Doctypeid { get; set; }
            public int Docnogid { get; set; }
            public string DocDate { get; set; }
            public string Docno { get; set; }
            public string Docamount { get; set; }

            public string Invoiceno { get; set; }

            //public SelectList DocTypeData { get; set; }
            public string DocTypeIdd { get; set; }
            public string DocTypeName { get; set; }

           // public SelectList StatusTypeData { get; set; }
            public string StatusTypeId { get; set; }
            public string StatusTypeName { get; set; }

            public string raiserName { get; set; }
            public string emporsupp { get; set; }

            public string DashBoardRequestType { get; set; }
            public int DraftCount { get; set; }
            public int InprocessCount { get; set; }
            public int ApprovedCount { get; set; }
            public int RejectedCount { get; set; }
            public int PaidCount { get; set; }
            public int ForApprovalCount { get; set; }
            public string ecfdescription { get; set; }
            public string ecfdelegate { get; set; }

            public int EPUInprocessCount { get; set; }
            public int EPURejectedCount { get; set; }
            public int CancelledCount { get; set; }

            public string ecfview { get; set; }
            public string ecfprint { get; set; }
            public string ecfselect { get; set; }
            public string ecfprintid { get; set; }

            public string sqlcon { get; set; }
            public string queuefor { get; set; }
            public string requesttype { get; set; }
            public string reqstatus { get; set; }
            public string empgid { get; set; }
        }


        //Approve
        public class Approveraction
        {
            public string status { get; set; }
            public string Rejecthold { get; set; }
            public string Concurrent { get; set; }
            public string Concurrentmsg { get; set; }
            public string appkremarks { get; set; }

             
            public string EcfGid { get; set; }
            public string invoiceGid { get; set; }
            public string empgid { get; set; }
            public string EcfType { get; set; }
            public string QueueGid { get; set; }
            public string queueamt { get; set; }
        }

        public class Approve
        {
         public   string appkremarks { get; set; }
       public int Concurrent { get; set; }
       public string Concurrentmsg { get; set; }
       public string Rejecthold { get; set; }
       public string status { get; set; }
      public  string EcfGid { get; set; }
      public  string invoiceGid { get; set; }
        public  string empgid { get; set; }
       public string EcfType { get; set; }
      public string QueueGid { get; set; }
      public  string queueamt { get; set; }
    public  string checker_raisergid { get; set; }
       public string delegates { get; set; }
            public string Ecfdesignation { get; set; }
            public string err_msg { get; set; }
              
        }

    }
}
