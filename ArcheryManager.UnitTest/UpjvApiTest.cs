using ArcheryManager.Upjv;
using NUnit.Framework;
using Refit;
using System;

namespace ArcheryManager.UnitTest
{
    [TestFixture]
    public class UpjvApiTest
    {
        public IUpjvScore Api;

        [Test]
        public void ApiTest()
        {
            try
            {
                var res = Api.StartShoot("test@test").Result;
                var update = new JsonUpdate() { Id = res.Id, MaxScore = 30, Score = 28, TenCount = 2 };
                Api.UpdateShoot(update).Wait();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [SetUp]
        public void Init()
        {
            Api = RestService.For<IUpjvScore>("http://localhost:51964/");//"http://upjv-archery-api.azurewebsites.net");
        }
    }
}
