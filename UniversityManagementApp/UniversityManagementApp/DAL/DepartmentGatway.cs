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
    public class DepartmentGatway
    {
        public string deptConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public decimal Save(Department departments)
        {
            SqlConnection connection = new SqlConnection(deptConString);
            string query = "INSERT INTO tbl_department VALUES ('" + departments.departmentName + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<Department> GetAllDepartments()
        {
            SqlConnection connection = new SqlConnection(deptConString);

            string query = "SELECT * FROM tbl_department";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Department> departments = new List<Department>();

            while (reader.Read())
            {
                Department department = new Department();
                department.departmentId = Convert.ToInt32(reader["department_id"]);
                department.departmentName = reader["department_name"].ToString();


                departments.Add(department);
            }
            reader.Close();
            connection.Close();

            return departments;
        }
    }
}
