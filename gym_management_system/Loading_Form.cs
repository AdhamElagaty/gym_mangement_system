using MySql.Data.MySqlClient;
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
    public partial class Loading_Form : Form
    {
        bool conState;
        public Loading_Form()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MySqlConnection con = Global.sqlService.connection;
                con.Open();
                conState = true;
            }catch (Exception ex)
            {
                Console.WriteLine($"Error in connection : {ex.Message}");
                conState = false;
            }
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Visible = false;
            Login_form login_Form = new Login_form(conState);
            login_Form.ShowDialog();
            this.Close();
        }
    }
}
