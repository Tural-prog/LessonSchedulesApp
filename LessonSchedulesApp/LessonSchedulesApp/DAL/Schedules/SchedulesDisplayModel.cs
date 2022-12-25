using System.ComponentModel;

namespace LessonSchedulesApp.DAL.Schedules
{
    internal class SchedulesDisplayModel
    {
        [Browsable(false)]
        public int DayId { get; set; }
        [DisplayName("Fənn")]
        public string SubjectName { get; set; }
        [Browsable(false)]
        public int OrderIndex { get; set; }
    }


}
