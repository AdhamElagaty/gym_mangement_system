using ComponentFactory.Krypton.Toolkit;
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
    public partial class Subscription : Form
    {
        private KryptonCheckButton nb;
        private List<PackgeSubscriptionModel> subscriptionsPk;
        private List<MonthSubscriptionModel> subscriptionsM;
        private List<ClassSubscriptionModel> subscriptionsC;
        private List<PrivateSubscriptionModel> subscriptionsP;
        private List<PackgeSubscriptionModel> FilterPk;
        private List<MonthSubscriptionModel> FilterM;
        private List<ClassSubscriptionModel> FilterC;
        private List<PrivateSubscriptionModel> FilterP;
        private bool firstR = true;
        public Subscription()
        {
            InitializeComponent();
            nb = ButtonPck;
            nb.Checked = true;
            PackageData.AutoGenerateColumns = false;
            MonthData.AutoGenerateColumns = false;
            ClassData.AutoGenerateColumns = false;
            PrivateData.AutoGenerateColumns = false;
            panelloading.Visible = true;
            panelconnectionError.Visible = false;
            PackageData.Visible = false;
            MonthData.Visible = false;
            ClassData.Visible = false;
            PrivateData.Visible = false;
            ButtonPck.Enabled = false;
            ButtonC.Enabled = false;
            ButtonP.Enabled = false;
            ButtonM.Enabled = false;
            textSearch.Enabled = false; 
            LoadAll();
        }

        private void KryptonButtonSetting(KryptonCheckButton button)
        {
            nb.Checked = false;
            nb = button;
            textSearch.Text = "Search";
            textSearch.StateActive.Content.Color1 = Color.FromArgb(70, 71, 78);
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

        private void ButtonPck_Click(object sender, EventArgs e)
        {
            if (!ButtonPck.Checked)
            {
                ButtonPck.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonPck);
            PackageData.Visible = true;
            MonthData.Visible = false;
            ClassData.Visible = false;
            PrivateData.Visible = false;
            try
            {
                loadData();
                pictureBox3.Visible = true;
                textSearch.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ButtonM_Click(object sender, EventArgs e)
        {
            if (!ButtonM.Checked)
            {
                ButtonM.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonM);
            PackageData.Visible = false;
            MonthData.Visible = true;
            ClassData.Visible = false;
            PrivateData.Visible = false;
            try
            {
                loadData();
                pictureBox3.Visible = true;
                textSearch.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            if (!ButtonC.Checked)
            {
                ButtonC.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonC);
            PackageData.Visible = false;
            MonthData.Visible = false;
            ClassData.Visible = true;
            PrivateData.Visible = false;
            try
            {
                loadData();
                pictureBox3.Visible = true;
                textSearch.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ButtonP_Click(object sender, EventArgs e)
        {
            if (!ButtonP.Checked)
            {
                ButtonP.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonP);
            PackageData.Visible = false;
            MonthData.Visible = false;
            ClassData.Visible = false;
            PrivateData.Visible = true;
            try
            {
                loadData();
                pictureBox3.Visible = true;
                textSearch.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            subscriptionsPk = Global.PackgeSupscribtionService.GetPackageSubscriptions();
        }

        private void loadData()
        {
            try
            {
                if (ButtonPck.Checked)
                {
                    backgroundWorkerPk.RunWorkerAsync();
                }
                else if (ButtonM.Checked)
                {
                    backgroundWorkerM.RunWorkerAsync();
                }
                else if (ButtonC.Checked)
                {
                    backgroundWorkerC.RunWorkerAsync();
                }
                else if (ButtonP.Checked)
                {
                    backgroundWorkerP.RunWorkerAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! on backGroundWorker: {e.Message}");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (subscriptionsPk != null)
            {
                PackageData = Global.mangeDataGrid.GridRefresh(PackageData, subscriptionsPk);
                panelloading.Visible = false;
                panelconnectionError.Visible = false;
                ButtonC.Enabled = true;
                ButtonP.Enabled = true;
                ButtonM.Enabled = true;
                ButtonPck.Enabled = true;
                pictureBox3.Visible = false;
                textSearch.Enabled = true;
                if (ButtonPck.Checked)
                {
                    PackageData.Visible = true;
                    MonthData.Visible = false;
                    ClassData.Visible = false;
                    PrivateData.Visible = false;
                }
            }
            else
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = true;
                PackageData.Visible = false;
                MonthData.Visible = false;
                ClassData.Visible = false;
                PrivateData.Visible = false;
                ButtonPck.Enabled = false;
                ButtonC.Enabled = false;
                ButtonP.Enabled = false;
                ButtonM.Enabled = false;
            }
        }

        private void backgroundWorkerrfilter_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ButtonPck.Checked)
            {
                PackageData = Global.mangeDataGrid.GridRefresh(PackageData, FilterPk);
            }
            else if (ButtonM.Checked)
            {
                MonthData =  Global.mangeDataGrid.GridRefresh(MonthData, FilterM);
            }
            else if (ButtonC.Checked)
            {
                ClassData = Global.mangeDataGrid.GridRefresh(ClassData, FilterC);
            }
            else if (ButtonP.Checked)
            {
                PrivateData = Global.mangeDataGrid.GridRefresh(PrivateData, FilterP);
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textSearch.Text != "Search")
                {
                    if (ButtonPck.Checked)
                    {
                        FilterPk = subscriptionsPk.Where(pk => pk.PackgeModelName.ToLower().Contains(textSearch.Text) || pk.MemberId.ToString().Contains(textSearch.Text) || pk.EmployeeId.ToString().Contains(textSearch.Text)).ToList();
                        try
                        {
                            backgroundWorkerrfilter.RunWorkerAsync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    else if (ButtonM.Checked)
                    {
                        FilterM = subscriptionsM.Where(M => (M.MonthOfferNum + "m").ToString().Contains(textSearch.Text) || (M.MonthOfferNum + "M").ToString().Contains(textSearch.Text) || M.MemberId.ToString().Contains(textSearch.Text) || M.EmployeeId.ToString().Contains(textSearch.Text)).ToList();
                        try
                        {
                            backgroundWorkerrfilter.RunWorkerAsync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    else if (ButtonC.Checked)
                    {
                        FilterC = subscriptionsC.Where(C => C.ClassName.ToUpper().Contains(textSearch.Text) || C.ClassName.ToLower().Contains(textSearch.Text) || C.MemberId.ToString().Contains(textSearch.Text) || C.EmployeeId.ToString().Contains(textSearch.Text)).ToList();
                        try
                        {
                            backgroundWorkerrfilter.RunWorkerAsync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    else if (ButtonP.Checked)
                    {
                        FilterP = subscriptionsP.Where(P => P.TrainerId.ToString().Contains(textSearch.Text) || P.TrainerName.ToUpper().Contains(textSearch.Text) || P.TrainerName.ToLower().Contains(textSearch.Text) || P.MemberId.ToString().Contains(textSearch.Text) || P.EmployeeId.ToString().Contains(textSearch.Text)).ToList();
                        try
                        {
                            backgroundWorkerrfilter.RunWorkerAsync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"No Data to search: {ex.Message}");
            }
            
        }

        private void backgroundWorkerM_DoWork(object sender, DoWorkEventArgs e)
        {
            subscriptionsM = Global.monthSubscriptionService.GetMonthSubscriptions();
        }

        private void backgroundWorkerM_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (subscriptionsM != null)
            {
                MonthData = Global.mangeDataGrid.GridRefresh(MonthData, subscriptionsM);
                panelloading.Visible = false;
                panelconnectionError.Visible = false;
                ButtonC.Enabled = true;
                ButtonP.Enabled = true;
                ButtonM.Enabled = true;
                ButtonPck.Enabled = true;
                pictureBox3.Visible = false;
                textSearch.Enabled = true;
                if (ButtonM.Checked)
                {
                    PackageData.Visible = false;
                    MonthData.Visible = true;
                    ClassData.Visible = false;
                    PrivateData.Visible = false;
                }
            }
            else
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = true;
                PackageData.Visible = false;
                MonthData.Visible = false;
                ClassData.Visible = false;
                PrivateData.Visible = false;
                ButtonPck.Enabled = false;
                ButtonC.Enabled = false;
                ButtonP.Enabled = false;
                ButtonM.Enabled = false;
            }
        }

        private void backgroundWorkerC_DoWork(object sender, DoWorkEventArgs e)
        {
            subscriptionsC = Global.classSubscriptionService.GetClassSubscriptions();
        }

        private void backgroundWorkerC_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (subscriptionsC != null)
            {
                ClassData = Global.mangeDataGrid.GridRefresh(ClassData, subscriptionsC);
                panelloading.Visible = false;
                panelconnectionError.Visible = false;
                ButtonC.Enabled = true;
                ButtonP.Enabled = true;
                ButtonM.Enabled = true;
                ButtonPck.Enabled = true;
                pictureBox3.Visible = false;
                textSearch.Enabled = true;
                if (ButtonC.Checked)
                {
                    PackageData.Visible = false;
                    MonthData.Visible = false;
                    ClassData.Visible = true;
                    PrivateData.Visible = false;
                }
            }
            else
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = true;
                PackageData.Visible = false;
                MonthData.Visible = false;
                ClassData.Visible = false;
                PrivateData.Visible = false;
                ButtonPck.Enabled = false;
                ButtonC.Enabled = false;
                ButtonP.Enabled = false;
                ButtonM.Enabled = false;
            }
        }

        private void backgroundWorkerP_DoWork(object sender, DoWorkEventArgs e)
        {
            subscriptionsP = Global.PrivateSubscriptionService.GetPrivateSubscriptions();
        }

        private void backgroundWorkerP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (subscriptionsP != null)
            {
                PrivateData = Global.mangeDataGrid.GridRefresh(PrivateData, subscriptionsP);
                panelloading.Visible = false;
                panelconnectionError.Visible = false;
                ButtonC.Enabled = true;
                ButtonP.Enabled = true;
                ButtonM.Enabled = true;
                ButtonPck.Enabled = true;
                pictureBox3.Visible = false;
                textSearch.Enabled = true;
                if (ButtonP.Checked)
                {
                    PackageData.Visible = false;
                    MonthData.Visible = false;
                    ClassData.Visible = false;
                    PrivateData.Visible = true;
                }
            }
            else
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = true;
                PackageData.Visible = false;
                MonthData.Visible = false;
                ClassData.Visible = false;
                PrivateData.Visible = false;
                ButtonPck.Enabled = false;
                ButtonC.Enabled = false;
                ButtonP.Enabled = false;
                ButtonM.Enabled = false;
            }
        }

        private void LoadAll()
        {
            try
            {
                backgroundWorkerPk.RunWorkerAsync();
                backgroundWorkerM.RunWorkerAsync();
                backgroundWorkerC.RunWorkerAsync();
                backgroundWorkerP.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! on backGroundWorker: {ex.Message}");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                panelloading.Visible = true;
                panelconnectionError.Visible = false;
                PackageData.Visible = false;
                MonthData.Visible = false;
                ClassData.Visible = false;
                PrivateData.Visible = false;
                ButtonPck.Enabled = false;
                ButtonC.Enabled = false;
                ButtonP.Enabled = false;
                ButtonM.Enabled = false;
                LoadAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! on backGroundWorker: {ex.Message}");
            }
        }
    }
}
