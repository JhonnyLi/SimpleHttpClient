using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProxyHttpClient.Test
{
    [TestClass]
    public class SimpleClientConfigTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            SimpleClientConfig target = Mockup.GetMockupConfig();
            PrivateObject obj = new PrivateObject(target);
            var retVal = obj.Invoke("CreateUriFromUrl",Mockup.MockUrl);
            Assert.AreEqual(typeof(Uri),retVal.GetType());
        }
        [TestMethod]
        public void AddCustomHeaderTest()
        {
            ProxyHttpClient.SimpleClientConfig model = Mockup.GetMockupConfig();
            var result = model.AddCustomHeader("key", "value");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveCustomHeaderTest()
        {
            ProxyHttpClient.SimpleClientConfig model = Mockup.GetMockupConfigWithCustomHeader();
            var result = model.RemoveCustomHeader(Mockup.MockCustomHeaderKey);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddProtocolTypeByNameTest()
        {
            var model = Mockup.GetMockupConfig();
            bool result = model.AddProtocolTypeByName(SecurityProtocolNames.Ssl3);

            Assert.IsTrue(result);
        }
    }
}
