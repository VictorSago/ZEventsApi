using System.Collections.Generic;

namespace ZEventsApi.Models.Entities
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string CompanyUrl { get; set; }
        public string BlogUrl { get; set; }
        public string GitHub { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}