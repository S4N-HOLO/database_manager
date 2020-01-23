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


namespace datagridview_and_database
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Tommy\\Desktop\\BAZA.mdb");

        OleDbDataAdapter da = new OleDbDataAdapter();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();


        int curr_Row = int.MaxValue;

        string save_string = "INSERT INTO baza(field1, field2, field3, field4) values('','','','')";
        public Form1()
        {
            InitializeComponent();
        }
      
        
        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            da = new OleDbDataAdapter("select*from baza", con);
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);
            dataGridView1.DataSource = bs;
            curr_Row = dataGridView1.Rows.Count - 1;
            MessageBox.Show(curr_Row.ToString());
            con.Close();
        }


        private void refresh(object sender, EventArgs e)
        {
           
           OleDbCommand Ins = new OleDbCommand("INSERT INTO BAZA(field1, field2, field3, field4) VALUES (1, 2, 3, 4)", con);
            con.Open();
            Ins.ExecuteNonQuery();
            con.Close();
        }


        private void update_dgv(object sender, EventArgs e)
        {
            OleDbCommand refresh = new OleDbCommand("select*from baza", con);
            
            dataGridView1.DataSource = null;
            con.Open();
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);
            dataGridView1.DataSource = bs;
            con.Close();
        }

        private void save_data_to_db(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[curr_Row + 1].Cells[1] == null &&
                dataGridView1.Rows[curr_Row + 1].Cells[2] == null &&
                 dataGridView1.Rows[curr_Row + 1].Cells[2] == null &&
                  dataGridView1.Rows[curr_Row + 1].Cells[2] == null)
            {
                return;
            }
            else
            {
                OleDbCommand save = new OleDbCommand(save_string, con);
                con.Open();
                save.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
