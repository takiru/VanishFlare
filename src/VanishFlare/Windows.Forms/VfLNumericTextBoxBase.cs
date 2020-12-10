using System;
using System.ComponentModel;
using System.Text;
using Metroit.Windows.Forms;
using Metroit.Windows.Forms.Extensions;

namespace VanishFlare.Windows.Forms
{
    /// <summary>
    /// フィールドマッピングを行う要素を提供します。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class VfLNumericTextBoxBase<T> : MetNumericTextBox, IFieldComtrolMaps<T> where T : FieldControlMapBase
    {
        /// <summary>
        /// 新しい VfLNumericTextBoxBase のインスタンスを生成します。
        /// </summary>
        public VfLNumericTextBoxBase() : base()
        {
            if (this.IsDesignMode())
            {
                return;
            }
            this.CandidateSelected += (s, e) => { this.MapFields(); };
        }

        /// <summary>
        /// 候補選択値のフィールド値を、表示する値としてマッピングするコントロールを指定します。
        /// </summary>
        [Category("VanishFlare 動作")]
        [Description("候補選択値のフィールド値を、表示する値としてマッピングするコントロールを指定します。")]
        public T[] FieldControlMaps { get; set; }

        /// <summary>
        /// 選択されたアイテムオブジェクトから、フィールドとコントロールをマッピングします。
        /// </summary>
        public virtual void MapFields()
        {
            if (this.CustomAutoCompleteBox.SelectedItem == null)
            {
                return;
            }
            (new FieldsMap()).Map(this.FieldControlMaps, this.CustomAutoCompleteBox.SelectedItem);
        }
    }
}
