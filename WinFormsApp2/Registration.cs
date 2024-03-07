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
    public partial class Registration : Form
    {
        string cn = "Server=localhost;Port=5432;Database=ARM;Username=postgres;Password=11299133;";

        public Registration()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
               using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = $"insert into roles(name, password) values('{textBox1.Text}', '{textBox2.Text}')";

                var cmd = new NpgsqlCommand(sql, npgsql);

                cmd.ExecuteNonQuery();

                Form2.role = textBox1.Text;

                this.Close();
            }

            catch
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
