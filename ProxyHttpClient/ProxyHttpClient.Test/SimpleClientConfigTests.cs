using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleHttpClient;

namespace SimpleHttpClient.Test
{
    [TestClass]
    public class SimpleClientConfigTests
    {
        [TestMethod]
        public void Constructor_CreateUriFromUrl_ValidUri()
        {
            SimpleClientConfig target = Mockup.GetMockupConfig();
            PrivateObject obj = new PrivateObject(target);
            var retVal = obj.Invoke("CreateUriFromUrl", Mockup.MockUrl);
            Assert.AreEqual(typeof(Uri), retVal.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(System.Reflection.TargetInvocationException), ErrorHandling.ErrorConstants.Uri.InvalidUrl)]
        public void Constructor_CreateUriFromInvalidUrl_ThrownException()
        {
            SimpleClientConfig target = Mockup.GetMockupConfig();
            PrivateObject obj = new PrivateObject(target);
            var retVal = obj.Invoke("CreateUriFromUrl", Mockup.MockInvalidUrl);
        }

        [TestMethod]
        public void AddCustomHeader_AddCustomHeader_ReturnsTrue()
        {
            SimpleHttpClient.SimpleClientConfig model = Mockup.GetMockupConfig();
            var result = model.AddCustomHeader("key", "value");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddCustomHeader_AddAlreadyExistingCustomHeader_ReturnsFalse()
        {
            SimpleHttpClient.SimpleClientConfig model = Mockup.GetMockupConfigWithCustomHeader();
            var result = model.AddCustomHeader(Mockup.MockCustomHeaderKey, "value");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveCustomHeader_RemoveCustomHeader_ReturnsTrue()
        {
            SimpleHttpClient.SimpleClientConfig model = Mockup.GetMockupConfigWithCustomHeader();
            var result = model.RemoveCustomHeader(Mockup.MockCustomHeaderKey);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveCustomHeader_RemoveNonExistantCustomHeader_ReturnsFalse()
        {
            SimpleHttpClient.SimpleClientConfig model = Mockup.GetMockupConfigWithCustomHeader();
            var result = model.RemoveCustomHeader("ThisKeyDoesNotExist");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddProtocolTypeByName_SpecifySslType_ReturnsTrue()
        {
            var model = Mockup.GetMockupConfig();
            bool result = model.AddProtocolTypeByName(SecurityProtocolNames.Ssl3);

            Assert.IsTrue(result);
        }
    }
}
