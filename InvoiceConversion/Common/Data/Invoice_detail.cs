using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceConversion.Data
{
    [Serializable]
   public class Invoice_detail:Common.BusinessObjectBase
    {
        public override string ToString()
        {
            return "Invoice_detail";
        }
        private int detail_id;

        public int Detail_id
        {
            get { return detail_id; }
            set {
                if (detail_id != value)
                {
                    if (InEdit)
                    {
                        SaveState("detail_id", detail_id);
                        SaveData("detail_id", value);
                    }
                    detail_id = value;
                    OnPropertyChanged("detail_id");
                }

                }
        }
        private string invoice_nmber;

        public string Invoice_nmber
        {
            get { return invoice_nmber; }
            set
            {
                if (invoice_nmber != value)
                {
                    if (InEdit)
                    {
                        SaveState("invoice_nmber", invoice_nmber);
                        SaveData("invoice_nmber", value);
                    }
                    invoice_nmber = value;
                    OnPropertyChanged("invoice_nmber");
                }
            }
        }
        private string aInvoice_id;

        public string AInvoice_id
        {
            get { return aInvoice_id; }
            set {
                if (aInvoice_id != value)
                {
                    if (InEdit)
                    {
                        SaveState("AInvoice_id", aInvoice_id);
                        SaveData("AInvoice_id", value);
                    }
                    aInvoice_id = value;
                    OnPropertyChanged("AInvoice_id");
                }
                }
        }
        private float item_id;

        public float Item_id
        {
            get { return item_id; }
            set {
                if (item_id != value)
                {
                    if (InEdit)
                    {
                        SaveState("Item_id", item_id);
                        SaveData("Item_id", value);
                    }
                    item_id = value;
                    OnPropertyChanged("Item_id");
                }
                }
        }
        private float rpice;

        public float Rpice
        {
            get { return rpice; }
            set {
                if (rpice != value)
                {
                    if (InEdit)
                    {
                        SaveState("Rpice", rpice);
                        SaveData("Rpice", value);
                    }
                    rpice = value;
                    OnPropertyChanged("Rpice");
                }
                }
        }
        private string unit;

        public string Unit
        {
            get { return unit; }
            set {
                if (unit != value)
                {
                    if (InEdit)
                    {
                        SaveState("Unit", unit);
                        SaveData("Unit", value);
                    }
                    unit = value;
                    OnPropertyChanged("Unit");
                }
                }
        }
        private float qty;

        public float Qty
        {
            get { return qty; }
            set {
                if (qty != value)
                {
                    if (InEdit)
                    {
                        SaveState("Qty", qty);
                        SaveData("Qty", value);
                    }
                    qty = value;
                    OnPropertyChanged("Qty");
                }
                }
        }

        private string item_name;

        public string Item_name
        {
            get { return item_name; }
            set {
                if (item_name != value)
                {
                    if (InEdit)
                    {
                        SaveState("Item_name", item_name);
                        SaveData("Item_name", value);
                    }
                    item_name = value;
                    OnPropertyChanged("Item_name");
                }
            }
        }

        private string remake;

        public string Remake
        {
            get { return remake; }
            set
            {
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

        private float money;

        public float Money
        {
            get {
                money = this.Rpice * this.Qty;
                return money; }
            private set { money = value; }
        }

    }
}
