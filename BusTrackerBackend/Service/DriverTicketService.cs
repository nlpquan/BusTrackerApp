using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Service
{
    internal sealed class DriverTicketService : IDriverTicketService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public DriverTicketService(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<DriverTicketDto> GetAllDriverTickets(bool trackChanges)
        {
            var driverTickets = _repository.DriverTicket.GetAllDriverTickets(trackChanges);

            var driverTicketsDto = _mapper.Map<IEnumerable<DriverTicketDto>>(driverTickets);

            return driverTicketsDto;
        }

        public DriverTicketDto GetDriverTicket(Guid id, bool trackChanges)
        {
            var driverTicket = _repository.DriverTicket.GetDriverTicket(id, trackChanges);
            if (driverTicket is null)
                throw new DriverTicketNotFoundException(id);

            var driverTicketDto = _mapper.Map<DriverTicketDto>(driverTicket);
            return driverTicketDto;
        }

        public DriverTicketDto CreateDriverTicket(DriverTicketForCreationDto driverTicket)
        {
            var driverTicketEntity = _mapper.Map<DriverTicket>(driverTicket);
            _repository.DriverTicket.CreateDriverTicket(driverTicketEntity);
            _repository.Save();
            var driverTicketToReturn = _mapper.Map<DriverTicketDto> (driverTicketEntity);
            return driverTicketToReturn;
        }

        public void DeleteDriverTicket(Guid driverTicketId, bool trackChanges)
        {
            var driverTicket = _repository.DriverTicket.GetDriverTicket(driverTicketId, trackChanges);
            if (driverTicket is null)
                throw new DriverTicketNotFoundException(driverTicketId);
            _repository.DriverTicket.DeleteDriverTicket(driverTicket);
            _repository.Save();
        }

        public void UpdateDriverTicket(Guid driverTicketId, DriverTicketForUpdateDto driverTicketForUpdate, bool trackChanges)
        {
            var driverTicketEntity = _repository.DriverTicket.GetDriverTicket(driverTicketId, trackChanges);
            if (driverTicketEntity is null)
                throw new DriverTicketNotFoundException(driverTicketId);
            _mapper.Map(driverTicketForUpdate, driverTicketEntity);
            _repository.Save();
        }
    }
}
