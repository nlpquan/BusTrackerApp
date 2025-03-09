using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BusLocationRepository : RepositoryBase<BusLocation>, IBusLocationRepository
    {
        public BusLocationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
