﻿using ComponentFactory.Krypton.Toolkit;
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
    public partial class Main_Form : Form
    {
        private KryptonCheckButton nb = new KryptonCheckButton();
        private List<Form> form = new List<Form>();
        public EmployeeModel employee;
        private Home home;
        private Members members;
        private Employees employees;
        private Trainer trainer;
        private Payments payments;
        private Subscription subscription;
        public Main_Form()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            nb = ButtonHome;
            nb.Checked = true;
            if(employee != null)
            {
                if (employee.Picture != null)
                {
                    PictureBoxAccountProfile.Image = employee.Picture;
                }
                else
                {
                    Console.WriteLine("Error! No Profile Picture to Load");
                }
                labelName.Text = employee.Name;
            }
            else
            {
                Console.WriteLine("Error! No employee data to load");
            }

        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Visible = true;
        }
        public Main_Form(EmployeeModel employeeModel)
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            nb = ButtonHome;
            nb.Checked = true;
            employee = employeeModel;
            if (employee != null)
            {
                home = new Home(employeeModel, this);
                members = new Members(employeeModel, this);
                employees = new Employees(employeeModel, this);
                trainer = new Trainer(employeeModel,home, this);
                subscription = new Subscription();
                trainer.Tag = home;
                payments = new Payments();
                if (!employee.Admin)
                {
                    ButtonEmployees.Visible = false;
                    ButtonTrainer.Visible = false;
                    ButtonPayments.Visible = false;
                }
                if (employee.Picture != null)
                {
                    PictureBoxAccountProfile.Image = employee.Picture;
                }
                else
                {
                    Console.WriteLine("Error! No Profile Picture to Load");
                }
                labelName.Text = employee.Name;
            }
            else
            {
                Console.WriteLine("Error! No employee data to load");
            }
        }

        private void timer_fadding_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05;
            }
            else
            {
                timer_fadding.Stop();
            }
        }

        private void timer_slider_hide_Tick(object sender, EventArgs e)
        {
            if (Panel_slider.Size.Width > 102)
            {
                int x = Panel_slider.Size.Width - 21, y = Panel_slider.Size.Height;
                Panel_slider.Size = new Size(x, y);
                int z = mainpanel.Size.Width + 21, w = mainpanel.Size.Height;
                mainpanel.Size = new Size(z, w);
                int ly = mainpanel.Location.Y, lx = mainpanel.Location.X - 21;
                mainpanel.Location = new Point(lx, ly);
            }
            else
            {
                timer_slider_hide.Stop();
            }
        }

        private void timer_slider_show_Tick(object sender, EventArgs e)
        {
            if (Panel_slider.Size.Width < 333)
            {
                int x = Panel_slider.Size.Width + 21, y = Panel_slider.Size.Height;
                Panel_slider.Size = new Size(x, y);
                int z = mainpanel.Size.Width - 21, w = mainpanel.Size.Height;
                mainpanel.Size = new Size(z, w);
                int ly = mainpanel.Location.Y, lx = mainpanel.Location.X + 21;
                mainpanel.Location = new Point(lx, ly);
            }
            else
            {
                timer_slider_show.Stop();
            }
        }

        private void KryptonButtonSetting(KryptonCheckButton button)
        {
            nb.Checked = false;
            nb = button;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!timer_slider_show.Enabled && !timer_slider_hide.Enabled)
            {
                if (Panel_slider.Size.Width == 333)
                {
                    timer_slider_hide.Start();
                    pictureBox1.Image = Image.FromFile("system_image\\bars-sort 1.png");
                }
                else if (Panel_slider.Size.Width == 102)
                {
                    pictureBox1.Image = Image.FromFile("system_image\\bars-staggered 2Greypng.png");
                    timer_slider_show.Start();

                }
            }
        }

        private void ButtonHome_Click(object sender, EventArgs e)
        {
            if (!ButtonHome.Checked)
            {
                ButtonHome.Checked = true;
                return;
            }
            loadform(home);
            KryptonButtonSetting(ButtonHome);
        }

        private void ButtonMembers_Click(object sender, EventArgs e)
        {
            if (!ButtonMembers.Checked)
            {
                ButtonMembers.Checked = true;
                return;
            }
            loadform(members);
            KryptonButtonSetting(ButtonMembers);
        }

        private void ButtonEmployees_Click(object sender, EventArgs e)
        {
            if (!ButtonEmployees.Checked)
            {
                ButtonEmployees.Checked = true;
                return;
            }
            loadform(employees);
            KryptonButtonSetting(ButtonEmployees);
        }

        private void ButtonPayments_Click(object sender, EventArgs e)
        {
            if (!ButtonPayments.Checked)
            {
                ButtonPayments.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonPayments);
            loadform(payments);
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            loadform(home);
            this.Opacity = 0;
            timer_fadding.Start();
        }

        private void ButtonTrainer_Click(object sender, EventArgs e)
        {
            if (!ButtonTrainer.Checked)
            {
                ButtonTrainer.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonTrainer);
            loadform(trainer);
        }

        private void bunifuPictureBox1_MouseHover(object sender, EventArgs e)
        {
            bunifuPictureBox1.Image = Image.FromFile("system_image\\x_red(39).png");
        }

        private void bunifuPictureBox1_MouseLeave(object sender, EventArgs e)
        {
            bunifuPictureBox1.Image = Image.FromFile("system_image\\x(39).png");
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonSubscriptions_Click(object sender, EventArgs e)
        {
            if (!ButtonSubscriptions.Checked)
            {
                ButtonSubscriptions.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonSubscriptions);
            loadform(subscription);
        }

        private void ButtonLogOut_Click(object sender, EventArgs e)
        {
            if (!ButtonLogOut.Checked)
            {
                ButtonLogOut.Checked = true;
                return;
            }
            this.Close();
        }
    }
}
