using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZEventsApi.Data;
using ZEventsApi.Models.DTO;
using ZEventsApi.Models.Entities;

namespace ZEventsApi.Controllers
{
    [Route("api/events/{name}/lectures")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
        private readonly EventsApiContext _dbContext;
        private readonly IMapper _mapper;
        private readonly EventRepo _eventDayRepo;

        public LecturesController(EventsApiContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
            _eventDayRepo = new EventRepo(context);
        }

        [HttpGet]
        public async Task<ActionResult<LectureDto>> GetAll(string name, bool includeSpeakers = false)
        {
            var lectures = await _eventDayRepo.GetAllLecturesAsync(name, includeSpeakers);
            var model = _mapper.Map<LectureDto[]>(lectures);
            return Ok(model);
        }

        // POST: api/events/name/lectures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LectureDto>> AddLecture(string name, LectureDto dto)
        {
            var eventday = await _eventDayRepo.GetEventAsync(name, true);
            // ToDo: Finish!
            return Ok();
        }


    }
}
