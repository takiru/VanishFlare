using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace VanishFlare.Windows.Forms
{
    /// <summary>
    /// フィールドで保持する値をコントロールにマッピングするための要素を提供します。
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public abstract class FieldControlMapBase
    {
        /// <summary>
        /// マッピングを行うコントロールオブジェクトの取得または設定します。
        /// </summary>
        [Description("マッピングを行うコントロールオブジェクトの取得または設定します。")]
        public Control Control { get; set; }

        /// <summary>
        /// マッピングを行う値を保持するフィールド名の取得または設定します。
        /// </summary>
        [Description("マッピングを行う値を保持するフィールド名の取得または設定します。")]
        [TypeConverter(typeof(FieldListConverter))]
        public string FieldName { get; set; }

        /// <summary>
        /// マッピング情報を表す文字列を返します。
        /// </summary>
        /// <returns>文字列。</returns>
        public override string ToString()
        {
            return "FieldName=" + FieldName + ", Control=" + Control?.Name;
        }
    }

    /// <summary>
    /// フィールドで保持する値をコントロールにマッピングするための要素を提供します。
    /// </summary>
    /// <typeparam name="T">フィールドで選択可能とするクラス要素。</typeparam>
    public abstract class FieldControlMapBase<T> : FieldControlMapBase where T : class { }
}
