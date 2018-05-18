using NUnit.Framework;
using System.Collections.Generic;

namespace CSVFileKata
{
    [TestFixture]
    public class DuplicatesTest
    {
        [Test]
        public void RemoveDuplicates_GivenDuplicateCustomers_ShouldRemoveDuplicates()
        {
            // Arrange
            var oldListOfCustomers = new List<Customer> {
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Banana", ContactNumber = "0784455812"},
                new Customer { Name = "Grape", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"}
            };
            var cleanListOfCustomers = new List<Customer> {
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Banana", ContactNumber = "0784455812"},
                new Customer { Name = "Grape", ContactNumber = "0784455812"}
            };
            var duplicates = new Duplicates();

            // Act
            var result = duplicates.RemoveDuplicates(oldListOfCustomers);

            // Assert
            CollectionAssert.AreNotEqual(oldListOfCustomers, result);
            Assert.AreEqual(cleanListOfCustomers.Count, result.Count);
        }
    }
}
