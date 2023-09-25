using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiEg.Models;

namespace WebApiEg.Repository
{
    public class StudentRepository : BaseRepository
    {
        //save to database
        public string Save(StudentData data)
        {
            string response = string.Empty;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_student_save";
                using (SqlConnection connection = Connection())
                {
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = data.First_Name;
                    cmd.Parameters.Add("@LName", SqlDbType.VarChar).Value = data.Last_Name;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows && dr.Read())
                        {
                            response = dr.GetString(0);
                        }
                    }
                }
            }
            return response;
        }
        //get data using id from database
        public StudentData GetById(int id)
        {
            StudentData student = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_student_display";
                using (SqlConnection connection = Connection())
                {
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {                    
                        while (dr.Read())
                        {
                            student = new StudentData();
                            student.First_Name = dr.GetValue(1).ToString();
                            student.Last_Name = dr.GetValue(2).ToString();
                        }
                    }
                }
            }
            return student;
        }
        //delete data using id from database
        public void DeleteById(int id)
        {
           
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_student_delete";
                using (SqlConnection connection = Connection())
                {
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    SqlDataReader dr = cmd.ExecuteReader();
                
                }
            }
        }
        //get all data  from database
        public List<StudentData> GetAll()
        {
            List<StudentData> studentlist=new List<StudentData>();
            StudentData student = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_student_displayAll";
                using (SqlConnection connection = Connection())
                {
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 30;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            student = new StudentData();
                            student.First_Name = dr.GetValue(1).ToString();
                            student.Last_Name = dr.GetValue(2).ToString();
                            studentlist.Add(student);

                        }
                    }
                }
            }
            return studentlist;     
        }
       

    }
}
