using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vf.Windows.Forms
{
    /// <summary>
    /// コントロールへフィールドをマッピングする処理を提供します。
    /// </summary>
    public class FieldsMap
    {
        /// <summary>
        /// 選択されたアイテムの内容を、指定されたコントロールへマッピングを行います。
        /// </summary>
        /// <param name="fieldTextMaps">FieldControlMap オブジェクト。</param>
        /// <param name="item">選択されたアイテムオブジェクト。</param>
        public void Map(FieldControlMapBase[] fieldTextMaps, object item)
        {
            // SelectedItem が DataRowの場合
            var row = item as DataRow;
            if (row != null)
            {
                foreach (var m in fieldTextMaps)
                {
                    MapToControl(m.Control, row[m.FieldName]);
                }
                return;
            }

            // SelectedItem が DataRow 以外の objectの場合
            foreach (var m in fieldTextMaps)
            {
                var tree = CreateFieldItemTree(m.FieldName);
                var value = GetTargetValue(tree, item);
                MapToControl(m.Control, value);
            }
        }

        /// <summary>
        /// 選択されたフィールドのアロー文字列からフィールドのツリー構造を取得する。
        /// </summary>
        /// <param name="fieldItem"></param>
        /// <returns></returns>
        private FieldItemTree CreateFieldItemTree(string fieldItem)
        {
            var splitFieldItem = fieldItem.Split(new string[] { "->" }, StringSplitOptions.None);

            var treeList = new List<FieldItemTree>();

            foreach (var field in splitFieldItem)
            {
                treeList.Add(new FieldItemTree()
                {
                    FieldName = field
                });
            }

            for (var i = 0; i < treeList.Count; i++)
            {
                if (i < treeList.Count - 1)
                {
                    treeList[i].Child = treeList[i + 1];
                    treeList[i].HasChild = true;
                }
            }

            return treeList[0];
        }

        /// <summary>
        /// 選択されたフィールドのツリー構造から、選択されたアイテムオブジェクトの値を取得する。
        /// </summary>
        /// <param name="tree">選択されたフィールドのツリー構造。</param>
        /// <param name="item">選択されたアイテムオブジェクト。</param>
        /// <returns></returns>
        private object GetTargetValue(FieldItemTree tree, object item)
        {
            var d = TypeDescriptor.GetProperties(item).Find(tree.FieldName, true);
            var v = d.GetValue(item);

            // 最終子データなら値確定
            if (!tree.HasChild)
            {
                return v;
            }

            var vType = v.GetType();
            if (!vType.IsGenericType)
            {
                // ジェネリックでないが、最終子データでないので、再帰
                return GetTargetValue(tree.Child, v);
            }

            // ジェネリックだけどDbSet<>でない時
            if (vType.GetGenericTypeDefinition() != typeof(DbSet<>))
            {
                var vList = v as IList;
                if (vList != null)
                {
                    // IList の時
                    if (vList.Count > 0)
                    {
                        return GetTargetValue(tree.Child, vList[0]);
                    }
                }
                else
                {
                    return GetTargetValue(tree.Child, v);
                }
            }

            // ジェネリックでDbSet<>の時
            if (vType.GetGenericTypeDefinition() == typeof(DbSet<>))
            {
                var dGeneric = TypeDescriptor.GetProperties(v).Find("Local", true);
                var vGeneric = dGeneric.GetValue(v);
                var vList = vGeneric as IList;
                if (vList != null)
                {
                    if (vList.Count > 0)
                    {
                        return GetTargetValue(tree.Child, vList[0]);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// コントロールのオブジェクトに応じて値を設定する。
        /// </summary>
        /// <param name="control">コントロール。</param>
        /// <param name="value">マッピングする値。</param>
        protected virtual void MapToControl(Control control, object value)
        {
            if (control is DateTimePicker)
            {
                MapControlDateTimePicker((DateTimePicker)control, value);
                return;
            }

            if (control is CheckBox)
            {
                MapControlCheckBox((CheckBox)control, value);
                return;
            }

            if (control is RadioButton)
            {
                MapControlRadioButton((RadioButton)control, value);
                return;
            }

            if (control is ComboBox)
            {
                MapControlComboBox((ComboBox)control, value);
                return;
            }

            control.Text = value.ToString();
        }

        /// <summary>
        /// DateTimePicker は Value に適用する。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        private void MapControlDateTimePicker(DateTimePicker control, object value)
        {
            if (value is DateTime)
            {
                control.Value = (DateTime)value;
            } else
            {
                control.Value = DateTime.Parse(value.ToString());
            }
        }

        /// <summary>
        /// CheckBox は Checked に適用する。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        private void MapControlCheckBox(CheckBox control, object value)
        {
            var valueType = value.GetType();

            if (valueType == typeof(bool))
            {
                control.Checked = (bool)value;
                return;
            }

            // 文字列はtrue/falseだとそれに準ずる, 0だとfalse, それ以外の値が入っているとtrue
            if (valueType == typeof(string))
            {
                var text = ((string)value).ToLower();
                if (text == "true")
                {
                    control.Checked = true;
                    return;
                }
                if (text == "false" || text == "0")
                {
                    control.Checked = false;
                    return;
                }

                control.Checked = ((string)value != "");
                return;
            }

            // 数字は0以外だとtrue
            var numericTypes = new Type[]
            {
                typeof(int), typeof(uint), typeof(short), typeof(ushort), typeof(long), typeof(ulong), typeof(byte),
                typeof(decimal), typeof(double)
            };
            if (numericTypes.Contains(valueType))
            {
                dynamic numeric = Convert.ChangeType(value, valueType);
                control.Checked = (numeric != 0);
            }
        }

        /// <summary>
        /// RadioButton は Checked に適用する。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        private void MapControlRadioButton(RadioButton control, object value)
        {
            var valueType = value.GetType();

            if (valueType == typeof(bool))
            {
                control.Checked = (bool)value;
                return;
            }

            // 文字列はtrue/falseだとそれに準ずる, 0だとfalse, それ以外の値が入っているとtrue
            if (valueType == typeof(string))
            {
                var text = ((string)value).ToLower();
                if (text == "true")
                {
                    control.Checked = true;
                    return;
                }
                if (text == "false" || text == "0")
                {
                    control.Checked = false;
                    return;
                }

                control.Checked = ((string)value != "");
                return;
            }

            // 数字は0以外だとtrue
            var numericTypes = new Type[]
            {
                typeof(int), typeof(uint), typeof(short), typeof(ushort), typeof(long), typeof(ulong), typeof(byte),
                typeof(decimal), typeof(double)
            };
            if (numericTypes.Contains(valueType))
            {
                dynamic numeric = Convert.ChangeType(value, valueType);
                control.Checked = (numeric != 0);
            }
        }

        /// <summary>
        /// ComboBox は Text または SelectedItem に適用する。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        private void MapControlComboBox(ComboBox control, object value)
        {
            // DataSource が未指定の場合は、Textに文字列として適用する
            if (control.DataSource == null)
            {
                control.Text = value.ToString();
                return;
            }

            // DataSource がある場合は、ValueMember に文字列で合致するオブジェクトをSelectedする
            if (control.DataSource is DataSet || control.DataSource is DataTable)
            {
                var dt = control.DataSource as DataTable ?? (control.DataSource as DataSet).Tables[0];
                foreach (var row in dt.AsEnumerable())
                {
                    if (row[control.ValueMember].ToString() == value.ToString())
                    {
                        control.SelectedItem = row;
                        return;
                    }
                }
            }

            // LIst の場合は ValueMember に文字列で合致するオブジェクトをSelectedする
            if (control.DataSource is IList)
            {
                var list = control.DataSource as IList;
                foreach (var item in list)
                {
                    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(item).Find(control.ValueMember, true);
                    if (descriptor.GetValue(item).ToString() == value.ToString())
                    {
                        control.SelectedItem = item;
                        return;
                    }
                }
            }

        }
    }
}
