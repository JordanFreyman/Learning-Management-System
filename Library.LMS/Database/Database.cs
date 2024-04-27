using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LMS.Models;

namespace Library.LMS.Database
{
    public static class Database
    {
        public static List<Person> People
        {
            get
            {
                return new List<Person>();
            }

        }

        public static List<Course> Courses
        {
            get
            {
                return new List<Course>();
            }
        }
    }
}
