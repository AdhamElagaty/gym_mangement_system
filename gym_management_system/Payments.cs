using gym_management_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system
{
    public partial class Payments : Form
    {
        private List<PaymentModel> paymentModel;
        public Payments()
        {
            InitializeComponent();
            panelloading.Visible = true;
            PaymentData.AutoGenerateColumns = false;
            backgroundWorkergetpayment.RunWorkerAsync();
        }
        private List<MemberModel> members;
        private List<PaymentModel> filteredList;

        private void backgroundWorkergetMember_DoWork(object sender, DoWorkEventArgs e)
        {
            paymentModel = Global.paymentService.GetAllPayments();
        }

        private void backgroundWorkergetMember_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (paymentModel != null)
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = false;
                panelMemberView.Visible = true;
                PaymentData = Global.mangeDataGrid.GridRefresh(PaymentData, paymentModel);
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
                backgroundWorkergetpayment.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! on backgroundWorkergetMember is : {ex.Message}");
            }

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerPaymentFilter.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! on backgroundWorkerMemberFilter is : {ex.Message}");
            }
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            textSD.ForeColor = Color.FromArgb(70, 71, 78);
            textSD.Text = metroDateTime1.Value.ToString("yyyy-MM-dd");
        }

        private void metroDateTime2_ValueChanged(object sender, EventArgs e)
        {
            textED.ForeColor = Color.FromArgb(70, 71, 78);
            textED.Text = metroDateTime2.Value.ToString("yyyy-MM-dd");
        }

        private void backgroundWorkerPaymentFilter_DoWork(object sender, DoWorkEventArgs e)
        {
            filteredList = paymentModel.Where(m => m.Id.ToString().Contains(textSearch.Text == "Search" ? "" : textSearch.Text)).Where(m => m.Date.Date >= metroDateTime1.Value.Date && m.Date.Date <= metroDateTime2.Value.Date).ToList();
        }

        private void backgroundWorkerPaymentFilter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (filteredList != null)
            {
                PaymentData = Global.mangeDataGrid.GridRefresh(PaymentData, filteredList);
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
            Add_Person add_Person = new Add_Person(Mem: true);
            add_Person.ShowDialog();
            panelloading.Visible = true;
            panelconnectionError.Visible = false;
            panelMemberView.Visible = false;
            backgroundWorkergetpayment.RunWorkerAsync();
        }
    }
}
