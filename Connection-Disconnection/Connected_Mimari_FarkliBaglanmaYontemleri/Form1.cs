using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Connected_Mimari_FarkliBaglanmaYontemleri
{
   
    public partial class Form1 : Form
    {
        SqlConnection conn4;
        SqlConnection conn2 = new SqlConnection();
        SqlConnection conn3 = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (conn4.State == ConnectionState.Closed)
            {
                conn4.Open();
                MessageBox.Show("Bağlantı açıldı.");
            }
            else
            {
                conn4.Close();
                MessageBox.Show("Bağlantı zaten açık. Bu nedenle kapatıldı.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn2.ConnectionString = (@"Data Source=WISSEN\MSSQLSRV;Initial Catalog=Northwind;User ID=sa ; Password = 12345srv"); // Global bağlantı
            
            conn4 = new SqlConnection(); // Connection intance'ı oluşturulur.
            try
            {
                conn4.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString; // Connection için path belirlenir. 
                //App.config'deki connection adındaki bağlantının connection string'ini alır.
            }
            catch
            {

                MessageBox.Show("Server'a bağlanılamadı.");

            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection();
            

            if (conn1.State != ConnectionState.Open)
            {
                conn1.ConnectionString = (@"Server=.;Data Source=WISSEN\MSSQLSRV;Initial Catalog=Northwind;User ID=sa ; Password = 12345srv"); // Lokal bağlantı için instance
                conn1.Open();
                MessageBox.Show("Bağlantı açıldı.");
            }
            else
            {
                conn1.Close();
                MessageBox.Show("Bağlantı zaten açık. Bu nedenle kapatıldı.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (conn2.State != ConnectionState.Open)
            {
                conn2.Open();
                MessageBox.Show("Bağlantı açıldı.");
            }
            else
            {
                conn2.Close();
                MessageBox.Show("Bağlantı zaten açık. Bu nedenle kapatıldı.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (conn3.State != ConnectionState.Open)
            {
                conn3.ConnectionString = Tools.ConnectionString;
                conn3.Open();
                MessageBox.Show("Bağlantı açıldı.");
            }
            else
            {
                conn3.Close();
                MessageBox.Show("Bağlantı zaten açık. Bu nedenle kapatıldı.");
            }

        }
    }
}
