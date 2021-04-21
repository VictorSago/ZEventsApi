
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using ZEventsApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<EventDay> GetEventAsync(string name, bool includeLectures)
        {
            // TODO: Validate name

            var query = _dbContext.EventDays.Include(e => e.Location).AsQueryable();

            if (includeLectures)
            {
                query = query.Include(e => e.Lectures);
            }
            return await query.FirstOrDefaultAsync(e => e.Name.Equals(name));
        }

        public async Task AddAsync<T>(T added)
        {
            await _dbContext.AddAsync(added);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync()) >= 0;
        }

        public async Task<Lecture[]> GetAllLecturesAsync(string name, bool includeSpeakers)
        {
            var query = _dbContext.Lectures.AsQueryable();
            query = includeSpeakers ? query.Include(l => l.Speaker) : query;
            query = query.Where(l => l.EventDay.Name.ToUpper().Equals(name.ToUpper()));

            return await query.ToArrayAsync();
        }
    }
}