using LessonSchedulesApp.DAL.Days;
using LessonSchedulesApp.DAL.Groups;
using LessonSchedulesApp.DAL.Subjects;
using LessonSchedulesApp.DAL.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LessonSchedulesApp.DAL.Schedules
{
    public partial class frmSchedules : Form
    {
        int selectedId = -1;
        SchedulesCrudOperation _schedulesOperation;
        ScheduleValidation _vlaidation;

        GroupsCrudOperation _groupsCrud;

        DaysCrudOperations _daysCrud;

        SubjectsCrudOperation _subjectsCrud;

        UserCrudOperation _userCrud;
        public frmSchedules()
        {
            _schedulesOperation = new SchedulesCrudOperation();
            _groupsCrud = new GroupsCrudOperation();
            _daysCrud = new DaysCrudOperations();
            _subjectsCrud = new SubjectsCrudOperation();
            _userCrud = new UserCrudOperation();
            _vlaidation = new ScheduleValidation();
            InitializeComponent();

            cmbGroup.DataSource = _groupsCrud.GetGroupByIdName();
            cmbDay.DataSource = _daysCrud.GetDaysByIdName();
            cmbSubject.DataSource = _subjectsCrud.GetSubjectIdName();
            cmbUser.DataSource = _userCrud.GetUsersIdName();

        }
        private void CmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedIndex == 1)
            {
                // CmbGroup.Items[0] = ""

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_vlaidation.Validate(cmbGroup.SelectedItem, cmbDay.SelectedItem, cmbSubject.SelectedItem, cmbUser.SelectedItem))
            {
                _schedulesOperation.ScheduslesInsert(cmbGroup.SelectedItem.AsInt(), cmbDay.SelectedItem.AsInt(), cmbSubject.SelectedItem.AsInt(), 
                    cmbUser.SelectedItem.AsInt(), Convert.ToInt32(txtOrder.Text));

                dgwSchedules.DataSource = _schedulesOperation.GetSchedulesV2();
            }
            else

            {
                MessageBox.Show("Bütün məlumatları daxil edin");
            }
        }

        private void dgwSchedules_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgwSchedules.Rows[e.RowIndex].DataBoundItem;
                var val = (ScheduleViewModel)row;

                var group = _schedulesOperation.GetSchedulesById(val.Id);
                cmbGroup.SelectedValue = group.GroupId;
                cmbDay.SelectedValue = group.DayId;
                cmbSubject.SelectedValue = group.SubjectId;
                cmbUser.SelectedValue = group.UsersId;
                txtOrder.Text = group.OrderIndex.ToString();

                selectedId = val.Id;

            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgwSchedules.DataSource = _schedulesOperation.GetSchedulesV2();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {



            _schedulesOperation.UpdateSchedules(selectedId, cmbGroup.AsInt(), cmbDay.AsInt(), cmbSubject.AsInt(), cmbUser.AsInt(), Convert.ToInt32(txtOrder.Text));

            dgwSchedules.DataSource = _schedulesOperation.GetSchedulesV2();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _schedulesOperation.DeleteSchedules(selectedId);

            dgwSchedules.DataSource = _schedulesOperation.GetSchedulesV2();
        }
    }
}
