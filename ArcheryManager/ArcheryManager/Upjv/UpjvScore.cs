using System.Collections.Generic;
using System.Threading.Tasks;
using ArcheryGlobalResult.Upjv;
using ArcheryManager.Controllers;

namespace ArcheryManager.Upjv
{
    internal class UpjvScore : IUpjvScore
    {
        private readonly RestController Controller;

        public UpjvScore(string uri)
        {
            Controller = new RestController(uri);
        }

        public async Task<IEnumerable<JsonRegistered>> GetAll()
        {
            return await Controller.GetAsync<IEnumerable<JsonRegistered>>("api/get-registered");
        }

        public async Task<JsonShoot> StartShoot(string email)
        {
            return await Controller.PutAsync<JsonShoot>("/api/start-shoot/", body: email);
        }

        public async Task UpdateShoot(JsonUpdate update)
        {
            await Controller.PutAsync<object>("/api/update-shoot", body: update);
        }
    }
}
