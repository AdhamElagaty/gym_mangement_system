using gym_management_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system
{
    public partial class Trainer : Form
    {
        private List<TrainerModel> trainer;
        private List<TrainerModel> filteredList;
        private EmployeeModel employee;
        private Home home;
        private Main_Form main_Form;
        public Trainer()
        {
            InitializeComponent();
            panelloading.Visible = true;
            MemberData.AutoGenerateColumns = false;
            backgroundWorkergetTrainer.RunWorkerAsync();
        }

        public Trainer(EmployeeModel model,Home h, Main_Form m)
        {
            InitializeComponent();
            panelloading.Visible = true;
            MemberData.AutoGenerateColumns = false;
            backgroundWorkergetTrainer.RunWorkerAsync();
            home = h;
            main_Form = m;
            employee = model;
        }

        public Trainer(EmployeeModel model)
        {
            InitializeComponent();
            panelloading.Visible = true;
            MemberData.AutoGenerateColumns = false;
            backgroundWorkergetTrainer.RunWorkerAsync();
            employee = model; 
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

        private void backgroundWorkergetTrainer_DoWork(object sender, DoWorkEventArgs e)
        {
            trainer = Global.trainerService.getAllTrainer(false,false);
        }

        private void backgroundWorkergetTrainer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (trainer != null)
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = false;
                panelMemberView.Visible = true;
                MemberData = Global.mangeDataGrid.GridRefresh(MemberData, trainer);
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
                backgroundWorkergetTrainer.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! on backgroundWorkergetMember is : {ex.Message}");
            }

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text != "Search")
            {
                try
                {
                    backgroundWorkerTrainerFilter.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! on backgroundWorkerMemberFilter is : {ex.Message}");
                }
            }
        }

        private void backgroundWorkerTrainerFilter_DoWork(object sender, DoWorkEventArgs e)
        {
            filteredList = trainer.Where(trainer => trainer.Name.ToLower().Contains(textSearch.Text) || trainer.Id.ToString().Contains(textSearch.Text) || trainer.Name.Contains(textSearch.Text) || trainer.Name.ToUpper().Contains(textSearch.Text)).ToList();
        }

        private void backgroundWorkerTrainerFilter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            Add_Person add_Person = new Add_Person(employee ,Tra: true);
            timer_fadding.Start();
            add_Person.ShowDialog();
            timer_fadding2.Start();
            home.refTdata();
            panelloading.Visible = true;
            panelconnectionError.Visible = false;
            panelMemberView.Visible = false;
            backgroundWorkergetTrainer.RunWorkerAsync();
        }
    }
}
