using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebMongo.Models;

namespace WebMongo.Data.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Phone>> GetPhones(int? min, int? max, string id);
        Task Create(Phone game);
        Task Update(Phone game);
        Task Delete(string name);
        Task<Phone> Read(string id);
        Task<byte[]> GetImage(string id);
        Task StoreImage(string id, Stream imageStream, string imageName);
    }
}
