using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToWordConverter.Services.Controllers;
using System.Web.Http;
using Moq;
using NumberToWordConverter.Core.ViewModel;
using System.Threading;
using System.Net;
using System.Web.Http.Results;
using NumberToWordConverter.Core.Response;
using NumberToWordConverter.Repository.Interfaces;

namespace NumberToWordConverter.Services.Tests
{
    [TestClass]
    public class ConvertWordTest
    {
        /// <summary>
        /// Convert Word API Method Positive Test
        /// </summary>
        [TestMethod]
        public void ConvertWord_Positive_Test()
        {
            //Arrange
            var expectedOutput = "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Six Dollars and Ninety Eight Cents Only";
            Mock<IConvertRepository> mockRepository = new Mock<IConvertRepository>();
            mockRepository.Setup(m => m.ConvertCurrenyWords(It.IsAny<decimal>()))
                .Returns(expectedOutput);
            ConvertController controller = new ConvertController(mockRepository.Object);
            var model = new ConvertWordsModel() { Currency = 1234566.98m, Name = "John Smith" };

            // Act
            IHttpActionResult result = controller.ConvertWords(model) as IHttpActionResult;
            var contentResult = result as OkNegotiatedContentResult<ConvertWordsResult>;

            //Assert
            Assert.AreEqual(true, contentResult != null && contentResult.Content.Success);
            Assert.AreEqual(expectedOutput, contentResult.Content.CurrencyWords);
        }

        /// <summary>
        /// Convert Word API Method Negative Test
        /// </summary>
        [TestMethod]
        public void ConvertWord_Negative_Test()
        {
            //Arrange
            Mock<IConvertRepository> mockRepository = new Mock<IConvertRepository>();
            mockRepository.Setup(m => m.ConvertCurrenyWords(It.IsAny<decimal>()))
                .Throws(new Exception());
            ConvertController controller = new ConvertController(mockRepository.Object);
            var model = new ConvertWordsModel() { Currency = 12345.98m, Name = "John Smith" };

            // Act
            IHttpActionResult result = controller.ConvertWords(model) as IHttpActionResult;
            var contentResult = result as OkNegotiatedContentResult<ConvertWordsResult>;

            //Assert
            Assert.AreEqual(false, contentResult != null && contentResult.Content.Success);
            Assert.AreEqual(null, contentResult.Content.CurrencyWords);
        }
    }
}
