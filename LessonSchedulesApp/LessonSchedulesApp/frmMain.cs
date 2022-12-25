using LessonSchedulesApp.Common;
using LessonSchedulesApp.DAL.Groups;
using LessonSchedulesApp.DAL.Schedules;
using LessonSchedulesApp.DAL.Users;
using LessonSchedulesApp.Days;
using LessonSchedulesApp.Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonSchedulesApp
{
    public partial class Form1 : Form
    {
        SchedulesCrudOperation _schedule;
        public Form1()
        {
            InitializeComponent();
            _schedule = new SchedulesCrudOperation();
        }

        private void schedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmSchedules = new frmSchedules();
            frmSchedules.Show();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmSchedules = new frmSchedules();
            frmSchedules.Show();

        }

        private void daysToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmDay = new frmDays();
            frmDay.Show();

        }

        private void subjectsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            var frmSubject = new frmSubjects();
            frmSubject.Show();

        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmUser = new frmUsers();
            frmUser.Show();

        }

        private void groupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmGroup = new frmGroup();
            frmGroup.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var data = _schedule.GetSchedulesForDisplay();

            dgvUstI.DataSource = data.Where(c => c.DayId == (int)DaysEnumeration.Monday).OrderBy(c => c.OrderIndex).ToList();
            dgvUstII.DataSource = data.Where(c => c.DayId == (int)DaysEnumeration.Tuesday).OrderBy(c => c.OrderIndex).ToList();
            dgvUstIII.DataSource = data.Where(c => c.DayId == (int)DaysEnumeration.Wednesday).OrderBy(c => c.OrderIndex).ToList();
            dgvUstIV.DataSource = data.Where(c => c.DayId == (int)DaysEnumeration.Thursday).OrderBy(c => c.OrderIndex).ToList();
            dgvUstV.DataSource = data.Where(c => c.DayId == (int)DaysEnumeration.Friday).OrderBy(c => c.OrderIndex).ToList();
        }

      
    }
}
