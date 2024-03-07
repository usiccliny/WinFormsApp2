namespace WinFormsApp2
{
    partial class Authorization
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.showPassword = new System.Windows.Forms.CheckBox();
            this.Entry_btn = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите имя пользователя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введите пароль";
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.LightGray;
            this.txtLogin.Location = new System.Drawing.Point(92, 119);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(153, 23);
            this.txtLogin.TabIndex = 2;
            this.txtLogin.Text = "admin";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.LightGray;
            this.txtPassword.Location = new System.Drawing.Point(92, 193);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(153, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "admin";
            // 
            // showPassword
            // 
            this.showPassword.AutoSize = true;
            this.showPassword.Location = new System.Drawing.Point(198, 232);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(119, 19);
            this.showPassword.TabIndex = 4;
            this.showPassword.Text = "Показать пароль";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.CheckedChanged += new System.EventHandler(this.showPassword_CheckedChanged);
            // 
            // Entry_btn
            // 
            this.Entry_btn.BackColor = System.Drawing.Color.RosyBrown;
            this.Entry_btn.Location = new System.Drawing.Point(92, 348);
            this.Entry_btn.Name = "Entry_btn";
            this.Entry_btn.Size = new System.Drawing.Size(153, 31);
            this.Entry_btn.TabIndex = 5;
            this.Entry_btn.Text = "Войти";
            this.Entry_btn.UseVisualStyleBackColor = false;
            this.Entry_btn.Click += new System.EventHandler(this.Entry_btn_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(125, 272);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(76, 15);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Регистрация";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(340, 438);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Entry_btn);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private CheckBox showPassword;
        private Button Entry_btn;
        private LinkLabel linkLabel1;
    }
}