using System;

namespace GMIS_G19.Models
{
       public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
       public class Class
    {  
            public int Id { get; set; }
            public int GroupId { get; set; }
            public Day Day { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string Room { get; set; }
    }
}



