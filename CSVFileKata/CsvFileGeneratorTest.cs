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
                new Customer { Name = "Andile",     ContactNumber = "0784455801"},
                new Customer { Name = "Benni",      ContactNumber = "0784455802"},
                new Customer { Name = "Grace",      ContactNumber = "0784455803"},
                new Customer { Name = "Ayanda",     ContactNumber = "0784455804"},
                new Customer { Name = "Akhona",     ContactNumber = "0784455805"},
                new Customer { Name = "Bruce",      ContactNumber = "0784455806"},
                new Customer { Name = "Gredd",      ContactNumber = "0784455807"},
                new Customer { Name = "Philani",    ContactNumber = "0784455808"},
                new Customer { Name = "Malungi",    ContactNumber = "0784455809"},
                new Customer { Name = "Lunga",      ContactNumber = "0784455810"},
                new Customer { Name = "Lee",        ContactNumber = "0784455811"},
                new Customer { Name = "Kevin",      ContactNumber = "0784455812"},
                new Customer { Name = "Andre",      ContactNumber = "0784455813"},
                new Customer { Name = "Blake",      ContactNumber = "0784455814"},
                new Customer { Name = "Glen",       ContactNumber = "0784455815"},
                new Customer { Name = "Mandisa",    ContactNumber = "0784455816"},
                new Customer { Name = "Nonhle",     ContactNumber = "0784455817"},
                new Customer { Name = "Hlengiwe",   ContactNumber = "0784455818"},
                new Customer { Name = "Themba",     ContactNumber = "0784455819"},
                new Customer { Name = "Andile",     ContactNumber = "0784455820"},
                new Customer { Name = "Melusi",     ContactNumber = "0784455821"},
                new Customer { Name = "Fred",       ContactNumber = "0784455822"},
                new Customer { Name = "Lewis",      ContactNumber = "0784455823"},
                new Customer { Name = "Mike",       ContactNumber = "0784455824"},
                new Customer { Name = "Craig",      ContactNumber = "0784455825"},
                new Customer { Name = "Berry",      ContactNumber = "0784455826"},
                new Customer { Name = "Floyd",      ContactNumber = "0784455827"},
                new Customer { Name = "Blair",      ContactNumber = "0784455828"},
                new Customer { Name = "Mako",       ContactNumber = "0784455829"},
                new Customer { Name = "Bethuel",    ContactNumber = "0784455830"},
                new Customer { Name = "Bandile",    ContactNumber = "0784455831"},
                new Customer { Name = "Bonga",      ContactNumber = "0784455832"},
                new Customer { Name = "Lungi",      ContactNumber = "0784455833"}
        };
    }
}
