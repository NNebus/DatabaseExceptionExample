using Microsoft.EntityFrameworkCore;
using Shared.Models.Services;
using Shared.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Repositories
{
    public class TicketRepository
    {
        private IDependencyService _dependencyService;
        public DatabaseContext _databaseContext;

        public TicketRepository(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
            _databaseContext = new DatabaseContext(_dependencyService);
        }

        public TicketRepository() : this(new DependencyServiceWrapper()){}


        public bool AddEntity(Ticket entity)
        {
            try
            {
                var tracking = _databaseContext.Tickets.Add(entity);
                int amoutDataWritten = _databaseContext.SaveChanges();

                var isAdded = amoutDataWritten > 0;

                return isAdded;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Ticket>> GetEntityAsync()
        {
            try
            {
                var entity = await _databaseContext.Tickets.ToListAsync();
                return entity;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}
