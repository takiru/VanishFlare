using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanishFlare.DataAnnotations;

namespace Sample.MapFieldControls
{
    public class ListItem
    {
        [MapFiledName]
        public string DispValue { get; set; }

        [MapFiledName]
        public string ValueValue { get; set; }

        [MapFiledName]
        public List<DataTest> List { get; set; } = new List<DataTest>();
    }

    public class DataTest
    {
        public string Column1 { get; set; }

        public string Column2 { get; set; }
    }
}
