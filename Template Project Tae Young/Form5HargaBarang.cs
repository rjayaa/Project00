using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Template_Project_Tae_Young
{
    public partial class Form5HargaBarang : Form
    {
        MySqlConnection con = new MySqlConnection("server = localhost; uid = root; database = taeyoung");
        DataTable dataTable = new DataTable();
        MySqlCommand cmd;
        MySqlDataReader dr;
       
        public Form5HargaBarang()
        {
            InitializeComponent();
        }
        
        public void DisableInput()
        {
            txtIDPerusahaan.Enabled = false;
            txtIDNamaBarang.Enabled = false;
        }
       
        public void fetchDataPerusahaan()
        {
            string sql = "SELECT * FROM Perusahaan";
            cmd = new MySqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbNamaPerusahaan.Items.Add(dr["Nama_Perusahaan"]);
            }
            con.Close();
        }

        public void fetchDataBarang()
        {
            string sql = "SELECT * FROM Barang";
            cmd = new MySqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbNamaBarang.Items.Add(dr["Nama_Barang"]);
            }
            con.Close();

        }
        private void Form5HargaBarang_Load(object sender, EventArgs e)
        {
            DisableInput();
            fetchDataPerusahaan();
            fetchDataBarang();
        }

        private void cbNamaPerusahaan_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("SELECT * FROM Perusahaan WHERE Nama_Perusahaan=@companyName", con);
            cmd.Parameters.AddWithValue("@companyName", cbNamaPerusahaan.Text);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string temp_Id = dr["ID_Perusahaan"].ToString();

                txtIDPerusahaan.Text = temp_Id;
            }

            con.Close();
        }

        private void cbNamaBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("SELECT * FROM Barang WHERE Nama_Barang=@productName", con);
            cmd.Parameters.AddWithValue("@productName", cbNamaBarang.Text);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string temp_Id = dr["ID_Barang"].ToString();

                txtIDNamaBarang.Text = temp_Id;
            }

            con.Close();
        }
    }
}
