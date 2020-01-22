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
        OleDbConnection con = new OleDbConnection();
        OleDbDataAdapter da = new OleDbDataAdapter();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }
      
        
        private void Form1_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\Tommy\\Desktop\\BAZA.mdb");
            con.Open();
            da = new OleDbDataAdapter("select*from baza", con);
            ds = new DataSet();
            da.Fill(ds);
            bs = new BindingSource(ds, ds.Tables[0].TableName);
            dataGridView1.DataSource = bs;
            con.Close();
        }


        private void refresh(object sender, EventArgs e)
        {
           
           OleDbCommand Ins = new OleDbCommand("INSERT INTO BAZA(field1, field2, field3, field4) VALUES (1, 2, 3, 4)");
            con.Open();
            Ins.ExecuteNonQuery();
            con.Close();
        }
    }
}
