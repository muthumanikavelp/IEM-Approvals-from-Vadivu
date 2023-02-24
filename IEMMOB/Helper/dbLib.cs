//using IEMMOB.Common;
using IEMMOB_DataModel.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IEMMOB.Helper
{
    public class dbLib: sqlLib
    {
        CmnFunctions obj = new CmnFunctions();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;

        public void getconnection(string ConString)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConString;
                con.Open();
            }
        }


        #region Dashboard
        //Asms Dashboard Count
        public DataTable GetASMSDashboardCount(string empgid, string raiser, string action,string ConString)
        {
           getconnection(ConString);
               SqlCommand cmd = new SqlCommand("MOB_ASMS_DashboardCount", con);
             cmd.CommandType = CommandType.StoredProcedure;
             DataTable dt = new DataTable();
            
               cmd.Parameters.Add("empgid", SqlDbType.VarChar).Value = empgid;
             cmd.Parameters.Add("raiser", SqlDbType.VarChar).Value = raiser;
               cmd.Parameters.Add("action", SqlDbType.VarChar).Value = action;
               da = new SqlDataAdapter(cmd);
             da.Fill(dt); 
            return dt;
        }

        //EOW Dashboard count
        public DataTable GetEOWDashboardCount(string empgid, string raiser, string action, string ConString)
        {
            getconnection(ConString);
            SqlCommand cmd = new SqlCommand("[MOB_EOW_DashboardCount]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
           
            cmd.Parameters.Add("empgid", SqlDbType.VarChar).Value = empgid;
            cmd.Parameters.Add("raiser", SqlDbType.VarChar).Value = raiser;
            cmd.Parameters.Add("action", SqlDbType.VarChar).Value = action;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
             
             return dt;
        }

        //EOW Dashboard count
        public DataTable GetEProcureDashboardCount(string empgid, string raiser, string action, string ConString)
        {
            getconnection(ConString);
            SqlCommand cmd = new SqlCommand("[MOB_EProcure_DashboardCount]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();

            cmd.Parameters.Add("empgid", SqlDbType.VarChar).Value = empgid;
            cmd.Parameters.Add("raiser", SqlDbType.VarChar).Value = raiser;
            cmd.Parameters.Add("action", SqlDbType.VarChar).Value = action;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }


        public DataSet GetCountOfForMyApproval(string employee_gid, string doctype)
        {
            ProcedureName = "proGetCountOfForMyApproval";
            AddParameter("employee_gid", employee_gid);
            AddParameter("doctype", doctype);
            return ExecuteProcedure;
        }


        public DataSet GetDashboardSummary(string empgid, string action, string requesttype, string requeststatus, string proxytype)
        {
            ProcedureName = "PR_Get_DashboardSummary";
            AddParameter("empgid", empgid);
            AddParameter("requesttype", requesttype);
            AddParameter("proxytype", proxytype);
            AddParameter("requeststatus", requeststatus);
            AddParameter("action", action);
            return ExecuteProcedure;
        }

        public DataSet GetASMSHistory(string DateFrom, string DateTo, string RequestType, string RequestStatus, string UId)
        {
            ProcedureName = "PR_Get_HistoryASMS";
            AddParameter("DateFrom", DateFrom);
            AddParameter("DateTo", DateTo);
            AddParameter("RequestType", RequestType);
            AddParameter("RequestStatus", RequestStatus);
            AddParameter("UId", UId);
            return ExecuteProcedure;
        }

        public DataSet GetEProcureHistory(string DateFrom, string DateTo, string RequestType, string RequestStatus, string UId)
        {
            ProcedureName = "PR_Get_HistoryFB";
            AddParameter("DateFrom", DateFrom);
            AddParameter("DateTo", DateTo);
            AddParameter("RequestType", RequestType);
            AddParameter("RequestStatus", RequestStatus);
            AddParameter("UId", UId);
            return ExecuteProcedure;
        }

        public DataSet GetEClaimHistory(string DateFrom, string DateTo, string RequestType, string RequestStatus, string UId)
        {
            ProcedureName = "PR_Get_HistoryEOW";
            AddParameter("DateFrom", DateFrom);
            AddParameter("DateTo", DateTo);
            AddParameter("RequestType", RequestType);
            AddParameter("RequestStatus", RequestStatus);
            AddParameter("UId", UId);
            return ExecuteProcedure;
        }

        //ASMS
        public DataSet GetASMSSupplierHeaderDetails(string Suppliergid, string Action)
        {
            ProcedureName = "PR_Get_ApproverSummaryASMS";
            AddParameter("Suppliergid", Suppliergid);
            AddParameter("Action", Action);
            return ExecuteProcedure;
        }

        //FB
        public DataSet GetFBDetails(string Refgid, string Action)
        {
            ProcedureName = "PR_Get_ApproverSummaryFB";
            AddParameter("Refgid", Refgid);
            AddParameter("Action", Action);
            return ExecuteProcedure;
        }

        //EClaims
        public DataSet GetEClaimsDetails(string ECFId, string DocSubtype)
        {
            ProcedureName = "PR_Get_ApproverSummaryEOW";
            AddParameter("ECFId", ECFId);
            AddParameter("DocSubtype", DocSubtype);
            return ExecuteProcedure;
        }

        //Eprocure Approve/Reject
        public DataSet SubmitEprocure(string RefGId, string Action, string Submit, string Remarks, string UId)
        {
            ProcedureName = "PR_Set_ApproverSummaryFB";

            AddParameter("RefGId", RefGId);
            AddParameter("Action", Action);
            AddParameter("Submit", Submit);
            AddParameter("Remarks", Remarks);
            AddParameter("UId", UId);
            return ExecuteProcedure;
        }

        //EClaim Approve/Reject
        public DataSet SubmitEClaim(string EcfId, string DocType, string Submit, string Remarks, string ConcurrentTo, string UId)
        {
            ProcedureName = "PR_Set_ApproverSummaryEOW";

            AddParameter("EcfId", EcfId);
            AddParameter("DocType", DocType);
            AddParameter("ConcurrentTo", ConcurrentTo);
            AddParameter("Submit", Submit);
            AddParameter("Remarks", Remarks);
            AddParameter("UId", UId);
            return ExecuteProcedure;
        }

        public DataSet GetMaxQueueGidEClaim(string EcfId, string EmployeeGid)
        {
            ProcedureName = "pr_eow_mst_NatureofExpenses";

            AddParameter("para1", EmployeeGid);
            AddParameter("para2", EcfId);
            AddParameter("action", "GetMaxqueuegid");
            return ExecuteProcedure;
        }

        public DataSet GetDocTypeGIDEClaim(string queue_gid)
        {
            ProcedureName = "pr_eow_mst_NatureofExpenses";
            AddParameter("para1", queue_gid);
            AddParameter("action", "Getdocsubtype");
            return ExecuteProcedure;
        }

        //ASMS Approve/Reject
        public DataSet SubmitASMS(string refgid, string empgid, string requesttype, string actionremark, string queueto, string actionstatus, string skipflag, string action)
        {
            ProcedureName = "pr_asms_SubmitApproval";

            AddParameter("refgid", refgid);
            AddParameter("empgid", empgid);
            AddParameter("requesttype", requesttype);
            AddParameter("actionremark", actionremark);
            AddParameter("queueto", queueto);
            AddParameter("actionstatus", actionstatus);
            AddParameter("skipflag", skipflag);
            AddParameter("action", action);

            return ExecuteProcedure;
        }

        //Attachment SP

        public DataSet SetAttachmentNew(string RefFlag, string RefType, string RefGId, string AttachmentName, string Description, string UId)
        {
            ProcedureName = "PR_Set_AttachmentNew";
            AddParameter("RefFlag", RefFlag);
            AddParameter("RefType", RefType);
            AddParameter("RefGId", RefGId);
            AddParameter("AttachmentName", AttachmentName);
            AddParameter("Description", Description);
            AddParameter("UId", UId);
            return ExecuteProcedure;
        }

        public DataSet SubmitCBF(string CBFHeaderGId, string Type, string IsReject, string Remarks, string UId)
        {
            ProcedureName = "PR_FB_Set_CBF";

            AddParameter("CBFHeaderGId", CBFHeaderGId);
            AddParameter("Type", Type);
            AddParameter("IsReject", IsReject);
            AddParameter("Remarks", Remarks);
            AddParameter("UId", UId);
            return ExecuteProcedure;
        }

        public DataSet SubmitPO(string POHeaderGId, string POEndDate, string ProjectOwnerGId, string VendorGId, string Type, string VendorNote, string TemplateGId, string AddedTermAndCondtion, string IsRemoved, string ViewType, string IsReject, string Remarks, string UId, string VendorcontactId)
        {
            ProcedureName = "PR_FB_Set_PO";

            AddParameter("POHeaderGId", POHeaderGId);
            AddParameter("POEndDate", POEndDate);
            AddParameter("ProjectOwnerGId", ProjectOwnerGId);
            AddParameter("VendorGId", VendorGId);
            AddParameter("Type", Type);
            AddParameter("VendorNote", VendorNote);
            AddParameter("TemplateGId", TemplateGId);
            AddParameter("AddedTermAndCondtion", AddedTermAndCondtion);
            AddParameter("IsRemoved", IsRemoved);
            AddParameter("ViewType", ViewType);
            AddParameter("IsReject", IsReject);
            AddParameter("Remarks", Remarks);
            AddParameter("UId", UId);
            AddParameter("VendorcontactId", VendorcontactId);
            return ExecuteProcedure;
        }

        public DataSet GetASMSMailDetails(string RefId)
        {
            ProcedureName = "pr_asms_GetCSC";
            AddParameter("supplierheadergid", RefId);
            AddParameter("action", "getemaildetails");
            return ExecuteProcedure;
        }
        #endregion

        //load ECF invoice details
        public DataSet LoadInvoiceHeaderDetails(string EcfId, string InvId)
        {
            ProcedureName = "PR_EOW_Set_LoadInvoiceDetails";
            AddParameter("EcfId", EcfId);
            AddParameter("InvId", InvId);
            return ExecuteProcedure;
        }
    }
}
