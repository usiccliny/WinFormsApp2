using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Authorization : Form
    {
        string cn = "Server=localhost;Port=5432;Database=ARM;Username=postgres;Password=11299133;";

        public Authorization()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else txtPassword.UseSystemPasswordChar = true;
        }

        private void Entry_btn_Click(object sender, EventArgs e)
        {
            using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
            npgsql.Open();

            var sql = @"select exists (select * from roles where name = @name and password = @password);";

            var cmd = new NpgsqlCommand(sql, npgsql);
            cmd.Parameters.AddWithValue("@name", txtLogin.Text);
            cmd.Parameters.AddWithValue("password", txtPassword.Text);
            
            if (cmd.ExecuteScalar().ToString() == "True")
            {
                Hide();
                Form2.role = txtLogin.Text;
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration reg = new Registration();
            reg.ShowDialog();
        }
    }
}
