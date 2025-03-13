using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Service
{
    internal sealed class BusService : IBusService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BusService(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        public IEnumerable<BusDto> GetAllBuses(bool trackChanges)
        {
            var buses = _repository.Bus.GetAllBuses(trackChanges);

            var busesDto = _mapper.Map<IEnumerable<BusDto>>(buses);

            return busesDto;
        }

        public BusDto GetBus(Guid id, bool trackChanges)
        {
            var bus = _repository.Bus.GetBus(id, trackChanges);
            if (bus is null)
                throw new BusNotFoundException(id);

            var busDto = _mapper.Map<BusDto>(bus);
            return busDto;
        }

        public BusDto CreateBus(BusForCreationDto bus)
        {
            var busEntity = _mapper.Map<Bus>(bus);
            _repository.Bus.CreateBus(busEntity);
            _repository.Save();
            var busToReturn = _mapper.Map<BusDto>(busEntity);
            return busToReturn;
        }

        public void DeleteBus(Guid busId, bool trackChanges)
        {
            var bus = _repository.Bus.GetBus(busId, trackChanges);
            if (bus is null)
                throw new BusNotFoundException(busId);
            _repository.Bus.DeleteBus(bus);
            _repository.Save();
        }

        public void UpdateBus(Guid busId, BusForUpdateDto busForUpdate, bool trackChanges)
        {
            var busEntity = _repository.Bus.GetBus(busId, trackChanges);
            if (busEntity is null)
                throw new BusNotFoundException(busId);
            _mapper.Map(busForUpdate, busEntity);
            _repository.Save();
        }


    }

}
