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
        private FieldsMap fieldsMap = new FieldsMap();

        /// <summary>
        /// コントロールのマッピングを検証しているときに発生します。
        /// </summary>
        [Category("VanishFlare 動作")]
        [Description("コントロールのマッピングを検証しているときに発生します。")]
        public event ControlMappingEventHandler ControlMapping;

        /// <summary>
        /// コントロールのマッピングが検証された後に発生します。
        /// </summary>
        [Category("VanishFlare 動作")]
        [Description("コントロールのマッピングが検証された後に発生します。")]
        public event ControlMappedEventhander ControlMapped;

        /// <summary>
        /// コントロールのマッピングを検証しているときに発生します。
        /// </summary>
        /// <param name="sender">実行発生オブジェクト。</param>
        /// <param name="e">ControlMappingEventArgs オブジェクト。</param>
        protected virtual void OnControlMapping(object sender, ControlMappingEventArgs e)
        {
            ControlMapping?.Invoke(sender, e);
        }

        /// <summary>
        /// コントロールのマッピングが検証された後に発生します。
        /// </summary>
        /// <param name="sender">実行発生オブジェクト。</param>
        /// <param name="e">ControlMappedEventArgs オブジェクト。</param>
        protected virtual void OnControlMapped(object sender, ControlMappedEventArgs e)
        {
            ControlMapped?.Invoke(sender, e);
        }

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
            fieldsMap.ControlMapping = OnControlMapping;
            fieldsMap.ControlMapped = OnControlMapped;
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
        public void MapFields()
        {
            fieldsMap.Map(this.FieldControlMaps, this.CustomAutoCompleteBox.SelectedItem);
        }

        /// <summary>
        /// 指定されたアイテムオブジェクトから、フィールドとコントロールをマッピングします。
        /// </summary>
        /// <param name="items">アイテムオブジェクト。</param>
        public void MapFields(object items)
        {
            fieldsMap.Map(this.FieldControlMaps, items);
        }
    }
}
