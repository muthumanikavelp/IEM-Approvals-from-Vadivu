using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
//using IEMMOB.Common;
using IEMMOB.Helper;
using IEMMOB_DataModel.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IEMMOB.Controllers.EOW
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeClaimNewController : ControllerBase
    {

        #region Variables
          proLib plib = new proLib();
        dbLib db = new dbLib();
        CmnFunctions objCmnFunctions = new CmnFunctions();
        #endregion
 
    }
}
