using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.DAL;
using UniversityManagementApp.MODEL;

namespace UniversityManagementApp.BLL
{
    public class DepartmentManager
    {
        DepartmentGatway gatway = new DepartmentGatway();
        public string Save(Department departments)
        {
            if (gatway.Save(departments) > 0)
            {
                return "Added Successfully!";
            }
            else
            {
                return "Failed!";
            }
        }
        public List<Department> GetAllDepartments()
        {
            return gatway.GetAllDepartments();
        }
    }
}
