using ComponentFactory.Krypton.Toolkit;
using Guna.UI2.WinForms.Suite;
using gym_management_system.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system
{
    public partial class Add_Package: Form
    {
        private Image image = null;
        private string base64 = null;
        private bool Ofr = false, Pkg= false;
        string Gender;
        bool Role, passE = false, status_Add;
        private MonthOfferModel offer;
        private PackgeModel package;
        private Loading_Indicator loading;

        public Add_Package()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        public Add_Package(bool Ofr = false, bool Pkg = false)
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            btnSub.Enabled = false;
            if (Ofr)
            {
                this.Ofr = true;
                offer = new MonthOfferModel();
                labelAdd.Text = "Add offer";

            }else if(Pkg)
            {
                this.Pkg = true;
                package = new PackgeModel();
                textMC.Visible = true;
                labelMC.Visible = true;
                labelMC.Text = "Classes";
                labelMC.Visible = false;
                textN.Visible = true;
                textP.Text = "Discount";
                textP.Tag = "Discount";
                labelAdd.Text = "Add offer";
                labelF.Text = "Invatations";
            }

        }
        public void Text_enter(object sender, EventArgs e)
        {
            if ((sender as KryptonTextBox).Text == (sender as KryptonTextBox).Tag.ToString())
            {
                (sender as KryptonTextBox).Text = "";
            }
            (sender as KryptonTextBox).ForeColor = Color.FromArgb(229, 231, 255);
        }

        public void Text_leave(object sender, EventArgs e)
        {
            if (string.Concat((sender as KryptonTextBox).Text.Where(c => !char.IsWhiteSpace(c))) == "")
            {
                (sender as KryptonTextBox).Text = (sender as KryptonTextBox).Tag.ToString();
                (sender as KryptonTextBox).ForeColor = Color.FromArgb(70, 71, 78);
            }
        }

 

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            labelimageError.Text = string.Empty;
            OpenFileDialog open_form = new OpenFileDialog();
            open_form.Title = "Choose Picture";
            open_form.Filter = "Images|*.jpg;*.png;*.bmp";
            open_form.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (open_form.ShowDialog() == DialogResult.OK)
            {
                if (Global.mangeImage.GetFileSizeInBytes(open_form.FileName) > 1000)
                {
                    labelimageError.Text = "This image is Big in Size";
                    return;
                }
                image = Global.mangeImage.CompressImageSize(Image.FromFile(open_form.FileName));
                if (image == null)
                {
                    labelimageError.Text = "This image is Big in Size";
                    return;
                }
                bunifuPictureBox1.Image = image;
                base64 = Global.mangeImage.CompressImageSizeGetBase64(Image.FromFile(open_form.FileName));
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (Pkg)
            {
 //               package.MonthOffer = ;
                package.NumOfClass = Convert.ToInt32(textMC.Text);
                package.DiscountPercentage = Convert.ToInt32(textP.Text);
                package.NumOfInvatation = Convert.ToInt32(textF.Text);
            }
            else if (Ofr)
            {
                offer.NumOfMonth = Convert.ToInt32(textMC.Text);
                offer.MaxNumFreze = Convert.ToInt32(textF.Text);
                offer.Price = Convert.ToInt32(textP.Text);
            }
            loading = new Loading_Indicator();
            loading.Show();
            backgroundWorkeradd.RunWorkerAsync();
        }

        private void backgroundWorkeradd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (status_Add)
            {
                labelerrorAdd.Text = string.Empty;
            }
            else
            {
                labelerrorAdd.Text = "error on Add";
            }
            loading.Close();
        }

        private void Add_Package_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorkeradd_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Pkg)
            {
                status_Add = Global.packgeService.AddPackage(package);
            }
            else if (Ofr)
            {
                status_Add = Global.monthOfferService.InsertMonthOffer(offer);
            }
        }

        private void textPP_TextChanged(object sender, EventArgs e)
        {
            //if (textMC.Text != "First Name" && textF.Text != "Second Name" && textN.Text != "Email" && textBrith.Text != "Brithdate" && (radioButtonM.Checked || radioButtonF.Checked))
            //{
            //    if (Emp)
            //    {
            //        if(textC.Text != "Username" && textPass.Text != "Password" && textCPass.Text != "Confirm Password" && (radioButtonA.Checked || radioButtonU.Checked) && passE)
            //        {
            //            btnSub.Enabled = true;
            //        }
            //        else
            //        {
            //            btnSub.Enabled = false;
            //        }
            //    } else if (Mem)
            //    {
            //        btnSub.Enabled = true;
            //    }
                
            //}
            //else
            //{
            //    btnSub.Enabled = false;
            //}
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
