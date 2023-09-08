using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace EcoleAPITests
{
    [TestClass]
    public class ElevesControllerTests
    {
        private ElevesController _controller;

        [TestInitialize]
        public void Setup()
        {
            _controller = new ElevesController();
        }

        [TestMethod]
        public void Test_GetNom_ValidId()
        {
            var result = _controller.GetNom(1) as ActionResult<string>;
            Assert.IsNotNull(result);
            Assert.AreEqual("Jean", result.Value);
        }

        [TestMethod]
        public void Test_GetAge_ValidId()
        {
            var result = _controller.GetAge(1) as ActionResult<int>;
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Value);
        }

        [TestMethod]
        public void Test_GetNote_ValidId()
        {
            var result = _controller.GetNote(1) as ActionResult<double>;
            Assert.IsNotNull(result);
            Assert.AreEqual(15, result.Value);
        }

    }
}
