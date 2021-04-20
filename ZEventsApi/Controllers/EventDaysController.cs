using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<EventDayDto>>> GetAllEvents(bool includeLectures = false)
        {
            var result = await _eventDayRepo.GetAllAsync(includeLectures);
            var dto = _mapper.Map<IEnumerable<EventDayDto>>(result);
            return Ok(dto);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<EventDayDto>> GetEvent(string name, bool includeLectures = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var result = await _eventDayRepo.GetEventAsync(name, includeLectures);

            if (result is null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<EventDayDto>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<EventDayDto>> CreateEvent(EventDayDto dto)
        {
            if (await _eventDayRepo.GetEventAsync(dto.Name, false) is not null)
            {
                ModelState.AddModelError("Name", "Name already in use");
                return BadRequest(ModelState);
            }

            var eventday = _mapper.Map<EventDay>(dto);
            await _eventDayRepo.AddAsync(eventday);

            if (await _eventDayRepo.SaveAsync())
            {
                var model = _mapper.Map<EventDayDto>(eventday);
                return CreatedAtAction(nameof(GetEvent), new { name = model.Name}, model);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
