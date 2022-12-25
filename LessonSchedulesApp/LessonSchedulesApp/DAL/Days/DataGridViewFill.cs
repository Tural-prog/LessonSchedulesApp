using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LessonSchedulesApp.DAL.Days
{

    internal class DataGridViewFill
    {

        
        [DisplayName("Adı")]
        public string Name { get; set; }
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Statusu")]
        public bool Status { get; set; }
        public int  OrderIndex { get; set; }
    }
}
