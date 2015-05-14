using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.DAL;
using UniversityManagementApp.MODEL;

namespace UniversityManagementApp.BLL
{
    public class StudentDepartmentManager
    {
        StudentDepartmentGatway stdDeptGatway = new StudentDepartmentGatway();
        public List<StudentDepartment> GetAllStudentDepartment()
        {
            return stdDeptGatway.GetAllStudentDepartment();
        }

        public List<StudentDepartment> SearchStudentByRegNoName(string searchRegNo, string searchName)
        {
            return stdDeptGatway.SearchStudentByRegNoName(searchRegNo, searchName);
        }

    }
}
