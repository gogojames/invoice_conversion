using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceConversion.Data
{
    [Serializable]
   public class Customer:Common.BusinessObjectBase
    {
        private string client_id;

        public string Client_id
        {
            get { return client_id; }
            set { client_id = value; }
        }
        private string clent_n;

        public string Clent_n
        {
            get { return clent_n; }
            set { clent_n = value; }
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
    }
}
