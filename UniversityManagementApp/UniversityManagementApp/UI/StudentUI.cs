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

namespace UniversityManagementApp
{
    public partial class StudentUI : Form
    {
        public StudentUI()
        {
            InitializeComponent();            
        }
        //StudentDepartment stdDept = new StudentDepartment();
        StudentManager stdManager = new StudentManager();
        DepartmentManager deptManager = new DepartmentManager();
        StudentDepartmentManager stdDeptManager = new StudentDepartmentManager();
        public int studentID = 0;
        public string regNoId = "";
        public bool IsUpdateMode = false;
        private void saveButton_Click(object sender, EventArgs e)
        {
            Student students = new Student();
            students.studentRegNo = regNoTextBox.Text;
            students.studentName = nameTextBox.Text;
            students.studentAddress = addressTextBox.Text;
            students.studentId = studentID;
            int selectDepartmentId = int.Parse(departmentComboBox.SelectedValue.ToString());

            students.departmentId = selectDepartmentId;

            if (IsUpdateMode)
            {
                MessageBox.Show(stdManager.Update(students, studentID));
            }
            else
            {
                MessageBox.Show(stdManager.Save(students));
                LoadAllStudentDepartmentListView();
            }
 
        }

        private void StudentUI_Load(object sender, EventArgs e)
        {
            LoadAllDepartmentComboBox();
            //LoadAllStudentListView();
            //LoadAllStudentDepartmentListView();
            ViewStudentDepartmentById();
        }

        public void LoadAllStudentListView()
        {
            List<Student> students = stdManager.GetAllStudents();
            studentListView.Items.Clear();
            foreach (var student in students)
            {
                ListViewItem listView = new ListViewItem(student.studentId.ToString());
                listView.SubItems.Add(student.studentRegNo);
                listView.SubItems.Add(student.studentName);
                listView.SubItems.Add(student.studentAddress);
                listView.SubItems.Add(student.departmentId.ToString());

                studentListView.Items.Add(listView);
            }
        }

        public void LoadAllDepartmentComboBox()
        {
            List<Department> departments = deptManager.GetAllDepartments();

            departmentComboBox.DisplayMember = "departmentName";
            departmentComboBox.ValueMember = "departmentId";
            departmentComboBox.DataSource = null;
            departmentComboBox.DataSource = departments;
        }

        public void LoadAllStudentDepartmentListView()
        {
            List<StudentDepartment> studentDepartments = stdDeptManager.GetAllStudentDepartment();
            studentListView.Items.Clear();
            foreach (var studentDepartment in studentDepartments)
            {
                ListViewItem listView = new ListViewItem(studentDepartment.StdDeptId.ToString());
                listView.SubItems.Add(studentDepartment.StdDeptRegNo);
                listView.SubItems.Add(studentDepartment.StdDeptName);
                listView.SubItems.Add(studentDepartment.StdDeptAddress);
                listView.SubItems.Add(studentDepartment.StdDepartmentName);

                studentListView.Items.Add(listView);
            }
        }

        public void ViewStudentDepartmentById()
        {
            List<StudentDepartmentView> stdDeptView = stdManager.ViewStudentDepartmentById();
            studentListView.Items.Clear();
            foreach (var stdDept in stdDeptView)
            {
                ListViewItem listView = new ListViewItem(stdDept.StdDeptId.ToString());
                listView.SubItems.Add(stdDept.StdDeptRegNo);
                listView.SubItems.Add(stdDept.StdDeptName);
                listView.SubItems.Add(stdDept.StdDeptAddress);
                listView.SubItems.Add(stdDept.StdDepartmentName);

                studentListView.Items.Add(listView);
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchRegNo = searchRegNoTextBox.Text;
            string searchName = searchNameTextBox.Text;

            List<StudentDepartment> stdDeptList = stdDeptManager.SearchStudentByRegNoName(searchRegNo, searchName);

            studentListView.Items.Clear();
            foreach (var studentDepartment in stdDeptList)
            {
                ListViewItem listView = new ListViewItem(studentDepartment.StdDeptId.ToString());
                listView.SubItems.Add(studentDepartment.StdDeptRegNo);
                listView.SubItems.Add(studentDepartment.StdDeptName);
                listView.SubItems.Add(studentDepartment.StdDeptAddress);
                listView.SubItems.Add(studentDepartment.StdDepartmentName);

                studentListView.Items.Add(listView);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (studentListView.SelectedItems.Count > 0)
            {
                ListViewItem listView = studentListView.SelectedItems[0];
                studentID = int.Parse(listView.Text);

                Student students = new Student();

                students.studentId = studentID;
                students.studentRegNo = regNoTextBox.Text;
                students.studentName = nameTextBox.Text;
                students.studentAddress = addressTextBox.Text;
                students.departmentName = departmentComboBox.Text;

                bool isDeleteMode = stdManager.Delete(students, studentID);
                if (isDeleteMode)
                {
                    MessageBox.Show("Deleted Successfully!");
                    LoadAllStudentDepartmentListView();
                }
                else
                {
                    MessageBox.Show("Could Not Delete!");
                }
            }
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (studentListView.SelectedItems.Count > 0)
            {
                ListViewItem listView = studentListView.SelectedItems[0];
                studentID = int.Parse(listView.Text);

                Student students = stdManager.GetStudentDepartmentByRegNo(studentID);

                regNoTextBox.Text = students.studentRegNo;
                nameTextBox.Text = students.studentName;
                addressTextBox.Text = students.studentAddress;
                departmentComboBox.Text = students.departmentName;

                IsUpdateMode = true;

                saveButton.Text = "Update";
            }
        }
    }
}
