using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMIS_G19
{
       public enum Day { Monday, Tusesday, Wednesday, Thursday, Firday, Saturday, Sunday };
       class Class
    {  
            public int Class_id { get; set; }
            public int Group_id { get; set; }
            public Day Day { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string Room { get; set; }

        public override string ToString()
        {
            return Group_id.ToString();
        }
    }
}



