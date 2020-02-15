using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.Sql;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Text.RegularExpressions;



namespace datagridview_and_database
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private String fileName = "C:\\";
        private String con_path_mask = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=";


        String push_string = "select";
        String From_collector = String.Empty;
        String conn_mask = String.Empty;
        String insert_command_mask = String.Empty;
        OleDbDataAdapter da = new OleDbDataAdapter();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();

        int curr_Row = int.MaxValue;

        List<String> TableNameList = new List<String>();
        List<String> Addedtables = new List<String>();
        List<String> Table_cell_equals_list = new List<String>();
        List<String> Test = new List<String>();
        Dictionary<String, List<String>> test_dic = new Dictionary<String, List<String>>();


        private void Open_db_dialog_method(object sender, EventArgs e)
        {

            open_db_file_dialog.InitialDirectory = "c:\\";
            open_db_file_dialog.Filter = "db files (*.mdb)|*mdb|ll files (*.*)|*.*";
            open_db_file_dialog.FilterIndex = 2;
            open_db_file_dialog.RestoreDirectory = true;

            if (open_db_file_dialog.ShowDialog() == DialogResult.OK)
            {
                db_path_strings.Items.Add(open_db_file_dialog.FileName);
                fileName = open_db_file_dialog.FileName;
                //button7.Enabled = true;
                //button8.Enabled = true;
                //button10.Enabled = true;
            }


        } //откдываем дб из локальных файлов по пути 
        private void newultramethod_add_data_totree(object sender, EventArgs e)
        {
            foreach (var VARIABLE in db_path_strings.CheckedItems)
            {
                string temp = con_path_mask + fileName;
                string temp_2 = string.Empty;
                OleDbConnection con = new OleDbConnection(con_path_mask + VARIABLE);

                con.Open();
                DataTable DataBaseTables = con.GetSchema("Tables", new[] { null, null, null, "TABLE" });
                TableNameList.AddRange(from DataRow item in DataBaseTables.Rows select item["TABLE_NAME"].ToString());
                String Result = String.Empty;
                for (var index = 0; index < TableNameList.Count; index++)
                {
                    bool finder = false;
                    String Data = TableNameList[index];
                    for (int node_counter = 0; node_counter < treeView1.Nodes.Count; node_counter++)
                    {
                        if (treeView1.Nodes[node_counter].Text.Contains(Data))
                            finder = true;
                    }
                    if (finder)
                        continue;
                    treeView1.Nodes.Add(Data);
                    temp_2 = "select * from " + Data;
                    da = new OleDbDataAdapter(temp_2, con);
                    ds = new DataSet();
                    da.Fill(ds);
                    bs = new BindingSource(ds, ds.Tables[0].TableName);
                    DataTable dataTables = new DataTable();
                    da.Fill(dataTables);
                    foreach (var item in dataTables.Columns)
                    {
                        if (item == null)
                            continue;
                        treeView1.Nodes[index].Nodes.Add(item.ToString());
                    }
                }
                con.Close();
            }
        }
        private void push_data(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(con_path_mask + fileName);

            conn_mask = String.Empty;
            push_string = "select";
            From_collector = String.Empty;
            String a = String.Empty;
            test_dic.Clear();
            for (int counter = 0; counter < treeView1.Nodes.Count; counter++)
            {
                bool added = false;

                foreach (TreeNode checkedNodes in treeView1.Nodes[counter].Nodes)
                {
                    
                    if (checkedNodes.Checked)
                    {
                        conn_mask += " " + treeview_deleter(treeView1.Nodes[counter].ToString()) +
                            "." + treeview_deleter(checkedNodes.ToString()) + ",";
                        //Test.Add(treeview_deleter(checkedNodes.ToString()));
                        if (!added)
                        {
                            From_collector += treeview_deleter(treeView1.Nodes[counter].ToString()) + ", ";
                            a += treeview_deleter(treeView1.Nodes[counter].ToString()) + ", ";
                        }

                        added = true;
                    }

                }
                Test.Add(a);
                //if (!test_dic.ContainsKey(a))
                //    test_dic.Add(a, Test);
                //else
                //    test_dic[a] = Test;
                //Test.Clear();
            }
            //foreach (var x in test_dic.Keys)
            //    MessageBox.Show(x);
            //foreach (var x in test_dic[a])
            //    MessageBox.Show(x);
            if (conn_mask != String.Empty)
            {
                treeView1.CheckBoxes = false;
                
                push_string += conn_mask.Remove(conn_mask.Length - 1) + " from " + From_collector.Remove(From_collector.Length - 2);
                con.Open();

                OleDbCommand select_data = new OleDbCommand(push_string);
                da = new OleDbDataAdapter(push_string, con);
                ds = new DataSet();
                da.Fill(ds);
                bs = new BindingSource(ds, ds.Tables[0].TableName);
                dataGridView1.DataSource = bs;
                curr_Row = dataGridView1.Rows.Count - 1; // считаем количество строк данных

                con.Close();
            }
        }
        private void validate_checkboxes(object sender, EventArgs e) => treeView1.CheckBoxes = true;
        private void update_datatables(object sender, EventArgs e)
        {
            insert_command_mask = "INSERT INTO";

            foreach(var dic in test_dic.Keys)
            {
                foreach (string v in test_dic[dic])
                    MessageBox.Show(v);

            }
    
        }
        private String treeview_deleter(String con_path) {return con_path.Substring(10, con_path.Length - 10);}
        
        /*
         * 
         * 
         * 
         * 
         * НАРАБОТКИ, ПУСТЬ БУДЕТ
         * 
         * 
         * */
        private void aaaaaaaaaaaaaaaaaaaaaaaa(object sender, EventArgs e)
        {

        }
        private void edit_databases(object sender, EventArgs e)
        {

        }
        private string select_command_builder(string a)
        {

            return "a";
        }
        private void treeview_test(object sender, EventArgs e)
        {

        }


        /*
         * 
         * 
         * 
         * 
         * OLD METHODS
         * 
         * 
         * 
         * 
         * */
        private void get_column_name(object sender, EventArgs e)
        {
            db_tables_cellnames.Items.Add("----");
            string temp = con_path_mask + fileName;
            OleDbConnection con = new OleDbConnection(temp);
            con.Open();

            da = new OleDbDataAdapter("select*from Группы", con);
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);

            DataTable dataTables = new DataTable();
            da.Fill(dataTables);
            con.Close();
            foreach (var item in dataTables.Columns)
            {
                db_tables_cellnames.Items.Add(item.ToString());
                db_tables_cellnames.Items.Add("____");
            }
        } // получаем названия столбцов и закидываем их в секедлистбокс
        private void db_path_strings_checked(object sender, EventArgs e)
        {

        } //получаем названия столбцов
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            int temp = curr_Row++;
            if (dataGridView1.Rows[temp].Cells[1] != null &&
                dataGridView1.Rows[temp].Cells[2] != null &&
                dataGridView1.Rows[temp].Cells[3] != null &&
                dataGridView1.Rows[temp].Cells[4] != null)
                curr_Row++;
            else
                MessageBox.Show("ты не заполнил все строки");
            //textBox1.Text = curr_Row.ToString();
        } //на самом деле в душе не ебу что оно должно делать, но вроде как при спадении фокуса добавляет строку с переменную со строками
        private void update_dgv(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(con_path_mask + fileName);

            OleDbCommand refresh = new OleDbCommand("select*from test", con);

            dataGridView1.DataSource = null;
            con.Open();
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);
            dataGridView1.DataSource = bs;
            con.Close();
        } //обновление дгв
        private void add_data_from_table_to_dgv(object sender, EventArgs e)
        {
            string temp = con_path_mask + fileName;


            OleDbConnection con = new OleDbConnection(temp);

            con.Open();
            da = new OleDbDataAdapter("select*from Группы", con);
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);
            dataGridView1.DataSource = bs;
            curr_Row = dataGridView1.Rows.Count - 1;
            MessageBox.Show(curr_Row.ToString());
            con.Close();
        } //добавление данных из дб БАЗА в дгв
        private void test1(object sender, EventArgs e) { }//textBox1.Text = curr_Row.ToString(); // тест количества строк с данными в дб
        private void push_data_to_dgv(object sender, EventArgs e)
        {
            string temp = con_path_mask + fileName;
            string temp2 = string.Empty;
            string pattern = string.Empty;
            //Regex rx = new Regex(pattern); регулярка


            OleDbConnection con = new OleDbConnection(temp);

            foreach (var variable in db_tables_names.CheckedItems)
            {
                temp2 = "select ";

                foreach (var table_cell in db_tables_cellnames.CheckedItems)
                {

                    if (table_cell.Equals("----"))
                        continue;
                    pattern = variable.ToString() + " " + table_cell.ToString();

                    if (!Table_cell_equals_list.Contains(pattern))
                    {
                        continue;
                    }


                    temp2 = temp2 + " " + table_cell + ",";

                }

                int temp_index = temp2.Length - 1;
                temp2 = temp2.Remove(temp_index); // костыль для удаления последней запятой, кек

                temp2 = temp2 + " from " + variable;

                con.Open();
                OleDbCommand select_data = new OleDbCommand(temp2);
                da = new OleDbDataAdapter(temp2, con);
                ds = new DataSet();
                da.Fill(ds);
                bs = new BindingSource(ds, ds.Tables[0].TableName);
                dataGridView1.DataSource = bs;
                curr_Row = dataGridView1.Rows.Count - 1; // считаем количество строк данных
                MessageBox.Show(curr_Row.ToString());
                con.Close();

            }
        } //грузим данные в дгв
        private void push_data_to_dgv_ver2(object sender, EventArgs e)
        {
            string temp = con_path_mask + fileName;
            string temp2 = string.Empty;
            string temp3 = string.Empty;
            string pattern = string.Empty;
            //Regex rx = new Regex(pattern); регулярка


            OleDbConnection con = new OleDbConnection(temp);
            foreach (var variable in db_tables_names.CheckedItems)
            {
                temp2 = "select ";
                temp3 = temp3 + variable + ", ";
                foreach (var table_cell in db_tables_cellnames.CheckedItems)
                {

                    if (table_cell.Equals("----"))
                        continue;
                    pattern = variable.ToString() + "." + table_cell.ToString();
                    if (Table_cell_equals_list.Contains(pattern))
                        if (db_tables_cellnames.CheckedItems.Count == 1)
                            temp2 = temp2 + pattern + "";
                        else if (db_tables_cellnames.CheckedItems.Count > 1)
                            temp2 = temp2 + pattern + ", ";

                }
            }

            // костыль для удаления последней запятой, кек

            temp2 = temp2 + " from " + temp3;
            int temp_index = temp2.Length - 1;
            temp2 = temp2.Remove(temp_index);
            temp_index = temp2.Length - 1;
            temp2 = temp2.Remove(temp_index);

            con.Open();
            OleDbCommand select_data = new OleDbCommand(temp2);
            da = new OleDbDataAdapter(temp2, con);
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);
            dataGridView1.DataSource = bs;
            curr_Row = dataGridView1.Rows.Count - 1; // считаем количество строк данных
            MessageBox.Show(curr_Row.ToString());
            con.Close();

        } //новая версия
        private void get_tablenames(object sender, EventArgs e)
        {
            foreach (var VARIABLE in db_path_strings.CheckedItems)
            {
                OleDbConnection con = new OleDbConnection(con_path_mask + VARIABLE);

                con.Open();

                DataTable DataBaseTables = con.GetSchema("Tables", new[] { null, null, null, "TABLE" });
                TableNameList.AddRange(from DataRow item in DataBaseTables.Rows select item["TABLE_NAME"].ToString());
                String Result = String.Empty;
                for (var index = 0; index < TableNameList.Count; index++)
                {

                    String Data = TableNameList[index];
                    listBox1.Items.Add(Data);
                    db_tables_names.Items.Add(Data);
                    Result += Data.ToString() + "\n";

                }
                con.Close();
            }

        } //получаем названия таблиц
        private void get_column_name_ver2(object sender, EventArgs e)
        {
            string temp = con_path_mask + fileName;
            string temp_2 = string.Empty;
            OleDbConnection con = new OleDbConnection(temp);
            con.Open();

            if (db_tables_cellnames.Items.Count != 0)
            {
                db_tables_cellnames.Items.Add("----");

            } //добавляем разделитель


            foreach (var variable in db_tables_names.CheckedItems)
            {
                if (Addedtables.Contains(variable))
                    continue;


                Addedtables.Add(variable.ToString());


                temp_2 = "select * from " + variable;

                da = new OleDbDataAdapter(temp_2, con);
                ds = new DataSet();
                da.Fill(ds);
                bs = new BindingSource(ds, ds.Tables[0].TableName);

                ;
                DataTable dataTables = new DataTable();
                da.Fill(dataTables);
                con.Close();
                foreach (var item in dataTables.Columns)
                {
                    if (item == null)
                        continue;
                    db_tables_cellnames.Items.Add(item.ToString());
                    string addstring = variable + "." + item;
                    Table_cell_equals_list.Add(addstring);
                }

                db_tables_cellnames.Items.Add("----");

                //foreach (var test in Table_cell)
                //    MessageBox.Show(test); вывод названий для теста
            }
        } //получаем названия столбцов
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            db_tables_cellnames.Items.Clear();

            string temp = con_path_mask + fileName;
            string temp_2 = string.Empty;
            OleDbConnection con = new OleDbConnection(temp);
            con.Open();
            Addedtables.Add(listBox1.SelectedItem.ToString());


            temp_2 = "select * from " + listBox1.SelectedItem;

            da = new OleDbDataAdapter(temp_2, con);
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);

            ;
            DataTable dataTables = new DataTable();
            da.Fill(dataTables);
            con.Close();
            foreach (var item in dataTables.Columns)
            {
                if (item == null)
                    continue;
                db_tables_cellnames.Items.Add(item.ToString());
                //string addstring = variable + "." + item;
                //Table_cell_equals_list.Add(addstring);
            }
        }
        private void push_data_to_dgv_ver3(object sender, EventArgs e)
        {
            string select_cmd = "select";
            string temp = con_path_mask + fileName;
            //da.Dispose();

            OleDbConnection con = new OleDbConnection(temp);

            if (db_tables_cellnames.CheckedItems.Count == 0)
            { MessageBox.Show("выберите столбцы"); }
            else
            {
                foreach (var table_cellname in db_tables_cellnames.CheckedItems)
                {
                    select_cmd += " " + table_cellname + ",";
                }
                int temp_index = select_cmd.Length - 1;
                select_cmd = select_cmd.Remove(temp_index);
                select_cmd = select_cmd + " from " + listBox1.SelectedItem;
                con.Open();
                OleDbCommand select_data = new OleDbCommand(select_cmd);
                da = new OleDbDataAdapter(select_cmd, con);
                ds = new DataSet();
                da.Fill(ds);
                bs = new BindingSource(ds, ds.Tables[0].TableName);
                dataGridView1.DataSource = bs;
                curr_Row = dataGridView1.Rows.Count - 1; // считаем количество строк данных
                MessageBox.Show(curr_Row.ToString());
                con.Close();
            }
        } //super new version

    }
    
}
