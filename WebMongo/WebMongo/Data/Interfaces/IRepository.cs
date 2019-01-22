using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMongo.Models;

namespace WebMongo.Data.Interfaces
{
    interface IRepository
    {
        Task<IEnumerable<Phone>> GetAllGames();
        Task<Phone> GetGame(string name);
        Task Create(Phone game);
        Task<bool> Update(Phone game);
        Task<bool> Delete(string name);
    }
}
