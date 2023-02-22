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
        public DataTable getDataTable(){
            dataTable.Reset();
            dataTable = new DataTable();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM Harga_Barang;", con))
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
            }

            return dataTable;
        }

        public void fillData(){
            DataGridHargaBarang.DataSource = getDataTable();

            DataGridViewButtonColumn colEdit = new DataGridViewButtonColumn();
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Name = "";
            colEdit.Text = "View";
            colEdit.UseColumnTextForButtonValue= true;
            DataGridHargaBarang.Columns.Add(colEdit);

            DataGridHargaBarang.Columns[0].ReadOnly = true;
            DataGridHargaBarang.Columns[1].ReadOnly = true;
            DataGridHargaBarang.Columns[2].ReadOnly = true;
            DataGridHargaBarang.Columns[3].ReadOnly = true;

            con.Close();
        }

         
        public void DisableInput(){
            txtIDPerusahaan.Enabled = false;
            txtIDNamaBarang.Enabled = false;
            txtNPView.Enabled       = false;
            txtNBView.Enabled       = false;
            txtHBView.Enabled       = false;
            txtIDView.Enabled       = false;
            txtIDView2.Enabled      = false;
            
        }
       
        public void fetchDataPerusahaan(){
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

        public void fetchDataBarang(){
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
        public string LastID(){
            con.Open();

            string Query = "SELECT ID_HargaBarang FROM Harga_Barang ORDER BY ID_HargaBarang DESC LIMIT 1;";
            MySqlCommand Cmd = new MySqlCommand(Query, con);

            string LastID = Convert.ToString(Cmd.ExecuteScalar());
            int IntId = 0;

            if (LastID == "") IntId = 1;
            else
            {
                string subString = LastID.Substring(LastID.Length - 4, 4);
                IntId = Convert.ToInt32(subString) + 1;
            }

            con.Close();

            string ID = "HB";

            if (IntId < 10) ID = string.Concat(ID, "000", IntId.ToString());
            else if (IntId < 100 && IntId >= 10) ID = string.Concat(ID, "00", IntId.ToString());
            else if (IntId < 1000 && IntId >= 100) ID = string.Concat(ID, "0", IntId.ToString());
            else ID = string.Concat(ID, IntId.ToString());


            return ID;
        }
        
        private void Form5HargaBarang_Load(object sender, EventArgs e){
            DisableInput();
            fillData();
            fetchDataPerusahaan();
            fetchDataBarang();
        }

        public void ClearInsert(){
            cbNamaPerusahaan.Text = "";
            txtIDPerusahaan.Text = "";
            cbNamaBarang.Text   = "";
            txtIDNamaBarang.Text = "";
            nilaiHargaBarang.Text = "";
        }
        public void InsertData(){
            string txt_0 = txtIDNamaBarang.Text;
            string txt_1 = txtIDPerusahaan.Text;
            string txt_2 = LastID();
            string txt_3 = nilaiHargaBarang.Text;

            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Harga_Barang VALUE (@txt_0,@txt_1,@txt_2,@txt_3);";

            cmd.Parameters.AddWithValue("@txt_0",@txt_0);
            cmd.Parameters.AddWithValue("@txt_1",@txt_1);
            cmd.Parameters.AddWithValue("@txt_2",@txt_2);
            cmd.Parameters.AddWithValue("@txt_3",@txt_3);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridHargaBarang.Columns.Clear();

            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void UpdateData(){
            string txt_0 = txtIDPerusahaan.Text;
            string txt_1 = cbNamaPerusahaan.Text;
            string txt_2 = txtIDNamaBarang.Text;
            string txt_3 = cbNamaBarang.Text;
            string txt_4 = nilaiHargaBarang.Text;

            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Harga_Barang Set ID_Barang = @txt_1 WHERE ID_Barang = @txt_0;";

            cmd.Parameters.AddWithValue("@txt_0", txt_0);
            cmd.Parameters.AddWithValue("@txt_1", txt_1);
            cmd.Parameters.AddWithValue("@txt_2", txt_2);
            cmd.Parameters.AddWithValue("@txt_3", txt_3);

            cmd.ExecuteNonQuery();
            con.Close();

            DataGridHargaBarang.Columns.Clear();

            dataTable.Clear();
            fillData();
            ClearInsert();
        }
        public void DeleteData(){
            string txt_0 = txtIDPerusahaan.Text;
            
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Harga_Barang WHERE ID_Barang = @txt_0;";

            cmd.Parameters.AddWithValue("@txt_0", txt_0);

            cmd.ExecuteNonQuery ();
            con.Close();

            DataGridHargaBarang.Columns.Clear();

            dataTable.Clear();
            fillData();
            ClearInsert();
        }



        private void cbNamaPerusahaan_SelectedIndexChanged(object sender, EventArgs e){
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

        private void cbNamaBarang_SelectedIndexChanged(object sender, EventArgs e){
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertData();
        }
    }
}
