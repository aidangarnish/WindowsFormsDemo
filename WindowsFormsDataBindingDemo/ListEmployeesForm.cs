using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using WindowsFormsDataBindingDemo.Models;

namespace WindowsFormsDataBindingDemo
{
    public partial class ListEmployeesForm : Form
    {

        public ListEmployeesForm()
        {
            InitializeComponent();
        }

        private void ListEmployees_Load(object sender, EventArgs e)
        {
            PopulateEmployeesGV();

            lblLoggedInUser.Text = "Hello " + Program.currentUser.FirstName + " " + Program.currentUser.LastName;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var createEmployee = new CreateEmployeeForm();
            createEmployee.Show();
            this.Hide();
        }

        internal void PopulateEmployeesGV()
        {
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Employees.json"))
            {
                string json = r.ReadToEnd();
                AppData appData = JsonConvert.DeserializeObject<AppData>(json);

                dataGridViewEmployees.DataSource = appData.Employees;
                dataGridViewEmployees.AutoGenerateColumns = true;
            }
        }
    }
}
