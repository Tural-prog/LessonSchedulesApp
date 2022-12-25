using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonSchedulesApp.DAL.Schedules
{
    internal class ScheduleModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Qurup")]
        public int GroupId { get; set; }
        [DisplayName("Gün")]
        public int DayId { get; set; }
        [DisplayName("Fənn")]
        public int SubjectId { get; set; }
        [DisplayName("İstifadəçi")]
        public int UsersId { get; set; }
        [DisplayName ("Sıra")]
        public int OrderIndex { get; set; }
    }


}
