using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using NSubstitute;
using NUnit.Framework;

namespace CSVFileKata
{
    [TestFixture]
    public class CsvFileGeneratorTest
    {
        [Test]
        public void CreateCSVFile_GivenFileNameAnd1Customer_ShouldSaveOneContact()
        {
            // Arrange
            var customers = Builder<Customer>.CreateListOfSize(1).Build();
            var fileSystem = Substitute.For<IFileSystem>();
            var dublicates = Substitute.For<IDublicates>();
            var csvFileGenerator = new CsvFileGenerator(fileSystem, dublicates);
            var filename = "customers";

            // Act
            csvFileGenerator.CreateCsvFile(filename, customers);

            // Assert
            fileSystem.Received(1).WriteLine(filename, Arg.Any<string>());
        }

        [Test]
        public void CreateCSVFile_GivenFileNameAnd2Customers_ShouldSave2Customers()
        {
            // Arrange
            var customers = Builder<Customer>.CreateListOfSize(2).Build();
            var fileSystem = Substitute.For<IFileSystem>();
            var dublicates = Substitute.For<IDublicates>();
            var csvFileGenerator = new CsvFileGenerator(fileSystem, dublicates);
            var filename = "customers";

            // Act
            csvFileGenerator.CreateCsvFile(filename, customers);

            // Assert
            fileSystem.Received(2).WriteLine(filename, Arg.Any<string>());
        }

        [Test]
        public void CreateCSVFile_GivenFileNameAnd10Customers_ShouldSave10Customers()
        {
            // Arrange
            var customers = Builder<Customer>.CreateListOfSize(10).Build();
            var fileSystem = Substitute.For<IFileSystem>();
            var dublicates = Substitute.For<IDublicates>();
            var csvFileGenerator = new CsvFileGenerator(fileSystem, dublicates);
            var filename = "customers";

            // Act
            csvFileGenerator.CreateCsvFile(filename, customers);

            // Assert
            fileSystem.Received(10).WriteLine(filename, Arg.Any<string>());
        }

        [Test]
        public void CreateCSVFile_GivenFileNameAndManyCustomers_ShouldSaveManyContacts()
        {
            // Arrange
            var customers = Builder<Customer>.CreateListOfSize(12).Build();
            var fileSystem = Substitute.For<IFileSystem>();
            var dublicates = Substitute.For<IDublicates>();
            var csvFileGenerator = new CsvFileGenerator(fileSystem, dublicates);
            var filename = "customers";

            // Act
            csvFileGenerator.CreateCsvFile(filename, customers);

            // Assert
            fileSystem.Received(12).WriteLine(filename, Arg.Any<string>());
        }

        [TestCase(12, 10, 2)]
        [TestCase(1501, 1500, 1)]
        [TestCase(1508, 1500, 8)]
        public void CreateCSVFile_GivenCustomerBatchOf10Or1500_ShouldSave2Files(int numberOfCustomers, int maximumLineLimit, int access)
        {
            // Arrange
            var customers = Builder<Customer>.CreateListOfSize(numberOfCustomers).Build().ToList();
            var filename = "customers";
            var fileSystem = Substitute.For<IFileSystem>();
            var dublicates = new Duplicates();
            var csvFileGenerator = new CsvFileGenerator(fileSystem, dublicates);

            // Act
            csvFileGenerator.GetBatchOfCustomers("customers", customers, maximumLineLimit);

            // Assert
            fileSystem.Received(maximumLineLimit).WriteLine($"{filename}1.csv", Arg.Any<string>());
            fileSystem.Received(access).WriteLine($"{filename}2.csv", Arg.Any<string>());
        }

        [Test]
        public void FileSystem_GivenNullFileSystem_ShouldThrowAnException()
        {
            // Arrange
            var dublicates = Substitute.For<IDublicates>();

            // Act
            var result = Assert.Throws<ArgumentNullException>(() => new CsvFileGenerator(null, dublicates));

            // Assert
            Assert.AreEqual("fileSystem", result.ParamName);
        }

        [Test]
        public void FileSystem_GivenNullDublicates_ShouldThrowAnException()
        {
            // Arrange
            var fileSystem = Substitute.For<IFileSystem>();

            // Act
            var result = Assert.Throws<ArgumentNullException>(() => new CsvFileGenerator(fileSystem, null));

            // Assert
            Assert.AreEqual("dublicates", result.ParamName);
        }

        [Test]
        public void FileSystem_GivenAllData_ShouldSaveBatchesOf20Customers()
        {
            // Arrange
            var customers = GetCustomCustomerList();
            var fileSystem = Substitute.For<IFileSystem>();
            var dublicates = new Duplicates();
            var csvFileGenerator = new CsvFileGenerator(fileSystem, dublicates);
            var filename = "customers";

            // Act
            csvFileGenerator.GetBatchOfCustomers("customers", customers, 20);

            // Assert
            fileSystem.Received(20).WriteLine($"{filename}1.csv", Arg.Any<string>());
            fileSystem.Received(12).WriteLine($"{filename}2.csv", Arg.Any<string>());
        }

        private static List<Customer> GetCustomCustomerList() => new List<Customer> {
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Banana", ContactNumber = "0784455812"},
                new Customer { Name = "Grape", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Banana", ContactNumber = "0784455812"},
                new Customer { Name = "Grape", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Banana", ContactNumber = "0784455812"},
                new Customer { Name = "Grape", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Banana", ContactNumber = "0784455812"},
                new Customer { Name = "Grape", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Banana", ContactNumber = "0784455812"},
                new Customer { Name = "Grape", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Banana", ContactNumber = "0784455812"},
                new Customer { Name = "Grape", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Banana", ContactNumber = "0784455812"},
                new Customer { Name = "Grape", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"},
                new Customer { Name = "Banana", ContactNumber = "0784455812"},
                new Customer { Name = "Grape", ContactNumber = "0784455812"},
                new Customer { Name = "Apple", ContactNumber = "0784455812"}
        };
    }
}
