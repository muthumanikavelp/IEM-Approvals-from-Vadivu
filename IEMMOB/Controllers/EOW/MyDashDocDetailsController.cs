using System.Collections.Generic;
using System.Linq;
using IEMMOB_DataModel.Common;
using IEMMOB_DataModel.EOW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static IEMMOB_Model.EOW.EOW_Employee;

namespace IEMMOB.Controllers.EOW
{
    [Route("api/EOW/[controller]")]
    [ApiController]
    public class MyDashDocDetailsController : ControllerBase
    {

        CmnFunctions objCmnFunctions = new CmnFunctions();
        EOW_DataModel objModel = new EOW_DataModel();

        private EOW_DataModel eOW_DataModel;
        private readonly IOptions<DashBoard> appSettings;
        string ConString;
        private IConfiguration _configuration;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        public MyDashDocDetailsController(IOptions<DashBoard> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.sqlcon;
            _configuration = configuration;
        }

        [HttpPost("GetSummary")]
        public List<DashBoard> ToGetecfdoccount(DashBoard objDashBoard)
        {
             
            DashBoard objDashBard = new DashBoard();
            List<DashBoard> lstDashBoard = new List<DashBoard>();
            EOW_DataModel objModel = new EOW_DataModel();
            this.ConString = _configuration.GetSection("ConnectionString")["ConnectionString"].ToString();


            if (objDashBoard.requesttype == "EMPLOYEE CLAIMS")
            {

                if (objDashBoard.reqstatus == "forapproval")
                {
                    lstDashBoard = objModel.GetDashBoardMyAppval(objDashBoard, "1", ConString).ToList();
                }

            }
            if (objDashBoard.requesttype == "SUPPLIER INVOICE")
            {

                if (objDashBoard.reqstatus == "forapproval")
                {
                    lstDashBoard = objModel.GetDashBoardMyAppval(objDashBoard, "3", ConString).ToList();
                }

            }
            if (objDashBoard.requesttype == "ADVANCE REQUEST")
            {
                if (objDashBoard.reqstatus == "forapproval")
                {
                    lstDashBoard = objModel.GetDashBoardMyAppval(objDashBoard, "2", ConString).ToList();
                }
            }


            if (objDashBoard.requesttype == "INSURANCE")
            {
                if (objDashBoard.reqstatus == "forapproval")
                {
                    lstDashBoard = objModel.GetDashBoardMyAppval(objDashBoard, "4", ConString).ToList();
                }
            }

            if (objDashBoard.requesttype == "INSURANCE ADVANCE")
            {
                if (objDashBoard.reqstatus == "forapproval")
                {
                    lstDashBoard = objModel.GetDashBoardMyAppval(objDashBoard, "5", ConString).ToList();
                }
            }
            return lstDashBoard;
        }
    }
}
