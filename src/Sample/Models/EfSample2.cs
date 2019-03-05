using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class EfSample2 : DbContext
    {
        [Key]
        public string Sample2Data { get; set; }

        public DbSet<EfSample3> EfSample3 { get; set; }
    }
}
