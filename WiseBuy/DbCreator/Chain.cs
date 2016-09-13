using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCreator
{
    public class Chain
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ChainId { get; set; }
        public string ChainName { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public Chain()
        {
            Stores = new HashSet<Store>();
        }
    }
}
