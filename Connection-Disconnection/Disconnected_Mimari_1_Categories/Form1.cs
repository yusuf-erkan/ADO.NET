using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Disconnected_Mimari_1_Categories
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        SqlCommand cmd;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urundoldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select CategoryId , CategoryName from Categories", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
            comboBox1.DataSource = dt;

        }

        private void Urundoldur()
        {
            //list view doldur
            listView1.Items.Clear();
            //2.Yöntem
            /*string selectStr = "Select ProductName, UnitPrice, UnitsInStock, UnitPrice*UnitsInstock TotalValue from Products where CategoryID = " + comboBox1.SelectedValue;
            SqlDataAdapter da = new SqlDataAdapter(selectStr, con);*/
           
            SqlDataAdapter da = new SqlDataAdapter("Select ProductName,UnitPrice , UnitsInStock, UnitPrice*UnitsInstock TotalValue from Products where CategoryID = @catid", con);
            da.SelectCommand.Parameters.AddWithValue("@catid", comboBox1.SelectedValue);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem kayit = new ListViewItem();
                kayit.Text = dt.Rows[i]["ProductName"].ToString();
                kayit.SubItems.Add(dt.Rows[i]["UnitPrice"].ToString());
                kayit.SubItems.Add(dt.Rows[i]["UnitsInStock"].ToString());
                kayit.SubItems.Add(dt.Rows[i]["TotalValue"].ToString());
                listView1.Items.Add(kayit);
//------------------------------------------------------------------------------------------------
                /*ListViewItem kayit = new ListViewItem();
                kayit.Text = dt.Rows[i]["ProductName"].ToString();
                kayit.SubItems.Add(dt.Rows[i][1].ToString());
                kayit.SubItems.Add(dt.Rows[i][2].ToString());
                kayit.SubItems.Add(dt.Rows[i][3].ToString());
                listView1.Items.Add(kayit);*/
//------------------------------------------------------------------------------------------------
                /*string[] arr = new string[4]; 
                arr[0] = dt.Rows[i]["ProductName"].ToString();
                arr[1] = dt.Rows[i]["UnitPrice"].ToString();
                arr[2] = dt.Rows[i]["UnitsInStock"].ToString();
                arr[3] = dt.Rows[i]["TotalValue"].ToString();
                ListViewItem itm = new ListViewItem(arr);
                listView1.Items.Add(itm);*/
            }

            dataGridView1.DataSource = dt;
            //dataGridView1.Columns["ProductName"].Visible = false;


        }
    }
}
