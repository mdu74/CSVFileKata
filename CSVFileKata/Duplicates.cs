using System.Collections.Generic;
using System.Linq;

namespace CSVFileKata
{
    public class Duplicates : IDublicates
    {
        public List<Customer> RemoveDuplicates(List<Customer> customers)
        {
            var cleanCustomerList = customers.GroupBy(c => c.Name)
                                             .Select(c => c.First());

            return cleanCustomerList.ToList();
        }
    }
}
