
using IEMMOB_Model.ASMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IEMMOB_Model.ASMS.OnboardingModel;
//using static IEMMOB_Model.ASMS.OnboardingModel;




namespace IEMMOB_DataModel.ASMS
{
    public class Onboarding_DataModel
    {
        private SqlConnection con;



        public DataConnection sqlCon;

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

       
        public Employee GetEmployeeList(string ConString)
        {
            Employee objList = new Employee();   
            //sqlCon = new DataConnection(ConString);
            SqlCommand cmd = new SqlCommand("ASMS_MOB_SampleEmployeeList");
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                objList.Employee_Gid = (dt.Rows[i]["employee_gid"].ToString().ToString());
                objList.Employee_Code = (dt.Rows[i]["employee_code"].ToString());
                objList.Employee_Name = dt.Rows[i]["employee_name"].ToString();
                objList.Employee_mobileno = dt.Rows[i]["employee_mobile_no"].ToString();
                objList.Employee_Designation = dt.Rows[i]["employee_iem_designation"].ToString();
            }
            return objList;
        }
    }
}
