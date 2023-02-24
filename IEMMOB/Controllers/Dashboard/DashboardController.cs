using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IEMMOB.Helper;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using static IEMMOB_Model.ASMS.OnboardingModel;
using Microsoft.Extensions.Options;
using static IEMMOB_Model.Dashboard.Dashboard_Model;
using static IEMMOB_Model.EOW.EOW_Employee;
using IEMMOB_Model.EOW;
using IEMMOB.Controllers.EOW;
using IEMMOB_DataModel.EOW;
using Microsoft.Extensions.Logging;
using IEMMOB_DataModel.Common;

namespace IEMMOB.Controllers.Dashboard
{
    [Route("api/Dashboard/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {


        #region Declaration
        proLib plib = new proLib();
        dbLib db = new dbLib();
        CmnFunctions objCmnFunctions = new CmnFunctions();
        DataTable dt = new DataTable();
        #endregion


        private readonly IOptions<Employee> appSettings;
        string ConString;
        private IConfiguration _configuration;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        public object logger { get; private set; }

        public DashboardController(IOptions<Employee> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.sqlcon;
            _configuration = configuration;
        }
        #region Dashboard
        [HttpPost("ASMSCount")]
        public List<ASMSCount> GetASMSDashboardCount(string EmployeeCode,string RaierGid,String raisermode)  // Dashboard bind 
        {
            try
            {
                 
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(this.appSettings.Value);
                dt = db.GetASMSDashboardCount(EmployeeCode.ToString(),RaierGid.ToString(), raisermode, ConString);
                 ASMSCount ObjmodelAsmsDashboard = new ASMSCount(); //objmodel
                List<ASMSCount> ObjmodelAsmsDashboardList = new List<ASMSCount>(); //objmodel
                foreach (DataRow dr in dt.Rows)
                {
                    ObjmodelAsmsDashboardList.Add
                        (
                        new ASMSCount
                        {
                            supplierheaderrequesttype = (dr["supplierheaderrequesttype"].ToString()),
                            draft = dr["draft"].ToString(),
                            inprocess = dr["inprocess"].ToString(),
                            approved = dr["approved"].ToString(),
                            rejected = (dr["rejected"].ToString()),
                            waitingforapproval = dr["waitingforapproval"].ToString(),

                        });
                }
                return ObjmodelAsmsDashboardList;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [HttpPost("EOWCount")]
        public List<EOWCount> GetEOWDashboardCount(string EmployeeCode, string RaierGid, String raisermode)  // Dashboard bind 
        {
            try
            {
                
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(this.appSettings.Value);
                 dt = db.GetEOWDashboardCount(EmployeeCode.ToString(), RaierGid.ToString(), raisermode, ConString);
                  EOWCount ObjmodelEOWDashboard = new EOWCount(); //objmodel
                List<EOWCount> ObjmodelEOWDashboardList = new List<EOWCount>(); //objmodel
                foreach (DataRow dr in dt.Rows)
                {
                    ObjmodelEOWDashboardList.Add
                        (
                        new EOWCount
                        {
                            Claim = (dr["CLAIM"].ToString()),
                            Draft = dr["DRAFT"].ToString(),
                            Cancelled = dr["CANCELLED"].ToString(),
                            Inprocess = dr["INPROCESS"].ToString(),
                            Approved = (dr["APPROVED"].ToString()),
                            Rejected = dr["REJECTED"].ToString(),
                            Paid = dr["PAID"].ToString(),
                            FormyApproval = dr["ForMyApproval"].ToString(),

                        });
                }
                return ObjmodelEOWDashboardList;

            }
            catch (Exception ex)
            {
                return null;
            }

        }


        //Eprocure Count
        [HttpPost("EProcureCount")]
        public List<EProcureCount> GetEProcureDashboardCount(string EmployeeCode, string RaierGid, String raisermode)  // Dashboard bind 
        {
            try
            {
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(this.appSettings.Value);
                dt = db.GetEProcureDashboardCount(EmployeeCode.ToString(), RaierGid.ToString(), raisermode, ConString);

                EProcureCount ObjmodelEOWDashboard = new EProcureCount(); //objmodel
                List<EProcureCount> ObjmodelEOWDashboardList = new List<EProcureCount>(); //objmodel
                foreach (DataRow dr in dt.Rows)
                {
                    ObjmodelEOWDashboardList.Add
                        (
                        new EProcureCount
                        {
                            Category = (dr["CATEGORY"].ToString()),
                            Draft = dr["DRAFT"].ToString(),
                            Inprocess = dr["INPROCESS"].ToString(),
                            Approved = (dr["APPROVED"].ToString()),
                            Rejected = dr["REJECTED"].ToString(),
                         });
                }
                return ObjmodelEOWDashboardList;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string GetCountOfForMyApproval(string employee_gid, string doctype)
        {
            try
            {
                DataTable dt;
                string Data1 = "0";
                DataSet ds = db.GetCountOfForMyApproval(employee_gid, doctype);
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0) { Data1 = ds.Tables[0].Rows[0][0].ToString(); }
                }
                return Data1;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        #endregion
         
    }
}
