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
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; 
 Data Source=G:\My Project\DB.accdb;";    
        }


        private void refresh(object sender, EventArgs e)
        {
            string uodate_command = "INSERT INTO BAZA() VALUES ()"
            OleDbCommand ref = new OleDbCommand(uodate_command, con );
        }
    }
}
