using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonSchedulesApp.DAL.Users
{
    internal class DataGridViewUser
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("İstifadəçi adı")]
        public string  Name { get; set; }
        [DisplayName("İstifadəçi şifrəsi")]
        public string Password { get; set; }
    }
}
