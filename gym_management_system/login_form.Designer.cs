namespace gym_management_system
{
    partial class Login_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_form));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.textUsername = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.textPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.show_pass_btn = new System.Windows.Forms.PictureBox();
            this.hide_pass_btn = new System.Windows.Forms.PictureBox();
            this.btnLogin = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.lab_login_error = new System.Windows.Forms.Label();
            this.lab_pass_err = new System.Windows.Forms.Label();
            this.lab_username_err = new System.Windows.Forms.Label();
            this.backgroundWorkerLogin = new System.ComponentModel.BackgroundWorker();
            this.panellog = new System.Windows.Forms.Panel();
            this.panelconnectionerrorpackage = new System.Windows.Forms.Panel();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelloadingCon = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.show_pass_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide_pass_btn)).BeginInit();
            this.panellog.SuspendLayout();
            this.panelconnectionerrorpackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelloadingCon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 50;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 35;
            this.bunifuElipse2.TargetControl = this.textUsername;
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(27, 168);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(321, 70);
            this.textUsername.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.textUsername.StateActive.Border.Color1 = System.Drawing.Color.Transparent;
            this.textUsername.StateActive.Border.Color2 = System.Drawing.Color.Transparent;
            this.textUsername.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.textUsername.StateActive.Border.Width = -2;
            this.textUsername.StateActive.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(78)))));
            this.textUsername.StateActive.Content.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.StateActive.Content.Padding = new System.Windows.Forms.Padding(-1, 12, -1, 13);
            this.textUsername.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.textUsername.StateDisabled.Border.Color1 = System.Drawing.Color.Transparent;
            this.textUsername.StateDisabled.Border.Color2 = System.Drawing.Color.Transparent;
            this.textUsername.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.textUsername.StateDisabled.Border.Width = -2;
            this.textUsername.StateDisabled.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(78)))));
            this.textUsername.StateDisabled.Content.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F);
            this.textUsername.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(-1, 12, -1, 13);
            this.textUsername.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.textUsername.TabIndex = 6;
            this.textUsername.Text = "Username";
            this.textUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textUsername.Enter += new System.EventHandler(this.textUsername_Enter);
            this.textUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_Key);
            this.textUsername.Leave += new System.EventHandler(this.textUsername_Leave);
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 35;
            this.bunifuElipse3.TargetControl = this.textPassword;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(27, 268);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(321, 70);
            this.textPassword.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.textPassword.StateActive.Border.Color1 = System.Drawing.Color.Transparent;
            this.textPassword.StateActive.Border.Color2 = System.Drawing.Color.Transparent;
            this.textPassword.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.textPassword.StateActive.Border.Width = -2;
            this.textPassword.StateActive.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(78)))));
            this.textPassword.StateActive.Content.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F);
            this.textPassword.StateActive.Content.Padding = new System.Windows.Forms.Padding(-1, 12, -1, 13);
            this.textPassword.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.textPassword.StateDisabled.Border.Color1 = System.Drawing.Color.Transparent;
            this.textPassword.StateDisabled.Border.Color2 = System.Drawing.Color.Transparent;
            this.textPassword.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.textPassword.StateDisabled.Border.Width = -2;
            this.textPassword.StateDisabled.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(78)))));
            this.textPassword.StateDisabled.Content.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F);
            this.textPassword.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(-1, 12, -1, 13);
            this.textPassword.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.textPassword.TabIndex = 7;
            this.textPassword.Text = "Password";
            this.textPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textPassword.TextAlignChanged += new System.EventHandler(this.textPassword_TextAlignChanged);
            this.textPassword.Enter += new System.EventHandler(this.textPassword_Enter);
            this.textPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_Key);
            this.textPassword.Leave += new System.EventHandler(this.textPassword_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(25)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.panelloadingCon);
            this.panel1.Controls.Add(this.panelconnectionerrorpackage);
            this.panel1.Controls.Add(this.panellog);
            this.panel1.Controls.Add(this.bunifuPictureBox1);
            this.panel1.Controls.Add(this.lab_login_error);
            this.panel1.Controls.Add(this.lab_pass_err);
            this.panel1.Controls.Add(this.lab_username_err);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 631);
            this.panel1.TabIndex = 0;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(25)))));
            this.bunifuPictureBox1.BorderRadius = 17;
            this.bunifuPictureBox1.Image = global::gym_management_system.Properties.Resources.x_39_;
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(920, 17);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(35, 35);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 38;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            this.bunifuPictureBox1.Click += new System.EventHandler(this.bunifuPictureBox1_Click);
            this.bunifuPictureBox1.MouseLeave += new System.EventHandler(this.bunifuPictureBox1_MouseLeave);
            this.bunifuPictureBox1.MouseHover += new System.EventHandler(this.bunifuPictureBox1_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gilroy-Bold", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(52, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 69);
            this.label1.TabIndex = 37;
            this.label1.Text = "Welcome";
            // 
            // show_pass_btn
            // 
            this.show_pass_btn.BackColor = System.Drawing.Color.Transparent;
            this.show_pass_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.show_pass_btn.Image = global::gym_management_system.Properties.Resources.eye_2;
            this.show_pass_btn.Location = new System.Drawing.Point(342, 282);
            this.show_pass_btn.Name = "show_pass_btn";
            this.show_pass_btn.Size = new System.Drawing.Size(68, 43);
            this.show_pass_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.show_pass_btn.TabIndex = 35;
            this.show_pass_btn.TabStop = false;
            this.show_pass_btn.Visible = false;
            this.show_pass_btn.Click += new System.EventHandler(this.show_pass_btn_Click);
            // 
            // hide_pass_btn
            // 
            this.hide_pass_btn.BackColor = System.Drawing.Color.Transparent;
            this.hide_pass_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hide_pass_btn.Image = global::gym_management_system.Properties.Resources.eye_crossed_1;
            this.hide_pass_btn.Location = new System.Drawing.Point(342, 282);
            this.hide_pass_btn.Name = "hide_pass_btn";
            this.hide_pass_btn.Size = new System.Drawing.Size(68, 43);
            this.hide_pass_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hide_pass_btn.TabIndex = 36;
            this.hide_pass_btn.TabStop = false;
            this.hide_pass_btn.Visible = false;
            this.hide_pass_btn.Click += new System.EventHandler(this.hide_pass_btn_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AllowAnimations = true;
            this.btnLogin.AllowMouseEffects = true;
            this.btnLogin.AllowToggling = true;
            this.btnLogin.AnimationSpeed = 200;
            this.btnLogin.AutoGenerateColors = false;
            this.btnLogin.AutoRoundBorders = false;
            this.btnLogin.AutoSizeLeftIcon = true;
            this.btnLogin.AutoSizeRightIcon = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.ButtonText = "Login";
            this.btnLogin.ButtonTextMarginLeft = 0;
            this.btnLogin.ColorContrastOnClick = 45;
            this.btnLogin.ColorContrastOnHover = 45;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnLogin.CustomizableEdges = borderEdges2;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnLogin.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnLogin.IconMarginLeft = 11;
            this.btnLogin.IconPadding = 10;
            this.btnLogin.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnLogin.IconSize = 25;
            this.btnLogin.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnLogin.IdleBorderRadius = 30;
            this.btnLogin.IdleBorderThickness = 1;
            this.btnLogin.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.IdleIconLeftImage = null;
            this.btnLogin.IdleIconRightImage = null;
            this.btnLogin.IndicateFocus = false;
            this.btnLogin.Location = new System.Drawing.Point(103, 385);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnDisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.OnDisabledState.BorderRadius = 30;
            this.btnLogin.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnDisabledState.BorderThickness = 1;
            this.btnLogin.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.OnDisabledState.IconLeftImage = null;
            this.btnLogin.OnDisabledState.IconRightImage = null;
            this.btnLogin.onHoverState.BorderColor = System.Drawing.Color.Empty;
            this.btnLogin.onHoverState.BorderRadius = 30;
            this.btnLogin.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.onHoverState.BorderThickness = 1;
            this.btnLogin.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.onHoverState.IconLeftImage = null;
            this.btnLogin.onHoverState.IconRightImage = null;
            this.btnLogin.OnIdleState.BorderColor = System.Drawing.Color.Empty;
            this.btnLogin.OnIdleState.BorderRadius = 30;
            this.btnLogin.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnIdleState.BorderThickness = 1;
            this.btnLogin.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.OnIdleState.IconLeftImage = null;
            this.btnLogin.OnIdleState.IconRightImage = null;
            this.btnLogin.OnPressedState.BorderColor = System.Drawing.Color.Empty;
            this.btnLogin.OnPressedState.BorderRadius = 30;
            this.btnLogin.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnPressedState.BorderThickness = 1;
            this.btnLogin.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btnLogin.OnPressedState.IconLeftImage = null;
            this.btnLogin.OnPressedState.IconRightImage = null;
            this.btnLogin.Size = new System.Drawing.Size(163, 71);
            this.btnLogin.TabIndex = 34;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogin.TextMarginLeft = 0;
            this.btnLogin.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnLogin.UseDefaultRadiusAndThickness = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lab_login_error
            // 
            this.lab_login_error.AutoSize = true;
            this.lab_login_error.BackColor = System.Drawing.Color.Transparent;
            this.lab_login_error.Font = new System.Drawing.Font("Ubuntu", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_login_error.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.lab_login_error.Location = new System.Drawing.Point(520, 552);
            this.lab_login_error.Name = "lab_login_error";
            this.lab_login_error.Size = new System.Drawing.Size(0, 26);
            this.lab_login_error.TabIndex = 33;
            // 
            // lab_pass_err
            // 
            this.lab_pass_err.AutoSize = true;
            this.lab_pass_err.BackColor = System.Drawing.Color.Transparent;
            this.lab_pass_err.Font = new System.Drawing.Font("Ubuntu", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_pass_err.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.lab_pass_err.Location = new System.Drawing.Point(545, 435);
            this.lab_pass_err.Name = "lab_pass_err";
            this.lab_pass_err.Size = new System.Drawing.Size(0, 27);
            this.lab_pass_err.TabIndex = 32;
            // 
            // lab_username_err
            // 
            this.lab_username_err.AutoSize = true;
            this.lab_username_err.BackColor = System.Drawing.Color.Transparent;
            this.lab_username_err.Font = new System.Drawing.Font("Ubuntu", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_username_err.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.lab_username_err.Location = new System.Drawing.Point(545, 329);
            this.lab_username_err.Name = "lab_username_err";
            this.lab_username_err.Size = new System.Drawing.Size(0, 27);
            this.lab_username_err.TabIndex = 31;
            // 
            // backgroundWorkerLogin
            // 
            this.backgroundWorkerLogin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLogin_DoWork);
            this.backgroundWorkerLogin.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLogin_RunWorkerCompleted);
            // 
            // panellog
            // 
            this.panellog.Controls.Add(this.textPassword);
            this.panellog.Controls.Add(this.btnLogin);
            this.panellog.Controls.Add(this.label1);
            this.panellog.Controls.Add(this.hide_pass_btn);
            this.panellog.Controls.Add(this.textUsername);
            this.panellog.Controls.Add(this.show_pass_btn);
            this.panellog.Location = new System.Drawing.Point(489, 70);
            this.panellog.Name = "panellog";
            this.panellog.Size = new System.Drawing.Size(423, 519);
            this.panellog.TabIndex = 39;
            this.panellog.Visible = false;
            // 
            // panelconnectionerrorpackage
            // 
            this.panelconnectionerrorpackage.Controls.Add(this.bunifuButton1);
            this.panelconnectionerrorpackage.Controls.Add(this.label5);
            this.panelconnectionerrorpackage.Controls.Add(this.pictureBox4);
            this.panelconnectionerrorpackage.Location = new System.Drawing.Point(518, 155);
            this.panelconnectionerrorpackage.Name = "panelconnectionerrorpackage";
            this.panelconnectionerrorpackage.Size = new System.Drawing.Size(372, 371);
            this.panelconnectionerrorpackage.TabIndex = 40;
            this.panelconnectionerrorpackage.Visible = false;
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.AllowAnimations = true;
            this.bunifuButton1.AllowMouseEffects = true;
            this.bunifuButton1.AllowToggling = true;
            this.bunifuButton1.AnimationSpeed = 200;
            this.bunifuButton1.AutoGenerateColors = false;
            this.bunifuButton1.AutoRoundBorders = false;
            this.bunifuButton1.AutoSizeLeftIcon = true;
            this.bunifuButton1.AutoSizeRightIcon = true;
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.ButtonText = "Refresh";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.ColorContrastOnClick = 45;
            this.bunifuButton1.ColorContrastOnHover = 45;
            this.bunifuButton1.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.bunifuButton1.CustomizableEdges = borderEdges1;
            this.bunifuButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton1.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton1.Font = new System.Drawing.Font("Gilroy-SemiBold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.bunifuButton1.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bunifuButton1.IconMarginLeft = 11;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bunifuButton1.IconSize = 25;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.Empty;
            this.bunifuButton1.IdleBorderRadius = 30;
            this.bunifuButton1.IdleBorderThickness = 1;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.IndicateFocus = false;
            this.bunifuButton1.Location = new System.Drawing.Point(112, 280);
            this.bunifuButton1.Name = "bunifuButton1";
            this.bunifuButton1.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton1.OnDisabledState.BorderRadius = 30;
            this.bunifuButton1.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.OnDisabledState.BorderThickness = 1;
            this.bunifuButton1.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton1.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton1.OnDisabledState.IconLeftImage = null;
            this.bunifuButton1.OnDisabledState.IconRightImage = null;
            this.bunifuButton1.onHoverState.BorderColor = System.Drawing.Color.Empty;
            this.bunifuButton1.onHoverState.BorderRadius = 30;
            this.bunifuButton1.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.onHoverState.BorderThickness = 1;
            this.bunifuButton1.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.bunifuButton1.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.bunifuButton1.onHoverState.IconLeftImage = null;
            this.bunifuButton1.onHoverState.IconRightImage = null;
            this.bunifuButton1.OnIdleState.BorderColor = System.Drawing.Color.Empty;
            this.bunifuButton1.OnIdleState.BorderRadius = 30;
            this.bunifuButton1.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.OnIdleState.BorderThickness = 1;
            this.bunifuButton1.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.bunifuButton1.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.bunifuButton1.OnIdleState.IconLeftImage = null;
            this.bunifuButton1.OnIdleState.IconRightImage = null;
            this.bunifuButton1.OnPressedState.BorderColor = System.Drawing.Color.Empty;
            this.bunifuButton1.OnPressedState.BorderRadius = 30;
            this.bunifuButton1.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.OnPressedState.BorderThickness = 1;
            this.bunifuButton1.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.bunifuButton1.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.bunifuButton1.OnPressedState.IconLeftImage = null;
            this.bunifuButton1.OnPressedState.IconRightImage = null;
            this.bunifuButton1.Size = new System.Drawing.Size(163, 71);
            this.bunifuButton1.TabIndex = 35;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuButton1.TextMarginLeft = 0;
            this.bunifuButton1.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuButton1.UseDefaultRadiusAndThickness = true;
            this.bunifuButton1.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Gilroy-SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(71)))), ((int)(((byte)(78)))));
            this.label5.Location = new System.Drawing.Point(12, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(354, 39);
            this.label5.TabIndex = 1;
            this.label5.Text = "Check your connection";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::gym_management_system.Properties.Resources.wifi_slash_2;
            this.pictureBox4.Location = new System.Drawing.Point(49, 9);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(270, 177);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panelloadingCon
            // 
            this.panelloadingCon.Controls.Add(this.pictureBox3);
            this.panelloadingCon.Location = new System.Drawing.Point(572, 175);
            this.panelloadingCon.Name = "panelloadingCon";
            this.panelloadingCon.Size = new System.Drawing.Size(270, 331);
            this.panelloadingCon.TabIndex = 41;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::gym_management_system.Properties.Resources._154039234778Fitness_Center;
            this.pictureBox3.Location = new System.Drawing.Point(-6, -31);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(290, 362);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // Login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(971, 631);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Gilroy-UltraLight", 7.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enter_Key);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.show_pass_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide_pass_btn)).EndInit();
            this.panellog.ResumeLayout(false);
            this.panellog.PerformLayout();
            this.panelconnectionerrorpackage.ResumeLayout(false);
            this.panelconnectionerrorpackage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelloadingCon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textUsername;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textPassword;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private System.Windows.Forms.Label lab_login_error;
        private System.Windows.Forms.Label lab_pass_err;
        private System.Windows.Forms.Label lab_username_err;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnLogin;
        private System.Windows.Forms.PictureBox show_pass_btn;
        private System.Windows.Forms.PictureBox hide_pass_btn;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLogin;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.Panel panellog;
        private System.Windows.Forms.Panel panelconnectionerrorpackage;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelloadingCon;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

