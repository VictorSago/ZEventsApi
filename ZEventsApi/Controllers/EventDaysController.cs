using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZEventsApi.Data;
using ZEventsApi.Models.DTO;
using ZEventsApi.Models.Entities;

namespace ZEventsApi.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventDaysController : ControllerBase
    {
        private readonly EventRepo _eventDayRepo;
        private readonly IMapper _mapper;

        public EventDaysController(EventsApiContext context, IMapper mapper)
        {
            _eventDayRepo = new EventRepo(context);
            _mapper = mapper;
        }

        // GET: api/EventDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDay>>> GetAllEvents(bool includeLectures = false)
        {
            var dto = _mapper.Map<EventDayDto>(await _eventDayRepo.GetAllAsync(includeLectures));
            return Ok(dto);
        }

        
    }
}
