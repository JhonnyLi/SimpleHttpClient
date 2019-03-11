using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProxyHttpClient.Test
{
    [TestClass]
    public class ProxyClientConfigTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            ProxyClientConfig target = Mockup.GetMockupConfig();
            PrivateObject obj = new PrivateObject(target);
            var retVal = obj.Invoke("CreateUriFromUrl",Mockup.MockUrl);
            Assert.AreEqual(typeof(Uri),retVal.GetType());
        }
        [TestMethod]
        public void AddCustomHeaderTest()
        {
            ProxyHttpClient.ProxyClientConfig model = Mockup.GetMockupConfig();
            var result = model.AddCustomHeader("key", "value");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveCustomHeaderTest()
        {
            ProxyHttpClient.ProxyClientConfig model = Mockup.GetMockupConfigWithCustomHeader();
            var result = model.RemoveCustomHeader(Mockup.MockCustomHeaderKey);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddProtocolTypeByNameTest()
        {

        }
    }
}
