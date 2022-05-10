using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMIS_G19
{
    public enum Campus { Hobart, Launceston};
    public enum Category { Bachelors, Masters };
    class Student
    {
        public int Student_id { get; set; }
        public string Given_name { get; set; }
        public string Family_name { get; set; }
        public int Group_id { get; set; }
        public string Title { get; set; }
        public Campus Campus { get; set; }
        public string Phone { get; set; }
        public string  Email { get; set; }

        public string Photo { get; set; }

        public Category Category { get; set; }

    }
}


