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

        private string fileName = "C:\\";

        private string con_path_mask = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=";

        OleDbDataAdapter da = new OleDbDataAdapter();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();

        int curr_Row = int.MaxValue;

        List<String> TableNameList = new List<string>();
        List<string> Addedtables = new List<string>();
        List<string> Table_cell = new List<string>();


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
                button7.Enabled = true;
                button8.Enabled = true;
                button10.Enabled = true;
            }

            
        } //откдываем дб из локальных файлов по пути 


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
                    db_tables_names.Items.Add(Data);
                    Result += Data.ToString() + "\n";

                }
                con.Close();
            }
           
        } //получаем названия таблиц


        private void push_data_to_dgv(object sender, EventArgs e)
        {
            string temp = con_path_mask + fileName;
            string temp2 = string.Empty;

            OleDbConnection con = new OleDbConnection(temp);

            foreach (var variable in db_tables_names.CheckedItems)
            {
                temp2 = "select ";
                foreach (var table_cell in db_tables_cellnames.CheckedItems)
                {


                    if (table_cell.Equals("----"))
                        break;
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


        private void get_column_name_ver2(object sender, EventArgs e)
        {
            string temp = con_path_mask + fileName;
            string temp_2 = string.Empty;
            OleDbConnection con = new OleDbConnection(temp);
            con.Open();

            db_tables_cellnames.Items.Add("----");

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
                    string addstring =variable + " " + item;
                    Table_cell.Add(addstring);
                }
                
                    db_tables_cellnames.Items.Add("----");

                foreach (var test in Table_cell)
                    MessageBox.Show(test);
            }
        } //получаем названия столбцов


        private void edit_databases(object sender, EventArgs e)
        {

        }


        private string select_command_builder(string a)
        {

            return "a";
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

            ;
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

    }
}
