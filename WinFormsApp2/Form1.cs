using Excel = Microsoft.Office.Interop.Excel;
using Npgsql;
using System.Data;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.IO.Packaging;
using System.Net.Http.Headers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public string role = "";
        string cn = "Server=localhost;Port=5432;Database=ARM;Username=postgres;Password=11299133;";
        string field_name = "";
        string table_name = "";
        public List<string> condition_string = new List<string>();
        List<string> fields = new List<string>();
        List<string> fields_translate = new List<string>();
        List<string> from = new List<string>();
        public List<string> field_list = new List<string>();
        public List<string> table_list = new List<string>();
        static public string nonStandartSQL = "";
        BindingList<SampleRow> data = new BindingList<SampleRow>();
        public List<string> order_list = new List<string>();

        public Form1()
        {
            InitializeComponent();

            using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
            npgsql.Open();

            var sql = "select * from meta;";

            var cmd = new NpgsqlCommand(sql, npgsql);

            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["Translate"]);
                field_list.Add(dr["field_name"].ToString());
                table_list.Add(dr["table_name"].ToString());
                fieldNameBox.Items.Add(dr["Translate"]);
            }

            linkBox.Items.Add("");
            linkBox.Items.Add("И");
            linkBox.Items.Add("Или");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!checkedListBox1.Items.Contains(listBox1.SelectedItem))
                {
                    checkedListBox1.Items.Add(listBox1.SelectedItem);
                    listBox2.Items.Add(listBox1.SelectedItem);

                    fields.Add($"{table_list[listBox1.SelectedIndex]}.{field_list[listBox1.SelectedIndex]} ");
                    fields_translate.Add(listBox1.SelectedItem.ToString());
                    if (!from.Contains($"{table_list[listBox1.SelectedIndex]} "))
                        from.Add($"{table_list[listBox1.SelectedIndex]} ");

                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при переносе элемента");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string tmp_string = string.Concat(table_list[listBox1.FindString(checkedListBox1.SelectedItem.ToString())], ".", field_list[listBox1.FindString(checkedListBox1.SelectedItem.ToString())], " ");
                string tmp_string2 = checkedListBox1.SelectedItem.ToString();

                int count = 0;
                foreach (var field in fields)
                {
                    if (field.Contains($"{table_list[checkedListBox1.SelectedIndex]}."))
                        count += 1;
                }
                if (count == 1)
                    from.Remove($"{table_list[checkedListBox1.SelectedIndex]} ");

                listBox2.Items.Remove(checkedListBox1.SelectedItem);

                if (checkedListBox2.Items.Contains(checkedListBox1.SelectedItem))
                    checkedListBox2.Items.Remove(checkedListBox1.SelectedItem);

                checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);

                fields.Remove(tmp_string);
                fields_translate.Remove(tmp_string2);

            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var elem in listBox2.Items)
            {
                if (checkedListBox2.Items.Contains(elem))
                    checkedListBox2.Items.Remove(elem);
            }

            checkedListBox1.Items.Clear();
            listBox2.Items.Clear();

            fields.Clear();
            fields_translate.Clear();
            from.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int k = 0;
                foreach (var elem in listBox1.Items)
                {
                    if (!from.Contains($"{table_list[k]} "))
                        from.Add($"{table_list[k]} ");

                    if (!checkedListBox1.Items.Contains(elem))
                    {
                        checkedListBox1.Items.Add(elem);
                        listBox2.Items.Add(elem);

                        fields.Add($"{table_list[k]}.{field_list[k]} ");
                        fields_translate.Add(elem.ToString());
                    }

                    k++;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при переносе элемента");
            }
        }

        private void fieldNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
            npgsql.Open();

            var sql = @"select field_type, field_name, table_name from meta where ""Translate""  = @name;";

            var cmd = new NpgsqlCommand(sql, npgsql);
            cmd.Parameters.AddWithValue("@name", fieldNameBox.Text);

            using var dr = cmd.ExecuteReader();
            string field_type = "";
            while (dr.Read())
            {
                field_type = dr["field_type"].ToString();
                field_name = dr["field_name"].ToString();
                table_name = dr["table_name"].ToString();
            }

            if (field_type == "D" || field_type == "I")
            {
                criterionBox.Items.Clear();
                criterionBox.Items.Add(">");
                criterionBox.Items.Add("<");
                criterionBox.Items.Add("=");
                criterionBox.Items.Add(">=");
                criterionBox.Items.Add("<=");
            }
            else
            {
                criterionBox.Items.Clear();
                criterionBox.Items.Add("=");
            }
        }

        private void criterionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = string.Format("SELECT {0} FROM {1}", field_name, table_name);
                var cmd = new NpgsqlCommand(sql, npgsql);

                using var dr = cmd.ExecuteReader();
                expressionBox.Items.Clear();
                while (dr.Read())
                {
                    expressionBox.Items.Add(dr[0]);
                }
            }
            catch
            {
                MessageBox.Show("(");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = new ListViewItem(new string[] { fieldNameBox.Text, criterionBox.Text, expressionBox.Text, linkBox.Text });
            bool flag = true;
            foreach (ListViewItem elem in listView1.Items)
            {
                if ((elem.SubItems[0].Text == listViewItem.SubItems[0].Text &&
                      elem.SubItems[1].Text == listViewItem.SubItems[1].Text &&
                      elem.SubItems[2].Text == listViewItem.SubItems[2].Text &&
                      elem.SubItems[3].Text == listViewItem.SubItems[3].Text))
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                listView1.Items.Add(listViewItem);


                if (fieldNameBox.SelectedIndex == 1 || fieldNameBox.SelectedIndex == 3 || fieldNameBox.SelectedIndex == 5 || fieldNameBox.SelectedIndex == 6)
                {
                    if (linkBox.Text == "И")
                        condition_string.Add($" {table_list[fieldNameBox.SelectedIndex]}.{field_list[fieldNameBox.SelectedIndex]} {criterionBox.Text} '{expressionBox.Text}' AND ");
                    if (linkBox.Text == "Или")
                        condition_string.Add($" {table_list[fieldNameBox.SelectedIndex]}.{field_list[fieldNameBox.SelectedIndex]} {criterionBox.Text} '{expressionBox.Text}' OR ");
                    if (linkBox.Text == "")
                        condition_string.Add($" {table_list[fieldNameBox.SelectedIndex]}.{field_list[fieldNameBox.SelectedIndex]} {criterionBox.Text} '{expressionBox.Text}'  ");
                    if (!from.Contains($"{table_list[fieldNameBox.SelectedIndex]} "))
                        from.Add($"{table_list[fieldNameBox.SelectedIndex]} ");
                }
                if (fieldNameBox.SelectedIndex == 0)
                {
                    if (linkBox.Text == "И")
                        condition_string.Add($" {table_list[fieldNameBox.SelectedIndex]}.{field_list[fieldNameBox.SelectedIndex]} {criterionBox.Text} {expressionBox.Text.Replace(',', '.')} AND ");
                    if (linkBox.Text == "Или")
                        condition_string.Add($" {table_list[fieldNameBox.SelectedIndex]}.{field_list[fieldNameBox.SelectedIndex]} {criterionBox.Text} {expressionBox.Text.Replace(',', '.')} OR ");
                    if (linkBox.Text == "")
                        condition_string.Add($" {table_list[fieldNameBox.SelectedIndex]}.{field_list[fieldNameBox.SelectedIndex]} {criterionBox.Text} {expressionBox.Text.Replace(',', '.')}  ");
                    if (!from.Contains($"{table_list[fieldNameBox.SelectedIndex]} "))
                        from.Add($"{table_list[fieldNameBox.SelectedIndex]} ");
                }
                if (fieldNameBox.SelectedIndex == 2 || fieldNameBox.SelectedIndex == 4 || fieldNameBox.SelectedIndex == 7)
                {
                    if (linkBox.Text == "И")
                        condition_string.Add($" {table_list[fieldNameBox.SelectedIndex]}.{field_list[fieldNameBox.SelectedIndex]} {criterionBox.Text} {expressionBox.Text} AND ");
                    if (linkBox.Text == "Или")
                        condition_string.Add($" {table_list[fieldNameBox.SelectedIndex]}.{field_list[fieldNameBox.SelectedIndex]} {criterionBox.Text} {expressionBox.Text} OR ");
                    if (linkBox.Text == "")
                        condition_string.Add($" {table_list[fieldNameBox.SelectedIndex]}.{field_list[fieldNameBox.SelectedIndex]} {criterionBox.Text} {expressionBox.Text}  ");
                    if (!from.Contains($"{table_list[fieldNameBox.SelectedIndex]} "))
                        from.Add($"{table_list[fieldNameBox.SelectedIndex]} ");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection collection = listView1.SelectedIndices;
            if (collection.Count != 0)
            {
                string s = "";
                string temp = "";
                string s1 = listView1.SelectedItems[0].SubItems[2].Text;
                string s2 = field_list[listBox1.Items.IndexOf(listView1.SelectedItems[0].SubItems[0].Text)];
                if (listView1.SelectedItems[0].SubItems[3].Text == "И")
                    s = "AND";
                if (listView1.SelectedItems[0].SubItems[3].Text == "Или")
                    s = "OR";
                if (listView1.SelectedItems[0].SubItems[3].Text == " ")
                    s = "";
                if (listView1.SelectedItems[0].SubItems[0].Text == "Оценка ресторана")
                    s1 = s1.Replace(',', '.');
                if (s2 == "fio" || s2 == "address" || s2 == "restaurant_name" || s2 == "city_name")
                {
                    temp = $" {table_list[listBox1.Items.IndexOf(listView1.SelectedItems[0].SubItems[0].Text)]}.{s2}" +
                                  $" {listView1.SelectedItems[0].SubItems[1].Text} '{s1}'" +
                                  $" {s} ";
                }
                else
                {
                    temp = $" {table_list[listBox1.Items.IndexOf(listView1.SelectedItems[0].SubItems[0].Text)]}.{s2}" +
                                  $" {listView1.SelectedItems[0].SubItems[1].Text} {s1}" +
                                  $" {s} ";
                }

                foreach (string elem in condition_string)
                {
                    bool f = true;

                    if (elem.Contains($"{table_list[listBox1.Items.IndexOf(listView1.SelectedItems[0].SubItems[0].Text)]}."))
                        f = false;

                    if (f)
                        from.Remove($"{table_list[listBox1.Items.IndexOf(listView1.SelectedItems[0].SubItems[0].Text)]} ");
                }

                condition_string.Remove(temp);


                listView1.Items.RemoveAt(collection[0]);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkedListBox2.Items.Contains(listBox2.SelectedItem))
                {
                    checkedListBox2.Items.Add(listBox2.SelectedItem);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при переносе элемента");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string temp_string = fields[fields_translate.IndexOf(checkedListBox2.SelectedItem.ToString())];

            for (int i = 0; i < order_list.Count; i++)
            {
                if (order_list[i].Contains($"{temp_string} ASC"))
                {
                    order_list.Remove($"{temp_string} ASC");
                }
                else if (order_list[i].Contains($"{temp_string} DESC"))
                {
                    order_list.Remove($"{temp_string} DESC");
                }
            }

            checkedListBox2.Items.Remove(checkedListBox2.SelectedItem);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var elem in listBox2.Items)
                {
                    if (!checkedListBox2.Items.Contains(elem))
                        checkedListBox2.Items.Add(elem);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при переносе элемента");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            checkedListBox2.Items.Clear();
            order_list.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            nonStandartSQL = "";
            if (fields.Count >= 1)
                nonStandartSQL += "SELECT ";
            for (int i = 0; i < fields.Count; i++)
            {
                nonStandartSQL += fields[i];
                if (i < fields.Count - 1)
                {
                    nonStandartSQL += ", ";
                }
            }

            if (fields.Count >= 1)
                nonStandartSQL += " FROM ";

            for (int i = 0; i < from.Count; i++)
            {
                nonStandartSQL += from[i];
                if (i < from.Count - 1)
                {
                    nonStandartSQL += ", ";
                }
            }

            if (!from.Contains("branches ") && from.Count > 1)
                nonStandartSQL += ",branches ";


            if (condition_string.Count >= 1 || from.Count > 1)
                nonStandartSQL += " WHERE ";
            for (int i = 0; i < condition_string.Count; i++)
            {
                nonStandartSQL += condition_string[i];
            }

            if (from.Count > 1)
            {
                using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
                npgsql.Open();

                var sql = "select * from meta2;";

                var cmd = new NpgsqlCommand(sql, npgsql);

                using var dr = cmd.ExecuteReader();
                List<string> relation_string = new List<string>();

                while (dr.Read())
                {
                    if (from.Count > 1 && from.Contains($"{dr.GetString(0)} ") && from.Contains($"{dr.GetString(1)} ") && (dr.GetString(3) == "-") &&
                        !relation_string.Contains(dr.GetString(2)))
                        relation_string.Add(dr.GetString(2));

                    else if (from.Count > 1 && dr.GetString(2).Contains(" and ") && from.Contains($"{dr.GetString(0)} ") && from.Contains($"{dr.GetString(1)} "))
                    {
                        string[] split = dr.GetString(2).Split(" and ");

                        if (!relation_string.Contains(split[0]))
                            relation_string.Add(split[0]);

                        if (!relation_string.Contains(split[1]))
                            relation_string.Add(split[1]);

                    }
                }

                if (from.Count > 1 && condition_string.Count >= 1)
                    nonStandartSQL += " AND ";
                for (int i = 0; i < relation_string.Count; i++)
                {
                    nonStandartSQL += relation_string[i];
                    if (relation_string.Count != 1 && i != relation_string.Count - 1)
                    {
                        nonStandartSQL += " AND ";
                    }
                }
            }

            if (order_list.Count > 0)
            {
                nonStandartSQL += " ORDER BY ";

                for (int i = 0; i < order_list.Count; i++)
                {
                    nonStandartSQL += order_list[i];
                    if (i != order_list.Count - 1)
                        nonStandartSQL += ", ";
                }
            }

            MessageBox.Show(nonStandartSQL);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void executeSQL_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = fields.Count;

            for (int i = 0; i < fields.Count; i++)
            {
                dataGridView1.Columns[i].Name = fields_translate[i];
            }

            using NpgsqlConnection npgsql = new NpgsqlConnection(cn);
            npgsql.Open();

            var cmd = new NpgsqlCommand(nonStandartSQL, npgsql);

            try
            {
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string[] row = new string[fields.Count];
                    for (int i = 0; i < fields.Count; i++)
                    {
                        row[i] = dr[i].ToString();
                    }

                    dataGridView1.Rows.Add(row);
                }

                tabControl1.SelectedTab = tabPage4;
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {
                if (order_list.Contains($"{fields[fields_translate.IndexOf(checkedListBox2.Items[i].ToString())]} DESC"))
                {
                    order_list.Remove($"{fields[fields_translate.IndexOf(checkedListBox2.Items[i].ToString())]} DESC");
                    order_list.Add($"{fields[fields_translate.IndexOf(checkedListBox2.Items[i].ToString())]} ASC");
                }

                else if (!order_list.Contains($"{fields[fields_translate.IndexOf(checkedListBox2.Items[i].ToString())]} ASC"))
                    order_list.Add($"{fields[fields_translate.IndexOf(checkedListBox2.Items[i].ToString())]} ASC");
                
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {
                if (order_list.Contains($"{fields[fields_translate.IndexOf(checkedListBox2.Items[i].ToString())]} ASC"))
                {
                    order_list.Remove($"{fields[fields_translate.IndexOf(checkedListBox2.Items[i].ToString())]} ASC");
                    order_list.Add($"{fields[fields_translate.IndexOf(checkedListBox2.Items[i].ToString())]} DESC");
                }

                else if (!order_list.Contains($"{fields[fields_translate.IndexOf(checkedListBox2.Items[i].ToString())]} DESC"))
                    order_list.Add($"{fields[fields_translate.IndexOf(checkedListBox2.Items[i].ToString())]} DESC");
            }

        }

        private void excelBtn_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Excel.Application();

            app.Visible = true;

            Workbook wb = app.Workbooks.Add();
            Worksheet ws = wb.Worksheets[1];

            for (int i =0; i<dataGridView1.Columns.Count;i++)
            {
                ws.Cells[1, i +1] = fields_translate[i];
            }
            
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j =0; j < dataGridView1.Columns.Count; j++)
                {
                    ws.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }

        }
    }
}