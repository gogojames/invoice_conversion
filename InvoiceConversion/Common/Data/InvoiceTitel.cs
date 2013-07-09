using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceConversion.Data
{
    [Serializable]
  public  class InvoiceTitel:Common.BusinessObjectBase
    {
        public override string ToString()
        {
            return "invoiceTitel";
        }
        private string company_name;

        public string Company_name
        {
            get { return company_name; }
            set {
                if (company_name != value)
                {
                    if (InEdit)
                    {
                        SaveState("Company_name", company_name);
                        SaveData("Company_name", value);
                    }
                    company_name = value;
                    OnPropertyChanged("Company_name");
                }
                }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set {
                if (address != value)
                {
                    if (InEdit)
                    {
                        SaveState("Address", address);
                        SaveData("Address", value);
                    }

                    address = value;
                    OnPropertyChanged("Address");
                }
                }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set {
                if (phone != value)
                {
                    SaveState("Phone", phone);
                    SaveData("Phone", value);
                }
                phone = value;
                OnPropertyChanged("Phone");
            }
        }
        private string fax;

        public string Fax
        {
            get { return fax; }
            set {
                if (fax != value)
                {
                    if (InEdit)
                    {
                        SaveState("Fax", fax);
                        SaveData("Fax", value);
                    }

                    fax = value;
                    OnPropertyChanged("Fax");
                }
                }
        }
        private string e_mail;

        public string E_mail
        {
            get { return e_mail; }
            set {
                if (e_mail != value)
                {
                    if (InEdit)
                    {
                        SaveState("E_mail", e_mail);
                        SaveData("E_mail", value);
                    }
                    e_mail = value;
                    OnPropertyChanged("E_mail");
                }
                }
        }

        private int company_id;

        public int Company_id
        {
            get { return company_id; }
            set {
                if (value != company_id)
                {
                    if (InEdit)
                    {
                        SaveState("Company_id", company_id);
                        SaveData("Company_id", value);
                    }
                    company_id = value;
                    OnPropertyChanged("Company_id");
                }
                }
        }
    }
}
