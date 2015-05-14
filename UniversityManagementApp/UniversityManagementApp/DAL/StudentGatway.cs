using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.MODEL;

namespace UniversityManagementApp.DAL
{
    public class StudentGatway
    {
        public string studentConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public Student GetStudentByRegNo(string regNo)
        {
            SqlConnection connection = new SqlConnection(studentConString);

            string query = "SELECT * FROM tbl_student WHERE student_regNo = '" + regNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Student students = null;


            while (reader.Read())
            {

                if (students == null)
                {
                    students = new Student();
                }

                students.studentId = int.Parse(reader["student_id"].ToString());
                students.studentRegNo = reader["student_regNo"].ToString();
                students.studentName = reader["student_name"].ToString();
                students.studentAddress = reader["student_address"].ToString();
            }
            reader.Close();
            connection.Close();

            return students;
        }

        public int Save(Student students)
        {
            SqlConnection connection = new SqlConnection(studentConString);
            string query = "INSERT INTO tbl_student VALUES('" + students.studentRegNo +
                           "','" + students.studentName + "','" + students.studentAddress + "','"+students.departmentId+"')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<Student> GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(studentConString);

            string query = "SELECT * FROM tbl_student";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Student> studentList = new List<Student>();

            while (reader.Read())
            {
                Student students = new Student();
                students.studentId = int.Parse(reader["student_id"].ToString());
                students.studentRegNo = reader["student_regNo"].ToString();
                students.studentName = reader["student_name"].ToString();
                students.studentAddress = reader["student_address"].ToString();
                students.departmentId = int.Parse(reader["student_departmentId"].ToString());

                studentList.Add(students);
            }
            reader.Close();
            connection.Close();

            return studentList;
        }
        public int Delete(Student students, int studentID)
        {
            SqlConnection connection = new SqlConnection(studentConString);
            string query = "DELETE FROM tbl_student WHERE student_id = '" + studentID + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
        public Student GetStudentDepartmentByRegNo(int studentID)
        {
            SqlConnection connection = new SqlConnection(studentConString);

            string query = "SELECT * FROM tbl_student WHERE student_id = '" + studentID + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Student students = new Student();

            while (reader.Read())
            {
                //studentDepartments.StdDeptId = int.Parse(reader["student_id"].ToString());
                students.studentRegNo = reader["student_regNo"].ToString();
                students.studentName = reader["student_name"].ToString();
                students.studentAddress = reader["student_address"].ToString();
                students.departmentName = reader["department_name"].ToString();
            }
            reader.Close();
            connection.Close();

            return students;
        }


        public int Update(Student students, int studentID)
        {
            SqlConnection connection = new SqlConnection(studentConString);
            string query = "UPDATE tbl_student SET student_regNo = '" + students.studentRegNo +
                           "',student_name = '" + students.studentName + "',student_address = '" +
                           students.studentAddress + "',department_name = '" + students.departmentName +
                           "' WHERE student_id = '" + studentID + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<StudentDepartmentView> ViewStudentDepartmentById(int studentID)
        {
            SqlConnection connection = new SqlConnection(studentConString);

            string query = "GetStudentDepartmentById";

            SqlCommand command = new SqlCommand(query, connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.Add("@studentId", SqlDbType.Int);
            command.Parameters["@studentId"].Value = studentID;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<StudentDepartmentView> students = new List<StudentDepartmentView>();

            while (reader.Read())
            {
                StudentDepartmentView student = new StudentDepartmentView();

                student.StdDeptId = int.Parse(reader["student_id"].ToString());
                student.StdDeptRegNo = reader["student_regNo"].ToString();
                student.StdDeptName = reader["student_name"].ToString();
                student.StdDeptAddress = reader["student_address"].ToString();
                student.StdDepartmentName = reader["department_name"].ToString();
            }
            reader.Close();
            connection.Close();

            return students;
        }
    }
}
