using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileKata
{
    public class Customer
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        public override string ToString()
        {
            return string.Join(",", Name, ContactNumber);
        }
    }
}
