using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class ComboBoxItem
    {
        public string DispValue { get; set; }

        public string ValueValue { get; set; }

        public List<DataTest> List { get; set; } = new List<DataTest>();
    }

    public class DataTest
    {
        public string Column1 { get; set; }

        public string Column2 { get; set; }
    }
}
