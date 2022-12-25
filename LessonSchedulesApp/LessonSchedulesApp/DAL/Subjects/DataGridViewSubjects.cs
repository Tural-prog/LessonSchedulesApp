using System.ComponentModel;

namespace LessonSchedulesApp.DAL.Days
{
    internal class DataGridViewSubjects
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Fənnin adı")]
        public string Name { get; set; }
        [DisplayName("Fənnin təsviri")]
        public string Decription { get; set; }
        [DisplayName("Statusu")]
        public bool  Status { get; set; }
        [DisplayName ("Sıralama")]
        public int OrderIndex { get; set; }


    }
}
