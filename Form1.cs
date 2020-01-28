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


namespace datagridview_and_database
{
    public partial class Form1 : Form
    {
        //

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



       

       

        private string save_string = "INSERT INTO baza(field1, field2, field3, field4) values";

        private string table_name_sql =
            "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE table_type = 'BASE TABLE'";

        private void add_data_from_table_to_dgv(object sender, EventArgs e)
        {
            string temp = con_path_mask + fileName;


            OleDbConnection con = new OleDbConnection(temp);

            con.Open();
            da = new OleDbDataAdapter("select*from test", con);
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);
            dataGridView1.DataSource = bs;
            curr_Row = dataGridView1.Rows.Count-1;
            MessageBox.Show(curr_Row.ToString());
            con.Close();
        } //добавление данных из дб БАЗА в дгв

       
   

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


        private void openfile(object sender, EventArgs e)
        {

            open_db_file_dialog.InitialDirectory = "c:\\";
            open_db_file_dialog.Filter = "db files (*.mdb)|*mdb|ll files (*.*)|*.*";
            open_db_file_dialog.FilterIndex = 2;
            open_db_file_dialog.RestoreDirectory = true;

            if (open_db_file_dialog.ShowDialog() == DialogResult.OK)
            {
                db_path_strings.Items.Add(open_db_file_dialog.FileName);
                button8.Enabled = true;
            }

            
        } //откдываем дб из локальных файлов по пути 

        private void test1(object sender, EventArgs e) => textBox1.Text = curr_Row.ToString(); // тест количества строк с данными в дб

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
            textBox1.Text = curr_Row.ToString();
        } //на самом деле в душе не ебу что оно должно делать, но вроде как при спадении фокуса добавляет строку с переменную со строками

        private void get_column_name(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(con_path_mask + fileName);
            con.Open();
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            con.Close();
            foreach (var item in dataTable.Columns)
            {
                db_tables_cellnames.Items.Add(item.ToString());
            }




           
        } // получаем названия столбцов и закидываем их в секедлистбокс

       

        private void tablenames_from_db(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection(con_path_mask + fileName);
            con.Open();
            DataTable _This_DataBaseTables = con.GetSchema("Tables", new[] { null, null, null, "TABLE" });
            List<String> _This_TableNameList = new List<string>();
            _This_TableNameList.AddRange(from DataRow item in _This_DataBaseTables.Rows select item["TABLE_NAME"].ToString());
            String Result = String.Empty;
            for (var index = 1; index < _This_TableNameList.Count; index++)
            {

                String Data = _This_TableNameList[index];
                db_tables_names.Items.Add(Data);
                Result += Data.ToString() + "\n";
            }

            MessageBox.Show(Result);
            con.Close();
        }
    }
}
