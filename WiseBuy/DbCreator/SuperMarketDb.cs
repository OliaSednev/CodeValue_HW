using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCreator
{
    public class SuperMarketDb: DbContext
    {
        public SuperMarketDb() : base("SuperMarketDb"){}

        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Chain> Chains { get; set; }
    }
}
