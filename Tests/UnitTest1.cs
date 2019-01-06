using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Webservice.Controllers;
using System.Net.Http;
using System.Net;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new webservice.Controllers.PutNameHereController();
            var result = (c.Get(11).Result) as OkObjectResult;

            var expectedResult = 200;
            var actualResult = result?.StatusCode ?? 404;

            Assert.AreEqual(expectedResult, actualResult, "Got wrong statuscode!");
        }
    }
}
