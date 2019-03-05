using System;
using System.Collections.Generic;
using System.Text;

namespace Vf.Windows.Forms
{
    /// <summary>
    /// フィールド名の構造を提供します。
    /// </summary>
    class FieldItemTree
    {
        /// <summary>
        /// 現在のフィールド名を取得します。
        /// </summary>
        public string FieldName { get; set; } = "";

        /// <summary>
        /// 子のフィールドツリーを取得します。
        /// </summary>
        public FieldItemTree Child { get; set; } = null;

        /// <summary>
        /// 子のフィールドツリーを有しているかどうかを取得します。
        /// </summary>
        public bool HasChild { get; set; } = false;
    }
}
