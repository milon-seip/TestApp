using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.DAL;
using UniversityManagementApp.MODEL;

namespace UniversityManagementApp.BLL
{
    public class StudentManager
    {
        StudentGatway stdGatway = new StudentGatway();

        public bool IsRegNoExists(string regNo)
        {
            Student students = stdGatway.GetStudentByRegNo(regNo);
            if (students != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public string Save(Student students)
        {
            bool checkRegNo = IsRegNoExists(students.studentRegNo);
            if (checkRegNo)
            {
                return "Reg No Exists!";
            }
            if (stdGatway.Save(students) > 0)
            {
                return "Added Successfully!";
            }
            else
            {
                return "Failed!";
            }
        }

        public List<Student> GetAllStudents()
        {
            return stdGatway.GetAllStudents();
        }

        public bool Delete(Student students, int studentID)
        {
            return stdGatway.Delete(students, studentID) > 0;
        }

        public Student GetStudentDepartmentByRegNo(int studentID)
        {
            return stdGatway.GetStudentDepartmentByRegNo(studentID);
        }
        public string Update(Student students, int studentID)
        {
            if (stdGatway.Update(students, studentID) > 0)
            {
                return "Updated Successfully!";
            }
            else
            {
                return "Could Not Update!";
            }
        }

        public List<StudentDepartmentView> ViewStudentDepartmentById()
        {
            return stdGatway.ViewStudentDepartmentById(5);
        }
    }
}
