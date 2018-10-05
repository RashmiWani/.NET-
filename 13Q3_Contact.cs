using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagment
{
    [Serializable]
    class Contact
    {
        public int ContactNo { get; set; }
        public string ContactName { get; set; }
        public string CellNo { get; set; }

    }
}