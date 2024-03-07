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
    public partial class Form4 : Form
    {
        static public int choise;
        int selectedRow = 0;
        string cn = "Server=localhost;Port=5432;Database=ARM;Username=postgres;Password=11299133;";

        public Form4()
        {
            InitializeComponent();

            using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
            npgsql.Open();

            if (Form2.instanse.datagrid == 1)
            {

                var sql = "select restaurant_name from restaurant_chain;";
                var cmd = new NpgsqlCommand(sql, npgsql);
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["restaurant_name"].ToString());
                }
            }

            if (Form2.instanse.datagrid == 2)
            {
                label1.Text = "Название города";
                cityBox.Visible = cityBox.Enabled = true;
                label2.Visible = label3.Visible = label4.Visible = false;
                addressBox.Visible = numBox.Visible = comboBox1.Visible = reviewBox.Visible = restaurantBox.Visible = false;
            }

            if (Form2.instanse.datagrid == 3)
            {
                label1.Text = "Название ресторана";
                restaurantBox.Visible = restaurantBox.Enabled = true;
                label2.Visible = label3.Visible = label4.Visible = false;
                addressBox.Visible = numBox.Visible = comboBox1.Visible = reviewBox.Visible = false;
                addressBox.Enabled = numBox.Enabled = comboBox1.Enabled = reviewBox.Enabled = false;
            }

            if (Form2.instanse.datagrid == 4)
            {
                label1.Text = "ФИО сотрудника";
                label2.Text = "Возраст сотрудника";
                label3.Text = "Зарплата сотрудника";
                label4.Text = "Адрес работы";
                fioBox.Visible = fioBox.Enabled = true;
                ageBox.Visible = ageBox.Enabled = true;
                salaryBox.Visible = salaryBox.Enabled = true;
                comboBox2.Visible = comboBox2.Enabled = true;

                var sql = "select address from branches;";
                var cmd = new NpgsqlCommand(sql, npgsql);
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr[0].ToString());
                }

                addressBox.Visible = numBox.Visible = comboBox1.Visible = reviewBox.Visible = false;
                addressBox.Enabled = numBox.Enabled = comboBox1.Enabled = reviewBox.Enabled = false;
            }
        }

        public Form4(SampleRow row, int selectedRow)
        {
            InitializeComponent();

            if (Form2.role.Contains("user"))
            {
                addressBox.Enabled = numBox.Enabled = comboBox1.Enabled = false;
            }

            using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
            npgsql.Open();

            this.comboBox1.Text = row.brenchName;
            this.addressBox.Text = row.address;
            this.numBox.Text = row.number_of_seats.ToString();
            this.reviewBox.Text = row.reviews.ToString();
            this.selectedRow = selectedRow;

            var sql = "select restaurant_name from restaurant_chain;";

            var cmd = new NpgsqlCommand(sql, npgsql);

            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox1.Items.Add(dr["restaurant_name"].ToString());
            }
        }

        public Form4(Cities city, int selectedRow)
        {
            InitializeComponent();

            label1.Text = "Название города";
            cityBox.Visible = cityBox.Enabled = true;
            label2.Visible = label3.Visible = label4.Visible = false;
            addressBox.Visible = numBox.Visible = comboBox1.Visible = reviewBox.Visible = restaurantBox.Visible = false;

            cityBox.Text = city.city;
            this.selectedRow = selectedRow;
        }

        public Form4(Restaurants restaurant, int selectedRow)
        {
            InitializeComponent();

            label1.Text = "Название ресторана";
            restaurantBox.Visible = restaurantBox.Enabled = true;
            label2.Visible = label3.Visible = label4.Visible = false;
            addressBox.Visible = numBox.Visible = comboBox1.Visible = reviewBox.Visible = false;
            addressBox.Enabled = numBox.Enabled = comboBox1.Enabled = reviewBox.Enabled = false;

            restaurantBox.Text = restaurant.restaurant;
            this.selectedRow = selectedRow;
        }

        public Form4(Employee employee, int selectedRow)
        {
            InitializeComponent();

            using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
            npgsql.Open();

            label1.Text = "ФИО сотрудника";
            label2.Text = "Возраст сотрудника";
            label3.Text = "Зарплата сотрудника";
            label4.Text = "Адрес работы";
            fioBox.Visible = fioBox.Enabled = true;
            ageBox.Visible = ageBox.Enabled = true;
            salaryBox.Visible = salaryBox.Enabled = true;
            comboBox2.Visible = comboBox2.Enabled = true;

            var sql = "select address from branches;";
            var cmd = new NpgsqlCommand(sql, npgsql);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }

            addressBox.Visible = numBox.Visible = comboBox1.Visible = reviewBox.Visible = false;
            addressBox.Enabled = numBox.Enabled = comboBox1.Enabled = reviewBox.Enabled = false;
  
            fioBox.Text = employee.fio;
            ageBox.Text = employee.age.ToString();
            salaryBox.Text = employee.salary.ToString();
            comboBox2.Text = employee.branch_address;

            this.selectedRow = selectedRow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form2.instanse.datagrid == 1)
            {
                try
                {
                    if (choise == 0)
                        Form2.instanse.addBranch(comboBox1.SelectedItem.ToString(), addressBox.Text, int.Parse(numBox.Text), decimal.Parse(reviewBox.Text));
                    else
                    {
                        string branch_name = comboBox1.SelectedItem is null ? comboBox1.Text : comboBox1.SelectedItem.ToString();
                        Form2.instanse.updBranch(branch_name, addressBox.Text, int.Parse(numBox.Text), decimal.Parse(reviewBox.Text), selectedRow);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при сохранении результата.");
                }
            }

            if (Form2.instanse.datagrid == 2)
            {
                if (choise == 0)
                    Form2.instanse.addCities(cityBox.Text);
                else
                {
                    Form2.instanse.updCities(cityBox.Text, selectedRow);
                }
            }

            if (Form2.instanse.datagrid == 3)
            {
                if (choise == 0)
                    Form2.instanse.addRestaurant(restaurantBox.Text);
                else
                {
                    Form2.instanse.updRestaurant(restaurantBox.Text, selectedRow);
                }
            }

            if (Form2.instanse.datagrid == 4)
            {
                if (choise == 0)
                    Form2.instanse.addEmployee(new Employee(fioBox.Text, int.Parse(ageBox.Text), int.Parse(salaryBox.Text), comboBox2.SelectedItem.ToString()));
                else
                {
                    string branch_name = comboBox2.SelectedItem is null ? comboBox2.Text : comboBox2.SelectedItem.ToString();
                    Form2.instanse.updEmployee(new Employee(fioBox.Text, int.Parse(ageBox.Text), int.Parse(salaryBox.Text), branch_name), selectedRow);
                }
            }

            Close();
        }
    }
}
