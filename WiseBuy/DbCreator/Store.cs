using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCreator
{
    public class Store
    {

        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StoreId { get; set; }

        [Key, Column(Order = 1), ForeignKey("Chain"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ChainId { get; set; }
        public virtual Chain Chain { get; set; }

        
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        
        public virtual ICollection<Price> Prices { get; set; }
        public Store()
        {
            Prices = new HashSet<Price>();
        }
    }
}
