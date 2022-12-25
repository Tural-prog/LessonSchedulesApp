using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonSchedulesApp.DAL.Schedules
{
    internal class ScheduleValidation
    {
        bool IsValid(object obj)
        {
            return obj != null;

        }
        internal bool Validate(object groupid, object dayid, object subjectid, object userid)
        {
            return IsValid(groupid) & IsValid(dayid) & IsValid(subjectid) & IsValid(userid);
        }

    }
}
