using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToWordConverter;
using NumberToWordConverter.Controllers;

namespace NumberToWordConverter.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// Index Controller Method Test
        /// </summary>
        [TestMethod]
        public void Index_Test()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Index Method Page Name Test
        /// </summary>
        [TestMethod]
        public void Index_Result_Test()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Convert Number to Words(Upto Billion)", result?.ViewBag.Message);
        }
    }
}
