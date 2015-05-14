using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.MODEL;

namespace UniversityManagementApp.DAL
{
    public class StudentDepartmentGatway
    {
        public string databaseConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public List<StudentDepartment> GetAllStudentDepartment()
        {
            SqlConnection connection = new SqlConnection(databaseConString);

            string query = "SELECT * FROM view_studentDepartment";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<StudentDepartment> studentList = new List<StudentDepartment>();

            while (reader.Read())
            {
                StudentDepartment studentDepartments = new StudentDepartment();
                studentDepartments.StdDeptId = int.Parse(reader["student_id"].ToString());
                studentDepartments.StdDeptRegNo = reader["student_regNo"].ToString();
                studentDepartments.StdDeptName = reader["student_name"].ToString();
                studentDepartments.StdDeptAddress = reader["student_address"].ToString();
                //studentDepartments.StdDepartmentName = (reader["department_name"].ToString());
                studentDepartments.StdDepartmentName = (reader["department_name"].ToString());

                studentList.Add(studentDepartments);
            }
            reader.Close();
            connection.Close();

            return studentList;
        }

        public List<StudentDepartment> SearchStudentByRegNoName(string searchRegNo, string searchName)
        {
            SqlConnection connection = new SqlConnection(databaseConString);

            string query = "SELECT * FROM view_studentDepartment";
            if (searchRegNo!="" && searchName!="")
            {
                query = "SELECT * FROM view_studentDepartment WHERE student_regNo = '" + searchRegNo + "' AND student_name = '" + searchName + "'";
            }
            else if (searchRegNo!="")
            {
                query = "SELECT * FROM view_studentDepartment WHERE student_regNo = '" + searchRegNo + "'";
            }
            else if (searchName != "")
            {
                query = "SELECT * FROM view_studentDepartment WHERE student_name = '" + searchName + "'";
            }

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<StudentDepartment> studentList = new List<StudentDepartment>();

            while (reader.Read())
            {
                StudentDepartment studentDepartments = new StudentDepartment();
                studentDepartments.StdDeptId = int.Parse(reader["student_id"].ToString());
                studentDepartments.StdDeptRegNo = reader["student_regNo"].ToString();
                studentDepartments.StdDeptName = reader["student_name"].ToString();
                studentDepartments.StdDeptAddress = reader["student_address"].ToString();
                //studentDepartments.StdDepartmentName = (reader["department_name"].ToString());
                studentDepartments.StdDepartmentName = (reader["department_name"].ToString());

                studentList.Add(studentDepartments);
            }
            reader.Close();
            connection.Close();

            return studentList;
        }

        //public int Delete(Student students, string regNoId)
        //{
        //    SqlConnection connection = new SqlConnection(databaseConString);
        //    string query = "DELETE FROM tbl_student WHERE student_regNo = '" + regNoId + "'";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    connection.Open();
        //    int rowAffected = command.ExecuteNonQuery();
        //    connection.Close();

        //    return rowAffected;
        //}


        //public StudentDepartment GetStudentDepartmentByRegNo(string regNoId)
        //{
        //    SqlConnection connection = new SqlConnection(databaseConString);

        //    string query = "SELECT * FROM tbl_student WHERE student_regNo = '" + regNoId + "'";
            
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();

        //    StudentDepartment studentDepartments = new StudentDepartment();

        //    while (reader.Read())
        //    {
        //        //studentDepartments.StdDeptId = int.Parse(reader["student_id"].ToString());
        //        studentDepartments.StdDeptRegNo = reader["student_regNo"].ToString();
        //        studentDepartments.StdDeptName = reader["student_name"].ToString();
        //        studentDepartments.StdDeptAddress = reader["student_address"].ToString();
        //        studentDepartments.StdDepartmentName = (reader["department_name"].ToString());
        //    }
        //    reader.Close();
        //    connection.Close();

        //    return studentDepartments;
        //}

        //public int Update(StudentDepartment students, string regNoId)
        //{
        //    SqlConnection connection = new SqlConnection(databaseConString);
        //    string query = "UPDATE tbl_student SET student_regNo = '" + studentDepartment.StdDeptRegNo +
        //                   "',student_name = '" + studentDepartment.StdDeptName + "',student_address = '" +
        //                   studentDepartment.StdDeptAddress + "',department_name = '" +
        //                   studentDepartment.StdDepartmentName + "' WHERE student_regNo = '"+regNoId+"'";
        //    SqlCommand command = new SqlCommand(query, connection);

        //    connection.Open();
        //    int rowAffected = command.ExecuteNonQuery();
        //    connection.Close();

        //    return rowAffected;
        //}
    }
}
