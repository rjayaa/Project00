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
using static System.Net.Mime.MediaTypeNames;

namespace Template_Project_Tae_Young
{
    public partial class Form4Barang : Form
    {

        MySqlConnection Koneksi = new MySqlConnection("server = localhost; uid = root; database = taeyoung");
        DataTable dataTable     = new DataTable();
        public Form4Barang()
        {
            InitializeComponent();
        }

        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM Barang;", Koneksi))
            {
                Koneksi.Open();
                MySqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
            }

            return dataTable;
        }

        public void fillData(){
            DataGridBarang.DataSource = getDataTable();

            DataGridViewButtonColumn colEdit = new DataGridViewButtonColumn();
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Name = "";
            colEdit.Text = "View";
            colEdit.UseColumnTextForButtonValue= true;
            DataGridBarang.Columns.Add(colEdit);

            DataGridBarang.Columns[0].ReadOnly = true;
            DataGridBarang.Columns[1].ReadOnly = true;
            


            DisableViewInput();
            Koneksi.Close();
        }

        public string LastID()
        {
            Koneksi.Open();

            string Query = "SELECT ID_Barang FROM Barang ORDER BY ID_Barang DESC LIMIT 1;";
            MySqlCommand Cmd = new MySqlCommand(Query, Koneksi);

            string LastID = Convert.ToString(Cmd.ExecuteScalar());
            int IntId = 0;

            if (LastID == "") IntId = 1;
            else
            {
                string subString = LastID.Substring(LastID.Length - 4, 4);
                IntId = Convert.ToInt32(subString) + 1;
            }

            Koneksi.Close();

            string ID = "BD";

            if (IntId < 10) ID = string.Concat(ID, "000", IntId.ToString());
            else if (IntId < 100 && IntId >= 10) ID = string.Concat(ID, "00", IntId.ToString());
            else if (IntId < 1000 && IntId >= 100) ID = string.Concat(ID, "0", IntId.ToString());
            else ID = string.Concat(ID, IntId.ToString());


            return ID;
        }

        public void DisableViewInput()
        {
            txtIDBarang.Enabled = false;
            txtNamaBarang2.Enabled = false;
        }

        public void ClearInsert()
        {
            txtIDBarang.Text = "";
            txtNamaBarang.Text = "";
            txtNamaBarang2.Text = "";
            comboBox.Text = "";
        }

        public void InsertData()
        {
            string txt_0 = LastID();
            string txt_1 = txtNamaBarang.Text;

            Koneksi.Open();

            MySqlCommand cmd = Koneksi.CreateCommand();
            cmd.CommandText = "INSERT INTO Barang Value (@txt_0, @txt_1);";

            cmd.Parameters.AddWithValue("@txt_0", txt_0);
            cmd.Parameters.AddWithValue("@txt_1", txt_1);

            cmd.ExecuteNonQuery();
            Koneksi.Close();

            DataGridBarang.Columns.Clear();

            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void ViewData()
        {
            int selectedRow = DataGridBarang.CurrentCell.RowIndex;

            txtIDBarang.Text     = DataGridBarang.Rows[selectedRow].Cells[0+1].Value.ToString();
            txtNamaBarang.Text   = DataGridBarang.Rows[selectedRow].Cells[1+1].Value.ToString();
            txtNamaBarang2.Text = DataGridBarang.Rows[selectedRow].Cells[1 + 1 ].Value.ToString();
        }

        public void ViewData2()
        {
            int selectedRow = DataGridBarang.CurrentCell.RowIndex;

            txtIDBarang.Text = DataGridBarang.Rows[selectedRow].Cells[0].Value.ToString();
            txtNamaBarang.Text = DataGridBarang.Rows[selectedRow].Cells[1].Value.ToString();
            txtNamaBarang2.Text = DataGridBarang.Rows[selectedRow].Cells[1].Value.ToString();
        }

        public void UpdateData()
        {
            string txt_0 = txtIDBarang.Text;
            string txt_1 = txtNamaBarang.Text;
            string txt_2 = txtNamaBarang2.Text;

            Koneksi.Open();
            MySqlCommand cmd = Koneksi.CreateCommand();
            cmd.CommandText = "UPDATE Barang Set Nama_Barang = @txt_1 WHERE ID_Barang = @txt_0;";

            cmd.Parameters.AddWithValue("@txt_0", txt_0);
            cmd.Parameters.AddWithValue("@txt_1", txt_1);

            cmd.ExecuteNonQuery();
            Koneksi.Close();

            DataGridBarang.Columns.Clear();

            dataTable.Clear();
            fillData();
            ClearInsert();

            txtIDBarang.Text = txt_0;
            txtNamaBarang2.Text = txt_1;
        }

        public void DeletData()
        {
            string txt_0 = txtIDBarang.Text;

            Koneksi.Open();
            MySqlCommand cmd = Koneksi.CreateCommand();
            cmd.CommandText = "DELETE FROM Barang WHERE ID_Barang = @txt_0;";

            cmd.Parameters.AddWithValue("@txt_0", txt_0);

            cmd.ExecuteNonQuery ();
            Koneksi.Close();

            DataGridBarang.Columns.Clear();

            dataTable.Clear();
            fillData();
            ClearInsert();
        }

        public void DisplaySearch()
        {
            Koneksi.Open();
            if(comboBox.Text == "Nama Barang")
            {
                string query = "SELECT ID_Barang, Nama_Barang FROM Barang WHERE Nama_Barang LIKE '" + txtSearch.Text + "%'";
                MySqlCommand cmd = new MySqlCommand(query,Koneksi);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBarang.DataSource = st;
                Koneksi.Close();
            }else if(comboBox.Text == "")
            {
                string query = "SELECT ID_Barang, Nama_Barang FROM Barang WHERE Nama_Barang LIKE '" + txtSearch.Text + "%'";
                MySqlCommand cmd = new MySqlCommand(query, Koneksi);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable st = new DataTable();
                st.Load(reader);
                DataGridBarang.DataSource = st;
                Koneksi.Close();
            }
        }
      

        private void Form4Barang_Load(object sender, EventArgs e)
        {
            fillData();
        }

        private void txtInsert_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplaySearch();
        }

        private void txtUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            DeletData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
        }

        private void DataGridBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 2)
            {
                ViewData2();
            }
        }
        private void DataGridBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewData();
            }

        }

    }
}
