using System;

namespace GMIS_G19.Models
{
    
    class Meeting
    {
        public int meeting_id { get; set; }
        public int Group_id { get; set; }
        public Day Day { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Room { get; set; }
    }

  
}
