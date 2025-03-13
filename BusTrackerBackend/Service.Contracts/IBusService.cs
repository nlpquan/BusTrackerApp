using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IBusService
    {
        IEnumerable<BusDto> GetAllBuses(bool trackChanges);
        BusDto GetBus(Guid busId, bool trackChanges);
        BusDto CreateBus(BusForCreationDto bus);
        void DeleteBus(Guid busId, bool trackChanges);
        void UpdateBus(Guid busId, BusForUpdateDto busForUpdate, bool trackChanges);

    }
}
