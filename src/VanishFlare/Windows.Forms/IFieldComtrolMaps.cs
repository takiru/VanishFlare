using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Vf.Windows.Forms
{
    interface IFieldComtrolMaps<T> where T : FieldControlMapBase
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        T[] FieldControlMaps { get; set; }

        void MapFields();
    }
}
