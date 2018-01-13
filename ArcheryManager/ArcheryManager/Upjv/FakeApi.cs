using System.Collections.Generic;
using System.Threading.Tasks;
using ArcheryGlobalResult.Upjv;

namespace ArcheryManager.Upjv
{
    public class FakeApi : IUpjvScore
    {
        public List<JsonRegistered> Registereds = new List<JsonRegistered>()
        {
            new JsonRegistered { FirstName = "firstname2", Name = "name2", Category = "cate 2", Licence = "licence 2"},
            new JsonRegistered { FirstName = "firstname3", Name = "name3", Category = "cate 3", Licence = "licence 3"},
            new JsonRegistered { FirstName = "firstname1", Name = "name1", Category = "cate 1", Licence = "licence 1"},
        };

        public List<JsonShoot> Shoots = new List<JsonShoot>();

        public Task<IEnumerable<JsonRegistered>> GetAll()

        {
            return Task.Run<IEnumerable<JsonRegistered>>(() => Registereds);
        }

        public Task<JsonShoot> StartShoot(string email)
        {
            var shoot = new JsonShoot();
            Shoots.Add(shoot);
            return Task.Run(() => shoot);
        }

        public Task UpdateShoot(JsonUpdate update)
        {
            return Task.Run(() => { });
        }
    }
}
