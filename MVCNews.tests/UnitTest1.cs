using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCNews.Controllers;
using System.Web.Mvc;
using Info.DAL;

namespace MVCNews.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Description("test unitaire de l'action index de mon controller")]
        [TestCategory("ViewResult")]
        public void Verifier_retour_Index_HomeController()
        {
            //arrange
            HomeController controller = new HomeController(); 

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Description("Test unitaire de l'action LesNews dans HomeController")]
        public void Verifier_retour_LesNews_HomeController()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult retour = controller.LesNews() as ViewResult;

            //Assert
            Assert.IsNotNull(retour);
            Assert.AreEqual(retour.ViewName, "LesNews");
            Assert.AreEqual((retour.Model as News).)
 
        }
    }
}
