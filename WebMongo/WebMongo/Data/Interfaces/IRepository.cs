using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMongo.Models;

namespace WebMongo.Data.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Phone>> GetPhones(int? min, int? max, string name);
        Task<byte[]> GetImage(string id);
        Task Create(Phone name);
        Task Update(Phone name);
        Task Delete(string name);
        Task<Phone> Read(string id);
    }
}
