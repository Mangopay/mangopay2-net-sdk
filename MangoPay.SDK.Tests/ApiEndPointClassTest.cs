using MangoPay.SDK.Core;
using MangoPay.SDK.Entities;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiEndPointClassTest : BaseTest
    {
        [Test]
        public void Test_EmbedParameters()
        {
			// No parameters
			var urlFragment = "/foo/bar";
			var endPoint = new ApiEndPoint(urlFragment, "GET");
			Assert.AreEqual(urlFragment, endPoint.GetUrl());

			endPoint.SetParameters("ignore");
			Assert.AreEqual(urlFragment, endPoint.GetUrl());

			endPoint.SetParameters("ignore", "ignore");
			Assert.AreEqual(urlFragment, endPoint.GetUrl());

			// One parameter
			urlFragment = "/foo/{0}/bar";
			endPoint = new ApiEndPoint(urlFragment, "GET");
			Assert.AreEqual(urlFragment, endPoint.GetUrl());

			endPoint.SetParameters("123");
			Assert.AreEqual("/foo/123/bar", endPoint.GetUrl());

			endPoint.SetParameters("123", "ignore");
			Assert.AreEqual("/foo/123/bar", endPoint.GetUrl());

			// Two parameters
			urlFragment = "/foo/{0}/bar/{1}";
			endPoint = new ApiEndPoint(urlFragment, "GET");
			Assert.AreEqual(urlFragment, endPoint.GetUrl());

			endPoint.SetParameters("123", "456");
			Assert.AreEqual("/foo/123/bar/456", endPoint.GetUrl());
		}
    }
}
