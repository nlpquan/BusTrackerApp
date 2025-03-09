using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BusRouteRepository : RepositoryBase<BusRoute>, IBusRouteRepository
    {
        public BusRouteRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
