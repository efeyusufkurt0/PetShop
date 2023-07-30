using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.DAL.Entities
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        public int ProductID { get; set; }
        public Product product { get; set; }

        public int CategoryID { get; set; }
        public Category category { get; set; }
    }
}
