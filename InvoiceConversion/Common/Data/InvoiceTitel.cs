using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceConversion.Data
{
    [Serializable]
  public  class InvoiceTitel:Common.BusinessObjectBase
    {
        private string company_name;

        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string fax;

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        private string e_mail;

        public string E_mail
        {
            get { return e_mail; }
            set { e_mail = value; }
        }

        private int company_id;

        public int Company_id
        {
            get { return company_id; }
            set { company_id = value; }
        }
    }
}
