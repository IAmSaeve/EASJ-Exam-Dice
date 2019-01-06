using Microsoft.VisualStudio.TestTools.UnitTesting;
using Webservice.Controllers;

namespace Tests
{
    [TestClass]
    public class ValuesControllerTests
    {
        [TestMethod]
        public void TestValueReturnedById()
        {
            var vc = new ValuesController();
            const int id = 1;

            const int expectedResult = 1;
            var actualResult = vc.Get(id).Value;

            Assert.AreEqual(expectedResult, actualResult, "Failed: Results not matching!");
        }
    }
}
