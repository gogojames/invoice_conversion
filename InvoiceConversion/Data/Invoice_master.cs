using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceConversion.Data
{
    [Serializable]
   public class Invoice_master:Common.BusinessObjectBase
    {
        private string client_id;

        public string Client_id
        {
            get { return client_id; }
            set {
                if (client_id != value)
                {
                    if (this.InEdit)
                    {
                        SaveState("Client_id", client_id);
                        SaveData("Client_id", value);
                    }
                    client_id = value;
                    OnPropertyChanged("Client_id");
                }
                 }
        }
        private string client_name;

        public string Client_name
        {
            get { return client_name; }
            set {
                if (client_name != value)
                {
                    if (this.InEdit)
                    {
                        SaveState("Client_name", client_name);
                        SaveData("Client_name", value);
                    }
                    client_name = value;
                    OnPropertyChanged("Client_name");
                }
            }
        }
        private string invoice_nmber;

        public string Invoice_nmber
        {
            get { return invoice_nmber; }
            set {
                if (invoice_nmber != value)
                {
                    if (this.InEdit)
                    {
                        SaveState("Invoice_nmber", invoice_nmber);
                        SaveData("Invoice_nmber", value);
                    }

                    invoice_nmber = value;
                    OnPropertyChanged("Invoice_nmber");
                }
            }
        }
        private int invoice_title_id;

        public int Invoice_title_id
        {
            get { return invoice_title_id; }
            set {
                if (invoice_title_id != value)
                {
                    if (InEdit)
                    {
                        SaveState("Invoice_title_id", invoice_title_id);
                        SaveData("Invoice_title_id", value);
                    }
                    invoice_title_id = value;
                    OnPropertyChanged("Invoice_title_id");
                }
                }
        }
        private string ainvoice_id;

        public string Ainvoice_id
        {
            get { return ainvoice_id; }
            set {
                if (ainvoice_id != value)
                {
                    if (InEdit)
                    {
                        SaveState("Ainvoice_id", ainvoice_id);
                        SaveData("Ainvoice_id", value);
                    }
                    ainvoice_id = value;
                    OnPropertyChanged("Ainvoice_id");
                }
                }
        }
        private string remake;

        public string Remake
        {
            get { return remake; }
            set {
                if (remake != value)
                {
                    if (InEdit)
                    {
                        SaveState("Remake", remake);
                        SaveData("Remake", value);
                    }
                    remake = value;
                    OnPropertyChanged("Remake");
                }
                }
        }
        private DateTime invoice_date;

        public DateTime Invoice_date
        {
            get { return invoice_date; }
            set
            {
                if (invoice_date != value)
                {
                    if (InEdit)
                    {
                        SaveState("Invoice_date", invoice_date);
                        SaveData("Invoice_date", value);
                    }
                    invoice_date = value;
                    OnPropertyChanged("Invoice_date");
                }
            }
        }
    }
}
