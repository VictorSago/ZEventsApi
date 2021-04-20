using AutoMapper;
using ZEventsApi.Models.DTO;
using ZEventsApi.Models.Entities;

namespace ZEventsApi.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EventDay, EventDayDto>().ReverseMap();
            CreateMap<Lecture, LectureDto>().ReverseMap();
        }
    }
}