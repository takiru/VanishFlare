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
    /// コントロールのマッピングされるデータを提供します。
    /// </summary>
    public class ControlMappingEventArgs : CancelEventArgs
    {
        /// <summary>
        /// マッピングが行われるコントロールを取得します。
        /// </summary>
        public Control Control { get; private set; }

        /// <summary>
        /// マッピングが行われる項目名を取得します。
        /// </summary>
        public string FieldName { get; private set; }

        /// <summary>
        /// マッピングが行われる値を取得します。
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="control">コントロール。</param>
        /// <param name="fieldName">項目名。</param>
        /// <param name="value">値。</param>
        public ControlMappingEventArgs(Control control, string fieldName, object value)
        {
            this.Control = control;
            this.FieldName = fieldName;
            this.Value = value;
        }
    }
}
