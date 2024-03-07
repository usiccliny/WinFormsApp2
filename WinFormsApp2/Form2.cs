using Microsoft.Office.Interop.Excel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        static public string role;
        string cn = "Server=localhost;Port=5432;Database=ARM;Username=postgres;Password=11299133;";
        BindingList<SampleRow> data = new BindingList<SampleRow>();
        BindingList<Employee> employees = new BindingList<Employee>();
        BindingList<Cities> cities = new BindingList<Cities>();
        BindingList<Restaurants> restaurants = new BindingList<Restaurants>();
        string city;
        static public Form2 instanse;
        public int datagrid = 0;

        public Form2()
        {
            instanse = this;

            InitializeComponent();

            if (role != "admin" && role != "manager")
            {
                addBtn.Enabled = addBtn.Visible = false;
                delBtn.Enabled = delBtn.Visible = false;
                editBtn.Enabled = editBtn.Visible = false;
            }

            if (role.Contains("user"))
            {
                tabControl1.TabPages.Remove(tabEmployees);
                    editBtn.Enabled = editBtn.Visible = true;
            }

            using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
            npgsql.Open();

            var sql = "select restaurant_name, b.address, reviews, number_of_seats, city_name from restaurant_chain rc join branches b on rc.id = restaurant_chain_id right join cities c on c.id = city_id";

            var cmd = new NpgsqlCommand(sql, npgsql);

            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                    data.Add(new SampleRow(dr["restaurant_name"].ToString(), dr["address"].ToString(), (int)dr["number_of_seats"], (decimal)dr["reviews"]));
                if (!comboBox1.Items.Contains(dr["city_name"]))
                    comboBox1.Items.Add(dr["city_name"]);
            }
            dr.Close();

            dataGridView2.DataSource = data;

            foreach (string elem in comboBox1.Items)
            {
                cities.Add(new Cities(elem));
            }

            dataGridView1.DataSource = cities;

            sql = "select restaurant_name from restaurant_chain;";
            cmd = new NpgsqlCommand(sql, npgsql);

            using var dr2 = cmd.ExecuteReader();
            while (dr2.Read())
            {
                if (!dr2.IsDBNull(0))
                    restaurants.Add(new Restaurants(dr2[0].ToString()));
            }
            dr2.Close();

            dataGridView4.DataSource = restaurants;

            sql = "select e.fio, e.age, e.salary, b.address from employees e join branches b on e.branch_id = b.id ;";
            cmd = new NpgsqlCommand(sql, npgsql);

            using var dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                if (!dr1.IsDBNull(0))
                    employees.Add(new Employee(dr1["fio"].ToString(), (int)dr1["age"], (int)dr1["salary"], dr1["address"].ToString()));
            }
            dr1.Close();

            dataGridView3.DataSource = employees;
        }

        private void nonStandartSql_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
            npgsql.Open();

            var sql = @"select restaurant_name, b.address, reviews, number_of_seats from restaurant_chain rc join branches b on rc.id = restaurant_chain_id right join cities c on c.id = city_id where city_name = @name;";

            var cmd = new NpgsqlCommand(sql, npgsql);
            cmd.Parameters.AddWithValue("@name", comboBox1.SelectedItem);

            using var dr = cmd.ExecuteReader();
            data.Clear();
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                    data.Add(new SampleRow(dr["restaurant_name"].ToString(), dr["address"].ToString(), (int)dr["number_of_seats"], (decimal)dr["reviews"]));
            }

            city = comboBox1.SelectedItem.ToString();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (role == "admin" || role == "manager")
            {
                if (tabControl1.SelectedTab == tabAddress)
                    datagrid = 1;

                if (tabControl1.SelectedTab == tabCities)
                    datagrid = 2;

                if (tabControl1.SelectedTab == tabRestaurant)
                    datagrid = 3;

                if (tabControl1.SelectedTab == tabEmployees)
                    datagrid = 4;

                Form4 form4 = new Form4();
                Form4.choise = 0;
                form4.ShowDialog();
            }
        }

        public void addBranch(string branch_name, string address, int number_of_seats, decimal reviews)
        {
            try
            {
                using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = @"insert into branches(address, number_of_seats, reviews, city_id, restaurant_chain_id)
                            values(@address, @num,  @review, (select id from cities  where city_name = @city_name),
                            (select id from restaurant_chain rc where restaurant_name = @name))";

                var cmd = new NpgsqlCommand(sql, npgsql);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@num", number_of_seats);
                cmd.Parameters.AddWithValue("@name", branch_name);
                cmd.Parameters.AddWithValue("@review", reviews);
                cmd.Parameters.AddWithValue("@city_name", city);

                cmd.ExecuteNonQuery();

                data.Add(new SampleRow(branch_name, address, number_of_seats, reviews));
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении");
            }
        }

        public void addCities(string city)
        {
            try
            {
                using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = $"insert into cities (city_name) values('{city}')";

                var cmd = new NpgsqlCommand(sql, npgsql);

                cmd.ExecuteNonQuery();

                cities.Add(new Cities(city));
                comboBox1.Items.Add(city);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении");
            }
        }

        public void addRestaurant(string restaurant)
        {
            try
            {
                using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = $"insert into restaurant_chain (restaurant_name) values('{restaurant}')";

                var cmd = new NpgsqlCommand(sql, npgsql);

                cmd.ExecuteNonQuery();

                restaurants.Add(new Restaurants(restaurant));

            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении");
            }
        }

        public void addEmployee(Employee employee)
        {
            try
            {
                using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = $"insert into employees (fio, age, salary, branch_id) " +
                    $"values('{employee.fio}', {employee.age}, {employee.salary}, (select id from branches where address = '{employee.branch_address}'))";

                var cmd = new NpgsqlCommand(sql, npgsql);

                cmd.ExecuteNonQuery();

                employees.Add(new Employee(employee.fio, employee.age, employee.salary, employee.branch_address));
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении");
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (role == "admin" || role == "manager")
            {
                if (tabControl1.SelectedTab == tabAddress)
                {

                    int selectedRow = dataGridView2.CurrentCell.RowIndex;

                    try
                    {
                        using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                        npgsql.Open();

                        var sql = @"delete from branches where address = @address and city_id = (select id from cities where city_name = @city_name);";

                        var cmd = new NpgsqlCommand(sql, npgsql);
                        cmd.Parameters.AddWithValue("@address", data[selectedRow].address);
                        cmd.Parameters.AddWithValue("@city_name", city);
                        cmd.ExecuteNonQuery();

                        data.Remove(data[selectedRow]);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при удалении");
                    }
                }

                if (tabControl1.SelectedTab == tabCities)
                {

                    int selectedRow = dataGridView1.CurrentCell.RowIndex;

                    try
                    {
                        using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                        npgsql.Open();

                        var sql = $"delete from cities where city_name = '{cities[selectedRow].city}';";

                        var cmd = new NpgsqlCommand(sql, npgsql);

                        cmd.ExecuteNonQuery();

                        comboBox1.Items.Remove(cities[selectedRow].city);
                        cities.Remove(cities[selectedRow]);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при удалении");
                    }
                }

                if (tabControl1.SelectedTab == tabRestaurant)
                {

                    int selectedRow = dataGridView4.CurrentCell.RowIndex;

                    try
                    {
                        using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                        npgsql.Open();

                        var sql = $"delete from restaurant_chain where restaurant_name = '{restaurants[selectedRow].restaurant}';";

                        var cmd = new NpgsqlCommand(sql, npgsql);

                        cmd.ExecuteNonQuery();

                        restaurants.Remove(restaurants[selectedRow]);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при удалении");
                    }
                }

                if (tabControl1.SelectedTab == tabEmployees)
                {

                    int selectedRow = dataGridView3.CurrentCell.RowIndex;

                    try
                    {
                        using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                        npgsql.Open();

                        var sql = $"delete from employees where fio = '{employees[selectedRow].fio}' and " +
                            $"age = {employees[selectedRow].age} and salary = {employees[selectedRow].salary} and " +
                            $"branch_id = (select id from restaurant_chain where restaurant_name = '{employees[selectedRow].branch_address}');";

                        var cmd = new NpgsqlCommand(sql, npgsql);

                        cmd.ExecuteNonQuery();

                        employees.Remove(employees[selectedRow]);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при удалении");
                    }
                }
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabAddress)
            {
                int selectedRow = dataGridView2.CurrentCell.RowIndex;

                Form4 form4 = new Form4(data[selectedRow], selectedRow);
                datagrid = 1;
                Form4.choise = 1;
                form4.ShowDialog();
            }

            if (tabControl1.SelectedTab == tabCities && (role == "admin" || role == "manager"))
            {
                int selectedRow = dataGridView1.CurrentCell.RowIndex;

                Form4 form4 = new Form4(cities[selectedRow], selectedRow);
                datagrid = 2;
                Form4.choise = 1;
                form4.ShowDialog();

            }
            if (tabControl1.SelectedTab == tabRestaurant && (role == "admin" || role == "manager"))
            {
                int selectedRow = dataGridView4.CurrentCell.RowIndex;

                Form4 form4 = new Form4(restaurants[selectedRow], selectedRow);
                datagrid = 3;
                Form4.choise = 1;
                form4.ShowDialog();
            }

            if (tabControl1.SelectedTab == tabEmployees && (role == "admin" || role == "manager"))
            {
                int selectedRow = dataGridView3.CurrentCell.RowIndex;

                Form4 form4 = new Form4(employees[selectedRow], selectedRow);
                datagrid = 4;
                Form4.choise = 1;
                form4.ShowDialog();
            }
        }

        public void updBranch(string branch_name, string address, int number_of_seats, decimal reviews, int selectedRow)
        {
            try
            {
                using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = @"update branches set address = @address, number_of_seats = @num, reviews = @review, restaurant_chain_id = (select id from restaurant_chain where restaurant_name = @name)
                            where address = @address1 and city_id = (select id from cities where city_name = @city_name);";

                var cmd = new NpgsqlCommand(sql, npgsql);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@address1", data[selectedRow].address);
                cmd.Parameters.AddWithValue("@num", number_of_seats);
                cmd.Parameters.AddWithValue("@name", branch_name);
                cmd.Parameters.AddWithValue("@review", reviews);
                cmd.Parameters.AddWithValue("@city_name", city);
                cmd.ExecuteNonQuery();

                data[selectedRow].address = address;
                data[selectedRow].number_of_seats = number_of_seats;
                data[selectedRow].brenchName = branch_name;
                data[selectedRow].reviews = reviews;

                dataGridView2.Refresh();
            }
            catch
            {
                MessageBox.Show("Ошибка при обновлении");
            }
        }

        public void updCities(string city, int selectedRow)
        {
            try
            {
                using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = $"update cities set city_name = '{city}' where city_name = '{cities[selectedRow].city}'";
                var cmd = new NpgsqlCommand(sql, npgsql);

                cmd.ExecuteNonQuery();

                cities[selectedRow].city = city;
                
                dataGridView1.Refresh();
            }
            catch
            {
                MessageBox.Show("Ошибка при обновлении");
            }
        }

        public void updRestaurant(string restaurant, int selectedRow)
        {
            try
            {
                using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = $"update restaurant_chain set restaurant_name = '{restaurant}' where restaurant_name = '{restaurants[selectedRow].restaurant}'";
                var cmd = new NpgsqlCommand(sql, npgsql);

                cmd.ExecuteNonQuery();

                restaurants[selectedRow].restaurant = restaurant;

                dataGridView4.Refresh();
            }
            catch
            {
                MessageBox.Show("Ошибка при обновлении");
            }
        }

        public void updEmployee(Employee employee, int selectedRow)
        {
            try
            {
                using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = $"update employees set fio = '{employee.fio}', age = {employee.age}," +
                    $"salary = {employee.salary}, branch_id = (select id from branches where address = '{employee.branch_address}') " +
                    $"where fio = '{employees[selectedRow].fio}' and age = {employees[selectedRow].age} and salary = {employees[selectedRow].salary} " +
                    $"and branch_id = (select id from branches where address = '{employees[selectedRow].branch_address}')";
                var cmd = new NpgsqlCommand(sql, npgsql);

                cmd.ExecuteNonQuery();

                employees[selectedRow].fio = employee.fio;
                employees[selectedRow].age = employee.age;
                employees[selectedRow].salary = employee.salary;
                employees[selectedRow].branch_address = employee.branch_address;

                dataGridView3.Refresh();
            }
            catch
            {
                MessageBox.Show("Ошибка при обновлении");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = tabControl1.SelectedTab.Text;
        }
    }
}
