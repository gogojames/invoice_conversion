﻿using System;
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
        private double rpice;

        public double Rpice
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
        private double qty;

        public double Qty
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

    }
}