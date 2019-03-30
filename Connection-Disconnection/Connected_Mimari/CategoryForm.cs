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
    public partial class CategoryForm : Form
    {
        SqlConnection conn;
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
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
            command.CommandText = "SELECT CategoryName , Description FROM Categories";
            command.Connection = conn;
            command.CommandTimeout = 15;
            command.CommandType = CommandType.Text;
            conn.Open();

            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                string adi;
                adi = rdr["CategoryName"].ToString();
                string des;
                des = rdr["Description"].ToString();
                
                listBox1.Items.Add(adi +" "+des);
            }
            conn.Close();
        }
    }
}
