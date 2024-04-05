using gym_management_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system
{
    public partial class Employees : Form
    {
        private List<EmployeeModel> employee;
        private List<EmployeeModel> filteredList;
        private EmployeeModel em;
        private Main_Form main_Form;
        public Employees()
        {
            InitializeComponent();
            panelloading.Visible = true;
            EmployeeData.AutoGenerateColumns = false;
            backgroundWorkergetEmployee.RunWorkerAsync();
        }

        public Employees(EmployeeModel model, Main_Form m)
        {
            InitializeComponent();
            panelloading.Visible = true;
            EmployeeData.AutoGenerateColumns = false;
            backgroundWorkergetEmployee.RunWorkerAsync();
            em = model;
            main_Form = m;
        }

        private void timer_fadding_Tick(object sender, EventArgs e)
        {
            if (main_Form.Opacity > 0.86)
            {
                main_Form.Opacity -= 0.01;
            }
            else
            {
                timer_fadding.Stop();
            }
        }

        private void timer_fadding2_Tick(object sender, EventArgs e)
        {
            if (main_Form.Opacity < 1.0)
            {
                main_Form.Opacity += 0.01;
            }
            else
            {
                timer_fadding2.Stop();
            }
        }

        private void backgroundWorkergetEmployee_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (employee != null)
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = false;
                panelMemberView.Visible = true;
                EmployeeData = Global.mangeDataGrid.GridRefresh(EmployeeData, employee);
            }
            else
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = true;
                panelMemberView.Visible = false;
            }
        }

        private void backgroundWorkergetEmployee_DoWork(object sender, DoWorkEventArgs e)
        {
            employee = Global.employeeService.getAllEmployee(false,false,false);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                panelloading.Visible = true;
                panelconnectionError.Visible = false;
                panelMemberView.Visible = false;
                backgroundWorkergetEmployee.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! on backgroundWorkergetEmployee is : {ex.Message}");
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text != "Search")
            {
                try
                {
                    backgroundWorkerEmployeeFilter.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! on backgroundWorkerMemberFilter is : {ex.Message}");
                }
            }
        }

        private void backgroundWorkerEmployeeFilter_DoWork(object sender, DoWorkEventArgs e)
        {
            filteredList = employee.Where(employee => employee.Name.ToLower().Contains(textSearch.Text) || employee.Id.ToString().Contains(textSearch.Text) || employee.Name.Contains(textSearch.Text) || employee.Name.ToUpper().Contains(textSearch.Text) || employee.Username.ToUpper().Contains(textSearch.Text) || employee.Username.ToLower().Contains(textSearch.Text)).ToList();
        }

        private void backgroundWorkerMemberFilter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (filteredList != null)
            {
                EmployeeData = Global.mangeDataGrid.GridRefresh(EmployeeData, filteredList);
            }
        }

        private void textSearch_Enter(object sender, EventArgs e)
        {
            if (textSearch.Text == "Search")
            {
                textSearch.Text = string.Empty;
                textSearch.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                if (textSearch.TabStop == false)
                {
                    textSearch.TabStop = true;
                }
            }
        }

        private void textSearch_Leave(object sender, EventArgs e)
        {
            if (textSearch.Text == "")
            {
                textSearch.Text = "Search";
                textSearch.StateActive.Content.Color1 = Color.FromArgb(70, 71, 78);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Person add_Person = new Add_Person(em,Emp: true);
            timer_fadding.Start();
            add_Person.ShowDialog();
            timer_fadding2.Start();
            panelloading.Visible = true;
            panelconnectionError.Visible = false;
            panelMemberView.Visible = false;
            backgroundWorkergetEmployee.RunWorkerAsync();
        }
    }
}
