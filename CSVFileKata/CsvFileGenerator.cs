using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVFileKata
{
    public class CsvFileGenerator
    {
        private readonly IFileSystem _fileSystem;
        private readonly IDublicates _dublicates;

        public CsvFileGenerator(IFileSystem fileSystem, IDublicates dublicates)
        {
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _dublicates = dublicates ?? throw new ArgumentNullException(nameof(dublicates));
        }

        public void GetBatchOfCustomers(string fileName, List<Customer> customers, int maximumLineLimit)
        {
            var numberOfFiles = 1;
            var newListIndex = 0;
            
            var cleanCustomersList = _dublicates.RemoveDuplicates(customers);
            var debugDataList = GetGroupOf(customers, maximumLineLimit);


            var finalList = GetGroupOf(cleanCustomersList, maximumLineLimit);

            while (numberOfFiles <= finalList.Count)
            {
                var fullFileName = $"{fileName}{numberOfFiles}.csv";

                CreateCsvFile(fullFileName, finalList[newListIndex].ToList());

                newListIndex++;
                numberOfFiles++;
            }
        }        

        private static List<IEnumerable<Customer>> GetGroupOf(List<Customer> customers, int maximumLineLimit)
        {
            var groupOfCustomers = customers.Select((customer, myIndexer) => new { Index = myIndexer, Value = customer })
                                            .GroupBy(shorterList => shorterList.Index / maximumLineLimit)
                                            .Select(newCustomer => newCustomer.Select(customer => customer.Value))
                                            .ToList();

            return groupOfCustomers;
        }

        public void CreateCsvFile(string fileName, IList<Customer> customers)
        {
            foreach (var customer in customers)
            {
                _fileSystem.WriteLine(fileName, customer.ToString());
            }
        }
    }
}
