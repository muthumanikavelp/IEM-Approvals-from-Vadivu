using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMMOB_Model.Dashboard
{
  public  class Dashboard_Model
    {
        //ASMS Count
        public class ASMSCount
        {
            public string supplierheaderrequesttype { get; set; }
            public string draft { get; set; }
            public string inprocess { get; set; }
            public string approved { get; set; }
            public string rejected { get; set; }
            public string waitingforapproval { get; set; }


            public string sqlcon { get; set; }
            public string ConnectionString { get; set; }

        }
        //EOW Count

        public class EOWCount
        {
            public string Claim { get; set; }
            public string Draft { get; set; }
            public string Cancelled { get; set; }
            public string Inprocess { get; set; }
            public string Approved { get; set; }
            public string Rejected { get; set; }
            public string Paid { get; set; }
            public string FormyApproval { get; set; }
        }

        //EProcure Count

        public class EProcureCount
        {
            public string Category { get; set; }
            public string Draft { get; set; }
            public string Inprocess { get; set; }
            public string Approved { get; set; }
            public string Rejected { get; set; }
        }
    }
}
