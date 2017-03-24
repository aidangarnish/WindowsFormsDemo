using System;
using System.ComponentModel;
using System.Windows.Forms;
using WindowsFormsDataBindingDemo.Models;

namespace WindowsFormsDataBindingDemo
{
    public partial class ListEmployees : Form
    {
        BindingSource bs = new BindingSource();

        public static BindingList<Employee> Employees { get; set; }
        public ListEmployees()
        {
            InitializeComponent();
        }

        private void ListEmployees_Load(object sender, EventArgs e)
        {
            Employees = new BindingList<Employee>();

            bs.DataMember = "Employees";

            bs.DataSource = Employees;

            Employees.Add(new Employee() { Id = 1, FirstName = "John", LastName = "Smith", Department = "IS" });
            Employees.Add(new Employee() { Id = 2, FirstName = "Fred", LastName = "Jones", Department = "HR" });
            Employees.Add(new Employee() { Id = 3, FirstName = "Alan", LastName = "Clegg", Department = "IS" });

            dataGridViewEmployees.DataSource = Employees;
            dataGridViewEmployees.AutoGenerateColumns = true;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var createEmployee = new CreateEmployee();
            createEmployee.Show();
        }
    }
}
