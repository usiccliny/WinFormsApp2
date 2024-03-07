namespace WinFormsApp2
{
    partial class Form2
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
            this.nonStandartSql = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRestaurant = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.tabCities = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabAddress = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabRestaurant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.tabCities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // nonStandartSql
            // 
            this.nonStandartSql.BackColor = System.Drawing.Color.RosyBrown;
            this.nonStandartSql.Location = new System.Drawing.Point(765, 420);
            this.nonStandartSql.Name = "nonStandartSql";
            this.nonStandartSql.Size = new System.Drawing.Size(23, 18);
            this.nonStandartSql.TabIndex = 0;
            this.nonStandartSql.Text = "^";
            this.nonStandartSql.UseVisualStyleBackColor = false;
            this.nonStandartSql.Click += new System.EventHandler(this.nonStandartSql_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.RosyBrown;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Рестораны";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.RosyBrown;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(493, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 46);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ваш город:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.LightGray;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(605, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.RosyBrown;
            this.addBtn.Location = new System.Drawing.Point(12, 403);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(134, 35);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "Добавить данные";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.BackColor = System.Drawing.Color.RosyBrown;
            this.delBtn.Location = new System.Drawing.Point(292, 403);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(134, 35);
            this.delBtn.TabIndex = 7;
            this.delBtn.Text = "Удалить данные";
            this.delBtn.UseVisualStyleBackColor = false;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.RosyBrown;
            this.editBtn.Location = new System.Drawing.Point(152, 403);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(134, 35);
            this.editBtn.TabIndex = 8;
            this.editBtn.Text = "Изменить данные";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRestaurant);
            this.tabControl1.Controls.Add(this.tabCities);
            this.tabControl1.Controls.Add(this.tabAddress);
            this.tabControl1.Controls.Add(this.tabEmployees);
            this.tabControl1.Location = new System.Drawing.Point(12, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(445, 339);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.Tag = "";
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabRestaurant
            // 
            this.tabRestaurant.Controls.Add(this.dataGridView4);
            this.tabRestaurant.Location = new System.Drawing.Point(4, 24);
            this.tabRestaurant.Name = "tabRestaurant";
            this.tabRestaurant.Padding = new System.Windows.Forms.Padding(3);
            this.tabRestaurant.Size = new System.Drawing.Size(437, 311);
            this.tabRestaurant.TabIndex = 3;
            this.tabRestaurant.Text = "Рестораны";
            this.tabRestaurant.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.RowTemplate.Height = 25;
            this.dataGridView4.Size = new System.Drawing.Size(441, 315);
            this.dataGridView4.TabIndex = 0;
            // 
            // tabCities
            // 
            this.tabCities.Controls.Add(this.dataGridView1);
            this.tabCities.Location = new System.Drawing.Point(4, 24);
            this.tabCities.Name = "tabCities";
            this.tabCities.Padding = new System.Windows.Forms.Padding(3);
            this.tabCities.Size = new System.Drawing.Size(437, 311);
            this.tabCities.TabIndex = 1;
            this.tabCities.Text = "Города";
            this.tabCities.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(437, 311);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabAddress
            // 
            this.tabAddress.Controls.Add(this.dataGridView2);
            this.tabAddress.Location = new System.Drawing.Point(4, 24);
            this.tabAddress.Name = "tabAddress";
            this.tabAddress.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddress.Size = new System.Drawing.Size(437, 311);
            this.tabAddress.TabIndex = 0;
            this.tabAddress.Text = "Филиалы ";
            this.tabAddress.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(441, 315);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabEmployees
            // 
            this.tabEmployees.Controls.Add(this.dataGridView3);
            this.tabEmployees.Location = new System.Drawing.Point(4, 24);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Size = new System.Drawing.Size(437, 311);
            this.tabEmployees.TabIndex = 2;
            this.tabEmployees.Text = "Сотрудники";
            this.tabEmployees.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 25;
            this.dataGridView3.Size = new System.Drawing.Size(437, 311);
            this.dataGridView3.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nonStandartSql);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabRestaurant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.tabCities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button nonStandartSql;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Button addBtn;
        private Button delBtn;
        private Button editBtn;
        private TabControl tabControl1;
        private TabPage tabAddress;
        private TabPage tabCities;
        private DataGridView dataGridView2;
        private DataGridView dataGridView1;
        private TabPage tabEmployees;
        private DataGridView dataGridView3;
        private TabPage tabRestaurant;
        private DataGridView dataGridView4;
    }
}