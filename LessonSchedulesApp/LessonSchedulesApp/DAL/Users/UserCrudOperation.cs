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
using LessonSchedulesApp.Common;

namespace LessonSchedulesApp.DAL.Users
{
    internal class UserCrudOperation
    {
        private bool IsUserDataValid(string name, string password)
        {
            
            if (name == "")
            {
                MessageBox.Show("Please type name.");
                return false;
            }
           
            else if (password == " ")
            {
                MessageBox.Show("Please type password");
                return false;
            }
            else
            {
                
                return true;
            }

        }
        internal void UserInsert(string name, string password)
        {
            if (IsUserDataValid(name, password))
            {
                string query = @"INSERT INTO Users (Name, Password)
                                VALUES (@Name, @Password) ";

                using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar,50).Value = password;
                  
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
        }
        internal void DeleteUsers(int id)
        {

            
            string query = @"DELETE FROM Users Where id= @id";

            
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

             
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }


        }
        internal void UpdateUsers(int id, string name, string password)
        {
            string query = @"UPDATE  Users SET  Name = @name, Password =@password  WHERE Id = @id";

           
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = password;

            
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        internal IEnumerable<DataGridViewUser> GetUsers()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Users  ", cn);

                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridViewUser>(dt);
            }
        }
        internal IEnumerable<IdName> GetUsersIdName()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT Id , Name,Password FROM Users  ", cn);

                sda.Fill(dt);
                return Tools.ConvertDataTable<IdName>(dt);
            }
        }
        internal DataGridViewUser GetUserById(int id)
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Users WHERE Id = @id ", cn);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridViewUser>(dt)[0];
            }
        }
    }
}
