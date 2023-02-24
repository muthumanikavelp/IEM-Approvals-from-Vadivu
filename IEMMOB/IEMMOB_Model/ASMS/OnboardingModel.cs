using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMMOB_Model.ASMS
{
    public class OnboardingModel
    {
        public class Employee 
            {

            public string Employee_Gid { get; set; }
            public string Employee_Code { get; set; }
            public string Employee_Name { get; set; }
            public string Employee_mobileno { get; set; }
            public string Employee_Designation { get; set; }
            

            public string sqlcon { get; set; }
            public string ConnectionString { get; set; }
        }
    }
}
