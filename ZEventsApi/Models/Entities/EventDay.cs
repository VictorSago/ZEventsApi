using System;
using System.Collections.Generic;

namespace ZEventsApi.Models.Entities
{
    public class EventDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public int Length { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
