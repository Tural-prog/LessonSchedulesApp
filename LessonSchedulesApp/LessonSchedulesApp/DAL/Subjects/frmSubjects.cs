using LessonSchedulesApp.DAL.Days;
using LessonSchedulesApp.DAL.Subjects;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LessonSchedulesApp.Subject
{
    public partial class frmSubjects : Form
    {
        int selectedId =-1;
        SubjectsCrudOperation _subjectsOperation;
       
        public frmSubjects()
        {
            _subjectsOperation = new SubjectsCrudOperation();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _subjectsOperation.SubjectInsert(txtName.Text,txtDecription.Text, chckStatus.Checked, Convert.ToInt32( txtOrder.Text)); 
            dgwSubjects.DataSource = _subjectsOperation.GetSubject();
        }
        private void dgwSubjects_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgwSubjects.Rows[e.RowIndex].DataBoundItem;
                var val = (DataGridViewSubjects)row;

                var subject = _subjectsOperation.GetDayById(val.Id);
                txtName.Text = subject.Name;
               
                chckStatus.Checked = subject.Status;
                selectedId = val.Id;
                txtDecription.Text = subject.Decription;
                txtOrder.Text = subject.OrderIndex.ToString();
            }

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            _subjectsOperation.DeleteSubject(selectedId);
            dgwSubjects.DataSource = _subjectsOperation.GetSubject();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _subjectsOperation.UpdateSubjects(selectedId, txtName.Text, chckStatus.Checked, txtDecription.Text, Convert.ToInt32(txtOrder.Text));
            dgwSubjects.DataSource = _subjectsOperation.GetSubject();

        }

        private void btnView_Click(object sender, EventArgs e)
        {

            dgwSubjects.DataSource = _subjectsOperation.GetSubject();
        }

       
    }
}
