using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace Vf.Windows.Forms
{
    /// <summary>
    /// FieldControlMapBase クラスのジェネリックに指定されている型から、フィールド項目名を選択可能とする。
    /// </summary>
    internal sealed class FieldListConverter : TypeConverter
    {
        /// <summary>
        /// 変換可能な文字列かどうかを取得します。
        /// </summary>
        /// <param name="context">コンテキスト情報。</param>
        /// <param name="sourceType">変換元のタイプ。</param>
        /// <returns>true:変換可能, false:変換不可能。</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            // ジェネリックが string 型の場合は手入力とする
            var genericType = this.GetGenericType(context);
            if (genericType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// 文字列を受け入れます。
        /// </summary>
        /// <param name="context">コンテキスト情報。</param>
        /// <param name="culture">カルチャー情報。</param>
        /// <param name="value">変換元の値。</param>
        /// <returns>文字エンコーディング。</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            // ジェネリックが string 型の場合は入力された文字そのままとする
            var genericType = this.GetGenericType(context);
            if (genericType == typeof(string))
            {
                return value.ToString();
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// ドロップダウンで選択可能にします。
        /// </summary>
        /// <param name="context">コンテキスト情報。</param>
        /// <returns>true</returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            // ジェネリックが string 型の場合はプルダウンにしない
            var genericType = this.GetGenericType(context);
            if (genericType == typeof(string))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 選択可能な文字列のリストを取得します。
        /// </summary>
        /// <param name="context">コンテキスト情報。</param>
        /// <returns>文字エンコーディング名のリスト。</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // ジェネリックが string 型の場合は制御しない
            var genericType = this.GetGenericType(context);
            if (genericType == typeof(string))
            {
                return base.GetStandardValues(context);
            }

            // ジェネリック型のクラス内に含まれるプロパティを選択候補にする
            var choices = new List<string>();
            choices = this.ScanProperties(genericType);
            return new StandardValuesCollection(choices);
        }

        /// <summary>
        /// 選択肢以外の入力を認めません。
        /// </summary>
        /// <param name="context">コンテキスト情報。</param>
        /// <returns>true</returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            // ジェネリックが string 型の場合は入力可能とする
            var genericType = this.GetGenericType(context);
            if (genericType == typeof(string))
            {
                return false;
            }

            return true;
        }

        private Type genericType = null;

        /// <summary>
        /// 指定されたFieldControlMapクラスから、ジェネリックの型を求める。
        /// </summary>
        /// <param name="context">ITypeDescriptorContext オブジェクト。</param>
        /// <returns>ジェネリックの型。</returns>
        private Type GetGenericType(ITypeDescriptorContext context)
        {
            if (this.genericType != null)
            {
                return this.genericType;
            }

            // 指定されたFieldControlMapクラスから、ジェネリックの型を求める
            var fieldControlMapType = context.Instance.GetType();
            var genericType = fieldControlMapType.BaseType.GenericTypeArguments[0];

            return genericType;
        }

        /// <summary>
        /// 選択候補となるプロパティを走査して取得する。
        /// </summary>
        /// <param name="type">走査対象となるType。</param>
        /// <param name="parentTree">ジェネリックの上位ツリー情報。</param>
        /// <returns>選択候補のプロパティ。</returns>
        private List<string> ScanProperties(Type type, string parentTree = "")
        {
            var result = new List<string>();
            var pis = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
            foreach (var pi in pis)
            {
                var propertyName = parentTree == "" ? pi.Name : parentTree + "->" + pi.Name;
                result.Add(propertyName);

                // ジェネリック型でない場合は次のプロパティへ
                if (!pi.PropertyType.IsGenericType)
                {
                    continue;
                }

                // ジェネリックの場合、指定されている型のプロパティもすべて走査する
                foreach (var genericType in pi.PropertyType.GenericTypeArguments)
                {
                    result.AddRange(this.ScanProperties(genericType, propertyName));
                }
            }

            return result;
        }
    }
}
