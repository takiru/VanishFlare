using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanishFlare.DataAnnotations;

namespace Sample.MapFieldControls
{
    public class SimpleItem
    {
        [MapFiledName]
        public string Column1 { get; set; }

        [MapFiledName]
        public DateTime Column2 { get; set; }

        [MapFiledName]
        public int CheckCheck { get; set; }

        [MapFiledName]
        public bool RadioCheck { get; set; }

        [MapFiledName]
        public string ComboItem { get; set; }
    }
}
