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
       

        public Form1()
        {
            InitializeComponent();
        }

        private string fileName = "C:\\Users\\Tommy\\Desktop\\BAZA.mdb";

        private string con_path_mask = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=";




        OleDbDataAdapter da = new OleDbDataAdapter();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();


        int curr_Row = int.MaxValue;

        private string save_string = "INSERT INTO baza(field1, field2, field3, field4) values";



        private void Form1_Load(object sender, EventArgs e)
        {
            string temp = con_path_mask + fileName;


            OleDbConnection con = new OleDbConnection(temp);

            con.Open();
            da = new OleDbDataAdapter("select*from baza", con);
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);
            dataGridView1.DataSource = bs;
            curr_Row = dataGridView1.Rows.Count;
            MessageBox.Show(curr_Row.ToString());
            con.Close();
        } //добавление данных из дб БАЗА в дгв

       
        private void test(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(con_path_mask + fileName);
            string temp = save_string + "(1, 2, 3, 6)";
            OleDbCommand Ins = new OleDbCommand(save_string, con);
            con.Open();
            Ins.ExecuteNonQuery();
            con.Close();
        } //добавление тестовой строки

        private void update_dgv(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(con_path_mask + fileName);

            OleDbCommand refresh = new OleDbCommand("select*from baza", con);
            
            dataGridView1.DataSource = null;
            con.Open();
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);
            dataGridView1.DataSource = bs;
            con.Close();
        } //обновление дгв

        private void save_data_to_db(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(con_path_mask + fileName);

            if (dataGridView1.Rows[curr_Row].Cells[1] == null &&
                dataGridView1.Rows[curr_Row].Cells[2] == null &&
                 dataGridView1.Rows[curr_Row].Cells[3] == null &&
                  dataGridView1.Rows[curr_Row].Cells[4] == null )
            {
                return;
            }
           
            else
            {
                string temp = save_string + "('"+ dataGridView1.Rows[curr_Row].Cells[1]+"', 2, 3, test)";
                OleDbCommand save = new OleDbCommand(temp, con);
                con.Open();
                save.ExecuteNonQuery();
                con.Close();
            }
        } //сейв в дб

        private void openfile(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "db files (*.mdb)|*mdb|ll files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }

            MessageBox.Show(fileName);
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
                checkedListBox1.Items.Add(item.ToString());
            }




           
        } // получаем названия столбцов и закидываем их в секедлистбокс
    }
}
