using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityManagementApp.UI
{
    public partial class MenuUI : Form
    {
        public MenuUI()
        {
            InitializeComponent();
        }

        private void studentButton_Click(object sender, EventArgs e)
        {
            StudentUI studentUi = new StudentUI();
            studentUi.Show();
        }

        private void departmentButton_Click(object sender, EventArgs e)
        {
            DepartmentUI departmentUi = new DepartmentUI();
            departmentUi.Show();
        }
    }
}
