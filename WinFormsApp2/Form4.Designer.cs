namespace WinFormsApp2
{
    partial class Form4
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.reviewBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cityBox = new System.Windows.Forms.TextBox();
            this.restaurantBox = new System.Windows.Forms.TextBox();
            this.fioBox = new System.Windows.Forms.TextBox();
            this.ageBox = new System.Windows.Forms.TextBox();
            this.salaryBox = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название ресторана";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(257, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Адрес ресторана";
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(257, 90);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(121, 23);
            this.addressBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество мест";
            // 
            // numBox
            // 
            this.numBox.Location = new System.Drawing.Point(257, 126);
            this.numBox.Name = "numBox";
            this.numBox.Size = new System.Drawing.Size(121, 23);
            this.numBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Отзыв об ресторане";
            // 
            // reviewBox
            // 
            this.reviewBox.Location = new System.Drawing.Point(257, 161);
            this.reviewBox.Name = "reviewBox";
            this.reviewBox.Size = new System.Drawing.Size(121, 23);
            this.reviewBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 53);
            this.button1.TabIndex = 8;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cityBox
            // 
            this.cityBox.Enabled = false;
            this.cityBox.Location = new System.Drawing.Point(257, 52);
            this.cityBox.Name = "cityBox";
            this.cityBox.Size = new System.Drawing.Size(121, 23);
            this.cityBox.TabIndex = 9;
            this.cityBox.Visible = false;
            // 
            // restaurantBox
            // 
            this.restaurantBox.Enabled = false;
            this.restaurantBox.Location = new System.Drawing.Point(257, 52);
            this.restaurantBox.Name = "restaurantBox";
            this.restaurantBox.Size = new System.Drawing.Size(121, 23);
            this.restaurantBox.TabIndex = 10;
            this.restaurantBox.Visible = false;
            // 
            // fioBox
            // 
            this.fioBox.Enabled = false;
            this.fioBox.Location = new System.Drawing.Point(257, 52);
            this.fioBox.Name = "fioBox";
            this.fioBox.Size = new System.Drawing.Size(121, 23);
            this.fioBox.TabIndex = 11;
            this.fioBox.Visible = false;
            this.fioBox.WordWrap = false;
            // 
            // ageBox
            // 
            this.ageBox.Enabled = false;
            this.ageBox.Location = new System.Drawing.Point(257, 90);
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(121, 23);
            this.ageBox.TabIndex = 12;
            this.ageBox.Visible = false;
            // 
            // salaryBox
            // 
            this.salaryBox.Enabled = false;
            this.salaryBox.Location = new System.Drawing.Point(257, 126);
            this.salaryBox.Name = "salaryBox";
            this.salaryBox.Size = new System.Drawing.Size(121, 23);
            this.salaryBox.TabIndex = 13;
            this.salaryBox.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(257, 161);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 14;
            this.comboBox2.Visible = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(477, 384);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.salaryBox);
            this.Controls.Add(this.ageBox);
            this.Controls.Add(this.fioBox);
            this.Controls.Add(this.restaurantBox);
            this.Controls.Add(this.cityBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reviewBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox addressBox;
        private Label label3;
        private TextBox numBox;
        private Label label4;
        private TextBox reviewBox;
        private Button button1;
        private TextBox cityBox;
        private TextBox restaurantBox;
        private TextBox fioBox;
        private TextBox ageBox;
        private TextBox salaryBox;
        private ComboBox comboBox2;
    }
}