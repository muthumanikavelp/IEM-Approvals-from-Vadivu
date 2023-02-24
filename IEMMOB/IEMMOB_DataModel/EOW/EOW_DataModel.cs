
using IEMMOB_DataModel.Common;
using IEMMOB_Model.EOW;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static IEMMOB_Model.EOW.EOW_Employee;
//using static IEMMOB_Model.EOW.EOW_Employee;


namespace IEMMOB_DataModel.EOW
{
    public class EOW_DataModel
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        CmnFunctions objCmnFunctions = new CmnFunctions();

        public void GetConnection(string ConString)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = ConString;
                con.Open();
            }
        }
        //
        public string selectsupplierinvoice(string queuegid, string type, string ConString)
        {
            string Emp_Msg = "";
            try
            {
                DataTable dt = new DataTable();
                string str = "";
                if (type == "D" || type == "L")
                {
                    str = "TYPEDL";
                }
                else
                {
                    str = "OTHERS";
                }

                GetConnection(ConString);

                // cmd = new SqlCommand("pr_eow_com_ecfdetails", con);
                cmd = new SqlCommand("MOB_pr_eow_com_ecfdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ecf_gid", SqlDbType.VarChar).Value = queuegid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = str;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Emp_Msg = Convert.ToString(dt.Rows[0]["ecf_docsubtype_gid"].ToString());
                }
                return Emp_Msg;
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        //
        public string selectsupplierinvoicestatus(string queuegid, string type, string ConString)
        {
            string Emp_Msg = "";
            try
            {
                DataTable dt = new DataTable();
                string str = "";
                if (type == "D" || type == "L")
                {
                    str = "TYPEDL";
                }
                else
                {
                    str = "OTHERS";
                }

                GetConnection(ConString);
                // cmd = new SqlCommand("pr_eow_com_ecfdetails", con);
                cmd = new SqlCommand("MOB_pr_eow_com_ecfdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ecf_gid", SqlDbType.VarChar).Value = queuegid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = str;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Emp_Msg = Convert.ToString(dt.Rows[0]["ecf_raiser"].ToString());
                }
                return Emp_Msg;
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }



        //
        public string selectsupplierinvoicestatuscen(string queuegid, string type, string ConString)
        {
            string Emp_Msg = "";
            try
            {
                DataTable dt = new DataTable();
                string str = "";
                if (type == "D" || type == "L")
                {
                    str = "TYPEDL";
                }
                else
                {
                    str = "OTHERS";
                }
                GetConnection(ConString);
                cmd = new SqlCommand("MOB_pr_eow_com_ecfdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ecf_gid", SqlDbType.VarChar).Value = queuegid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = str;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Emp_Msg = Convert.ToString(dt.Rows[0]["ecf_create_mode"].ToString());
                }
                return Emp_Msg;
            }
            catch (Exception ex)
            {

                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        //

        public string selectcemtam(string queuegid, string type, string ConString)
        {
            string Emp_Msg = "";
            try
            {
                DataTable dt = new DataTable();
                GetConnection(ConString);
                cmd = new SqlCommand("MOB_pr_eow_com_ecfdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ecf_gid", SqlDbType.VarChar).Value = queuegid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "OTHERS";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Emp_Msg = Convert.ToString(dt.Rows[0]["queue_from"].ToString());
                }
                return Emp_Msg;
            }
            catch (Exception ex)
            {

                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        //
        public IEnumerable<EOW_Supplierinvoice> SelectViewdatasupplier(string ecfid, string action, string ConString)
        {
            List<EOW_Supplierinvoice> objAttachment = new List<EOW_Supplierinvoice>();
            try
            {
                EOW_Supplierinvoice objModel;
                DataTable dt = new DataTable();
                string straction = "";
                if (action.ToString() == "D")
                {
                    straction = "data";
                }
                else if (action.ToString() == "check")
                {
                    straction = "check";
                }
                else if (action.ToString() == "checkview")
                {
                    straction = "checkview";
                }
                else if (action.ToString() == "ctdata")
                {
                    straction = "ctdata";
                }
                else
                {
                    straction = "others";
                }
                GetConnection(ConString);
                // cmd = new SqlCommand("pr_eow_com_SelectViewsupplierecf", con);[MOB_pr_eow_com_SelectViewsupplierecf]
                cmd = new SqlCommand("MOB_pr_eow_com_SelectViewsupplierecf", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ecf_gid", SqlDbType.VarChar).Value = ecfid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = straction;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objModel = new EOW_Supplierinvoice();
                        objModel.queueactionfor = Convert.ToString(dt.Rows[i]["queue_action_for"].ToString());
                        objModel.Doctypeid = Convert.ToInt32(dt.Rows[i]["ecf_docsubtype_gid"].ToString());
                        objModel.Queue_GID = Convert.ToInt32(dt.Rows[i]["queue_gid"].ToString());
                        objModel.ecf_GID = Convert.ToInt32(dt.Rows[i]["ecf_gid"].ToString());
                        objModel.raisermodeId = Convert.ToString(dt.Rows[i]["ecf_create_mode"].ToString());
                        objModel.raisermodeName = Convert.ToString(dt.Rows[i]["ecf_raiser"].ToString());
                        objModel.Raiser_Code = Convert.ToString(dt.Rows[i]["employee_code"].ToString());
                        objModel.Raiser_Name = Convert.ToString(dt.Rows[i]["employee_name"].ToString());
                        objModel.ecfdescription = Convert.ToString(dt.Rows[i]["ecf_description"].ToString());
                        objModel.Grade = Convert.ToString(dt.Rows[i]["employee_grade_code"].ToString());
                        objModel.ECF_Date = Convert.ToString(dt.Rows[i]["ecf_date"].ToString());
                        objModel.ECF_Amount = Convert.ToString(dt.Rows[i]["ecf_amount"].ToString());
                        objModel.chkraiser_gid = Convert.ToInt32(dt.Rows[i]["ecf_raiser"].ToString());
                        objModel.ecfno = Convert.ToString(dt.Rows[i]["ecf_no"].ToString());
                        objModel.ecfstatus = Convert.ToString(dt.Rows[i]["ecf_status"].ToString());
                        objModel.ecf_Paymode = dt.Rows[i]["ecf_pay_mode"].ToString();
                        objModel.CygnetFlag = dt.Rows[i]["CygnetFlag"].ToString();
                        string doctype = Convert.ToString(dt.Rows[i]["ecf_po_type"].ToString());
                        string doctypegid = Convert.ToString(dt.Rows[i]["ecf_docsubtype_gid"].ToString());
                        if (doctype == "P")
                        {
                            objModel.DocName = "PO";
                        }
                        else if (doctype == "W")
                        {
                            objModel.DocName = "WO";
                        }
                        else if (doctype == "N")
                        {
                            objModel.DocName = "Non PO/WO";
                        }
                        else if (doctype == "U")
                        {
                            objModel.DocName = "Utility";
                        }
                        else if (doctypegid == "11")
                        {
                            objModel.DocName = "Insurance";
                        }
                        else
                        {
                            objModel.DocName = "-- Select --";
                        }
                        objModel.Suppliergid = Convert.ToString(dt.Rows[i]["supplierheader_gid"].ToString());
                        objModel.Suppliercode = Convert.ToString(dt.Rows[i]["supplierheader_suppliercode"].ToString());
                        objModel.Suppliername = Convert.ToString(dt.Rows[i]["supplierheader_name"].ToString());
                        objModel.CurrencyId = Convert.ToString(dt.Rows[i]["ecf_currency_gid"].ToString());
                        objModel.CurrencyName = Convert.ToString(dt.Rows[i]["ecf_currency_code"].ToString());
                        objModel.Exrate = Convert.ToString(dt.Rows[i]["ecf_currency_rate"].ToString());
                        objModel.Currencyamount = Convert.ToString(dt.Rows[i]["ecf_currency_amount"].ToString());

                        string amort = Convert.ToString(dt.Rows[i]["ecf_amort_flag"].ToString());
                        if (amort == "N")
                        {
                            objModel.amort = "No";
                        }
                        else
                        {
                            objModel.amort = "Yes";
                        }
                        objModel.from = Convert.ToString(dt.Rows[i]["ecf_amort_from"].ToString());
                        objModel.to = Convert.ToString(dt.Rows[i]["ecf_amort_to"].ToString());
                        objModel.amortdec = Convert.ToString(dt.Rows[i]["ecf_amort_desc"].ToString());

                        objModel.ecfremark = Convert.ToString(dt.Rows[i]["ecf_remark"].ToString());

                        objAttachment.Add(objModel);
                    }
                }
                return objAttachment;
            }
            catch (Exception ex)
            {

                return objAttachment;
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        //
        public IEnumerable<EOW_Employee.EOW_Raisermode> GetRaiserMode()
        {
            List<EOW_Employee.EOW_Raisermode> objparenttax = new List<EOW_Employee.EOW_Raisermode>();
            try
            {
                objparenttax.Add(new EOW_Employee.EOW_Raisermode { raisermodeId = "0", raisermodeName = "-- Select --", });
                objparenttax.Add(new EOW_Employee.EOW_Raisermode { raisermodeId = "S", raisermodeName = "Self", });
                objparenttax.Add(new EOW_Employee.EOW_Raisermode { raisermodeId = "P", raisermodeName = "Proxy", });
                objparenttax.Add(new EOW_Employee.EOW_Raisermode { raisermodeId = "C", raisermodeName = "Central Team", });
                objparenttax.Add(new EOW_Employee.EOW_Raisermode { raisermodeId = "R", raisermodeName = "Central Team", });
                objparenttax.Add(new EOW_Employee.EOW_Raisermode { raisermodeId = "M", raisermodeName = "Manual", });
                return objparenttax;
            }
            catch (Exception ex)
            {
                //  objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return objparenttax;
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        //

        public IEnumerable<EOW_Employee.EOW_EmployeeeExpense> SelectViewdata(string ecfid, string type, string ConString)
        {
            List<EOW_Employee.EOW_EmployeeeExpense> objAttachment = new List<EOW_Employee.EOW_EmployeeeExpense>();
            try
            {
                EOW_Employee.EOW_EmployeeeExpense objModel;
                DataTable dt = new DataTable();
                string straction = "";
                if (type == "D")
                {
                    straction = "data";
                }
                else if (type == "L")
                {
                    straction = "check";
                }
                else if (type == "AL")
                {
                    straction = "checkview";
                }
                else
                {
                    straction = "others";
                }

                GetConnection(ConString);
                //  cmd = new SqlCommand("pr_eow_com_SelectViewsupplierinvoice", con);

                cmd = new SqlCommand("MOB_EOW_pr_eow_com_SelectViewsupplierinvoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ecf_gid", SqlDbType.VarChar).Value = ecfid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = straction;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objModel = new EOW_Employee.EOW_EmployeeeExpense();
                        objModel.queueactionfor = Convert.ToString(dt.Rows[i]["queue_action_for"].ToString());
                        objModel.Doctypeid = Convert.ToInt32(dt.Rows[i]["ecf_docsubtype_gid"].ToString());
                        objModel.Queue_GID = Convert.ToInt32(dt.Rows[i]["queue_gid"].ToString());
                        objModel.ecf_GID = Convert.ToInt32(dt.Rows[i]["ecf_gid"].ToString());
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["invoice_gid"])))
                        {
                            objModel.invoice_GID = Convert.ToInt32(dt.Rows[i]["invoice_gid"].ToString());
                        }
                        objModel.raisermodeId = Convert.ToString(dt.Rows[i]["ecf_create_mode"].ToString());
                        objModel.Raiser_Code = Convert.ToString(dt.Rows[i]["employee_code"].ToString());
                        objModel.ClaimMonth = Convert.ToString(dt.Rows[i]["ecf_claim_month"].ToString());
                        objModel.Raiser_Name = Convert.ToString(dt.Rows[i]["employee_name"].ToString());
                        objModel.Grade = Convert.ToString(dt.Rows[i]["employee_grade_code"].ToString());
                        objModel.ECF_Date = Convert.ToString(dt.Rows[i]["ecf_date"].ToString());

                        objModel.ecfno = Convert.ToString(dt.Rows[i]["ecf_no"].ToString());
                        string noperson = Convert.ToString(dt.Rows[i]["ecf_travelpersoncount"].ToString());
                        string doctyped = Convert.ToString(dt.Rows[i]["ecf_docsubtype_gid"].ToString());
                        if (doctyped == "2")
                        {
                            objModel.ECF_Amount = Convert.ToString(dt.Rows[i]["ecf_amount"].ToString());
                            objModel.ecfdelmatamt = Convert.ToString(dt.Rows[i]["ecf_delmat_amount"].ToString());
                        }
                        else
                        {
                            objModel.ecfdelmatamt = Convert.ToString(dt.Rows[i]["ecf_amount"].ToString());
                            objModel.ECF_Amount = Convert.ToString(dt.Rows[i]["ecf_delmat_amount"].ToString());
                        }
                        if (noperson != "")
                        {
                            objModel.noofperson = noperson;
                        }
                        else
                        {
                            objModel.noofperson = "0";
                        }
                        if (doctyped == "6" || doctyped == "7" || doctyped == "12")
                        {
                            string arftye = Convert.ToString(dt.Rows[i]["ecf_supplier_employee"].ToString());
                            if (arftye == "E")
                            {
                                objModel.arftype = "Employee";
                                objModel.arfempsupcode = Convert.ToString(dt.Rows[i]["employee_code"].ToString());
                                objModel.arfempsupname = Convert.ToString(dt.Rows[i]["employee_name"].ToString());
                            }
                            if (arftye == "S" || arftye == "I")
                            {
                                objModel.arftype = "Supplier";
                                objModel.arfempsupcode = Convert.ToString(dt.Rows[i]["supplierheader_suppliercode"].ToString());
                                objModel.arfempsupname = Convert.ToString(dt.Rows[i]["supplierheader_name"].ToString());
                            }
                            if (arftye == "P")
                            {
                                objModel.arftype = "Petty Cash";
                                objModel.arfempsupcode = Convert.ToString(dt.Rows[i]["employee_code"].ToString());
                                objModel.arfempsupname = Convert.ToString(dt.Rows[i]["employee_name"].ToString());
                            }
                        }
                        objModel.ecfdescription = Convert.ToString(dt.Rows[i]["ecf_description"].ToString());
                        objModel.SubCategoryName = Convert.ToString(dt.Rows[i]["ecf_supplier_employee"].ToString());
                        objModel.ecfremark = Convert.ToString(dt.Rows[i]["ecf_remark"].ToString());
                        objModel.ecf_paymode = dt.Rows[i]["ecf_pay_mode"].ToString();
                        objModel.CygnetFlag = dt.Rows[i]["CygnetFlag"].ToString();
                        objAttachment.Add(objModel);
                    }
                }
                return objAttachment;
            }
            catch (Exception ex)
            {

                return objAttachment;
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }

        //Get Payment
        public List<EOW_Payment> GetEmployeeePayment(string ecfgid, string invoicegid, string ConString)
        {
            List<EOW_Payment> objExpense = new List<EOW_Payment>();
            try
            {
                EOW_Payment objModel;
                GetConnection(ConString);
                DataTable dt = new DataTable();
                cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = ecfgid;
                cmd.Parameters.Add("@para2", SqlDbType.VarChar).Value = invoicegid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetEmpPayment";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objModel = new EOW_Payment();
                        objModel.Paymentgid = Convert.ToInt32(dt.Rows[i]["ecfcreditline_gid"].ToString());
                        objModel.PaymentModeName = Convert.ToString(dt.Rows[i]["ecfcreditline_pay_mode"].ToString());
                        objModel.RefNoName = Convert.ToString(dt.Rows[i]["ecfcreditline_ref_no"].ToString());
                        objModel.Beneficiary = Convert.ToString(dt.Rows[i]["ecfcreditline_beneficiary"].ToString());
                        objModel.Description = Convert.ToString(dt.Rows[i]["ecfcreditline_desc"].ToString());
                        objModel.Beneficiarycardno = Convert.ToString(dt.Rows[i]["ecfcreditline_defaultacc"].ToString());
                        objModel.PaymentAmount = Convert.ToString(dt.Rows[i]["ecfcreditline_amount"].ToString());
                        objModel.SplitPaymentAmt = dt.Rows[i]["Split_PaymentAmt"].ToString();
                        objExpense.Add(objModel);
                    }
                }
                return objExpense;
            }
            catch (Exception ex)
            {
                return objExpense;
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }
        //Get RCm

        public List<EOW_RCMEntries> GetRCMdetls(string invoiceid, string ConString)
        {
            List<EOW_RCMEntries> Objdetails = new List<EOW_RCMEntries>();
            try
            {
                DataTable dt = new DataTable();
                EOW_RCMEntries objModel;
                GetConnection(ConString);
                cmd = new SqlCommand("PR_EOW_GetRCMInvoiceDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvId", SqlDbType.VarChar).Value = invoiceid;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objModel = new EOW_RCMEntries();
                        objModel.Expsubcat_Name = dt.Rows[i]["Expsubcat_Name"].ToString();
                        objModel.HsnCode = (dt.Rows[i]["HsnCode"].ToString());
                        objModel.DebitRCM_Type = dt.Rows[i]["DebitRCM_Type"].ToString();
                        objModel.Taxable_Amount = dt.Rows[i]["Taxable_Amount"].ToString();
                        objModel.debitrcm_rate = Convert.ToDecimal(dt.Rows[i]["debitrcm_rate"]);
                        objModel.debitrcm_amount = Convert.ToDecimal(dt.Rows[i]["debitrcm_amount"]);
                        objModel.debitrcm_inputcreditgl = dt.Rows[i]["debitrcm_inputcreditgl"].ToString();
                        objModel.debitrcm_reversechargegl = dt.Rows[i]["debitrcm_reversechargegl"].ToString();
                        objModel.debitInputcreditRate = String.IsNullOrEmpty(dt.Rows[i]["debitrcm_inputcredit_rate"].ToString()) ? 0 : Convert.ToDecimal(dt.Rows[i]["debitrcm_inputcredit_rate"].ToString());
                        objModel.debitInputcreditAmt = String.IsNullOrEmpty(dt.Rows[i]["debitrcm_inputcredit_Amount"].ToString()) ? 0 : Convert.ToDecimal(dt.Rows[i]["debitrcm_inputcredit_Amount"].ToString());
                        objModel.Taxgst_InputCredit_Display_Rate = String.IsNullOrEmpty(dt.Rows[i]["Taxgst_InputCredit_Display_Rate"].ToString()) ? 0 : Convert.ToDecimal(dt.Rows[i]["Taxgst_InputCredit_Display_Rate"].ToString());
                        objModel.Taxgst_RCM_Display_Rate = String.IsNullOrEmpty(dt.Rows[i]["Taxgst_RCM_Display_Rate"].ToString()) ? 0 : Convert.ToDecimal(dt.Rows[i]["Taxgst_RCM_Display_Rate"].ToString());
                        Objdetails.Add(objModel);
                    }
                }
                return Objdetails;

            }
            catch (Exception ex)
            {
                //objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return Objdetails;
            }
        }


        //Get GST
        public List<EOW_TravelClaim> Getgstdetls(string ecfid, string invoiceid, string traveltype, string ConString)
        {
            List<EOW_TravelClaim> Objdetails = new List<EOW_TravelClaim>();
            try
            {
                DataTable dt = new DataTable();
                EOW_TravelClaim objModel;
                GetConnection(ConString);
                cmd = new SqlCommand("PR_EOW_GetGstInvoiceDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvId", SqlDbType.VarChar).Value = invoiceid;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objModel = new EOW_TravelClaim();
                        objModel.InvoiceTaxGid = Convert.ToInt32(dt.Rows[i]["invoicetaxgid"].ToString());
                        objModel.Hsncode = (dt.Rows[i]["HsnCode"].ToString());
                        objModel.HsnId = Convert.ToInt32(dt.Rows[i]["Hsngid"].ToString());
                        objModel.TaxAmt = Convert.ToDecimal(dt.Rows[i]["TaxAmt"].ToString());
                        objModel.GstRate = Convert.ToDecimal(dt.Rows[i]["Rate"].ToString());
                        objModel.TaxableAmt = Convert.ToDecimal(dt.Rows[i]["TaxableAmt"].ToString());
                        objModel.HsnDesc = dt.Rows[i]["HsnDescription"].ToString();
                        objModel.Subtax = dt.Rows[i]["TaxSubType"].ToString();
                        objModel.GstApplicable = dt.Rows[i]["GsnApplicable"].ToString();
                        Objdetails.Add(objModel);
                    }
                }
                return Objdetails;

            }
            catch (Exception ex)
            {
                // objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return Objdetails;
            }
        }

        //
        public string GetDecnote(string subsype, string type, string ConString)
        {
            string Emp_Msg = "";
            try
            {
                GetConnection(ConString);
                DataTable dt = new DataTable();
                cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = subsype;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Declnote";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (type == "S")
                    {
                        Emp_Msg = Convert.ToString(dt.Rows[0]["declnote_onsubmission"].ToString());
                    }
                    else
                    {
                        Emp_Msg = Convert.ToString(dt.Rows[0]["declnote_approval"].ToString());
                    }

                }
                return Emp_Msg;
            }
            catch (Exception ex)
            {
                //objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }
        //get attachment
        public List<EOW_File> GetEmployeeeAttachment(string ecfgid, string ConString)
        {
            List<EOW_File> objAttachment = new List<EOW_File>();
            try
            {

                EOW_File objModel;
                // GetConnection(ConString);
                DataTable dt = new DataTable();
                cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = ecfgid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "AttachmentDetails";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objModel = new EOW_File();
                        objModel.AttachmentFilenameId = Convert.ToInt32(dt.Rows[i]["attachment_gid"].ToString());
                        objModel.AttachmentFilename = Convert.ToString(dt.Rows[i]["attachment_filename"].ToString());
                        objModel.AttachmentTypeName = Convert.ToString(dt.Rows[i]["attachmenttype_name"].ToString());
                        objModel.AttachmentDate = Convert.ToString(dt.Rows[i]["attachment_date"].ToString());
                        objModel.AttachmentDescription = Convert.ToString(dt.Rows[i]["attachment_desc"].ToString());
                        objModel.AttachmentBy = Convert.ToString(dt.Rows[i]["codename"].ToString());
                        objModel.attachment_by = Convert.ToInt32(dt.Rows[i]["attachment_by"].ToString());
                        objAttachment.Add(objModel);
                    }
                }
                return objAttachment;
            }
            catch (Exception ex)
            {
                // objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return objAttachment;
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }

        //Get invoice Details
        public List<GetInvoicedetails> LoadInvoiceHeaderDetails(string EcfId, string InvId, string ConString)
        {
            List<GetInvoicedetails> invoicedtllst = new List<GetInvoicedetails>();
            GetInvoicedetails invoicedtls = new GetInvoicedetails();
            GetConnection(ConString);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("PR_EOW_Set_LoadInvoiceDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EcfId", SqlDbType.VarChar).Value = EcfId;
            cmd.Parameters.Add("@InvId", SqlDbType.VarChar).Value = InvId;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    invoicedtls.InvoiceGid = (dt.Rows[i]["InvId"].ToString());
                    invoicedtls.InvoiceNo = (dt.Rows[i]["InvNo"].ToString());
                    invoicedtls.InvoiceDate = dt.Rows[i]["InvDate"].ToString();
                    invoicedtls.InvoiceAmount = dt.Rows[i]["InvAmt"].ToString();
                    invoicedtls.ProviderLocation = dt.Rows[i]["ProviderLocation"].ToString();
                    invoicedtls.Receiverlocation = dt.Rows[i]["ReceiverLocation"].ToString();
                    invoicedtls.Gstinvendor = dt.Rows[i]["GstinVendor"].ToString();
                    invoicedtls.Gstinficcl = dt.Rows[i]["GstinFiccl"].ToString();
                    invoicedtls.WotaxAmount = dt.Rows[i]["WOTaxAmount"].ToString();
                    invoicedtls.PaymentNeting = dt.Rows[i]["PaymentNetting"].ToString();

                    invoicedtls.Isverified = dt.Rows[i]["isverified"].ToString();
                    invoicedtls.Isupdated = dt.Rows[i]["isupdated"].ToString();
                    invoicedtls.InvoiceDescription = dt.Rows[i]["InvDesc"].ToString();
                    invoicedtls.ServiceMonth = dt.Rows[i]["servicemonth"].ToString();
                    invoicedtls.SupplierGid = dt.Rows[i]["InvoiceSuppliergid"].ToString();


                    invoicedtls.Suppliercode = dt.Rows[i]["SupplierCode"].ToString();
                    invoicedtls.SupplierName = dt.Rows[i]["SupplierName"].ToString();
                    invoicedtls.GstCharged = dt.Rows[i]["GstCharged"].ToString();


                }
                invoicedtllst.Add(invoicedtls);
            }
            return invoicedtllst;
        }



        //Get  Travel Details
        public List<EOW_TravelClaim> GetTravelModedata(string ecfid, string invoiceid, string traveltype, string ConString)
        {
            List<EOW_TravelClaim> objExpense = new List<EOW_TravelClaim>();
            try
            {

                EOW_TravelClaim objModel;
                DataTable dt = new DataTable();
                GetConnection(ConString);
                cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = ecfid;
                cmd.Parameters.Add("@para2", SqlDbType.VarChar).Value = invoiceid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetTravelDetail";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objModel = new EOW_TravelClaim();
                    objModel.TravelMode_GID = Convert.ToInt32(dt.Rows[i]["ecftravel_gid"].ToString());
                    objModel.NatureofExpensesName = Convert.ToString(dt.Rows[i]["expnature_name"].ToString());
                    objModel.ExpenseCategoryName = Convert.ToString(dt.Rows[i]["expcat_name"].ToString());
                    objModel.SubCategoryName = Convert.ToString(dt.Rows[i]["expsubcat_name"].ToString());
                    objModel.PlaceFrom = Convert.ToString(dt.Rows[i]["ecftravel_city_from"].ToString());
                    objModel.ClaimPeriodFrom = Convert.ToString(dt.Rows[i]["ecfdebitline_period_from"].ToString());
                    objModel.ClaimPeriodTo = Convert.ToString(dt.Rows[i]["ecfdebitline_period_to"].ToString());
                    objModel.ClaimMonth = Convert.ToString(dt.Rows[i]["ecftravel_gl_no"].ToString());
                    objModel.FC = Convert.ToString(dt.Rows[i]["ecftravel_fc"].ToString());
                    objModel.CC = Convert.ToString(dt.Rows[i]["ecftravel_cc"].ToString());
                    objModel.ProductCode = Convert.ToString(dt.Rows[i]["ecftravel_product_code"].ToString());
                    objModel.OUCode = Convert.ToString(dt.Rows[i]["ecftravel_ou_code"].ToString());
                    objModel.Amount = Convert.ToString(dt.Rows[i]["ecftravel_amount"].ToString());
                    objModel.PlaceTo = Convert.ToString(dt.Rows[i]["ecftravel_city_to"].ToString());

                    objModel.Distance = Convert.ToString(dt.Rows[i]["ecftravel_distance"].ToString());
                    objModel.Rate = Convert.ToString(dt.Rows[i]["ecftravel_rate"].ToString());
                    objModel.TravelModeName = Convert.ToString(dt.Rows[i]["transport_name"].ToString());
                    objModel.TravelClassName = Convert.ToString(dt.Rows[i]["transportclass_name"].ToString());
                    objModel.TravelHsnid = Convert.ToInt32(dt.Rows[i]["HsnId"].ToString());
                    objModel.TravelHsnCode = dt.Rows[i]["HsnCode"].ToString();
                    objModel.TravelHsnDesc = dt.Rows[i]["HsnDesc"].ToString();

                    objExpense.Add(objModel);
                }
                return objExpense;
            }
            catch (Exception ex)
            {
                // objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return objExpense;
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        public IEnumerable<EOW_Employee.DashBoard> GetMydocDraft(string userlognid, string type)
        {
            List<EOW_Employee.DashBoard> objDashBoard = new List<EOW_Employee.DashBoard>();
            try
            {
                string raisermode = "";
                //if (HttpContext.Current.Session["Proxyemployee_gid"] != null)
                //{
                //    raisermode = "Proxy";
                //}
                //else
                //{
                //    raisermode = "Self";
                //}

                EOW_Employee.DashBoard objModel;
                DataTable dtdraft = new DataTable();
                string status = "";
                //  GetConnection();
                cmd = new SqlCommand("pr_eow_com_getmydocfulldetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ecf_raiser", SqlDbType.VarChar).Value = userlognid;
                cmd.Parameters.Add("@doctype_gid", SqlDbType.VarChar).Value = type;
                cmd.Parameters.Add("@proxytype", SqlDbType.VarChar).Value = raisermode;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetMydocDraft";
                da = new SqlDataAdapter(cmd);
                da.Fill(dtdraft);
                for (int i = 0; i < dtdraft.Rows.Count; i++)
                {
                    objModel = new EOW_Employee.DashBoard();
                    objModel.Docnogid = Convert.ToInt32(dtdraft.Rows[i]["ecf_gid"].ToString());
                    objModel.Doctypeid = Convert.ToInt32(dtdraft.Rows[i]["ecf_gid"].ToString());
                    objModel.Docno = Convert.ToString(dtdraft.Rows[i]["ecf_no"].ToString());
                    objModel.DocDate = Convert.ToString(dtdraft.Rows[i]["ecf_date"].ToString());
                    objModel.Docamount = Convert.ToString(dtdraft.Rows[i]["ecf_amount"].ToString());
                    objModel.raiserName = Convert.ToString(dtdraft.Rows[i]["rempname"].ToString());
                    objModel.ecfdescription = Convert.ToString(dtdraft.Rows[i]["ecf_description"].ToString());

                    objModel.DocTypeName = Convert.ToString(dtdraft.Rows[i]["ecf_supplier_employee"].ToString());
                    string emporsupp = Convert.ToString(dtdraft.Rows[i]["ecf_supplier_employee"].ToString());
                    if (emporsupp == "E")
                    {
                        objModel.emporsupp = Convert.ToString(dtdraft.Rows[i]["employeename"].ToString());
                    }
                    else
                    {
                        if (dtdraft.Rows[i]["employeename"].ToString() != "")
                        {
                            objModel.emporsupp = Convert.ToString(dtdraft.Rows[i]["employeename"].ToString());
                        }
                        else
                        {
                            objModel.emporsupp = Convert.ToString(dtdraft.Rows[i]["suppliername"].ToString());
                        }
                    }
                    status = Convert.ToString(dtdraft.Rows[i]["ecf_status"].ToString());
                    objModel.StatusTypeName = "Draft";
                    objModel.ecfselect = "active";
                    objModel.ecfview = "notactive";
                    objModel.ecfprint = "notactive";
                    objModel.ecfprintid = type;
                    objDashBoard.Add(objModel);
                }

                return objDashBoard;
            }
            catch (Exception ex)
            {
                // objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return objDashBoard;
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        //EOW Approver History
        public List<ApproverHistry> GetecfappHistory(string ecfgid, string invoicegid, string ConString)
        {
            List<ApproverHistry> objDashBoard = new List<ApproverHistry>();
            try
            {
                int rowvalues = 0;

                string ecfmainraiser = "";
                ApproverHistry objModel;
                GetConnection(ConString);
                DataTable dt = new DataTable();
                DataTable dtr = new DataTable();
                string streject = "";
                string strejectraiserid = "";
                string strejectnew = "";
                string status = "";
                GetConnection(ConString);
                cmd = new SqlCommand("pr_eow_com_audittrail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ecf_gid", SqlDbType.VarChar).Value = ecfgid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Normal";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string createmode = Convert.ToString(dt.Rows[0]["ecf_create_mode"].ToString());
                    if (createmode == "C" || createmode == "R")
                    {
                        DataTable dtcen = new DataTable();
                        GetConnection(ConString);
                        cmd = new SqlCommand("pr_eow_com_audittrail", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ecf_gid", SqlDbType.VarChar).Value = ecfgid;
                        cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Normalcombinecen";
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dtcen);
                        if (dtcen.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtcen.Rows.Count; i++)
                            {
                                if (i.ToString() == "0")
                                {
                                    string strinsert = Convert.ToString(dtcen.Rows[i]["ecf_insert_by"].ToString());
                                    string empcodnamer = Getempname(strinsert, ConString);
                                    string[] datarinr;
                                    datarinr = empcodnamer.Split(',');
                                    if (datarinr.Length > 1)
                                    {
                                        objModel = new ApproverHistry();
                                         objModel.empcode = datarinr[0].ToString() + "-" + datarinr[1].ToString() + " [ Central Team Maker ]";
                                        objModel.empname = Gethrsdesi(datarinr[0].ToString(), ConString);

                                        objModel.statusdate = Convert.ToString(dtcen.Rows[i]["queue_date"].ToString());
                                        objModel.remarks = Convert.ToString(dtcen.Rows[i]["ecf_remark"].ToString());
                                        objModel.status = "Submitted";
                                        objModel.rowcount = rowvalues;
                                        objDashBoard.Add(objModel);
                                    }
                                    string actions = Convert.ToString(dtcen.Rows[i]["queue_action_status"].ToString());
                                    if (actions != "0")
                                    {
                                        string empidchk = Convert.ToString(dtcen.Rows[i]["queue_action_by"].ToString());
                                        string empcodnamerchk = Getempname(empidchk, ConString);
                                        string[] datarinrchk;
                                        datarinrchk = empcodnamerchk.Split(',');
                                        if (datarinrchk.Length > 1)
                                        {
                                            objModel = new ApproverHistry();
                                             objModel.empcode = datarinrchk[0].ToString() + "-" + datarinrchk[1].ToString() + " [ Central Team Checker ]";
                                            objModel.empname = Gethrsdesi(datarinrchk[0].ToString(), ConString);

                                            objModel.statusdate = Convert.ToString(dtcen.Rows[i]["queue_action_date"].ToString());
                                            objModel.remarks = Convert.ToString(dtcen.Rows[i]["queue_action_remark"].ToString());
                                            status = Convert.ToString(dtcen.Rows[i]["queue_action_status"].ToString());
                                            if (status == "10")
                                            {
                                                objModel.status = "CT - Reject";
                                            }
                                            else if (status == "20")
                                            {
                                                objModel.status = "Rejected";
                                            }
                                            else
                                            {
                                                objModel.status = "Approved";
                                            }
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);
                                        }
                                    }
                                }
                                else
                                {
                                    string actionsnew = Convert.ToString(dtcen.Rows[i]["queue_action_status"].ToString());
                                    if (actionsnew != "0")
                                    {
                                        string empid = Convert.ToString(dtcen.Rows[i]["queue_to"].ToString());
                                        if (empid == "17")
                                        {
                                            string empidchkr = Convert.ToString(dtcen.Rows[i]["queue_action_by"].ToString());
                                            string empcodnamerchkr = Getempname(empidchkr, ConString);
                                            string[] datarinrchkr;
                                            datarinrchkr = empcodnamerchkr.Split(',');
                                            if (datarinrchkr.Length > 1)
                                            {
                                                objModel = new ApproverHistry();
                                                objModel.empcode = datarinrchkr[0].ToString() + "-" + datarinrchkr[1].ToString() + " [ Central Team Maker ]";
                                                objModel.empname = Gethrsdesi(datarinrchkr[0].ToString(), ConString);

                                                objModel.statusdate = Convert.ToString(dtcen.Rows[i]["queue_action_date"].ToString());
                                                objModel.remarks = Convert.ToString(dtcen.Rows[i]["queue_action_remark"].ToString());
                                                objModel.status = "Submitted";
                                                rowvalues++;
                                                objModel.rowcount = rowvalues;
                                                objDashBoard.Add(objModel);
                                            }
                                        }
                                        else if (empid == "18")
                                        {
                                            string empidchkrs = Convert.ToString(dtcen.Rows[i]["queue_action_by"].ToString());
                                            string empcodnamerchkrs = Getempname(empidchkrs, ConString);
                                            string[] datarinrchkrs;
                                            datarinrchkrs = empcodnamerchkrs.Split(',');
                                            if (datarinrchkrs.Length > 1)
                                            {
                                                objModel = new ApproverHistry();
                                                objModel.empcode = datarinrchkrs[0].ToString() + "-" + datarinrchkrs[1].ToString() + " [ Central Team Checker ]";
                                                objModel.empname = Gethrsdesi(datarinrchkrs[0].ToString(), ConString);

                                                objModel.statusdate = Convert.ToString(dtcen.Rows[i]["queue_action_date"].ToString());
                                                objModel.remarks = Convert.ToString(dtcen.Rows[i]["queue_action_remark"].ToString());
                                                status = Convert.ToString(dtcen.Rows[i]["queue_action_status"].ToString());
                                                if (status == "10")
                                                {
                                                    objModel.status = "CT - Reject";
                                                }
                                                else if (status == "20")
                                                {
                                                    objModel.status = "Rejected";
                                                }
                                                else
                                                {
                                                    objModel.status = "Approved";
                                                }
                                                rowvalues++;
                                                objModel.rowcount = rowvalues;
                                                objDashBoard.Add(objModel);
                                            }
                                        }
                                        else
                                        {
                                            streject = Convert.ToString(dtcen.Rows[i]["employee_gid"].ToString());
                                            string empcodnamer = Getempname(streject, ConString);
                                            string[] datar;
                                            datar = empcodnamer.Split(',');
                                            objModel = new ApproverHistry();
                                             objModel.empcode = datar[0].ToString() + "-" + datar[1].ToString();
                                            objModel.empname = Gethrsdesi(datar[0].ToString(), ConString);

                                            objModel.statusdate = Convert.ToString(dtcen.Rows[i]["queue_action_date"].ToString());
                                            objModel.remarks = Convert.ToString(dtcen.Rows[i]["queue_action_remark"].ToString());
                                            status = Convert.ToString(dtcen.Rows[i]["queue_action_status"].ToString());
                                            string statuspergid = Convert.ToString(dtcen.Rows[i]["queue_prev_gid"].ToString());
                                            if (status == "10")
                                            {
                                                objModel.status = "CT - Reject";
                                            }
                                            else if (status == "20")
                                            {
                                                objModel.status = "Rejected";
                                            }
                                            else
                                            {
                                                if (statuspergid == "0")
                                                {
                                                    objModel.status = "Reviewed";
                                                }
                                                else
                                                {
                                                    objModel.status = objCmnFunctions.GetQueueStatusHistry(status);
                                                }
                                            }
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);
                                        }
                                    }
                                }

                            }
                        }
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string pergid = Convert.ToString(dt.Rows[i]["queue_prev_gid"].ToString());
                        streject = Convert.ToString(dt.Rows[i]["queue_from"].ToString());
                        string streject11 = Convert.ToString(dt.Rows[i]["queue_to"].ToString());
                        string create_mode = Convert.ToString(dt.Rows[i]["ecf_create_mode"].ToString());
                        if (pergid == "0" || streject == "17")
                        {
                            strejectraiserid = streject;
                            if (streject == "17" && create_mode == "C")
                            {
                                string strinsert = Convert.ToString(dt.Rows[i]["ecf_insert_by"].ToString());
                                string empcodnamer = Getempname(strinsert, ConString);
                                string[] datarinr;
                                datarinr = empcodnamer.Split(',');
                                if (datarinr.Length > 1)
                                {
                                    objModel = new ApproverHistry();
                                    objModel.empcode = datarinr[0].ToString() + "-" + datarinr[1].ToString() + " [ Central Team Maker ]"; ;
                                    objModel.empname = Gethrsdesi(datarinr[0].ToString(), ConString); ;
                                    objModel.statusdate = Convert.ToString(dt.Rows[i]["queue_date"].ToString());
                                    objModel.remarks = Convert.ToString(dt.Rows[i]["ecf_remark"].ToString());
                                    objModel.status = "Submitted";
                                    rowvalues++;
                                    objModel.rowcount = rowvalues;
                                    objDashBoard.Add(objModel);
                                }
                                string actions = Convert.ToString(dt.Rows[i]["queue_action_status"].ToString());
                                if (actions != "0")
                                {
                                    string empidchk = Convert.ToString(dt.Rows[i]["queue_action_by"].ToString());
                                    string empcodnamerchk = Getempname(empidchk, ConString);
                                    string[] datarinrchk;
                                    datarinrchk = empcodnamerchk.Split(',');
                                    if (datarinrchk.Length > 1)
                                    {
                                        objModel = new ApproverHistry();
                                        objModel.empcode = datarinrchk[0].ToString() + "-" + datarinrchk[1].ToString() + " [ Central Team Checker ]"; ;
                                        objModel.empname = Gethrsdesi(datarinrchk[0].ToString(), ConString);
                                        objModel.statusdate = Convert.ToString(dt.Rows[i]["queue_action_date"].ToString());
                                        objModel.remarks = Convert.ToString(dt.Rows[i]["queue_action_remark"].ToString());
                                        status = Convert.ToString(dt.Rows[i]["queue_action_status"].ToString());
                                        if (status == "10")
                                        {
                                            objModel.status = "CT - Reject";
                                        }
                                        else if (status == "20")
                                        {
                                            objModel.status = "Rejected";
                                        }
                                        else
                                        {
                                            objModel.status = "Approved";
                                        }
                                        rowvalues++;
                                        objModel.rowcount = rowvalues;
                                        objDashBoard.Add(objModel);
                                    }
                                }
                                else
                                {
                                    objModel = new ApproverHistry();
                                    string empcodnamegr = Getrolename(dt.Rows[i]["queue_to"].ToString(), ConString);
                                    string[] data;
                                    data = empcodnamegr.Split(',');
                                    if (data.Length > 1)
                                    {
                                        objModel.empcode = data[1].ToString();
                                        objModel.empname = "";
                                    }
                                    objModel.statusdate = "";
                                    objModel.remarks = "";
                                    status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                    objModel.status = "Next Approver";
                                    rowvalues++;
                                    objModel.rowcount = rowvalues;
                                    objDashBoard.Add(objModel);
                                    objModel.status = data[0].ToString() + "-" + data[1].ToString();

                                }
                            }
                            else
                            {
                                ecfmainraiser = streject;
                                string empcodnamer = Getempname(streject, ConString);
                                string[] datar;
                                datar = empcodnamer.Split(',');
                                objModel = new ApproverHistry();
                                if (datar.Length > 1)
                                {
                                    objModel.empcode = datar[0].ToString() + "-" + datar[1].ToString();
                                    objModel.empname = Gethrsdesi(datar[0].ToString(), ConString);
                                }
                                objModel.statusdate = Convert.ToString(dt.Rows[i]["queue_date"].ToString());
                                objModel.remarks = Convert.ToString(dt.Rows[i]["ecf_remark"].ToString());
                                objModel.status = "Submitted";
                                objModel.rowcount = rowvalues;
                                objDashBoard.Add(objModel);

                                string actions = Convert.ToString(dt.Rows[i]["queue_action_status"].ToString());
                                if (actions != "0")
                                {
                                    string ecfstatus = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                    string empid = Convert.ToString(dt.Rows[i]["queue_action_by"].ToString());
                                    string empcodname = Getempname(empid, ConString);
                                    string[] data;
                                    data = empcodname.Split(',');
                                    string empiddel = Convert.ToString(dt.Rows[i]["queue_delegation_gid"].ToString());
                                    objModel = new ApproverHistry();
                                    if (data.Length > 1)
                                    {
                                        if (empid == empiddel || empiddel == "0")
                                        {
                                            objModel.empcode = data[0].ToString() + "-" + data[1].ToString();
                                        }
                                        else
                                        {
                                            string empcodnamedel = Getempname(empiddel, ConString);
                                            string[] datadel;
                                            datadel = empcodnamedel.Split(',');
                                            objModel.empcode = datadel[0].ToString() + "-" + datadel[1].ToString() + " instead of " + data[0].ToString() + "-" + data[1].ToString();

                                        }
                                        objModel.empname = Gethrsdesi(data[0].ToString(), ConString);
                                    }
                                    objModel.statusdate = Convert.ToString(dt.Rows[i]["queue_action_date"].ToString());
                                    objModel.remarks = Convert.ToString(dt.Rows[i]["queue_action_remark"].ToString());
                                    status = Convert.ToString(dt.Rows[i]["queue_action_status"].ToString());
                                    if (ecfstatus == "1")
                                    {
                                        objModel.status = "Final Approver";
                                    }
                                    else
                                    {
                                        objModel.status = objCmnFunctions.GetQueueStatusHistry(status);
                                    }
                                    rowvalues++;
                                    objModel.rowcount = rowvalues;
                                    objDashBoard.Add(objModel);
                                }
                                else
                                {
                                    string queuetotype = Convert.ToString(dt.Rows[i]["queue_to_type"].ToString());
                                    if (queuetotype == "U")
                                    {
                                     
                                        objModel = new ApproverHistry();
                                         
                                        objModel.empcode = "Audit Maker";
                                        objModel.empname = "";
                                           
                                        objModel.statusdate = "";
                                        objModel.remarks = "";
                                        objModel.status = "Next Approver";
                                        rowvalues++;
                                        objModel.rowcount = rowvalues;
                                        objDashBoard.Add(objModel);
                                         
                                        objModel.status = "Audit Maker";
                                    }
                                    else if (queuetotype == "D")
                                    {
                                        
                                        objModel = new ApproverHistry();
                                         objModel.empcode = "Head Human Capital";
                                        objModel.empname = "";
                                        //}
                                        objModel.statusdate = "";
                                        objModel.remarks = "";
                                        objModel.status = "Next Approver";
                                        rowvalues++;
                                        objModel.rowcount = rowvalues;
                                        objDashBoard.Add(objModel);
                                        //  HttpContext.Current.Session["NextApprover"] = "Head Human Capital";
                                        objModel.status = "Head Human Capital";

                                    }
                                    else
                                    {
                                        string empids = Convert.ToString(dt.Rows[i]["queue_to"].ToString());
                                        string empcodname = Getempname(empids, ConString);
                                        string[] data;
                                        data = empcodname.Split(',');
                                        objModel = new ApproverHistry();
                                        if (data.Length > 1)
                                        {
                                            objModel.empcode = data[0].ToString() + "-" + data[1].ToString();
                                            objModel.empname = "";
                                        }
                                        objModel.statusdate = "";
                                        objModel.remarks = "";
                                        objModel.status = "Next Approver";
                                        rowvalues++;
                                        objModel.rowcount = rowvalues;
                                        objDashBoard.Add(objModel);
                                        // HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                        objModel.status = data[0].ToString() + "-" + data[1].ToString();



                                    }
                                }
                            }
                        }
                        else
                        {
                            string queue_action_by = Convert.ToString(dt.Rows[i]["queue_action_by"].ToString());
                            if (queue_action_by == "")
                            {
                                string empidtype = Convert.ToString(dt.Rows[i]["queue_to_type"].ToString());
                                string empid = Convert.ToString(dt.Rows[i]["queue_to"].ToString());
                                if (empidtype == "E")
                                {
                                    if (empid != "")
                                    {
                                        if (strejectraiserid != empid)
                                        {
                                            string empcodname = Getempname(empid, ConString);
                                            string[] data;
                                            data = empcodname.Split(',');
                                            objModel = new ApproverHistry();
                                            if (data.Length > 1)
                                            {
                                                objModel.empcode = data[0].ToString() + "-" + data[1].ToString();
                                                objModel.empname = "";
                                            }
                                            objModel.statusdate = "";
                                            objModel.remarks = "";
                                            status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                            objModel.status = "Next Approver";
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);
                                            //  HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                            objModel.status = data[0].ToString() + "-" + data[1].ToString();



                                        }
                                    }
                                }
                                if (empidtype == "G")
                                {
                                    if (dt.Rows[i]["Additional_flag"].ToString() == "Y")
                                    {
                                        objModel = new ApproverHistry();
                                        string empcodnamegr = GetGradename(dt.Rows[i]["queue_to"].ToString(), ConString);
                                        string[] data;
                                        data = empcodnamegr.Split(',');
                                        if (data.Length > 1)
                                        {
                                            objModel.empcode = data[1].ToString();
                                            objModel.empname = "";
                                        }
                                        objModel.statusdate = "";
                                        objModel.remarks = "";
                                        status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                        objModel.status = "Next Approver";
                                        rowvalues++;
                                        objModel.rowcount = rowvalues;
                                        objDashBoard.Add(objModel);

                                        //HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                        objModel.status = data[0].ToString() + "-" + data[1].ToString();

                                    }
                                    else
                                    {
                                        string getempgid = Getempheryname(dt.Rows[i]["ecf_raiser"].ToString(), "Grade", empid, ConString);
                                        if (getempgid != "0" && getempgid != "")
                                        {
                                            string empcodname = Getempname(getempgid, ConString);
                                            string[] data;
                                            data = empcodname.Split(',');
                                            objModel = new ApproverHistry();
                                            if (data.Length > 1)
                                            {
                                                objModel.empcode = data[0].ToString() + "-" + data[1].ToString();
                                                objModel.empname = "";
                                            }
                                            objModel.statusdate = "";
                                            objModel.remarks = "";
                                            status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                            objModel.status = "Next Approver";
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);

                                            // HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                            objModel.status = data[0].ToString() + "-" + data[1].ToString();



                                        }
                                        else
                                        {
                                            objModel = new ApproverHistry();
                                            string empcodnamegr = GetGradename(dt.Rows[i]["queue_to"].ToString(), ConString);
                                            string[] data;
                                            data = empcodnamegr.Split(',');
                                            if (data.Length > 1)
                                            {
                                                objModel.empcode = data[1].ToString();
                                                objModel.empname = "";
                                            }
                                            objModel.statusdate = "";
                                            objModel.remarks = "";
                                            status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                            objModel.status = "Next Approver";
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);

                                            // HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                            objModel.status = data[0].ToString() + "-" + data[1].ToString();



                                        }
                                    }
                                }
                                if (empidtype == "D")
                                {
                                    if (dt.Rows[i]["Additional_flag"].ToString() == "Y")
                                    {
                                        objModel = new ApproverHistry();
                                        string empcodnamegr = GetDesignationname(dt.Rows[i]["queue_to"].ToString(), ConString);
                                        string[] data;
                                        data = empcodnamegr.Split(',');
                                        if (data.Length > 1)
                                        {
                                            objModel.empcode = data[1].ToString();
                                            objModel.empname = "";
                                        }
                                        objModel.statusdate = "";
                                        objModel.remarks = "";
                                        status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                        objModel.status = "Next Approver";
                                        rowvalues++;
                                        objModel.rowcount = rowvalues;
                                        objDashBoard.Add(objModel);
                                        // HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                        objModel.status = data[0].ToString() + "-" + data[1].ToString();

                                    }
                                    else
                                    {
                                        string getempgid = Getempheryname(dt.Rows[i]["ecf_raiser"].ToString(), "Designation", empid, ConString);
                                        if (getempgid != "0" && getempgid != "")
                                        {
                                            string empcodname = Getempname(getempgid, ConString);
                                            string[] data;
                                            data = empcodname.Split(',');
                                            objModel = new ApproverHistry();
                                            if (data.Length > 1)
                                            {
                                                objModel.empcode = data[0].ToString() + "-" + data[1].ToString();
                                                objModel.empname = "";
                                            }
                                            objModel.statusdate = "";
                                            objModel.remarks = "";
                                            status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                            objModel.status = "Next Approver";
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);

                                            // HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                            objModel.status = data[0].ToString() + "-" + data[1].ToString();

                                        }
                                        else
                                        {
                                            objModel = new ApproverHistry();
                                            string empcodnamegr = GetGradename(dt.Rows[i]["queue_to"].ToString(), ConString);
                                            string[] data;
                                            data = empcodnamegr.Split(',');
                                            if (data.Length > 1)
                                            {
                                                objModel.empcode = data[1].ToString();
                                                objModel.empname = "";
                                            }
                                            objModel.statusdate = "";
                                            objModel.remarks = "";
                                            status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                            objModel.status = "Next Approver";
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);

                                            // HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                            objModel.status = data[0].ToString() + "-" + data[1].ToString();

                                        }
                                    }
                                }
                                if (empidtype == "R")
                                {
                                    if (dt.Rows[i]["Additional_flag"].ToString() == "Y")
                                    {
                                        objModel = new ApproverHistry();
                                        string empcodnamegr = Getrolename(dt.Rows[i]["queue_to"].ToString(), ConString);
                                        string[] data;
                                        data = empcodnamegr.Split(',');
                                        if (data.Length > 1)
                                        {
                                            objModel.empcode = data[1].ToString();
                                            objModel.empname = "";
                                        }
                                        objModel.statusdate = "";
                                        objModel.remarks = "";
                                        status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                        objModel.status = "Next Approver";
                                        rowvalues++;
                                        objModel.rowcount = rowvalues;
                                        objDashBoard.Add(objModel);

                                        //HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                        objModel.status = data[0].ToString() + "-" + data[1].ToString();

                                    }
                                    else
                                    {
                                        string getempgid = Getempheryname(ecfmainraiser, "Role Group", empid, ConString);
                                        if (getempgid != "0" && getempgid != "")
                                        {
                                            string empcodname = Getempname(getempgid, ConString);
                                            string[] data;
                                            data = empcodname.Split(',');
                                            objModel = new ApproverHistry();
                                            if (data.Length > 1)
                                            {
                                                objModel.empcode = data[0].ToString() + "-" + data[1].ToString();
                                                objModel.empname = "";
                                            }
                                            objModel.statusdate = "";
                                            objModel.remarks = "";
                                            status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                            objModel.status = "Next Approver";
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);

                                            //HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                            objModel.status = data[0].ToString() + "-" + data[1].ToString();

                                        }
                                        else
                                        {
                                            objModel = new ApproverHistry();
                                            string empcodnamegr = Getrolename(dt.Rows[i]["queue_to"].ToString(), ConString);
                                            string[] data;
                                            data = empcodnamegr.Split(',');
                                            if (data.Length > 1)
                                            {
                                                objModel.empcode = data[1].ToString();
                                                objModel.empname = "";
                                            }
                                            objModel.statusdate = "";
                                            objModel.remarks = "";
                                            status = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());
                                            objModel.status = "Next Approver";
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);

                                            //HttpContext.Current.Session["NextApprover"] = data[0].ToString() + "-" + data[1].ToString();

                                            objModel.status = data[0].ToString() + "-" + data[1].ToString();

                                        }
                                    }
                                }
                            }
                            else
                            {
                                strejectnew = Convert.ToString(dt.Rows[i]["employee_gid"].ToString());
                                if (strejectnew == streject)
                                {
                                    string actionsnew = Convert.ToString(dt.Rows[i]["queue_action_status"].ToString());
                                    if (actionsnew != "0")
                                    {
                                        streject = Convert.ToString(dt.Rows[i]["employee_gid"].ToString());
                                        string empcodnamer = Getempname(streject, ConString);
                                        string[] datar;
                                        datar = empcodnamer.Split(',');
                                        objModel = new ApproverHistry();
                                        if (datar.Length > 1)
                                        {
                                            objModel.empcode = datar[0].ToString() + "-" + datar[1].ToString();
                                            objModel.empname = Gethrsdesi(datar[0].ToString(), ConString); ;
                                        }
                                        objModel.statusdate = Convert.ToString(dt.Rows[i]["queue_action_date"].ToString());
                                        objModel.remarks = Convert.ToString(dt.Rows[i]["queue_action_remark"].ToString());
                                        if (actionsnew == "4")
                                        {
                                            objModel.status = "Cancelled";
                                        }
                                        else
                                        {
                                            objModel.status = "Re-Submitted";
                                        }
                                        rowvalues++;
                                        objModel.rowcount = rowvalues;
                                        objDashBoard.Add(objModel);
                                    }
                                }
                                else
                                {
                                    string actionsecfstatus = Convert.ToString(dt.Rows[i]["queue_ref_status"].ToString());

                                    if (actionsecfstatus == "1" || actionsecfstatus == "20" || actionsecfstatus == "10")
                                    {
                                        if (actionsecfstatus != "20" && actionsecfstatus != "10")
                                        {
                                            string empid = Convert.ToString(dt.Rows[i]["queue_action_by"].ToString());
                                            string empiddel = Convert.ToString(dt.Rows[i]["queue_delegation_gid"].ToString());
                                            string empcodname = Getempname(empid, ConString);
                                            string[] data;
                                            data = empcodname.Split(',');
                                            objModel = new ApproverHistry();
                                            if (data.Length > 1)
                                            {
                                                if (empid == empiddel || empiddel == "0")
                                                {
                                                    objModel.empcode = data[0].ToString() + "-" + data[1].ToString();
                                                }
                                                else
                                                {
                                                    string empcodnamedel = Getempname(empiddel, ConString);
                                                    string[] datadel;
                                                    datadel = empcodnamedel.Split(',');
                                                    objModel.empcode = datadel[0].ToString() + "-" + datadel[1].ToString() + " instead of " + data[0].ToString() + "-" + data[1].ToString();
                                                }
                                                objModel.empname = Gethrsdesi(data[0].ToString(), ConString); ;
                                            }
                                            objModel.statusdate = Convert.ToString(dt.Rows[i]["queue_action_date"].ToString());
                                            objModel.remarks = Convert.ToString(dt.Rows[i]["queue_action_remark"].ToString());
                                            objModel.status = "Final Approver";
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);
                                        }
                                    }
                                    else
                                    {
                                        string actionscc = Convert.ToString(dt.Rows[i]["queue_action_status"].ToString());
                                        if (actionscc != "0")
                                        {
                                            string empid = Convert.ToString(dt.Rows[i]["queue_action_by"].ToString());
                                            string empiddel = Convert.ToString(dt.Rows[i]["queue_delegation_gid"].ToString());
                                            string empcodname = Getempname(empid, ConString);
                                            string[] data;
                                            data = empcodname.Split(',');
                                            objModel = new ApproverHistry();
                                            if (data.Length > 1)
                                            {
                                                if (empid == empiddel || empiddel == "0")
                                                {
                                                    objModel.empcode = data[0].ToString() + "-" + data[1].ToString();
                                                }
                                                else
                                                {
                                                    string empcodnamedel = Getempname(empiddel, ConString);
                                                    string[] datadel;
                                                    datadel = empcodnamedel.Split(',');
                                                    objModel.empcode = datadel[0].ToString() + "-" + datadel[1].ToString() + " instead of " + data[0].ToString() + "-" + data[1].ToString();
                                                }
                                                objModel.empname = Gethrsdesi(data[0].ToString(), ConString);
                                            }
                                            objModel.statusdate = Convert.ToString(dt.Rows[i]["queue_action_date"].ToString());
                                            objModel.remarks = Convert.ToString(dt.Rows[i]["queue_action_remark"].ToString());
                                            status = Convert.ToString(dt.Rows[i]["queue_action_status"].ToString());
                                            objModel.status = objCmnFunctions.GetQueueStatusHistry(status);
                                            rowvalues++;
                                            objModel.rowcount = rowvalues;
                                            objDashBoard.Add(objModel);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                var newList = objDashBoard.OrderByDescending(x => x.rowcount).ToList();
                return newList;
            }
            catch (Exception ex)
            {
                 
                return objDashBoard;
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }



        public string Getempname(string empgid, string ConString)
        {
            string status = "";
            try
            {
                DataTable dt = new DataTable();
                GetConnection(ConString);
                cmd = new SqlCommand("pr_eow_com_audittrail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@employee_gid", SqlDbType.VarChar).Value = empgid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "employeename";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string raisername = Convert.ToString(dt.Rows[0]["employee_code"].ToString());
                    string raisercode = Convert.ToString(dt.Rows[0]["employee_name"].ToString());
                    status = raisername + "," + raisercode;
                }
                return status;
            }
            catch (Exception ex)
            {
                //objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        public string Gethrsdesi(string empgid, string ConString)
        {
            string status = "";
            try
            {
                DataTable dt = new DataTable();
                GetConnection(ConString);
                cmd = new SqlCommand("pr_eow_com_audittrail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@employee_gid", SqlDbType.VarChar).Value = empgid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "empdesignation";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string raisername = Convert.ToString(dt.Rows[0]["employee_hris_designation"].ToString());
                    status = raisername;
                }
                return status;
            }
            catch (Exception ex)
            {
                // objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        public string Getrolename(string empgid, string ConString)
        {
            string status = "";
            try
            {
                DataTable dt = new DataTable();
                GetConnection(ConString);
                cmd = new SqlCommand("pr_eow_com_audittrail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@employee_gid", SqlDbType.VarChar).Value = empgid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Getrolename";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string raisername = Convert.ToString(dt.Rows[0]["rolegroup_code"].ToString());
                    string raisercode = Convert.ToString(dt.Rows[0]["rolegroup_name"].ToString());
                    status = raisername + "," + raisercode;
                }
                return status;
            }
            catch (Exception ex)
            {
                // objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }




        public string GetGradename(string empgid, string ConString)
        {
            string status = "";
            try
            {
                DataTable dt = new DataTable();
                GetConnection(ConString);
                cmd = new SqlCommand("pr_eow_com_audittrail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@employee_gid", SqlDbType.VarChar).Value = empgid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetGradename";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string raisername = Convert.ToString(dt.Rows[0]["grade_code"].ToString());
                    string raisercode = Convert.ToString(dt.Rows[0]["grade_name"].ToString());
                    status = raisername + "," + raisercode;
                }
                return status;
            }
            catch (Exception ex)
            {
                //objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }

        public string GetDesignationname(string empgid, string ConString)
        {
            string status = "";
            try
            {
                DataTable dt = new DataTable();
                GetConnection(ConString);
                cmd = new SqlCommand("pr_eow_com_audittrail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@employee_gid", SqlDbType.VarChar).Value = empgid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetDesignationname";
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string raisername = Convert.ToString(dt.Rows[0]["designation_code"].ToString());
                    string raisercode = Convert.ToString(dt.Rows[0]["designation_name"].ToString());
                    status = raisername + "," + raisercode;
                }
                return status;
            }
            catch (Exception ex)
            {
                // objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        //Approve
        #region Insertapprovedaction
        

        public string Insertapprovedaction(Approve ObjApprove,
             string Ecfdesignation, int EMPdelmattype, int SUPdelmattype, int EcfInprocess, int EcfApproved, int ecfHold,
                     int EcfConcurrentApproval, int EcfRejected, int centralckeckerreject, int centralmaker,
            string ConString)
        {

            List<Approve> ObjApprovelist = new List<Approve>();

            string err_msg = "", Mailstring = "", mail = "", doctypeid = "";

            try
            {
                GetConnection(ConString);

                #region ECFApprove
                if (ObjApprove.EcfType == "ECRegular" || ObjApprove.EcfType == "ECTravel" || ObjApprove.EcfType == "ECLocal" || ObjApprove.EcfType == "EcfSupplierDSA" || ObjApprove.EcfType == "EcfSupplier" || ObjApprove.EcfType == "Insurance")
                {
                    if (ObjApprove.status == "Approve")
                    {
                        GetConnection(ConString);
                        cmd = new SqlCommand("pr_ecfdelmat", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid.ToString());
                        cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@ecf_approver_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());

                        cmd.Parameters.Add("@ecf_next_queue_to_gid", SqlDbType.Int, 64);
                        cmd.Parameters["@ecf_next_queue_to_gid"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecf_next_queue_to_type", SqlDbType.Char, 1);
                        cmd.Parameters["@ecf_next_queue_to_type"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecf_next_queue_to_additional_flag", SqlDbType.Char, 1);
                        cmd.Parameters["@ecf_next_queue_to_additional_flag"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecf_final_flag", SqlDbType.Char, 1, "N");
                        cmd.Parameters["@ecf_final_flag"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecfdelmat_result", SqlDbType.Int, 32);
                        cmd.Parameters["@ecfdelmat_result"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecf_err_output", SqlDbType.VarChar, 10000);
                        cmd.Parameters["@ecf_err_output"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecf_sql_output", SqlDbType.VarChar, 10000);
                        cmd.Parameters["@ecf_sql_output"].Direction = ParameterDirection.Output;
                        cmd.CommandTimeout = 0;
                        cmd.ExecuteNonQuery();

                        var result = Convert.ToString(cmd.Parameters["@ecf_next_queue_to_gid"].Value);
                        var Flag = Convert.ToString(cmd.Parameters["@ecf_next_queue_to_type"].Value);
                        var Additionalflagnew = Convert.ToString(cmd.Parameters["@ecf_next_queue_to_additional_flag"].Value);
                        var finalapprver = Convert.ToString(cmd.Parameters["@ecf_final_flag"].Value);
                        var demmatresult = Convert.ToString(cmd.Parameters["@ecfdelmat_result"].Value);
                        var sqlerrors = Convert.ToString(cmd.Parameters["@ecf_err_output"].Value);
                        var ecferrors = Convert.ToString(cmd.Parameters["@ecf_sql_output"].Value);

                        string Additionalflagnewq = "N";
                        string titlevalues = "";
                        titlevalues = Flag.ToString();

                        string Emp_designation = "";
                        // Correction by sugumar
                        cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = Convert.ToString(ObjApprove.EcfGid);
                        cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetEmpSupperdesc";
                        da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Emp_designation = dt.Rows[0]["employee_iem_designation"].ToString();
                        }
                        else
                        {
                            Emp_designation = "0";
                        }
                        if (Emp_designation == "0" || Emp_designation == "" || Emp_designation == null || Emp_designation == " ")
                        {
                            err_msg = "Invalid Approver.";
                            return err_msg;
                        }
                        if (Emp_designation == Ecfdesignation)
                        {
                            demmatresult = "1";
                            result = "0";
                            Flag = "E";
                            finalapprver = "Y";
                        }

                        if (Emp_designation.Trim() == "President")
                        {
                            demmatresult = "1";
                            result = "0";
                            Flag = "E";
                            finalapprver = "Y";
                        }
                        if (result == "0" || result == "" || result == " " || result == null || Emp_designation.Trim() == "President")
                        {
                            //objErrorLog.WriteErrorLog("Employee supervisor is empty : Emp_designation=" + Emp_designation.Trim() + "ecfgid =" + ecfgid + "", "Ecfdesignation =" + Ecfdesignation + "Final approver =" + finalapprver + "demmatresult=" + demmatresult);
                        }

                        string remarks = "";
                        if (ObjApprove.Rejecthold != null)
                        {
                            remarks = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold);
                        }

                        if (demmatresult != "0" && demmatresult != "")
                        {
                            if (finalapprver != "Y" && (Emp_designation.Trim() != "President"))
                            {
                                if (Additionalflagnew != null)
                                {
                                    if (Additionalflagnew.ToString() == "Y")
                                    {
                                        Additionalflagnewq = "Y";
                                    }
                                    else
                                    {
                                        Additionalflagnewq = "N";
                                    }
                                }
                                GetConnection(ConString);
                                cmd = new SqlCommand("PR_EOW_COM_FINALECFQUEUEUPDATE", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@QUEUEGID", SqlDbType.VarChar).Value = ObjApprove.QueueGid.ToString();
                                cmd.Parameters.Add("@QUEUEACTIONBY", SqlDbType.VarChar).Value = ObjApprove.empgid.ToString();
                                cmd.Parameters.Add("@QUEUEACTIONSTATUS", SqlDbType.VarChar).Value = ObjApprove.status;
                                cmd.Parameters.Add("@ECFGID", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                                cmd.Parameters.Add("@INVOICEID", SqlDbType.Int).Value = 0;
                                cmd.Parameters.Add("@ECFAMOUNT", SqlDbType.VarChar).Value = ObjApprove.queueamt;
                                cmd.Parameters.Add("@DELEGATE", SqlDbType.VarChar).Value = ObjApprove.delegates;
                                cmd.Parameters.Add("@titlevalues", SqlDbType.VarChar).Value = titlevalues;
                                cmd.Parameters.Add("@Additionalflagnewq", SqlDbType.VarChar).Value = Additionalflagnewq;
                                cmd.Parameters.Add("@ECFRAISER", SqlDbType.VarChar).Value = "";
                                cmd.Parameters.Add("@RESULT", SqlDbType.VarChar).Value = result;
                                cmd.Parameters.Add("@ECFREMARK", SqlDbType.VarChar).Value = remarks;
                                cmd.Parameters.Add("@ECFDESC", SqlDbType.VarChar).Value = remarks;
                                cmd.Parameters.Add("@loginuserid", SqlDbType.VarChar).Value = objCmnFunctions.GetLoginUserGid().ToString();
                                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "InsertapprovedactionNOTfinalapprove";
                                cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                                cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                                cmd.ExecuteNonQuery();
                                err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);

                            }
                            else
                            {
                                GetConnection(ConString);
                                cmd = new SqlCommand("PR_EOW_COM_FINALECFQUEUEUPDATE", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@QUEUEGID", SqlDbType.VarChar).Value = ObjApprove.QueueGid.ToString();
                                cmd.Parameters.Add("@QUEUEACTIONBY", SqlDbType.VarChar).Value = ObjApprove.empgid.ToString();
                                cmd.Parameters.Add("@QUEUEACTIONSTATUS", SqlDbType.VarChar).Value = ObjApprove.status;
                                cmd.Parameters.Add("@ECFGID", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                                cmd.Parameters.Add("@INVOICEID", SqlDbType.Int).Value = 0;
                                cmd.Parameters.Add("@ECFAMOUNT", SqlDbType.VarChar).Value = ObjApprove.queueamt;
                                cmd.Parameters.Add("@DELEGATE", SqlDbType.VarChar).Value = ObjApprove.delegates;
                                cmd.Parameters.Add("@titlevalues", SqlDbType.VarChar).Value = titlevalues;
                                cmd.Parameters.Add("@Additionalflagnewq", SqlDbType.VarChar).Value = Additionalflagnewq;
                                cmd.Parameters.Add("@ECFRAISER", SqlDbType.VarChar).Value = "";
                                cmd.Parameters.Add("@RESULT", SqlDbType.VarChar).Value = result;
                                cmd.Parameters.Add("@ECFREMARK", SqlDbType.VarChar).Value = remarks;
                                cmd.Parameters.Add("@ECFDESC", SqlDbType.VarChar).Value = remarks;
                                cmd.Parameters.Add("@loginuserid", SqlDbType.VarChar).Value = objCmnFunctions.GetLoginUserGid().ToString();
                                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Insertapprovedactionfinalapprove";
                                cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                                cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                                cmd.ExecuteNonQuery();
                                err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);
                            }
                            if (err_msg != "Sucess")
                            {
                                return err_msg;
                            }
                            string queue_gid = "";
                            DataTable dtempsupnew = new DataTable();
                            cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = ObjApprove.empgid;
                            cmd.Parameters.Add("@para2", SqlDbType.VarChar).Value = ObjApprove.EcfGid;
                            cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetMaxqueuegid";
                            da = new SqlDataAdapter(cmd);
                            da.Fill(dtempsupnew);
                            if (dtempsupnew.Rows.Count > 0)
                            {
                                queue_gid = Convert.ToString(dtempsupnew.Rows[0]["queue_gid"].ToString());
                            }
                            mail = queue_gid.ToString();
                            DataTable dtdoctype = new DataTable();
                            cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = mail;
                            cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Getdocsubtype";
                            da = new SqlDataAdapter(cmd);
                            da.Fill(dtdoctype);
                            if (dtdoctype.Rows.Count > 0)
                            {
                                doctypeid = Convert.ToString(dtdoctype.Rows[0]["docsubtype_gid"].ToString());
                                doctypeid = objCmnFunctions.GetSubDocType(doctypeid);
                                Mailstring = "Approve";
                            }

                        }
                        else
                        {
                            err_msg = sqlerrors;
                            return err_msg;
                        }

                    }
                    #endregion
                    //------------------------------------------------------To Select Reject Status -------------
                    #region ECFReject
                    else if (ObjApprove.status == "Reject")
                    {
                        string doctyoeandmode = "";
                        DataTable dtrejectcon = new DataTable();
                        GetConnection(ConString);
                        cmd = new SqlCommand("pr_eow_com_ecfdetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ecf_gid", SqlDbType.VarChar).Value = ObjApprove.EcfGid;
                        cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "TYPEDL";
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dtrejectcon);
                        if (dtrejectcon.Rows.Count > 0)
                        {
                            doctyoeandmode = Convert.ToString(dtrejectcon.Rows[0]["ecf_create_mode"].ToString());
                            if (doctyoeandmode == "S" || doctyoeandmode == "P")
                            {
                                GetConnection(ConString);
                                cmd = new SqlCommand("pr_eow_com_reject", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@queue_delegation_gid", SqlDbType.Int).Value = Convert.ToInt32(objCmnFunctions.GetLoginUserGid().ToString());
                                cmd.Parameters.Add("@queue_action_by", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                                cmd.Parameters.Add("@queue_action_status", SqlDbType.Int).Value = Convert.ToInt32(EcfRejected.ToString());
                                cmd.Parameters.Add("@queue_action_remark", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold.ToString());
                                cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                                cmd.Parameters.Add("@ecf_create_mode", SqlDbType.Char).Value = Convert.ToChar(doctyoeandmode.ToString());
                                cmd.Parameters.Add("@ref_gid", SqlDbType.VarChar).Value = ObjApprove.EcfGid;
                                cmd.Parameters.Add("@queue_action", SqlDbType.VarChar).Value = "getqueuefromreject";
                                cmd.Parameters.Add("@queue_ref_flag", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@queue_ref_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid.ToString());
                                cmd.Parameters.Add("@queue_ref_status", SqlDbType.Int).Value = Convert.ToInt32(EcfRejected.ToString());
                                cmd.Parameters.Add("@queue_from", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                                cmd.Parameters.Add("@queue_to_type", SqlDbType.Char).Value = 'E';
                                cmd.Parameters.Add("@queue_to", SqlDbType.Int).Value = Convert.ToInt32(Convert.ToString(dtrejectcon.Rows[0]["ecf_raiser"]));
                                cmd.Parameters.Add("@queue_action_for", SqlDbType.Char).Value = 'R';
                                cmd.Parameters.Add("@queue_prev_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                                cmd.Parameters.Add("@ecf_all_status", SqlDbType.Int).Value = Convert.ToInt32(EcfRejected.ToString());
                                cmd.Parameters.Add("@ecf_status", SqlDbType.Int).Value = Convert.ToInt32(EcfRejected.ToString());
                                cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid.ToString());
                                cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = ObjApprove.empgid;
                                cmd.Parameters.Add("@para2", SqlDbType.VarChar).Value = ObjApprove.EcfGid;
                                cmd.Parameters.Add("@queue_max_action", SqlDbType.VarChar).Value = "GetMaxqueuegid";
                                cmd.Parameters.Add("@NOE_para1", SqlDbType.VarChar).Value = ObjApprove.QueueGid.ToString();
                                cmd.Parameters.Add("@NOE_action", SqlDbType.VarChar).Value = "Getdocsubtype";
                                //pandiaraj 22/06/2018
                                cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                                cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                                cmd.ExecuteNonQuery();
                                err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);
                                // int Result = cmd.ExecuteNonQuery(); 
                                // if (Result != 0)
                                if (err_msg != "Sucess")
                                {
                                    return err_msg;
                                }
                                string queue_gid = "";
                                DataTable dtempsupnew = new DataTable();
                                cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = ObjApprove.empgid;
                                cmd.Parameters.Add("@para2", SqlDbType.VarChar).Value = ObjApprove.EcfGid;
                                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetMaxqueuegid";
                                da = new SqlDataAdapter(cmd);
                                da.Fill(dtempsupnew);
                                if (dtempsupnew.Rows.Count > 0)
                                {
                                    queue_gid = Convert.ToString(dtempsupnew.Rows[0]["queue_gid"].ToString());
                                }
                                mail = queue_gid.ToString();
                                DataTable dtdoctype = new DataTable();
                                cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = mail;
                                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Getdocsubtype";
                                da = new SqlDataAdapter(cmd);
                                da.Fill(dtdoctype);
                                if (dtdoctype.Rows.Count > 0)
                                {
                                    doctypeid = Convert.ToString(dtdoctype.Rows[0]["docsubtype_gid"].ToString());
                                    doctypeid = objCmnFunctions.GetSubDocType(doctypeid);
                                    Mailstring = "Reject";
                                }
                                //return err_msg;

                            }

                            else
                            {
                                cmd = new SqlCommand("pr_eow_updat_queuedetails", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@queue_action_by", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                                cmd.Parameters.Add("@queue_delegation_gid", SqlDbType.Int).Value = Convert.ToInt32(objCmnFunctions.GetLoginUserGid().ToString());
                                cmd.Parameters.Add("@queue_action_status", SqlDbType.Int).Value = Convert.ToInt32(centralckeckerreject.ToString());
                                cmd.Parameters.Add("@queue_action_remark", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold.ToString());
                                cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                                cmd.Parameters.Add("@ref_gid", SqlDbType.VarChar).Value = ObjApprove.EcfGid;
                                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "getqueuefromreject";
                                cmd.Parameters.Add("@queue_ref_flag", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@queue_ref_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid.ToString());
                                cmd.Parameters.Add("@queue_ref_status", SqlDbType.Int).Value = Convert.ToInt32(centralckeckerreject.ToString());
                                cmd.Parameters.Add("@queue_from", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                                cmd.Parameters.Add("@queue_to_type", SqlDbType.Char).Value = Convert.ToChar('R');
                                cmd.Parameters.Add("@queue_to", SqlDbType.Int).Value = Convert.ToInt32(centralmaker.ToString());
                                cmd.Parameters.Add("@queue_action_for", SqlDbType.Char).Value = Convert.ToChar('R');
                                cmd.Parameters.Add("@queue_prev_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                                cmd.Parameters.Add("@ecf_all_status", SqlDbType.Int).Value = Convert.ToInt32(centralckeckerreject.ToString());
                                cmd.Parameters.Add("@ecf_status", SqlDbType.Int).Value = Convert.ToInt32(centralckeckerreject.ToString());
                                cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                                // int Result = cmd.ExecuteNonQuery();
                                //pandiaraj 22/06/2018
                                cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                                cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                                cmd.ExecuteNonQuery();
                                err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);
                                if (err_msg != "Sucess")
                                {
                                    return err_msg;
                                }
                                string queue_gid = "";
                                string Emp_Msgsuper = "";
                                DataTable dtempsupnew = new DataTable();
                                cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = Emp_Msgsuper.ToString();
                                cmd.Parameters.Add("@para2", SqlDbType.VarChar).Value = ObjApprove.EcfGid;
                                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetMaxqueuegid";
                                da = new SqlDataAdapter(cmd);
                                da.Fill(dtempsupnew);
                                if (dtempsupnew.Rows.Count > 0)
                                {
                                    queue_gid = Convert.ToString(dtempsupnew.Rows[0]["queue_gid"].ToString());
                                }
                                mail = queue_gid.ToString();
                                DataTable dtdoctype = new DataTable();
                                cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = mail;
                                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Getdocsubtype";
                                da = new SqlDataAdapter(cmd);
                                da.Fill(dtdoctype);
                                if (dtdoctype.Rows.Count > 0)
                                {
                                    doctypeid = Convert.ToString(dtdoctype.Rows[0]["docsubtype_gid"].ToString());
                                    doctypeid = objCmnFunctions.GetSubDocType(doctypeid);
                                }

                            }
                        }
                        else
                        {
                            err_msg = "Please Select ECF";
                            return err_msg;
                        }
                    }
                    #endregion
                    //------------------------------------------------------To Select Hold Status ------------- 
                    #region ECFHold
                    else if (ObjApprove.status == "Hold")
                    {
                        // string Rejecthold = "";
                        if (ObjApprove.Rejecthold != null)
                        {
                            ObjApprove.Rejecthold = ObjApprove.Rejecthold;
                        }

                        cmd = new SqlCommand("pr_eow_trn_hold", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ecf_all_status", SqlDbType.Int).Value = Convert.ToInt32(ecfHold.ToString());
                        cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                        cmd.Parameters.Add("@queue_action_by", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                        cmd.Parameters.Add("@queue_delegation_gid", SqlDbType.Int).Value = Convert.ToInt32(objCmnFunctions.GetLoginUserGid().ToString());
                        cmd.Parameters.Add("@queue_action_status", SqlDbType.Int).Value = Convert.ToInt32(ecfHold.ToString());
                        cmd.Parameters.Add("@queue_action_remark", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold.ToString());
                        cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@ecfhold_ecf_gid", SqlDbType.Int).Value = ObjApprove.EcfGid.ToString();
                        cmd.Parameters.Add("@ecfhold_queue_gid", SqlDbType.Int).Value = ObjApprove.QueueGid.ToString();
                        cmd.Parameters.Add("@ecfhold_by", SqlDbType.Int).Value = ObjApprove.empgid.ToString();
                        cmd.Parameters.Add("@ecfhold_remark ", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold.ToString());
                        cmd.Parameters.Add("@ecfhold_status", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                        cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);

                        if (err_msg != "Sucess")
                        {
                            return err_msg;
                        }

                    }
                    #endregion

                    //------------------------------------------------------To Select Concurrent Approval Status -------------

                    #region ConcurrentApproval
                    else if (ObjApprove.status == "Concurrent")
                    {
                        //string Concurrentmsg = "";
                        if (ObjApprove.Concurrentmsg != null)
                        {
                            ObjApprove.Concurrentmsg = ObjApprove.Concurrentmsg;
                        }
                        // string Rejecthold = "";
                        if (ObjApprove.Rejecthold != null)
                        {
                            ObjApprove.Rejecthold = ObjApprove.Rejecthold;
                        }
                        GetConnection(ConString);
                        cmd = new SqlCommand("pr_eow_trn_concurrent_aprvl", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ecf_all_status", SqlDbType.Int).Value = Convert.ToInt32(EcfConcurrentApproval.ToString());
                        cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                        cmd.Parameters.Add("@queue_action_by", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                        cmd.Parameters.Add("@queue_delegation_gid", SqlDbType.Int).Value = Convert.ToInt32(objCmnFunctions.GetLoginUserGid().ToString());
                        cmd.Parameters.Add("@queue_action_status", SqlDbType.Int).Value = Convert.ToInt32(EcfConcurrentApproval.ToString());
                        cmd.Parameters.Add("@queue_action_remark", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Concurrentmsg.ToString());
                        cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@queue_ref_flag", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@queue_ref_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid.ToString());
                        cmd.Parameters.Add("@queue_ref_status", SqlDbType.Int).Value = Convert.ToInt32(EcfConcurrentApproval.ToString());
                        cmd.Parameters.Add("@queue_from ", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                        cmd.Parameters.Add("@queue_to_type", SqlDbType.Char).Value = 'E';
                        cmd.Parameters.Add("@queue_to ", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.Concurrent.ToString());
                        cmd.Parameters.Add("@queue_action_for", SqlDbType.Char).Value = 'C';
                        cmd.Parameters.Add("@queue_prev_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_from", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_to", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.Concurrent.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_subject ", SqlDbType.VarChar).Value = ObjApprove.Concurrentmsg.ToString();
                        cmd.Parameters.Add("@ecfconcurrent_remark", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_status", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                        cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);
                        if (err_msg != "Sucess")
                        {
                            return err_msg;
                        }
                    }
                }
                #endregion


                //------------------------------------------------------To Select ARF -------------
                #region ARF
                else if (ObjApprove.EcfType == "Arf" || ObjApprove.EcfType == "Insuranceadvance")
                {
                    //------------------------------------------------------To Select ARF Approve Status -------------
                    #region  ARFApprove
                    if (ObjApprove.status == "Approve")
                    {
                        //Hashtable Togetlist = new Hashtable();
                        //Togetlist = (Hashtable)HttpContext.Current.Session["Queue_delegateslist"];

                        //if (Togetlist.ContainsKey(queuegid))
                        //{
                        //    empgid = Togetlist[queuegid].ToString();
                        //}

                        cmd = new SqlCommand("pr_ecfdelmat", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid.ToString());
                        cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@ecf_approver_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());

                        cmd.Parameters.Add("@ecf_next_queue_to_gid", SqlDbType.Int, 64);
                        cmd.Parameters["@ecf_next_queue_to_gid"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecf_next_queue_to_type", SqlDbType.Char, 1);
                        cmd.Parameters["@ecf_next_queue_to_type"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecf_next_queue_to_additional_flag", SqlDbType.Char, 1);
                        cmd.Parameters["@ecf_next_queue_to_additional_flag"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecf_final_flag", SqlDbType.Char, 1, "N");
                        cmd.Parameters["@ecf_final_flag"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecfdelmat_result", SqlDbType.Int, 32);
                        cmd.Parameters["@ecfdelmat_result"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecf_err_output", SqlDbType.VarChar, 10000);
                        cmd.Parameters["@ecf_err_output"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@ecf_sql_output", SqlDbType.VarChar, 10000);
                        cmd.Parameters["@ecf_sql_output"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        var result = Convert.ToString(cmd.Parameters["@ecf_next_queue_to_gid"].Value);
                        var Flag = Convert.ToString(cmd.Parameters["@ecf_next_queue_to_type"].Value);
                        var Additionalflagnew = Convert.ToString(cmd.Parameters["@ecf_next_queue_to_additional_flag"].Value);
                        var finalapprver = Convert.ToString(cmd.Parameters["@ecf_final_flag"].Value);
                        var demmatresult = Convert.ToString(cmd.Parameters["@ecfdelmat_result"].Value);
                        var sqlerrors = Convert.ToString(cmd.Parameters["@ecf_err_output"].Value);
                        var ecferrors = Convert.ToString(cmd.Parameters["@ecf_sql_output"].Value);

                        string Additionalflagnewq = "N";
                        string titlevalues = "";
                        titlevalues = Flag.ToString();
                        string remarks = "";
                        int Result = 0;
                        if (ObjApprove.Rejecthold != null && ObjApprove.Rejecthold != "")
                        {
                            remarks = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold);
                        }
                        if (demmatresult != "0" && demmatresult != "")
                        {
                            if (finalapprver != "Y")
                            {
                                if (Additionalflagnew != null)
                                {
                                    if (Additionalflagnew.ToString() == "Y")
                                    {
                                        Additionalflagnewq = "Y";
                                    }
                                    else
                                    {
                                        Additionalflagnewq = "N";
                                    }
                                }
                                cmd = new SqlCommand("pr_eow_arf_approve", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@queue_isremoved", SqlDbType.Char).Value = 'Y';
                                cmd.Parameters.Add("@queue_action_by", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                                cmd.Parameters.Add("@queue_delegation_gid", SqlDbType.Int).Value = Convert.ToInt32(objCmnFunctions.GetLoginUserGid().ToString());
                                cmd.Parameters.Add("@queue_action_status", SqlDbType.Int).Value = Convert.ToInt32(EcfApproved.ToString());
                                cmd.Parameters.Add("@queue_action_remark", SqlDbType.VarChar).Value = remarks;
                                cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                                cmd.Parameters.Add("@ecf_status", SqlDbType.Int).Value = Convert.ToInt32(EcfInprocess.ToString());
                                cmd.Parameters.Add("@ecf_all_status", SqlDbType.Int).Value = Convert.ToInt32(EcfApproved.ToString());
                                cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                                cmd.Parameters.Add("@queue_ref_flag", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@queue_ref_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                                cmd.Parameters.Add("@queue_ref_status", SqlDbType.Int).Value = Convert.ToInt32(EcfInprocess.ToString());
                                cmd.Parameters.Add("@queue_from", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                                cmd.Parameters.Add("@queue_to_type", SqlDbType.Char).Value = Convert.ToChar(titlevalues.ToString());
                                cmd.Parameters.Add("@queue_to", SqlDbType.Int).Value = Convert.ToInt32(result.ToString());
                                cmd.Parameters.Add("@queue_action_for", SqlDbType.Char).Value = 'A';
                                cmd.Parameters.Add("@Additional_flag", SqlDbType.Char).Value = Convert.ToChar(Additionalflagnewq.ToString());
                                cmd.Parameters.Add("@queue_prev_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                                cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                                cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                                cmd.ExecuteNonQuery();
                                err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);

                                if (err_msg != "Sucess")
                                {
                                    return err_msg;
                                }
                            }
                            else
                            {
                                GetConnection(ConString);
                                cmd = new SqlCommand("pr_eow_arf_approve", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@queue_isremoved", SqlDbType.Char).Value = 'Y';
                                cmd.Parameters.Add("@queue_action_by", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                                cmd.Parameters.Add("@queue_delegation_gid", SqlDbType.Int).Value = Convert.ToInt32(objCmnFunctions.GetLoginUserGid().ToString());
                                cmd.Parameters.Add("@queue_action_status", SqlDbType.Int).Value = Convert.ToInt32(EcfApproved.ToString());
                                cmd.Parameters.Add("@queue_ref_Ustatus", SqlDbType.Int).Value = Convert.ToInt32(EcfApproved.ToString());
                                cmd.Parameters.Add("@queue_action_remark", SqlDbType.VarChar).Value = remarks;
                                cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                                cmd.Parameters.Add("@ecf_status", SqlDbType.Int).Value = Convert.ToInt32(EcfApproved.ToString());
                                cmd.Parameters.Add("@ecf_all_status", SqlDbType.Int).Value = Convert.ToInt32(EcfApproved.ToString());
                                cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                                cmd.Parameters.Add("@queue_ref_flag", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@queue_ref_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                                cmd.Parameters.Add("@queue_ref_status", SqlDbType.Int).Value = 64;
                                cmd.Parameters.Add("@queue_from", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                                cmd.Parameters.Add("@queue_to_type", SqlDbType.Char).Value = 'U';
                                cmd.Parameters.Add("@queue_to", SqlDbType.Int).Value = 43;
                                cmd.Parameters.Add("@queue_action_for", SqlDbType.Char).Value = 'A';
                                cmd.Parameters.Add("@Additional_flag", SqlDbType.Char).Value = Convert.ToChar(Additionalflagnewq.ToString());
                                cmd.Parameters.Add("@queue_prev_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                                cmd.Parameters.Add("@employee_gid", SqlDbType.VarChar).Value = ObjApprove.empgid;
                                cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                                cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                                cmd.ExecuteNonQuery();
                                err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);
                                if (err_msg != "Sucess")
                                {
                                    return err_msg;
                                }
                            }
                            string queue_gid = "";
                            DataTable dtempsupnew = new DataTable();
                            cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = ObjApprove.empgid;
                            cmd.Parameters.Add("@para2", SqlDbType.VarChar).Value = ObjApprove.EcfGid;
                            cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetMaxqueuegid";
                            da = new SqlDataAdapter(cmd);
                            da.Fill(dtempsupnew);
                            if (dtempsupnew.Rows.Count > 0)
                            {
                                queue_gid = Convert.ToString(dtempsupnew.Rows[0]["queue_gid"].ToString());
                            }
                            mail = queue_gid.ToString();
                            GetConnection(ConString);
                            DataTable dtdoctype = new DataTable();
                            cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = mail;
                            cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Getdocsubtype";
                            da = new SqlDataAdapter(cmd);
                            da.Fill(dtdoctype);
                            if (dtdoctype.Rows.Count > 0)
                            {
                                doctypeid = Convert.ToString(dtdoctype.Rows[0]["docsubtype_gid"].ToString());
                                doctypeid = objCmnFunctions.GetSubDocType(doctypeid);
                                Mailstring = "ARF";
                            }
                        }
                        else
                        {
                            err_msg = sqlerrors;
                            return err_msg;
                        }

                    }
                    #endregion
                    //------------------------------------------------------To Select ARF Reject Status -------------
                    #region ARFReject
                    else if (ObjApprove.status == "Reject")
                    {

                        cmd = new SqlCommand("pr_eow_arf_upda_reject", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ecf_status", SqlDbType.Int).Value = EcfRejected.ToString();
                        cmd.Parameters.Add("@ecf_all_status", SqlDbType.Int).Value = EcfRejected.ToString();
                        cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = ObjApprove.EcfGid;
                        cmd.Parameters.Add("@queue_isremoved", SqlDbType.Char).Value = 'Y';
                        cmd.Parameters.Add("@queue_action_by", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                        cmd.Parameters.Add("@queue_delegation_gid", SqlDbType.Int).Value = Convert.ToInt32(objCmnFunctions.GetLoginUserGid().ToString());
                        cmd.Parameters.Add("@queue_action_status", SqlDbType.Int).Value = Convert.ToInt32(EcfRejected.ToString());
                        cmd.Parameters.Add("@queue_action_remark", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold.ToString());
                        cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@ref_gid", SqlDbType.VarChar).Value = ObjApprove.EcfGid;
                        cmd.Parameters.Add("@queue_ref_flag", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@queue_ref_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                        cmd.Parameters.Add("@queue_ref_status", SqlDbType.Int).Value = Convert.ToInt32(EcfRejected.ToString());
                        cmd.Parameters.Add("@queue_from", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                        cmd.Parameters.Add("@queue_to_type", SqlDbType.Char).Value = 'E';
                        cmd.Parameters.Add("@queue_action_for", SqlDbType.Char).Value = 'R';
                        cmd.Parameters.Add("@queue_prev_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                        cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);
                        if (err_msg != "Sucess")
                        {
                            return err_msg;
                        }
                        string queue_gid = "";
                        GetConnection(ConString);
                        DataTable dtempsupnew = new DataTable();
                        cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = ObjApprove.empgid;
                        cmd.Parameters.Add("@para2", SqlDbType.VarChar).Value = ObjApprove.EcfGid;
                        cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "GetMaxqueuegid";
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dtempsupnew);
                        if (dtempsupnew.Rows.Count > 0)
                        {
                            queue_gid = Convert.ToString(dtempsupnew.Rows[0]["queue_gid"].ToString());
                        }
                        mail = queue_gid.ToString();
                        GetConnection(ConString);
                        DataTable dtdoctype = new DataTable();
                        cmd = new SqlCommand("pr_eow_mst_NatureofExpenses", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@para1", SqlDbType.VarChar).Value = mail;
                        cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Getdocsubtype";
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dtdoctype);
                        if (dtdoctype.Rows.Count > 0)
                        {
                            doctypeid = Convert.ToString(dtdoctype.Rows[0]["docsubtype_gid"].ToString());
                            doctypeid = objCmnFunctions.GetSubDocType(doctypeid);
                            Mailstring = "ARFReject";
                            //mailsender.sendusermail("EOW", doctypeid, mail, "R", "0");
                        }

                    }
                    #endregion
                    //------------------------------------------------------To Select ARF Hold Status -------------------
                    #region ARFHold
                    else if (ObjApprove.status == "Hold")
                    {

                        //string Rejecthold = "";
                        if (ObjApprove.Rejecthold != null)
                        {
                            ObjApprove.Rejecthold = ObjApprove.Rejecthold;
                        }

                        cmd = new SqlCommand("pr_eow_trn_hold", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ecf_all_status", SqlDbType.Int).Value = ecfHold.ToString();
                        cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                        //cmd.Parameters.Add("@queue_isremoved", SqlDbType.Char).Value = 'Y';
                        cmd.Parameters.Add("@queue_action_by", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                        cmd.Parameters.Add("@queue_delegation_gid", SqlDbType.Int).Value = Convert.ToInt32(objCmnFunctions.GetLoginUserGid().ToString());
                        cmd.Parameters.Add("@queue_action_status", SqlDbType.Int).Value = Convert.ToInt32(ecfHold.ToString());
                        cmd.Parameters.Add("@queue_action_remark", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold.ToString());
                        cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@ecfhold_ecf_gid", SqlDbType.Int).Value = ObjApprove.EcfGid.ToString();
                        cmd.Parameters.Add("@ecfhold_queue_gid", SqlDbType.Int).Value = ObjApprove.QueueGid.ToString();
                        cmd.Parameters.Add("@ecfhold_by", SqlDbType.Int).Value = ObjApprove.empgid.ToString();
                        cmd.Parameters.Add("@ecfhold_remark ", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold.ToString());
                        cmd.Parameters.Add("@ecfhold_status", SqlDbType.Int).Value = 0;
                        // int Result = cmd.ExecuteNonQuery();
                        cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                        cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);
                        //if (Result != 0)
                        //{
                        //    err_msg = "Sucess";
                        //    tscope.Complete();
                        //}
                        //else
                        //{
                        //    err_msg = "Error";
                        //    tscope.Dispose();
                        //}
                        return err_msg;

                    }
                    #endregion
                    //------------------------------------------------------To Select ARF Concurrent Approval Status -------------
                    #region  ARFConcurrentApproval
                    else if (ObjApprove.status == "Concurrent")
                    {
                        //string Concurrentmsg = "";
                        if (ObjApprove.Concurrentmsg != null)
                        {
                            ObjApprove.Concurrentmsg = ObjApprove.Concurrentmsg;
                        }
                        // string Rejecthold = "";
                        if (ObjApprove.Rejecthold != null)
                        {
                            ObjApprove.Rejecthold = ObjApprove.Rejecthold;
                        }

                        GetConnection(ConString);
                        cmd = new SqlCommand("pr_eow_trn_concurrent_aprvl", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ecf_all_status", SqlDbType.Int).Value = Convert.ToInt32(EcfConcurrentApproval.ToString());
                        cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid);
                        cmd.Parameters.Add("@queue_isremoved", SqlDbType.Char).Value = 'Y';
                        cmd.Parameters.Add("@queue_action_by", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                        cmd.Parameters.Add("@queue_delegation_gid", SqlDbType.Int).Value = Convert.ToInt32(objCmnFunctions.GetLoginUserGid().ToString());
                        cmd.Parameters.Add("@queue_action_status", SqlDbType.Int).Value = Convert.ToInt32(EcfConcurrentApproval.ToString());
                        cmd.Parameters.Add("@queue_action_remark", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Concurrentmsg.ToString());
                        cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@queue_ref_flag", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@queue_ref_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid.ToString());
                        cmd.Parameters.Add("@queue_ref_status", SqlDbType.Int).Value = Convert.ToInt32(EcfConcurrentApproval.ToString());
                        cmd.Parameters.Add("@queue_from ", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                        cmd.Parameters.Add("@queue_to_type", SqlDbType.Char).Value = 'E';
                        cmd.Parameters.Add("@queue_to ", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.Concurrent.ToString());
                        cmd.Parameters.Add("@queue_action_for", SqlDbType.Char).Value = 'C';
                        cmd.Parameters.Add("@queue_prev_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.EcfGid.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_queue_gid", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.QueueGid.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_from", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.empgid.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_to", SqlDbType.Int).Value = Convert.ToInt32(ObjApprove.Concurrent.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_subject ", SqlDbType.VarChar).Value = ObjApprove.Concurrentmsg.ToString();
                        cmd.Parameters.Add("@ecfconcurrent_remark", SqlDbType.VarChar).Value = objCmnFunctions.Getreplacesinglequotes(ObjApprove.Rejecthold.ToString());
                        cmd.Parameters.Add("@ecfconcurrent_status", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@MSG", SqlDbType.VarChar, 10000);
                        cmd.Parameters["@MSG"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        err_msg = Convert.ToString(cmd.Parameters["@MSG"].Value);
                        //int Result = cmd.ExecuteNonQuery();

                        //if (Result != 0)
                        //{
                        //    err_msg = "Sucess";
                        //    tscope.Complete();
                        //}
                        //else
                        //{
                        //    err_msg = "Error";
                        //}

                        return err_msg;

                    }
                    #endregion
                }
                #endregion
                //  tscope.Complete();

            }
            catch (Exception ex)
            {
                // objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                //tscope.Dispose();
                return err_msg;
            }
            finally
            {
                con.Close();
                da.Dispose();

            }
            //}
            string mailreturn = "";
            if (err_msg == "Sucess")
            {
                // for Mail correction by sugumar
                if (Mailstring == "Approve")
                {
                    //old
                    // mailreturn = mailsender.sendusermail("EOW", doctypeid, mail, "A", "0");
                    //vadivu add
                    int PrGid = 0;
                    string POgid = "POgid";
                    string cbfgid = "cbfgid";
                    int WoGid = 0;

                    //  mailreturn = mailsender.sendusermailEOW("EOW", doctypeid, mail, "A", "0", ecfgid, PrGid, POgid, cbfgid, WoGid);

                    //vadivu end
                }
                else if (Mailstring == "Reject")
                {
                    // mailreturn = mailsender.sendusermail("EOW", doctypeid, mail, "R", "0"); old

                    int PrGid = 0;
                    string POgid = "POgid";
                    string cbfgid = "cbfgid";
                    int WoGid = 0;

                    // mailreturn = mailsender.sendusermailEOW("EOW", doctypeid, mail, "A", "0", ecfgid, PrGid, POgid, cbfgid, WoGid);

                }
                else if (Mailstring == "ARF")
                {
                    // mailreturn = mailsender.sendusermail("EOW", doctypeid, mail, "A", "0");
                    int PrGid = 0;
                    string POgid = "POgid";
                    string cbfgid = "cbfgid";
                    int WoGid = 0;

                    //mailreturn = mailsender.sendusermailEOW("EOW", doctypeid, mail, "A", "0", ecfgid, PrGid, POgid, cbfgid, WoGid);

                }
                else if (Mailstring == "ARFReject")
                {
                    //  mailreturn = mailsender.sendusermail("EOW", doctypeid, mail, "R", "0");
                    int PrGid = 0;
                    string POgid = "POgid";
                    string cbfgid = "cbfgid";
                    int WoGid = 0;

                    // mailreturn = mailsender.sendusermailEOW("EOW", doctypeid, mail, "A", "0", ecfgid, PrGid, POgid, cbfgid, WoGid);

                }
                else
                {
                    if (Mailstring != "")
                    {
                        // mailreturn = mailsender.sendusermail("EOW", doctypeid, mail, "R", "0");
                    }
                }
                //if (mailreturn != "Sucess")
                //{
                //    err_msg = err_msg + "! Mail " + mailreturn;
                //}
            }
            return err_msg;

        }
        #endregion




        //Approval Summary:

        public List<DashBoard> GetDashBoardMyAppval(DashBoard objDashBrd, string type, string ConString)
        {
            List<DashBoard> objDashBoard = new List<DashBoard>();
            DashBoard objModel;
            try
            {
                Hashtable queuelist = new Hashtable();
                Hashtable emplist = new Hashtable();
                int emplistid = 0;
                //emplist.Add(emplistid, userlognid);

                GetConnection(ConString);
                DataTable dtdel = new DataTable();
                cmd = new SqlCommand("Mob_pr_eow_mst_NatureofExpenses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@para1", SqlDbType.Int).Value = objDashBrd.empgid;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "Getdelegateuser";
                da = new SqlDataAdapter(cmd);
                da.Fill(dtdel);
                if (dtdel.Rows.Count > 0)
                {
                    for (int TR = 0; TR < dtdel.Rows.Count; TR++)
                    {
                        if (emplist.Count == 0)
                        {
                            emplist.Add(emplistid, Convert.ToString(dtdel.Rows[TR]["delegate_by"].ToString()));
                        }
                        else
                        {
                            if (!emplist.ContainsValue(Convert.ToString(dtdel.Rows[TR]["delegate_by"].ToString())))
                            {
                                emplistid++;
                                emplist.Add(emplistid, Convert.ToString(dtdel.Rows[TR]["delegate_by"].ToString()));
                            }
                        }
                    }
                }

                emplist.Add(emplistid, objDashBrd.empgid);
                string delegatesuser = "";
                for (int tr = 0; tr < emplist.Count; tr++)
                {
                    delegatesuser = emplist[tr].ToString().Trim();
                    GetConnection(ConString);
                    DataTable dt = new DataTable();
                    cmd = new SqlCommand("Mob_pr_eow_com_formyapprvol", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@employee_gid", SqlDbType.VarChar).Value = delegatesuser;
                    cmd.Parameters.Add("@doctype", SqlDbType.VarChar).Value = type;
                    cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "queueformyapprvolcount";
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    Boolean hierhy = false;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string status = "";
                        hierhy = false;
                        if (dt.Rows[i]["Additional_flag"].ToString() == "Y")
                        {
                            objModel = new DashBoard();
                            objModel.Docnogid = Convert.ToInt32(dt.Rows[i]["queue_gid"].ToString());
                            objModel.Doctypeid = Convert.ToInt32("0");
                            objModel.Docno = Convert.ToString(dt.Rows[i]["ecf_no"].ToString());
                            objModel.DocDate = Convert.ToString(dt.Rows[i]["ecf_date"].ToString());
                            objModel.Docamount = Convert.ToString(dt.Rows[i]["ecf_amount"].ToString());
                            objModel.raiserName = Convert.ToString(dt.Rows[i]["rempname"].ToString());
                            objModel.ecfdescription = Convert.ToString(dt.Rows[i]["ecf_description"].ToString());
                            objModel.DocTypeName = Convert.ToString(dt.Rows[i]["ecf_supplier_employee"].ToString());

                            string emporsupp = Convert.ToString(dt.Rows[i]["ecf_supplier_employee"].ToString());
                            if (emporsupp == "E")
                            {
                                objModel.emporsupp = Convert.ToString(dt.Rows[i]["employeename"].ToString());
                            }
                            else
                            {
                                if (dt.Rows[i]["employeename"].ToString() != "")
                                {
                                    objModel.emporsupp = Convert.ToString(dt.Rows[i]["employeename"].ToString());
                                }
                                else
                                {
                                    objModel.emporsupp = Convert.ToString(dt.Rows[i]["suppliername"].ToString());
                                }
                            }

                            status = Convert.ToString(dt.Rows[i]["queue_action_for"].ToString());
                            objModel.StatusTypeName = objCmnFunctions.GetQueueStatus(status);

                            objModel.ecfselect = "active";
                            objModel.ecfview = "notactive";
                            objModel.ecfprint = "notactive";
                            objModel.ecfprintid = type;
                            objDashBoard.Add(objModel);
                            if (!queuelist.ContainsKey(dt.Rows[i]["queue_gid"].ToString()))
                            {
                                queuelist.Add(dt.Rows[i]["queue_gid"].ToString(), delegatesuser);
                            }
                        }
                        else
                        {
                            string typecheck = dt.Rows[i]["queue_to_type"].ToString();
                            string raiser = dt.Rows[i]["ecf_raiser"].ToString();
                            string supervisor = dt.Rows[i]["queue_to"].ToString();
                            if (typecheck == "E")
                            {
                                //hierhy = Emphery(raiser, supervisor);
                                hierhy = true;
                                //string getempgid = Getempheryname(raiser, "Employee", supervisor);
                                //if (getempgid != "0")
                                //{
                                //    hierhy = true;
                                //}
                            }
                            else if (typecheck == "G")
                            {
                                //hierhy = Gradehery(raiser, supervisor);
                                string getempgid = Getempheryname(raiser, "Grade", supervisor, ConString);
                                if (getempgid != "0")
                                {
                                    if (emplist.ContainsValue(Convert.ToString(getempgid)))
                                    {
                                        hierhy = true;
                                    }
                                }
                            }
                            else if (typecheck == "D")
                            {
                                //hierhy = Deghery(raiser, supervisor);
                                string getempgid = Getempheryname(raiser, "Designation", supervisor, ConString);
                                if (getempgid != "0")
                                {
                                    if (emplist.ContainsValue(Convert.ToString(getempgid)))
                                    {
                                        hierhy = true;
                                    }
                                }
                            }
                            else if (typecheck == "R")
                            {
                                hierhy = true;
                            }
                            //if (dt.Rows[i]["employee_dept_gidnew"].ToString() == queue_toU.ToString())
                            //{
                            if (hierhy == true)
                            {
                                //if (userlognid != raiser)
                                //{
                                objModel = new DashBoard();
                                objModel.Docnogid = Convert.ToInt32(dt.Rows[i]["queue_gid"].ToString());
                                objModel.Doctypeid = Convert.ToInt32("0");
                                objModel.Docno = Convert.ToString(dt.Rows[i]["ecf_no"].ToString());
                                objModel.DocDate = Convert.ToString(dt.Rows[i]["ecf_date"].ToString());
                                objModel.Docamount = Convert.ToString(dt.Rows[i]["ecf_amount"].ToString());
                                objModel.raiserName = Convert.ToString(dt.Rows[i]["rempname"].ToString());
                                objModel.ecfdescription = Convert.ToString(dt.Rows[i]["ecf_description"].ToString());
                                objModel.DocTypeName = Convert.ToString(dt.Rows[i]["ecf_supplier_employee"].ToString());
                                status = Convert.ToString(dt.Rows[i]["queue_action_for"].ToString());
                                objModel.StatusTypeName = objCmnFunctions.GetQueueStatus(status);

                                string emporsupp = Convert.ToString(dt.Rows[i]["ecf_supplier_employee"].ToString());
                                if (emporsupp == "E")
                                {
                                    objModel.emporsupp = Convert.ToString(dt.Rows[i]["employeename"].ToString());
                                }
                                else
                                {
                                    if (dt.Rows[i]["employeename"].ToString() != "")
                                    {
                                        objModel.emporsupp = Convert.ToString(dt.Rows[i]["employeename"].ToString());
                                    }
                                    else
                                    {
                                        if (dt.Rows[i]["employeename"].ToString() != "")
                                        {
                                            objModel.emporsupp = Convert.ToString(dt.Rows[i]["employeename"].ToString());
                                        }
                                        else
                                        {
                                            objModel.emporsupp = Convert.ToString(dt.Rows[i]["suppliername"].ToString());
                                        }
                                    }
                                }

                                objModel.ecfselect = "active";
                                objModel.ecfview = "notactive";
                                objModel.ecfprint = "notactive";
                                objModel.ecfprintid = type;
                                objDashBoard.Add(objModel);
                                if (!queuelist.ContainsKey(dt.Rows[i]["queue_gid"].ToString()))
                                {
                                    queuelist.Add(dt.Rows[i]["queue_gid"].ToString(), delegatesuser);
                                }
                                //}
                            }
                            //}
                        }
                    }
                }
                //HttpContext.Current.Session["Queue_delegateslist"] = queuelist;
                return objDashBoard;
            }
            catch (Exception ex)
            {
                // objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return objDashBoard;
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }

        public string Getempheryname(string empgid, string titlevalue, string titlegid, string ConString)
        {
            string status = "";
            try
            {
                if (empgid != "" && titlegid != "")
                {
                    GetConnection(ConString);
                    cmd = new SqlCommand("Mob_pr_chk_employee_hierarchy", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@employee_gid", SqlDbType.Int).Value = Convert.ToInt32(empgid.ToString());
                    cmd.Parameters.Add("@title_value_gid", SqlDbType.Int).Value = Convert.ToInt32(titlegid.ToString());
                    cmd.Parameters.Add("@title_name", SqlDbType.VarChar).Value = titlevalue.ToString();

                    cmd.Parameters.Add("@title_employee_gid", SqlDbType.Int, 64);
                    cmd.Parameters["@title_employee_gid"].Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@pr_err_output", SqlDbType.VarChar, 10000);
                    cmd.Parameters["@pr_err_output"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    var result = Convert.ToString(cmd.Parameters["@title_employee_gid"].Value);
                    var sqlerrors = Convert.ToString(cmd.Parameters["@pr_err_output"].Value);
                    status = result.ToString();
                }
                return status;
            }
            catch (Exception ex)
            {
                //objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }


        //concurrent login to approve

        public string Insertapprovedactioncon(Approveraction EmployeeeExpense, string EcfConcurrentApprovalreject, string EcfApproved, string EcfConcurrentApproval, string EcfRejected, string EcfConcurrentApprovalnotapp, string EcfConcurrentApprovalappred, string ConString)
        {
            string statuss = "error";
            try
            {
                string Remarks = "";
                string EcfConcurrentApprovald = "";
                int docsubtype_gid = 0;
                int maxqueue = 0;
                string mailappstatus = "R"; // Pandiaraj 28-12-2018
                if (EmployeeeExpense.Rejecthold == null)
                {
                    Remarks = "";
                }
                else
                {
                    Remarks = EmployeeeExpense.Rejecthold;
                }


                if (EmployeeeExpense.status == "Approve" || EmployeeeExpense.status == "NotApplicable")
                {
                    mailappstatus = "A"; // Pandiaraj 28-12-2018
                    if (EmployeeeExpense.status == "NotApplicable")
                    {
                        EcfConcurrentApprovald = EcfConcurrentApprovalnotapp;
                    }
                    else
                    {
                        EcfConcurrentApprovald = EcfConcurrentApprovalappred;
                    }
                }
                else
                {
                    mailappstatus = "R";
                }

                GetConnection(ConString);
                cmd = new SqlCommand("Insertapprovedaction_concurrent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ecf_gid", SqlDbType.Int).Value = Convert.ToInt32(EmployeeeExpense.EcfGid.ToString());
                //cmd.Parameters.Add("@invoicegid", SqlDbType.Int).Value = Convert.ToInt32(invoicegid.ToString());
                cmd.Parameters.Add("@invoicegid", SqlDbType.Int).Value = string.IsNullOrEmpty(EmployeeeExpense.invoiceGid.ToString()) ? 0 : Convert.ToInt32(EmployeeeExpense.invoiceGid);
                cmd.Parameters.Add("@empgid", SqlDbType.Int).Value = Convert.ToInt32(EmployeeeExpense.empgid.ToString());
                cmd.Parameters.Add("@ecftype", SqlDbType.VarChar).Value = EmployeeeExpense.EcfType;
                cmd.Parameters.Add("@queue_gid", SqlDbType.Int).Value = Convert.ToInt32(EmployeeeExpense.QueueGid.ToString());

                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
                cmd.Parameters.Add("@EcfApproved", SqlDbType.VarChar).Value = EcfApproved;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = EmployeeeExpense.status;
                cmd.Parameters.Add("@EcfConcurrentApprovald", SqlDbType.VarChar).Value = EcfConcurrentApprovald;
                cmd.Parameters.Add("@EcfConcurrentApprovalreject", SqlDbType.VarChar).Value = EcfConcurrentApprovalreject;
                cmd.Parameters.Add("@EcfRejected", SqlDbType.VarChar).Value = EcfRejected;

                cmd.Parameters.Add("@docsubtype_gid", SqlDbType.Int, 64);
                cmd.Parameters["@docsubtype_gid"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@maxqueue", SqlDbType.Int, 64);
                cmd.Parameters["@maxqueue"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@constatus", SqlDbType.VarChar, 20);
                cmd.Parameters["@constatus"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                docsubtype_gid = Convert.ToInt32(cmd.Parameters["@docsubtype_gid"].Value);
                maxqueue = Convert.ToInt32(cmd.Parameters["@maxqueue"].Value);
                statuss = cmd.Parameters["@constatus"].Value.ToString();
                string doctypeid = docsubtype_gid.ToString();
                string max_queue = maxqueue.ToString();
                doctypeid = objCmnFunctions.GetSubDocType(doctypeid);
                // string mailstatus = mailsender.sendusermail("EOW", doctypeid, max_queue, mailappstatus, "0");

            }
            catch (Exception ex)
            {
                // objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                //return "";
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
            return statuss;
        }


    }
}
