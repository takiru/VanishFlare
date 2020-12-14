using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanishFlare.Windows.Forms
{
    /// <summary>
    /// コントロールのマッピングされたデータを提供します。
    /// </summary>
    public class ControlMappedEventArgs : EventArgs
    {
        /// <summary>
        /// マッピングが行われたコントロールを取得します。
        /// </summary>
        public Control Control { get; set; }

        /// <summary>
        /// マッピングが行われた項目名を取得します。
        /// </summary>
        public string FieldName { get; private set; }

        /// <summary>
        /// マッピングが行われた値を取得します。
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="control">コントロール。</param>
        /// <param name="fieldName">項目名。</param>
        /// <param name="value">値。</param>
        public ControlMappedEventArgs(Control control, string fieldName, object value)
        {
            this.Control = control;
            this.FieldName = fieldName;
            this.Value = value;
        }
    }
}
