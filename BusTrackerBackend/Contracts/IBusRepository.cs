using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Contracts
{
    public interface IBusRepository
    {
        IEnumerable<Bus> GetAllBuses(bool trackChanges);
        Bus GetBus(Guid busId, bool trackChanges);
        void CreateBus(Bus bus);
        void DeleteBus(Bus bus);
    }
}
