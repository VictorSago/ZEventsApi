using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZEventsApi.Data;
using ZEventsApi.Models.Entities;

namespace ZEventsApi.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventDaysController : ControllerBase
    {
        private readonly EventsApiContext _dbContext;

        public EventDaysController(EventsApiContext context)
        {
            _dbContext = context;
        }

        // GET: api/EventDays
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<EventDay>>> GetEventDay()
        // {
        //     return await _dbContext.EventDay.ToListAsync();
        // }

        
    }
}
