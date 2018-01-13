using ArcheryGlobalResult.Upjv;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArcheryManager.Upjv
{
    public interface IUpjvScore
    {
        Task<IEnumerable<JsonRegistered>> GetAll();

        Task<JsonShoot> StartShoot(string email);

        Task UpdateShoot(JsonUpdate update);
    }
}
