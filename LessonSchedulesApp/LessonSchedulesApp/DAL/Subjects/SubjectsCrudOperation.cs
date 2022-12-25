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

namespace LessonSchedulesApp.DAL.Subjects
{
    internal class SubjectsCrudOperation
    {
        private bool IsSubjectDataValid(string name,string decription, bool staus, int orderIndex)
        {
            
            if (name == "")
            {
                MessageBox.Show("Please type name.");
                return false;
            }           
            else if ((!staus))
            {
                MessageBox.Show("Please type status");
                return false;
            }
            else if (decription == " ")
            {
                MessageBox.Show("Please type decription");
                return false;
            }
           
            else
            {               
                return true;
            }
        }
        internal void SubjectInsert(string name, string decription ,bool status,int orderIndex)
        {
            if (IsSubjectDataValid( name, decription, status,orderIndex))
            {
                
                string query = @"INSERT INTO Subjects (Name, Decription, Status, OrderIndex)
                              VALUES (@Name, @Decription ,@Status ,@OrderIndex) ";

                
                using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
                    cmd.Parameters.Add("@Decription", SqlDbType.VarChar, 100).Value =decription;
                    cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = status;
                    cmd.Parameters.Add("@OrderIndex", SqlDbType.Int).Value = orderIndex;


                   
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
        }
        internal void DeleteSubject(int id)
        {

           
            string query = @"DELETE FROM Subjects WHERE id = @id ";

            
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }


        }
        internal void UpdateSubjects(int id, string name, bool status, string decription,int orderIndex)
        {
            string query = @"UPDATE  Subjects SET  Name = @name, Status = @status , Decription=@decription ,OrderIndex =@orderIndex WHERE Id = @id";

          
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = status;
                cmd.Parameters.Add("@Decription", SqlDbType.VarChar,50).Value = decription;
                cmd.Parameters.Add("@OrderIndex", SqlDbType.Int).Value = orderIndex;

                
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        internal IEnumerable<DataGridViewSubjects> GetSubject()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Subjects ORDER BY OrderIndex ", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridViewSubjects>(dt);
            }
        }
        internal IEnumerable<IdName> GetSubjectIdName()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT Id, Name, Decription ,OrderIndex FROM Subjects WHERE Status =1 ORDER BY OrderIndex ", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<IdName>(dt);
            }
        }
        internal DataGridViewSubjects GetDayById(int id)
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Subjects WHERE Id = @id ", cn);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridViewSubjects>(dt)[0];
            }
        }
    }
}
