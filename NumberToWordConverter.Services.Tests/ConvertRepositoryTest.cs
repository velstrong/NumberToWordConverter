using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using NumberToWordConverter.Core.ViewModel;
using NumberToWordConverter.Repository.Interfaces;
using NumberToWordConverter.Repository.Classes;

namespace NumberToWordConverter.Services.Tests
{
    [TestClass]
    public class ConvertRepositoryTest
    {
        /// <summary>
        /// Convert Currency in Words Positive Test
        /// </summary>
        [TestMethod]
        public void ConvertCurrenyWords_PositiveTest()
        {
            // Arrange
            var expectedOutput = "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Six Dollars and Ninety Eight Cents Only";
            IConvertRepository convertRepository = new ConvertRepository();
            var model = new ConvertWordsModel() { Currency = 1234566.98m, Name = "John Smith" };

            // Act
            string result = convertRepository.ConvertCurrenyWords(model.Currency);

            //Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void ConvertCurrenyWords_PositiveTest2()
        {
            // Arrange
            var expectedOutput = "Nine Million Six Hundred Seventy Eight Thousand Five Hundred Fourty Nine Dollars and Twenty Four Cents Only";
            IConvertRepository convertRepository = new ConvertRepository();
            var model = new ConvertWordsModel() { Currency = 9678549.24m, Name = "John Smith" };

            // Act
            string result = convertRepository.ConvertCurrenyWords(model.Currency);

            //Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void ConvertCurrenyWords_PositiveTest3()
        {
            // Arrange
            var expectedOutput = "One Hundred Seventy One Thousand Four Hundred Thirteen Dollars and Fifteen Cents Only";
            IConvertRepository convertRepository = new ConvertRepository();
            var model = new ConvertWordsModel() { Currency = 171413.15m, Name = "John Smith" };

            // Act
            string result = convertRepository.ConvertCurrenyWords(model.Currency);

            //Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void ConvertCurrenyWords_PositiveTest4()
        {
            // Arrange
            var expectedOutput = "Twelve Thousand Four Hundred Eleven Dollars and Ten Cents Only";
            IConvertRepository convertRepository = new ConvertRepository();
            var model = new ConvertWordsModel() { Currency = 12411.10m, Name = "John Smith" };

            // Act
            string result = convertRepository.ConvertCurrenyWords(model.Currency);

            //Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void ConvertCurrenyWords_PositiveTest5()
        {
            // Arrange
            var expectedOutput = "Eighteen Thousand Four Hundred Seventeen Dollars and Sixteen Cents Only";
            IConvertRepository convertRepository = new ConvertRepository();
            var model = new ConvertWordsModel() { Currency = 18417.16m, Name = "John Smith" };

            // Act
            string result = convertRepository.ConvertCurrenyWords(model.Currency);

            //Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void ConvertCurrenyWords_PositiveTest6()
        {
            // Arrange
            var expectedOutput = "Four Billion Five Hundred Sixty Five Million Six Hundred Eighteen Thousand Four Hundred Fourteen Dollars and Nineteen Cents Only";
            IConvertRepository convertRepository = new ConvertRepository();
            var model = new ConvertWordsModel() { Currency = 4565618414.19m, Name = "John Smith" };

            // Act
            string result = convertRepository.ConvertCurrenyWords(model.Currency);

            //Assert
            Assert.AreEqual(expectedOutput, result);
        }
        /// <summary>
        /// Convert Currency in Words Negative Test
        /// </summary>
        [TestMethod]
        public void ConvertCurrenyWords_NegativeTest()
        {
            // Arrange
            var expectedOutput = "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Six Dollars and Ninety Eight Cents Only";
            IConvertRepository convertRepository = new ConvertRepository();
            var model = new ConvertWordsModel() { Currency = 76345769467, Name = "John Smith" };

            // Act
            string result = convertRepository.ConvertCurrenyWords(model.Currency);

            //Assert
            Assert.AreNotEqual(expectedOutput, result);
        }
    }
}
