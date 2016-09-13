using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCreator
{
    public class Price
    {
        [Key]
        public long PriceId { get; set; }
        public double ItemPrice { get; set; }
 
        public string UnitQuantity { get; set; }
        public string Quantity { get; set; }
        public string IsWeighted { get; set; }

        public virtual Store Store { get; set; }
        public virtual Item Item { get; set; }
    }
}
