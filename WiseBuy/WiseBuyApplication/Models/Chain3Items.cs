using System.Collections.Generic;

namespace WiseBuyApplication.Models
{
    public class Chain3Items : ObservableObejct
    {
        #region Properties

        public string ChainName { get; set; }

        public List<string> Ordered3Items { get; set; }

        #endregion Properties
    }
}
