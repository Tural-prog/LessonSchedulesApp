using LessonSchedulesApp.DAL.Days;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LessonSchedulesApp.DAL.Groups
{
    public partial class frmGroup : Form
    {
        int selectedId = -1;
        GroupsCrudOperation _groupsOperation;
        public frmGroup()
        {

            _groupsOperation = new GroupsCrudOperation();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _groupsOperation.GroupInsert(txtName.Text, chckStatus.Checked);

            dgvGroup.DataSource = _groupsOperation.GetGroup();

        }

        private void dgvGroup_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                var row = dgvGroup.Rows[e.RowIndex].DataBoundItem;
                var val = (DataGridViewGroups)row;

                var group = _groupsOperation.GetGroupById(val.Id);
                txtName.Text = group.Name;
                chckStatus.Checked = group.Status;
                selectedId = val.Id;
               
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgvGroup.DataSource = _groupsOperation.GetGroup();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _groupsOperation.GroupUpdate( selectedId,txtName.Text, chckStatus.Checked);

            dgvGroup.DataSource = _groupsOperation.GetGroup();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _groupsOperation.GroupDelete(selectedId);

            dgvGroup.DataSource = _groupsOperation.GetGroup();
        }

       
    }
}
