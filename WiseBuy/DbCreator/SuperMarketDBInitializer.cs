using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCreator
{
    public class SuperMarketDbInitializer : DropCreateDatabaseIfModelChanges<SuperMarketDb>
    {
        //protected override void Seed(SuperMarketDb context)
        //{
        //    //Init code...
        //    //new InitializeData();
        //}
    }
}
