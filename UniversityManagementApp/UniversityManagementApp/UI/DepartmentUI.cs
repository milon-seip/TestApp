using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityManagementApp.BLL;
using UniversityManagementApp.MODEL;

namespace UniversityManagementApp.UI
{
    public partial class DepartmentUI : Form
    {
        public DepartmentUI()
        {
            InitializeComponent();
        }
        DepartmentManager manager = new DepartmentManager();
        private void saveButton_Click(object sender, EventArgs e)
        {
            Department departments = new Department();
            departments.departmentName = departmentTextBox.Text;

            MessageBox.Show(manager.Save(departments));
        }
    }
}
