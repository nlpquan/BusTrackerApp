using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class BusNotFoundException : NotFoundException
    {
        public BusNotFoundException(Guid busId)
        : base($"The bus with id: {busId} doesn't exist in the database.")
        {
        }
    }
}
