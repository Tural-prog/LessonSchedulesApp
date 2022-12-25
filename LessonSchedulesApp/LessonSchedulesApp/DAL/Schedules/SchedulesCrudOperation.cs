using LessonSchedulesApp.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace LessonSchedulesApp.DAL.Schedules
{
    internal class SchedulesCrudOperation
    {
        private bool IsSchedulesDataValid(int groupid, int dayid, int subjectid, int userid ,int orderIndex)
        {
            if (groupid == -1)
            {
                MessageBox.Show("Please type GroupId.");
                return false;
            }

            else if (dayid == -1)
            {
                MessageBox.Show("Please type Day");
                return false;
            }
            else if (subjectid == -1)
            {
                MessageBox.Show("Please type Subject");
                return false;
            }
            else if (userid == -1)
            {
                MessageBox.Show("Please type User");
                return false;
            }
            else if (orderIndex == -1)
            {
                MessageBox.Show("Please type OrderIndex");
                return false;
            }
            else
            {
                return true;
            }
        }
        internal void ScheduslesInsert(int groupid, int dayid, int subjectid, int userid, int orderIndex)
        {
            if (IsSchedulesDataValid(groupid, dayid, subjectid, userid, orderIndex))
            {
                string query = @"INSERT INTO Schedules (GroupId, DayId, SubjectId, UsersId, OrderIndex)
                                VALUES (@GroupId, @DayId ,@SubjectId, @UsersId, @OrderIndex) ";

                using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = groupid;
                    cmd.Parameters.Add("@DayId", SqlDbType.Int).Value = dayid;

                    cmd.Parameters.Add("@SubjectId", SqlDbType.Int).Value = subjectid;
                    cmd.Parameters.Add("@UsersId", SqlDbType.Int).Value = userid;
                    cmd.Parameters.Add("@OrderIndex", SqlDbType.Int).Value = orderIndex;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        internal void DeleteSchedules(int id)
        {
            string query = @"DELETE FROM Schedules Where id = @id";

            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }
        }
        internal void UpdateSchedules(int id, int groupid, int dayid, int subjectid, int userid, int orderIndex)
        {
            string query = @"UPDATE Schedules SET GroupId = @groupid,DayId =@dayid , SubjectId = @subjectid , UsersId= @userid, OrderIndex = @orderIndex, WHERE Id = @id";
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = groupid;
                cmd.Parameters.Add("@DayId", SqlDbType.Int).Value = dayid;

                cmd.Parameters.Add("@SubjectId", SqlDbType.Int).Value = subjectid;
                cmd.Parameters.Add("@UsersId", SqlDbType.Int).Value = userid;
                cmd.Parameters.Add(@"OrderIndex", SqlDbType.Int).Value = orderIndex;    

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        internal IEnumerable<ScheduleModel> GetSchedules()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT *FROM Schedules", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<ScheduleModel>(dt);
            }
        }
        internal IEnumerable<ScheduleViewModel> GetSchedulesV2()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT S.Id,G.Name AS GroupName,D.Name AS DayName, Sub.Name AS SubjectName,
                                            U.Name AS  UsersName, S.OrderIndex FROM Schedules as S
                                            LEFT JOIN Groups as G ON S.GroupId = G.Id
                                            LEFT JOIN Days as D ON S.DayId = D.Id
                                            LEFT JOIN Subjects as Sub ON S.SubjectId = Sub.Id
                                            LEFT JOIN Users as U ON S.UsersId = U.Id
                                            ORDER BY D.OrderIndex, S.OrderIndex ", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<ScheduleViewModel>(dt);
            }
        }
        internal IEnumerable<SchedulesDisplayModel> GetSchedulesForDisplay()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"		SELECT DayId,Subjects.Name AS SubjectName,Schedules.OrderIndex  FROM Schedules
		                                        JOIN Subjects ON Subjects.Id = Schedules.SubjectId ", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<SchedulesDisplayModel>(dt);
            }
        }
        internal ScheduleModel GetSchedulesById(int id)
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Schedules  WHERE Id = @id", cn);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.Fill(dt);
                return Tools.ConvertDataTable<ScheduleModel>(dt)[0];


            }
        }
    }
}
