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

namespace Connected_Mimari
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(); // Connection intance'ı oluşturulur.
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString; // Connection için path belirlenir. 
                //App.config'deki connection adındaki bağlantının connection string'ini alır.
            }
            catch
            {

                MessageBox.Show("Server'a bağlanılamadı.");

            }

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ProductName , UnitPrice , UnitsInStock FROM Products";
            command.Connection = conn;
            command.CommandTimeout = 15;
            command.CommandType = CommandType.Text;

            conn.Open();

            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                string urunAdi;
                urunAdi = rdr["ProductName"].ToString();
                int fiyat;
                fiyat = Convert.ToInt32(rdr["UnitPrice"]);
                int stock;
                stock = Convert.ToInt32(rdr["UnitsInStock"]);

                String a = urunAdi + "--" + fiyat.ToString() + "--" + stock.ToString();
                listBox1.Items.Add(a);
            }
            conn.Close();

        }

        private void listBox1_DataSourceChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoryForm frm = new CategoryForm();
            frm.Show();
        }
    }
}
