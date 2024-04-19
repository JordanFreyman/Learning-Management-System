using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.LMS.ViewModels
{
    public class StudentDetailViewModel
    {
        public int studentNumber { get; set; }
        public string Name { get; set; }
        public string ClassificationStr { get; set; }
        public int Classification { get; set; }
        

    }
}
