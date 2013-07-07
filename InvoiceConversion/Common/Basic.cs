using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceConversion.Common
{
    public delegate void OnEnterKeyPressHandler(string eString);
    public class Basic
    {
        public enum FormMode
        {
            /// <summary>
            /// 新增
            /// </summary>
            newMode,
            /// <summary>
            /// 刪除
            /// </summary>
            deleteMode,
            /// <summary>
            /// 修改
            /// </summary>
            modifyMode,
            /// <summary>
            /// 查看
            /// </summary>
            browseMode,
            /// <summary>
            /// 無
            /// </summary>
            noneMode
        }

        public static void OnException(Exception e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            while (e != null)
            {
                sb.Append(DateTime.Now.ToString() + "\r\n");
                sb.Append(e.StackTrace + "\r\n");
                sb.Append(e.GetType().FullName + "\r\n");
                sb.Append(e.Message + "\r\n");
                System.IO.File.AppendAllText("Error.log", sb.ToString(), System.Text.Encoding.UTF8);
                e = e.InnerException;
            }
        }

    }
}
