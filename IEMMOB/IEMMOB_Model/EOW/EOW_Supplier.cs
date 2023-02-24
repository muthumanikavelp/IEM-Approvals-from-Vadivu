using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IEMMOB_Model.EOW
{
   public class EOW_Supplier
    {
    }

    public class EOW_Supplierinvoice
    {
        public string ecfraisergid { get; set; }
        public string ecfstatus { get; set; }
        public string Raiser_Code { get; set; }
        public string Raiser_Mode { get; set; }
        public string Raiser_Name { get; set; }
        public string ECF_Date { get; set; }
        public string Grade { get; set; }
        public string ECF_Amount { get; set; }
        public string ecfno { get; set; }

        public SelectList Raiser_Modedata { get; set; }
        public string raisermodeId { get; set; }
        public string raisermodeName { get; set; }

        public string ecfremark { get; set; }

        public string Suppliergid { get; set; }
        public string Suppliercode { get; set; }
        public string Suppliername { get; set; }

        public SelectList doctypedata { get; set; }
        public string DocId { get; set; }
        public string DocName { get; set; }

        public SelectList Currencydata { get; set; }
        public string CurrencyId { get; set; }
        public string CurrencyName { get; set; }

        public string Exrate { get; set; }
        public string Currencyamount { get; set; }

        public string amort { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string amortdec { get; set; }

        public int chkraiser_gid { get; set; }
        public int ecf_GID { get; set; }
        public int Queue_GID { get; set; }
        public int Doctypeid { get; set; }
        public string queueactionfor { get; set; }
        public string ecfdescription { get; set; }


        public Int32 expsubcat_gid { get; set; }
        public Int32 expsubcat_expnature_gid { get; set; }
        public int selectedexpsubcat_expnature_gid { get; set; }
        public Int32 expsubcat_expcat_gid { get; set; }
        public string expsubcat_code { get; set; }
        public string expsubcat_name { get; set; }
        public string expsubcat_help { get; set; }
        public string expsubcat_active { get; set; }
        public Int32 expsubcat_insert_by { get; set; }
        public DateTime expsubcat_insert_date { get; set; }
        public Int32 expsubcat_update_by { get; set; }
        public DateTime expsubcat_update_date { get; set; }
        public string expsubcat_isremoved { get; set; }
        public int selectedexpcat_gid { get; set; }
        public Int32 expcat_gid { get; set; }
        public string expcat_name { get; set; }
        public string expcat_code { get; set; }
         public SelectList Getexpcat { get; set; }
        public SelectList GetexpcatById { get; set; }

        public Int32 expnature_gid { get; set; }
        public string expnature_name { get; set; }
         public SelectList Getexpnature { get; set; }
        public SelectList GetexpnatureById { get; set; }
        ////IEM_GST_PAHSE3
        public string ecf_Paymode { get; set; }
        public string CygnetFlag { get; set; }



        //add connection string

        public string sqlcon { get; set; }
        public string ConnectionString { get; set; }
    }
}
