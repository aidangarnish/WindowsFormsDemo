using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using WindowsFormsDataBindingDemo.Models;

namespace WindowsFormsDataBindingDemo
{
    public partial class CreateEmployeeForm : Form
    {
        public CreateEmployeeForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppData appData;
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Employees.json"))
            {
                string json = r.ReadToEnd();
                appData = JsonConvert.DeserializeObject<AppData>(json);

            }

            appData.Employees.Add(new Employee() { Id = appData.Employees.Count + 1, FirstName = txtFirstName.Text, LastName = txtLastName.Text, Department = "IS", Email = txtEmail.Text, Password = txtPassword.Text });

            using (StreamWriter writetext = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Employees.json"))
            {
                writetext.WriteLine(JsonConvert.SerializeObject(appData));
            }

            var listEmployeesForm = new ListEmployeesForm();
            listEmployeesForm.Show();
            this.Close();
        }

        
    }
}
