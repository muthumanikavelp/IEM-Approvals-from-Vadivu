using IEMMOB_DataModel.ASMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IEMMOB_Model.ASMS.OnboardingModel;
using System.Data.SqlClient;

namespace IEMMOB_Service.ASMS
{
  public  class Onboarding_Service
    {
        Onboarding_DataModel ObjDatamodel = new Onboarding_DataModel();  //datamodel obj
        Employee Objmodel = new Employee(); //Employee Obj
        public Employee GetEmployeeList(string ConString)
        {
            Objmodel = ObjDatamodel.GetEmployeeList(ConString);
            return Objmodel;
        }
    }
}
