using System.Collections.Generic;

namespace CSVFileKata
{
    public interface IDublicates
    {
        List<Customer> RemoveDuplicates(List<Customer> customers);
    }
}
