using IEMMOB_Model.EOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IEMMOB_Model.ASMS.OnboardingModel;

namespace IEMMOB.Controllers
{
    public class AllConnectionString
    {
        public string getRightConString(Employee obj)
        {
            string rightConString = "";
             
                rightConString = obj.ConnectionString;
            
            
            return rightConString;

        }

        
    }
}
