using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsDataBindingDemo.Models;

namespace WindowsFormsDataBindingDemo
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Employees.json"))
            {
                string json = r.ReadToEnd();
                AppData appData = JsonConvert.DeserializeObject<AppData>(json);

                Employee employee = appData.Employees.Where(emp => emp.Email == txtUsername.Text).FirstOrDefault();

                if(employee != null)
                {
                    if(employee.Password == txtPassword.Text)
                    {
                        Program.currentUser = employee;

                        var listEmployeesForm = new ListEmployeesForm();
                        listEmployeesForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        lblMessage.Text = "Username or password incorrect";
                    }
                }
            }
        }
    }
}
