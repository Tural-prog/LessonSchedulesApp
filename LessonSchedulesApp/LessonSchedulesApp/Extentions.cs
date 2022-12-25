using LessonSchedulesApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonSchedulesApp
{
    public static class Extentions
    {
        public static int AsInt(this object obj) 
        {
            var sub = obj as IdName;
            return sub.Id;
        }
    }
}
