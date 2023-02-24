using IEMMOB_Service.ASMS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IEMMOB_Model.ASMS.OnboardingModel;

namespace IEMMOB.Controllers.ASMS
{
    [Route("api/ASMS/[controller]")]
    [ApiController]
    public class OnboardingController : ControllerBase
    {
        private readonly IOptions<Employee> appSettings;
        string ConString;
        private IConfiguration _configuration;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        Employee Objmodel = new Employee();  //employee model Obj
        Onboarding_Service ObjService = new Onboarding_Service(); //Onboarding Service Obj

        public OnboardingController(IOptions<Employee> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.sqlcon;
            _configuration = configuration;
        }

        //Get Employee List
        [HttpGet("EmployeeList")]
        public Employee GetEmployee()
        {
            try
            {
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(this.appSettings.Value);
                Objmodel = ObjService.GetEmployeeList(ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Objmodel;
        }
    }
}
