namespace Login
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.label4 = new System.Windows.Forms.Label();
            this.User = new CCWin.SkinControl.SkinAlphaWaterTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Exit = new CCWin.SkinControl.SkinButton();
            this.skinPictureBox3 = new CCWin.SkinControl.SkinPictureBox();
            this.Login = new CCWin.SkinControl.SkinButton();
            this.skinPictureBox2 = new CCWin.SkinControl.SkinPictureBox();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.Password = new CCWin.SkinControl.SkinAlphaWaterTextBox();
            this.User10086 = new CCWin.SkinControl.SkinAlphaWaterTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label4.Location = new System.Drawing.Point(544, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 31;
            this.label4.Text = "欢迎使用";
            // 
            // User
            // 
            this.User.BackAlpha = 10;
            this.User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.User.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.User.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(60)))), ((int)(((byte)(84)))));
            this.User.Location = new System.Drawing.Point(240, 183);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(215, 17);
            this.User.TabIndex = 1;
            this.User.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.User.WaterFont = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.User.WaterText = "请输入账号";
            this.User.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User_KeyDown);
            this.User.MouseEnter += new System.EventHandler(this.User_MouseEnter);
            this.User.MouseLeave += new System.EventHandler(this.User_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label2.Location = new System.Drawing.Point(250, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "© 2019-2022 Passioniot.com ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label1.Location = new System.Drawing.Point(308, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "派迅智能";
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(159)))), ((int)(((byte)(176)))));
            this.Exit.BorderColor = System.Drawing.Color.Transparent;
            this.Exit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Exit.DownBack = null;
            this.Exit.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(60)))), ((int)(((byte)(84)))));
            this.Exit.FadeGlow = false;
            this.Exit.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.GlowColor = System.Drawing.Color.Empty;
            this.Exit.InnerBorderColor = System.Drawing.Color.Transparent;
            this.Exit.IsDrawGlass = false;
            this.Exit.Location = new System.Drawing.Point(333, 280);
            this.Exit.MouseBack = null;
            this.Exit.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(139)))), ((int)(((byte)(146)))));
            this.Exit.Name = "Exit";
            this.Exit.NormlBack = null;
            this.Exit.Radius = 20;
            this.Exit.RoundStyle = CCWin.SkinClass.RoundStyle.Right;
            this.Exit.Size = new System.Drawing.Size(122, 41);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "退 出";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // skinPictureBox3
            // 
            this.skinPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skinPictureBox3.BackgroundImage")));
            this.skinPictureBox3.Location = new System.Drawing.Point(287, 57);
            this.skinPictureBox3.Name = "skinPictureBox3";
            this.skinPictureBox3.Size = new System.Drawing.Size(96, 96);
            this.skinPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.skinPictureBox3.TabIndex = 26;
            this.skinPictureBox3.TabStop = false;
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.Transparent;
            this.Login.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(159)))), ((int)(((byte)(176)))));
            this.Login.BorderColor = System.Drawing.Color.Transparent;
            this.Login.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Login.DownBack = null;
            this.Login.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(60)))), ((int)(((byte)(84)))));
            this.Login.FadeGlow = false;
            this.Login.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.ForeColor = System.Drawing.Color.White;
            this.Login.GlowColor = System.Drawing.Color.Empty;
            this.Login.InnerBorderColor = System.Drawing.Color.Transparent;
            this.Login.IsDrawGlass = false;
            this.Login.Location = new System.Drawing.Point(210, 280);
            this.Login.MouseBack = null;
            this.Login.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(139)))), ((int)(((byte)(146)))));
            this.Login.Name = "Login";
            this.Login.NormlBack = null;
            this.Login.Radius = 20;
            this.Login.RoundStyle = CCWin.SkinClass.RoundStyle.Left;
            this.Login.Size = new System.Drawing.Size(122, 41);
            this.Login.TabIndex = 3;
            this.Login.Text = "登 录";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // skinPictureBox2
            // 
            this.skinPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("skinPictureBox2.Image")));
            this.skinPictureBox2.Location = new System.Drawing.Point(210, 240);
            this.skinPictureBox2.Name = "skinPictureBox2";
            this.skinPictureBox2.Size = new System.Drawing.Size(24, 24);
            this.skinPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.skinPictureBox2.TabIndex = 24;
            this.skinPictureBox2.TabStop = false;
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("skinPictureBox1.Image")));
            this.skinPictureBox1.Location = new System.Drawing.Point(210, 183);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(24, 24);
            this.skinPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.skinPictureBox1.TabIndex = 23;
            this.skinPictureBox1.TabStop = false;
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(225, 204);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(215, 1);
            this.skinPanel2.TabIndex = 22;
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(225, 263);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(215, 1);
            this.skinPanel1.TabIndex = 21;
            // 
            // Password
            // 
            this.Password.BackAlpha = 10;
            this.Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(60)))), ((int)(((byte)(84)))));
            this.Password.Location = new System.Drawing.Point(240, 242);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(215, 17);
            this.Password.TabIndex = 2;
            this.Password.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.Password.WaterFont = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Password.WaterText = "请输入密码";
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            this.Password.MouseEnter += new System.EventHandler(this.Password_MouseEnter);
            this.Password.MouseLeave += new System.EventHandler(this.Password_MouseLeave);
            this.Password.MouseHover += new System.EventHandler(this.Password_MouseHover);
            // 
            // User10086
            // 
            this.User10086.BackAlpha = 10;
            this.User10086.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.User10086.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.User10086.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User10086.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(60)))), ((int)(((byte)(84)))));
            this.User10086.Location = new System.Drawing.Point(649, 280);
            this.User10086.Name = "User10086";
            this.User10086.Size = new System.Drawing.Size(12, 17);
            this.User10086.TabIndex = 19;
            this.User10086.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.User10086.WaterFont = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.User10086.WaterText = "";
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(644, 453);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.User);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.skinPictureBox3);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.skinPictureBox2);
            this.Controls.Add(this.skinPictureBox1);
            this.Controls.Add(this.skinPanel2);
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.User10086);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("LoginView.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginView_Load);
            this.Shown += new System.EventHandler(this.LoginView_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private CCWin.SkinControl.SkinAlphaWaterTextBox User;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinButton Exit;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox3;
        private CCWin.SkinControl.SkinButton Login;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox2;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinAlphaWaterTextBox Password;
        private CCWin.SkinControl.SkinAlphaWaterTextBox User10086;
    }
}

