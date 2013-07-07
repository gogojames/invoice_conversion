using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceConversion.Data
{
    [Serializable]
  public  class Company
    {
        private string company_name;

        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }
        private int company_id;

        public int Company_id
        {
            get { return company_id; }
            set { company_id = value; }
        }
    }
}
