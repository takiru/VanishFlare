using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class EfSample3 : DbContext
    {
        [Key]
        public string Sample3Data { get; set; }
    }
}
