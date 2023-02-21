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
using Org.BouncyCastle.Math.Field;

namespace Template_Project_Tae_Young
{
    public partial class Form3Perusahaan : Form
    {
        MySqlConnection Koneksi = new MySqlConnection("server = localhost; uid = root; database = taeyoung");
        DataTable dataTable     = new DataTable();
        public Form3Perusahaan()
        {
            InitializeComponent();
        }

        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM Perusahaan;", Koneksi))
            {
                Koneksi.Open();
                MySqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
            }

            return dataTable;
        }
        public void fillData()
        {
            DataGridPerusahaan.DataSource = getDataTable();

            DataGridViewButtonColumn colEdit    = new DataGridViewButtonColumn();
            colEdit.UseColumnTextForButtonValue = true                          ;
            colEdit.Name = "";
            colEdit.Text                        = "View"                        ;
            DataGridPerusahaan.Columns.Add(colEdit)                             ;
            
            

            DataGridPerusahaan.Columns[0].ReadOnly  = true;
            DataGridPerusahaan.Columns[1].ReadOnly  = true;
            DataGridPerusahaan.Columns[2].ReadOnly  = true;
            DataGridPerusahaan.Columns[3].ReadOnly  = true;
            DataGridPerusahaan.Columns[4].ReadOnly  = true;
            DataGridPerusahaan.Columns[5].ReadOnly  = true;

            DisableViewInput();

            Koneksi.Close ();
        }

        public string LastID()
        {
            Koneksi.Open();

            string       Query = "SELECT ID_Perusahaan FROM Perusahaan ORDER BY ID_Perusahaan DESC LIMIT 1;";
            MySqlCommand Cmd   = new MySqlCommand (Query, Koneksi)                              ;

            string LastID = Convert.ToString (Cmd.ExecuteScalar())  ;
            int    IntId  = 0                                       ;

            if (LastID == "") IntId = 1 ;
            else {
                string subString = LastID.Substring(LastID.Length - 4, 4)   ;
                IntId            = Convert.ToInt32(subString) + 1           ;
            }

            Koneksi.Close();

            string ID = "PE";

            if      (IntId < 10)                    ID = string.Concat(ID, "000",   IntId.ToString());
            else if (IntId < 100 && IntId >= 10)    ID = string.Concat(ID, "00",    IntId.ToString());
            else if (IntId < 1000 && IntId >= 100)  ID = string.Concat(ID, "0",     IntId.ToString());
            else                                    ID = string.Concat(ID,          IntId.ToString());
            

            return ID;
        }

        public void DisableViewInput()
        {
            txtID.Enabled       = false;
            txtNama2.Enabled    = false;
            txtNpwp2.Enabled    = false;
            txtKontakv1.Enabled = false;
            txtKontakv2.Enabled = false;
            txtAlamat2.Enabled  = false;
        }
        public void ClearInsert()
        {
            txtNama.Text    = "";
            txtNpwp.Text    = "";
            txtKontak1.Text = "";
            txtKontak2.Text = "";
            txtAlamat.Text  = "";

            txtID.Text = "";
            txtNama2.Text = "";
            txtNpwp2.Text = "";
            txtKontakv1.Text = "";
            txtKontakv2.Text = "";
            txtAlamat2.Text = "";
            txtSearch.Text = string.Empty;
            comboBox.Text = string.Empty;
        }
        public void InsertData ()
        {
            string Text_0 = LastID ();
            string Text_1 = txtNama.Text;
            string Text_2 = txtNpwp.Text;
            string Text_3 = txtKontak1.Text;
            string Text_4 = txtKontak2.Text;
            string Text_5 = txtAlamat.Text;

            Koneksi.Open();

            MySqlCommand Cmd = Koneksi.CreateCommand();
            Cmd.CommandText  = "INSERT INTO Perusahaan VALUE (@Text_0, @Text_1, @Text_2, @Text_3, @Text_4, @Text_5);";

            Cmd.Parameters.AddWithValue("@Text_0" , Text_0);
            Cmd.Parameters.AddWithValue("@Text_1" , Text_1);
            Cmd.Parameters.AddWithValue("@Text_2" , Text_2);
            Cmd.Parameters.AddWithValue("@Text_3" , Text_3);
            Cmd.Parameters.AddWithValue("@Text_4" , Text_4);
            Cmd.Parameters.AddWithValue("@Text_5" , Text_5);

            Cmd.ExecuteNonQuery ();
            Koneksi.Close       ();

            DataGridPerusahaan.Columns.Clear();

            dataTable.Clear ();
            fillData        ();
            ClearInsert     ();
        }

        public void ViewData(){

            int selectedRow = DataGridPerusahaan.CurrentCell.RowIndex;
            txtNama.Text = DataGridPerusahaan.Rows[selectedRow].Cells[1 + 1].Value.ToString();
            txtNpwp.Text = DataGridPerusahaan.Rows[selectedRow].Cells[2 + 1].Value.ToString();
            txtKontak1.Text = DataGridPerusahaan.Rows[selectedRow].Cells[3 + 1].Value.ToString();
            txtKontak2.Text = DataGridPerusahaan.Rows[selectedRow].Cells[4 + 1].Value.ToString();
            txtAlamat.Text = DataGridPerusahaan.Rows[selectedRow].Cells[5 + 1].Value.ToString();

            txtID.Text = DataGridPerusahaan.Rows[selectedRow].Cells[0 + 1].Value.ToString();
            txtNama2.Text = DataGridPerusahaan.Rows[selectedRow].Cells[1 + 1].Value.ToString();
            txtNpwp2.Text = DataGridPerusahaan.Rows[selectedRow].Cells[2 + 1].Value.ToString();
            txtKontakv1.Text = DataGridPerusahaan.Rows[selectedRow].Cells[3 + 1].Value.ToString();
            txtKontakv2.Text = DataGridPerusahaan.Rows[selectedRow].Cells[4 + 1].Value.ToString();
            txtAlamat2.Text = DataGridPerusahaan.Rows[selectedRow].Cells[5 + 1].Value.ToString();
        }

        public void ViewData2()
        {
            int selectedRow = DataGridPerusahaan.CurrentCell.RowIndex;

            txtNama.Text = DataGridPerusahaan.Rows[selectedRow].Cells[1].Value.ToString();
            txtNpwp.Text = DataGridPerusahaan.Rows[selectedRow].Cells[2].Value.ToString();
            txtKontak1.Text = DataGridPerusahaan.Rows[selectedRow].Cells[3].Value.ToString();
            txtKontak2.Text = DataGridPerusahaan.Rows[selectedRow].Cells[4].Value.ToString();
            txtAlamat.Text = DataGridPerusahaan.Rows[selectedRow].Cells[5].Value.ToString();

            txtID.Text = DataGridPerusahaan.Rows[selectedRow].Cells[0].Value.ToString();
            txtNama2.Text = DataGridPerusahaan.Rows[selectedRow].Cells[1].Value.ToString();
            txtNpwp2.Text = DataGridPerusahaan.Rows[selectedRow].Cells[2].Value.ToString();
            txtKontakv1.Text = DataGridPerusahaan.Rows[selectedRow].Cells[3].Value.ToString();
            txtKontakv2.Text = DataGridPerusahaan.Rows[selectedRow].Cells[4].Value.ToString();
            txtAlamat2.Text = DataGridPerusahaan.Rows[selectedRow].Cells[5].Value.ToString();
        }
        
        public void UpdateData(){

            
            string Text_0 = txtID.Text;
            string Text_1 = txtNama.Text;
            string Text_2 = txtNpwp.Text;
            string Text_3 = txtKontak1.Text;
            string Text_4 = txtKontak2.Text;
            string Text_5 = txtAlamat.Text;

            Koneksi.Open();
            MySqlCommand Cmd = Koneksi.CreateCommand();
            Cmd.CommandText  = "UPDATE Perusahaan SET Nama_Perusahaan = @Text_1, NPWP_Perusahaan = @Text_2, Kontak_1_Perusahaan = @Text_3, Kontak_2_Perusahaan = @Text_4, Alamat_Perusahaan = @Text_5 WHERE Id_Perusahaan = @Text_0 ;";

            Cmd.Parameters.AddWithValue("@Text_0" , Text_0);
            Cmd.Parameters.AddWithValue("@Text_1" , Text_1);
            Cmd.Parameters.AddWithValue("@Text_2" , Text_2);
            Cmd.Parameters.AddWithValue("@Text_3" , Text_3);
            Cmd.Parameters.AddWithValue("@Text_4" , Text_4);
            Cmd.Parameters.AddWithValue("@Text_5" , Text_5);

            Cmd.ExecuteNonQuery ();
            Koneksi.Close       ();

            DataGridPerusahaan.Columns.Clear();

            dataTable.Clear ();
            fillData        ();
            ClearInsert();

            txtID.Text = Text_0;
            txtNama2.Text = Text_1;
            txtNpwp2.Text = Text_2;
            txtKontakv1.Text = Text_3;
            txtKontakv2.Text = Text_4;
            txtAlamat2.Text = Text_5;

        }

        public void DeleteData()
        {
            string Text_0 = txtID.Text;
            Koneksi.Open();

            MySqlCommand Cmd = Koneksi.CreateCommand();
            Cmd.CommandText  = "DELETE FROM Perusahaan WHERE ID_Perusahaan = @Text_0;";

            Cmd.Parameters.AddWithValue("@Text_0" , Text_0);

            Cmd.ExecuteNonQuery ();
            Koneksi.Close       ();

            DataGridPerusahaan.Columns.Clear();

            dataTable.Clear ();
            fillData        ();
            ClearInsert   ();
        }
        public void DisplaySearch()
        {
            Koneksi.Open();
            if (comboBox.Text == "Nama Perusahaan")
            {
                string query = "SELECT ID_Perusahaan, Nama_Perusahaan,NPWP_Perusahaan, Kontak_1_Perusahaan, Kontak_2_Perusahaan, Alamat_Perusahaan FROM Perusahaan WHERE Nama_Perusahaan LIKE '" + txtSearch.Text + "%'";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPerusahaan.DataSource = st;
                Koneksi.Close();

            }
            else if (comboBox.Text == "NPWP")
            {
                string query = "SELECT ID_Perusahaan, Nama_Perusahaan,NPWP_Perusahaan, Kontak_1_Perusahaan, Kontak_2_Perusahaan, Alamat_Perusahaan FROM Perusahaan WHERE NPWP_Perusahaan LIKE '" + txtSearch.Text + "%'";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPerusahaan.DataSource = st;

            }
            else if (comboBox.Text == "Kontak")
            {
                string query = "SELECT ID_Perusahaan, Nama_Perusahaan,NPWP_Perusahaan, Kontak_1_Perusahaan, Kontak_2_Perusahaan, Alamat_Perusahaan FROM Perusahaan WHERE Kontak_1_Perusahaan OR Kontak_2_Perusahaan LIKE '" + txtSearch.Text + "%'";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPerusahaan.DataSource = st;

            }
            else if (comboBox.Text == "Alamat Perusahaan")
            {
                string query = "SELECT ID_Perusahaan, Nama_Perusahaan,NPWP_Perusahaan, Kontak_1_Perusahaan, Kontak_2_Perusahaan, Alamat_Perusahaan FROM Perusahaan WHERE Alamat_Perusahaan LIKE '" + txtSearch.Text + "%'";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridPerusahaan.DataSource = st;

            }
            Koneksi.Close();


        }


        private void Form3Perusahaan_Load(object sender, EventArgs e)
        {
            fillData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            InsertData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
              DisplaySearch();
        }

        private void DataGridPerusahaan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                ViewData2();
            }
        }
        private void DataGridPerusahaan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewData();
            }
        }

    }
}
