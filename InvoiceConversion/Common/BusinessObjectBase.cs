using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;

namespace InvoiceConversion.Common
{
    public class BusinessObjectBase : AutoSqlExc, IDataErrorInfo, INotifyPropertyChanged, IEditableObject
    {
        private Dictionary<string, string> _errors;

        protected Dictionary<string, string> Errors
        {
            get
            {
                if (null == _errors)
                    _errors = new Dictionary<string, string>();
                return _errors;
            }
        }
        private Dictionary<string, object> _edits;

        protected Dictionary<string, object> Edits
        {
            get
            {
                if (null == _edits)
                    _edits = new Dictionary<string, object>();
                return _edits;
            }
        }

        private PropertyDescriptorCollection _shape;

        protected PropertyDescriptorCollection Shape
        {
            get
            {
                if (null == _shape)
                    _shape = TypeDescriptor.GetProperties(this);
                return _shape;
            }
        }

        private bool _inEdit = false;

        [Browsable(false)]
        public bool InEdit
        {
            get { return _inEdit; }
            private set { _inEdit = value; }
        }

        #region IDataErrorInfo 成员

        string IDataErrorInfo.Error
        {
            get { return ((Errors.Count > 0) ? "業務處於無效狀態." : string.Empty); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get { return GetColumnError(columnName); }
        }

        protected string GetColumn(string column)
        {
            string col = ((null == column) ? null : column.Trim().ToLower());
            if (string.IsNullOrEmpty(column) || (null == Shape.Find(col, true)))
                throw new ArgumentException("沒有找列名: " + column);
            return col;
        }

        protected void SetColumnError(string column, string error)
        {
            string col = GetColumn(column);
            if (null == error)
                Errors.Remove(col);
            else
                Errors[col] = error;

        }

        protected void ClearColumnError()
        {
            ClearColumnError(null);
        }

        protected void ClearColumnError(string column)
        {
            if (string.IsNullOrEmpty(column))
                Errors.Clear();
            else
                SetColumnError(column, null);
        }


        protected string GetColumnError(string column)
        {
            string col = GetColumn(column);
            return (Errors.ContainsKey(col) ? Errors[col] : null);
        }

        #endregion

        #region INotifyPropertyChanged 成员

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (null != PropertyChanged && !this.InEdit)
                PropertyChanged(this, e);
        }

        protected void FireRowResetEvent()
        {
            OnPropertyChanged(string.Empty);
        }

        #endregion

        #region IEditableObject 成员
        /// <summary>
        /// 保存修改前的状态
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        protected virtual void SaveState(string propertyName, object value)
        {
            if (!Edits.ContainsKey(propertyName))
            {
                Edits[propertyName] = value;
            }
            else if (((Edits[propertyName] != null) && Edits[propertyName].Equals(value)) || (Edits[propertyName] == value))
            {
                /* Reset to the original value back to itself - remove the key */
                Edits.Remove(propertyName);
            }
        }

        protected virtual void RollbackChanges()
        {
            if (Edits.Count > 0)
            {
                PropertyDescriptor pd;

                foreach (KeyValuePair<string, object> edit in Edits)
                {
                    /* Find property */
                    pd = Shape.Find(edit.Key, true);

                    /* Should always be found */
                    Debug.Assert(null != pd, "沒有發現屬性名: " + edit.Key);

                    if (null != pd)
                    {
                        pd.SetValue(this, edit.Value);
                    }
                }

                /* Reset edits */
                Edits.Clear();
            }
        }

        protected virtual void OnBeginEdit()
        {
            /* Allow sub-class to provide custom implementation */
            this.InEdit = true;
        }

        public void BeginEdit()
        {
            OnBeginEdit();
        }

        protected virtual void OnCancelEdit()
        {
            /* If in edit mode */
            if (this.InEdit)
            {
                /* Rollback */
                RollbackChanges();

                ClearData();

                /* Reset */
                this.InEdit = false;

                /* Reset Event */
                FireRowResetEvent();
            }
        }

        public void CancelEdit()
        {
            OnCancelEdit();
        }

        protected virtual void OnEndEdit()
        {
            if (this.InEdit)
            {
                /* Reset */
                this.InEdit = false;

                /* Check if there were changes */
                if (Edits.Count > 0)
                {
                    /* Clear Edits */
                    Edits.Clear();
                    /* Fire Reset Event */
                    FireRowResetEvent();
                }
            }
        }

        public void EndEdit()
        {
            OnEndEdit();
        }

        #endregion
    }
}
