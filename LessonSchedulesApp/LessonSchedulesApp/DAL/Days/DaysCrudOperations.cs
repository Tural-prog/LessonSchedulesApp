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
using LessonSchedulesApp.DAL.Schedules;
using LessonSchedulesApp.Common;

namespace LessonSchedulesApp.DAL.Days
{
    internal class DaysCrudOperations
    {
        private bool IsDayDataValid(string name, bool staus)
        {
            // Verify that CustomerID is present.
            if (name == "")
            {
                MessageBox.Show("Please type name.");
                return false;
            }
            // Verify that Amount isn't 0.
            else if ((!staus))
            {
                MessageBox.Show("Please type status");
                return false;
            }
            else
            {
                // Order can be submitted.
                return true;
            }
        }

        internal void DayInsert(string name, bool status ,int orderIndex)
        {
            if (IsDayDataValid(name, status))
            {
                // define INSERT query with parameters
                string query = @"INSERT INTO Days (Name, Status, OrderIndex)
                                VALUES (@Name, @Status ,@OrderIndex) ";

                // create connection and command
                using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // define parameters and their values
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
                    cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = status;

                    cmd.Parameters.Add("@OrderIndex", SqlDbType.Int).Value = orderIndex;

                    // open connection, execute INSERT, close connection
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
        }
        internal void DeleteDay(int id)
        {
            string query = @"DELETE FROM Days WHERE id = @id ";


            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }
        internal void UpdateDay(int id ,string name, bool status, int orderIndex)
        {
            string query = @"UPDATE  Days SET  Name = @name, Status = @status , OrderIndex=@orderIndex WHERE Id = @id";

            // create connection and command
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // define parameters and their values
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
                cmd.Parameters.Add("@Status", SqlDbType.Bit, 50).Value = status;
                cmd.Parameters.Add("@OrderIndex", SqlDbType.Int).Value = orderIndex;

                // open connection, execute INSERT, close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            } 
        }
        internal IEnumerable<DataGridViewFill> GetDays()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Days ORDER BY OrderIndex ", cn);
               
                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridViewFill>(dt);
            }
        }
        internal IEnumerable<IdName> GetDaysByIdName()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT Id, Name,OrderIndex FROM Days WHERE Status = 1 ORDER BY OrderIndex ", cn);

                sda.Fill(dt);
                return Tools.ConvertDataTable<IdName>(dt);
            }
        }
        internal DataGridViewFill GetDayById(int id)
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Days WHERE Id = @id ", cn);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridViewFill>(dt)[0];
            }
        }
    }
}
