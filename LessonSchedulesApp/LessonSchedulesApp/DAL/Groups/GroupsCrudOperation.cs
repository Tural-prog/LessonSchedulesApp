using LessonSchedulesApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LessonSchedulesApp.DAL.Days;
using LessonSchedulesApp.DAL.Users;
using LessonSchedulesApp.Common;

namespace LessonSchedulesApp.DAL.Groups
{
    internal class GroupsCrudOperation
    {
        private bool  IsGroupDataValid(string name ,bool satatus)
        {

            if (name == "")
            {
                MessageBox.Show("Please type name.");
                return false;
            }

            else if ((!satatus))
            {
                MessageBox.Show("Please type status");
                return false;
            }
           
            else
            {

                return true;
            }

        }
        internal void GroupInsert(string name, bool status)
        {
            if (IsGroupDataValid(name, status))
            {
                string query = @"INSERT INTO Groups (Name,  Status)
                                VALUES (@Name, @Status ) ";

                using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
                    cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = status;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
        }
        internal void GroupDelete(int id)
        {
            string query = @"DELETE FROM Groups Where id=@id";
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }
        internal void GroupUpdate(int id, string name, bool status)
        {
            string query = @"UPDATE Groups SET Name =@name , Status =@status WHERE Id = @id";
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Name", SqlDbType.Char).Value = name;
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = status;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }
        }
        internal IEnumerable<DataGridViewGroups> GetGroup()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Groups  ", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridViewGroups>(dt);
            }
        }

        internal IEnumerable<IdName> GetGroupByIdName()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT Id, Name FROM Groups WHERE Status = 1  ", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<IdName>(dt);
            }
        }
        internal DataGridViewGroups GetGroupById(int id)
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Groups WHERE Id = @id ", cn);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridViewGroups>(dt)[0];
            }
        }
    }
    
}
