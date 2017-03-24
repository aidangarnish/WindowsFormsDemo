using System;
using System.Windows.Forms;
using WindowsFormsDataBindingDemo.Models;

namespace WindowsFormsDataBindingDemo
{
    public partial class CreateEmployee : Form
    {
        public CreateEmployee()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ListEmployees.Employees.Add(new Employee() { Id = 1, FirstName = txtFirstName.Text, LastName = txtLastName.Text, Department = "IS" });

            this.Close();
        }
    }
}
