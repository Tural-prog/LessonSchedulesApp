using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonSchedulesApp.DAL.Schedules
{
    internal class ScheduleViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Qurup")]
        public string GroupName { get; set; }
        [DisplayName("Gün")]
        public string DayName { get; set; }
        [DisplayName("Fənn")]
        public string SubjectName { get; set; }
        [DisplayName("İstifadəçi")]
        public string UsersName { get; set; }
        [DisplayName("Sıra")]
        public int OrderIndex { get; set; }

    }
}
