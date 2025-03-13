using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DriverTicketRepository : RepositoryBase<DriverTicket>, IDriverTicketRepository
    {
        public DriverTicketRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<DriverTicket> GetAllDriverTickets(bool trackChanges) =>
           FindAll(trackChanges).OrderBy(c => c.BusRoute).ToList();

        public DriverTicket GetDriverTicket(Guid driverTicketId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(driverTicketId), trackChanges).SingleOrDefault();

        public void CreateDriverTicket(DriverTicket driverTicket) => Create(driverTicket);
        public void DeleteDriverTicket(DriverTicket driverTicket) => Delete(driverTicket);
    }
}
