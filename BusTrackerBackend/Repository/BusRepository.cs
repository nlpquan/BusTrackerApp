using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class BusRepository : RepositoryBase<Bus>, IBusRepository
    {
        public BusRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Bus> GetAllBuses(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.PlateNumber).ToList();

        public Bus GetBus(Guid busId, bool trackChanges) => 
            FindByCondition(c => c.Id.Equals(busId), trackChanges).SingleOrDefault();

        public void CreateBus(Bus bus) => Create(bus);
        public void DeleteBus(Bus bus) => Delete(bus);

    }
}
