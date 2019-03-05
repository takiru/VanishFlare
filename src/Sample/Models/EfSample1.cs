using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class EfSample1 : DbContext
    {
        [Key]
        public string Sample1Data { get; set; }

        public DbSet<EfSample2> EfSample2 { get; set; }
    }
}
