using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanishFlare.Windows.Forms
{
    /// <summary>
    /// ControlMapped イベントを発生させるためのデリゲート。
    /// </summary>
    /// <param name="sender">実行発生オブジェクト。</param>
    /// <param name="e">ControlMappedEventArgs オブジェクト。</param>
    public delegate void ControlMappedEventhander(object sender, ControlMappedEventArgs e);
}
