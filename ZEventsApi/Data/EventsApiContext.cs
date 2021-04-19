using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZEventsApi.Models.Entities;

namespace ZEventsApi.Data
{
    public class EventsApiContext : DbContext
    {
        public EventsApiContext (DbContextOptions<EventsApiContext> options)
            : base(options)
        {
        }

        public DbSet<ZEventsApi.Models.Entities.EventDay> EventDay { get; set; }
    }
}
