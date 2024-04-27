using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.LMS.Models;

namespace Maui.LMS.ViewModels
{
    internal class MainViewModel
    {
        public List<Library.LMS.Models.Person> Students { get; set; } = new List<Library.LMS.Models.Person>();
    }
}
