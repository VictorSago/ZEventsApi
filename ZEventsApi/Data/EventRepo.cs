
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using ZEventsApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ZEventsApi.Data
{
    public class EventRepo
    {
        private readonly EventsApiContext _dbContext;

        public EventRepo(EventsApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EventDay>> GetAllAsync(bool includeLectures)
        {
            return includeLectures ? await _dbContext.EventDays
                                                    .Include(e => e.Location)
                                                    .Include(e => e.Lectures)
                                                    .ThenInclude(e => e.Speaker)
                                                    .ToListAsync() :
                                     await _dbContext.EventDays
                                                    .Include(e => e.Location)
                                                    .ToListAsync();
        }
    }
}