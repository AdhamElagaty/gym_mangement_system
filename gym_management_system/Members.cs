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
    public partial class Members : Form
    {
        private List<MemberModel> members;
        private List<MemberModel> filteredList;
        private EmployeeModel model;
        private Main_Form main_Form;
        public Members()
        {
            InitializeComponent();
            panelloading.Visible = true;
            MemberData.AutoGenerateColumns = false;
            backgroundWorkergetMember.RunWorkerAsync();
        }

        public Members(EmployeeModel employee, Main_Form m)
        {
            InitializeComponent();
            panelloading.Visible = true;
            MemberData.AutoGenerateColumns = false;
            backgroundWorkergetMember.RunWorkerAsync();
            model = employee;
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

        private void backgroundWorkergetMember_DoWork(object sender, DoWorkEventArgs e)
        {
            members = Global.memberService.getAllMember();
        }

        private void backgroundWorkergetMember_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(members != null)
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = false;
                panelMemberView.Visible = true;
                MemberData = Global.mangeDataGrid.GridRefresh(MemberData,members);
            }
            else
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = true;
                panelMemberView.Visible = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                panelloading.Visible = true;
                panelconnectionError.Visible = false;
                panelMemberView.Visible = false;
                backgroundWorkergetMember.RunWorkerAsync();
            }catch(Exception ex)
            {
                Console.WriteLine($"Error! on backgroundWorkergetMember is : {ex.Message}");
            }
            
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if(textSearch.Text != "Search")
            {
                try
                {
                    backgroundWorkerMemberFilter.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! on backgroundWorkerMemberFilter is : {ex.Message}");
                }
            }
        }

        private void backgroundWorkerMemberFilter_DoWork(object sender, DoWorkEventArgs e)
        {
            filteredList = members.Where(members => members.Name.ToLower().Contains(textSearch.Text) || members.Id.ToString().Contains(textSearch.Text) || members.Name.Contains(textSearch.Text) || members.Name.ToUpper().Contains(textSearch.Text)).ToList();
        }

        private void backgroundWorkerMemberFilter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (filteredList != null)
            {
                MemberData = Global.mangeDataGrid.GridRefresh(MemberData, filteredList);
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
            Add_Person add_Person = new Add_Person(model, Mem: true);
            timer_fadding.Start();
            add_Person.ShowDialog();
            timer_fadding2.Start();
            panelloading.Visible = true;
            panelconnectionError.Visible = false;
            panelMemberView.Visible = false;
            backgroundWorkergetMember.RunWorkerAsync();
        }
    }
}
