using LessonSchedulesApp.DAL.Days;
using LessonSchedulesApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonSchedulesApp.Days
{
    public partial class frmDays : Form
    {
        int selectedId = -1;
        DaysCrudOperations _daysOperation;
        public frmDays()
        {
            _daysOperation = new DaysCrudOperations();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            _daysOperation.DayInsert(txtName.Text, chckStatus.Checked,Convert.ToInt32(txtOrder.Text));
            dgwDays.DataSource = _daysOperation.GetDays();


        }

        private void dgwDays_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgwDays.Rows[e.RowIndex].DataBoundItem;
                var val = (DataGridViewFill)row;

                var day = _daysOperation.GetDayById(val.Id);
                txtName.Text = day.Name;
                chckStatus.Checked = day.Status;
                selectedId = val.Id;
                txtOrder.Text = day.OrderIndex.ToString();
            }
        }

       

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            _daysOperation.DeleteDay(selectedId);
            dgwDays.DataSource = _daysOperation.GetDays();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            _daysOperation.UpdateDay(selectedId, txtName.Text, chckStatus.Checked,Convert.ToInt32(txtOrder.Text));
            dgwDays.DataSource = _daysOperation.GetDays();
            

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgwDays.DataSource = _daysOperation.GetDays();

        }

       
    }
}
