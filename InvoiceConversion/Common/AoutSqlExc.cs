using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceConversion.Common
{
    public partial class AutoSqlExc
    {
        bool _isKeyCol = false;

        [System.ComponentModel.Browsable(false)]
        public bool IsKeyCol
        {
            get { return _isKeyCol; }
            set { _isKeyCol = value; }
        }

        string _sql = string.Empty;

        protected string Sql
        {
            get { return _sql; }
            set { _sql = value; }
        }
        string _propertyName;

        protected string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        object _values;

        protected object Values
        {
            get { return _values; }
            set { _values = value; }
        }

        Dictionary<string, object> _edited;

        protected Dictionary<string, object> Edited
        {
            get
            {
                if (null == _edited)
                    _edited = new Dictionary<string, object>();
                return _edited;
            }

        }

        public AutoSqlExc(string propertyName, object value)
            : base()
        {
            string column = (null == propertyName) ? null : propertyName.Trim().ToLower();
            if (string.IsNullOrEmpty(column) && null == value)
                return;
            _propertyName = column;
            _values = value;
        }

        public AutoSqlExc()
            : this(string.Empty, null)
        { }

        protected void SaveData()
        {
            string column = (null == PropertyName) ? null : PropertyName.Trim().ToLower();
            if (string.IsNullOrEmpty(column))
                throw new ArgumentException("無效的列名: " + column);

            if (Edited.ContainsKey(column))
            {
                Edited.Remove(column);
            }
            Edited[column] = Values;
        }

        protected void SaveData(string propertyName, object value)
        {
            _propertyName = propertyName;
            _values = value;
            this.SaveData();
        }

        protected void ClearData()
        {
            if (Edited.Count > 1)
                Edited.Clear();
        }

        object[] _parameter;

        public object[] Parameter
        {
            get
            {
                if (null == _parameter)
                {
                    if (0 != Edited.Count && null != Edited)
                    {
                        int c = Edited.Count * 2;
                        _parameter = new object[c];
                    }
                }
                return _parameter;
            }
            private set
            {

                _parameter = value;
            }
        }

        public string GetSqlQuery(Common.Basic.FormMode formMode, string column)
        {

            int m = 0;
            int n = 1;
            string _whereCol = string.Empty;
            string _setCol = string.Empty;
            string _intoCol = string.Empty;
            string _intovaluesCol = string.Empty;

            switch (formMode)
            {
                case Common.Basic.FormMode.browseMode:
                    _sql = @"select * from " + this.ToString();
                    break;
                case Common.Basic.FormMode.deleteMode:
                    if (0 == Edited.Count)
                        return string.Empty;
                    m = 0;
                    object[] objs = new object[2];
                    foreach (KeyValuePair<string, object> edit in Edited)
                    {
                        if (edit.Key == column.Trim().ToLower())
                        {
                            _whereCol = edit.Key + "=@" + edit.Key;
                            objs[m] = "@" + edit.Key;
                            int y = m + 1;
                            objs[y] = edit.Value;
                            m = y + 1;
                            break;
                        }
                    }
                    Parameter = objs;
                    _sql = @"delete from " + this.ToString() + " where (" + _whereCol + ")";
                    break;
                case Common.Basic.FormMode.modifyMode:
                    if (0 == Edited.Count)
                        return string.Empty;
                    n = 1;
                    m = 0;
                    foreach (KeyValuePair<string, object> edit in Edited)
                    {
                        if (edit.Key != column.Trim().ToLower())
                        {
                            if (Edited.Count > n)
                            {
                                _setCol += edit.Key + "=@" + edit.Key + ", ";
                            }
                            else if (Edited.Count == n)
                            {
                                _setCol += edit.Key + "=@" + edit.Key + " ";
                            }

                        }
                        else
                        {
                            _whereCol = edit.Key + "=@" + edit.Key;
                        }
                        int y = 0;
                        if (Parameter.Length > m)
                        {
                            Parameter[m] = "@" + edit.Key;
                            y = m + 1;

                            Parameter[y] = edit.Value;
                        }
                        m = y + 1;

                        n++;
                    }

                    _sql = @"update " + this.ToString() + " set " + _setCol.Remove(_setCol.LastIndexOf(','),1) + " where (" + _whereCol + ")";
                    break;
                case Common.Basic.FormMode.newMode:
                    if (0 == Edited.Count)
                        return string.Empty;
                    n = 1;
                    m = 0;
                    foreach (KeyValuePair<string, object> edit in Edited)
                    {
                        if (IsKeyCol && edit.Key == column.Trim().ToLower())
                        {
                            int p = Parameter.Length - 2;
                            _parameter = new object[p];
                            n++;
                            continue;
                        }
                        if (Edited.Count > n)
                        {
                            _intoCol += edit.Key + ", ";
                            _intovaluesCol += "@" + edit.Key + ", ";
                        }
                        else if (Edited.Count == n)
                        {
                            _intoCol += edit.Key + " ";
                            _intovaluesCol += "@" + edit.Key + " ";
                        }
                        int y = 0;
                        if (Parameter.Length > m)
                        {

                            Parameter[m] = "@" + edit.Key;
                            y = m + 1;
                            Parameter[y] = edit.Value;
                        }
                        m = y + 1;

                        n++;
                    }
                    _sql = @"INSERT INTO " + this.ToString() + " (" + _intoCol.Remove(_intoCol.LastIndexOf(','),1) + ") VALUES(" + _intovaluesCol + ")";
                    break;
            }

            return Sql;
        }
        string col = string.Empty;
        internal bool setb(string s)
        {
            return s.ToLower().Equals(col);
        }

        public string GetSqlQuery(Common.Basic.FormMode formMode, List<string> columns)
        {

            int m = 0;
            int n = 1;
            int c = 0;
            string _whereCol = string.Empty;
            string _setCol = string.Empty;
            string _intoCol = string.Empty;
            string _intovaluesCol = string.Empty;

            switch (formMode)
            {
                case Common.Basic.FormMode.browseMode:
                    _sql = @"select * from " + this.ToString();
                    break;
                case Common.Basic.FormMode.deleteMode:
                    if (0 == Edited.Count)
                        return string.Empty;
                    m = 0;
                    c = 0;
                    object[] objs = new object[(columns.Count * 2)];
                    foreach (KeyValuePair<string, object> edit in Edited)
                    {
                        col = edit.Key;
                        if (columns.Exists(setb))
                        {
                            _whereCol += (c == (columns.Count - 1)) ? edit.Key + "=@" + edit.Key : edit.Key + "=@" + edit.Key + "\n\rAND\n\r";
                            objs[m] = "@" + edit.Key;
                            int y = m + 1;
                            objs[y] = edit.Value;
                            m = y + 1;
                            c++;
                        }

                    }
                    Parameter = objs;
                    _sql = @"delete from " + this.ToString();
                    _sql += string.IsNullOrEmpty(_whereCol) ? _whereCol : "\r\n where (" + _whereCol + ")";
                    break;
                case Common.Basic.FormMode.modifyMode:
                    if (0 == Edited.Count)
                        return string.Empty;
                    n = 1;
                    m = 0;
                    c = 0;
                    foreach (KeyValuePair<string, object> edit in Edited)
                    {
                        col = edit.Key;
                        if (!columns.Exists(setb))
                        {
                            if (Edited.Count > n)
                            {
                                _setCol += edit.Key + "=@" + edit.Key + ", ";

                            }
                            else if (Edited.Count == n)
                            {
                                _setCol += edit.Key + "=@" + edit.Key + " ";
                            }
                        }
                        else
                        {
                            _whereCol += (c == (columns.Count - 1)) ? edit.Key + "=@" + edit.Key : edit.Key + "=@" + edit.Key + "\n\rAND\n\r";
                            c++;
                        }

                        int y = 0;
                        if (Parameter.Length > m)
                        {
                            Parameter[m] = "@" + edit.Key;
                            y = m + 1;

                            Parameter[y] = edit.Value;
                        }
                        m = y + 1;

                        n++;

                    }
                    _sql = @"update " + this.ToString();
                    _sql += string.IsNullOrEmpty(_setCol) ? _setCol : "\r\n set " + _setCol.Remove(_setCol.LastIndexOf(','), 1);
                    _sql += string.IsNullOrEmpty(_whereCol) ? _whereCol : "\r\n where (" + _whereCol + ")";
                    break;
                case Common.Basic.FormMode.newMode:
                    if (0 == Edited.Count)
                        return string.Empty;
                    n = 1;
                    m = 0;
                    c = 0;
                    foreach (KeyValuePair<string, object> edit in Edited)
                    {
                        if (null != columns && columns.Count > 0)
                        {
                            if (IsKeyCol && edit.Key == (c < columns.Count ? columns[c].Trim().ToLower() : columns[0].Trim().ToLower()))
                            {
                                int p = Parameter.Length - 2;
                                _parameter = new object[p];
                                n++;
                                c++;
                                continue;
                            }
                        }

                        if (Edited.Count > n)
                        {
                            _intoCol += edit.Key + ", ";
                            _intovaluesCol += "@" + edit.Key + ", ";
                        }
                        else if (Edited.Count == n)
                        {
                            _intoCol += edit.Key + " ";
                            _intovaluesCol += "@" + edit.Key + " ";
                        }

                        int y = 0;
                        if (Parameter.Length > m)
                        {

                            Parameter[m] = "@" + edit.Key;
                            y = m + 1;
                            Parameter[y] = edit.Value;
                        }
                        m = y + 1;

                        n++;

                    }
                    _sql = @"INSERT INTO " + this.ToString() + " (" + _intoCol.Remove(_intoCol.LastIndexOf(','), 1) + ")\r\n VALUES(" + _intovaluesCol + ")";
                    break;
            }

            return Sql;
        }
    }
}
