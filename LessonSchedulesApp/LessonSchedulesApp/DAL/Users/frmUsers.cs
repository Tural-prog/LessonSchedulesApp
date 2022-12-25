using LessonSchedulesApp.DAL.Days;
using LessonSchedulesApp.DAL.Subjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LessonSchedulesApp.DAL.Users
{
    public partial class frmUsers : Form
    {
        int selectedId = -1;
        UserCrudOperation _usersOperation;
        public frmUsers()
        {
            _usersOperation = new UserCrudOperation();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _usersOperation.UserInsert(txtName.Text, txtPassword.Text);
            dgwUser.DataSource = _usersOperation.GetUsers();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgwUser.DataSource = _usersOperation.GetUsers();
        }

        private void dgwUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgwUser.Rows[e.RowIndex].DataBoundItem;
                var val = (DataGridViewUser) row;

                var user =  _usersOperation.GetUserById(val.Id);
                txtName.Text =user.Name;
                txtPassword.Text = user.Password;
                selectedId = val.Id;              
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _usersOperation.UpdateUsers(selectedId, txtName.Text, txtPassword.Text);
            dgwUser.DataSource = _usersOperation.GetUsers ();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _usersOperation.DeleteUsers(selectedId);
            dgwUser.DataSource = _usersOperation.GetUsers();
        }

      
    }
}
;