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

namespace CRUD_Tae_Young_Abadi_Jaya
{
    public partial class Form3Perusahaan : Form
    {

        // Global Variabel
        MySqlConnection connection = new MySqlConnection("server = localhost; uid = root; database = taeyoung");

        string[] HeaderColumn = new string[] { "ID Perusahaan", "Nama Perusahaan", "NPWP", "Kontak 1", "Kontak 2", "Domisili", "Alamat" };

        string[] Kalimat      = new string[7];


        public void GetValueFromTxt ()
        {
            // Mengisi array Kalimat dengan value dari textbox Txt0 hingga Txt6
            Kalimat[0] = Txt0.Text;
            Kalimat[1] = Txt1.Text;
            Kalimat[2] = Txt2.Text;
            Kalimat[3] = Txt3.Text;
            Kalimat[4] = Txt4.Text;
            Kalimat[5] = Txt5.Text;
            Kalimat[6] = Txt6.Text;
        }

        public void ClearInformation ()
        {
            Txt1.Text = "";
            Txt2.Text = "";
            Txt3.Text = "";
            Txt4.Text = "";
            Txt5.Text = "";
            Txt6.Text = "";
        }

        public void ClearView ()
        {
            Txt7 .Text = "";
            Txt8 .Text = "";
            Txt9 .Text = "";
            Txt10.Text = "";
            Txt11.Text = "";
            Txt12.Text = "";
        }

        public void ClearID ()
        {
            Txt0.Text = "";
        }

        public void EnabledBtnInformation()
        {
            Btn1.Enabled = true;
            Btn2.Enabled = true;
        }

        public void UnenabledBtnInformation()
        {
            Btn1.Enabled = false;
            Btn2.Enabled = false;
        }

        public void EnabledBtnCrud()
        {
            Btn3.Enabled = true;
            Btn4.Enabled = true;
            Btn5.Enabled = true;
            Btn6.Enabled = true;
        }

        public void UnenabledBtnCrud()
        {
            Btn3.Enabled = false;
            Btn4.Enabled = false;
            Btn5.Enabled = false;
            Btn6.Enabled = false;
        }

        public void EnabledTxtInformation(){
            Txt1.Enabled = true;
            Txt2.Enabled = true;
            Txt3.Enabled = true;
            Txt4.Enabled = true;
            Txt5.Enabled = true;
            Txt6.Enabled = true;
        }

        public void UnenabledTxtInformation(){
            Txt1.Enabled = false ;
            Txt2.Enabled = false ;
            Txt3.Enabled = false ;
            Txt4.Enabled = false ;
            Txt5.Enabled = false ;
            Txt6.Enabled = false ;
        }
        
        public void RefreshDataGrid (){
            DataGridPerusahaan.Columns.Clear();

            FillDataGridPerusahaan() ;
        }

        public void ChangeFormatQuery (){
            if (string.IsNullOrEmpty(Kalimat [0])) Kalimat [0] = "NULL";
            else                                   Kalimat [0] = "'" + Kalimat [0] + "'";
            if (string.IsNullOrEmpty(Kalimat [1])) Kalimat [1] = "NULL";
            else                                   Kalimat [1] = "'" + Kalimat [1] + "'";
            if (string.IsNullOrEmpty(Kalimat [2])) Kalimat [2] = "NULL";
            else                                   Kalimat [2] = "'" + Kalimat [2] + "'";
            if (string.IsNullOrEmpty(Kalimat [3])) Kalimat [3] = "NULL";
            else                                   Kalimat [3] = "'" + Kalimat [3] + "'";
            if (string.IsNullOrEmpty(Kalimat [4])) Kalimat [4] = "NULL";
            else                                   Kalimat [4] = "'" + Kalimat [4] + "'";
            if (string.IsNullOrEmpty(Kalimat [5])) Kalimat [5] = "NULL";
            else                                   Kalimat [5] = "'" + Kalimat [5] + "'";
            if (string.IsNullOrEmpty(Kalimat [6])) Kalimat [6] = "NULL";
            else                                   Kalimat [6] = "'" + Kalimat [6] + "'";

        }

        // Main Windows Form
        public Form3Perusahaan()
        {
            InitializeComponent();
        }

        // Load Database to DataGridView
        public void FillDataGridPerusahaan()
        {
            try
            {
                connection.Open();

                string query = "SELECT ID_Perusahaan, Nama_Perusahaan, NPWP_Perusahaan, Kontak_1_Perusahaan, Kontak_2_Perusahaan, Domisili_Perusahaan, Alamat_Perusahaan FROM Perusahaan";
                MySqlCommand command = new MySqlCommand(query, connection);

                DataTable dataTable = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                DataGridPerusahaan.Columns.Clear();
                DataGridPerusahaan.DataSource = dataTable;
                
                DataGridViewButtonColumn viewButton = new DataGridViewButtonColumn();
                viewButton.HeaderText = "View";
                viewButton.Text = "View";
                viewButton.UseColumnTextForButtonValue = true;
                DataGridPerusahaan.Columns.Add(viewButton);

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
        
        private void Form3Perusahaan_Load(object sender, EventArgs e)
        {
            FillDataGridPerusahaan ();

            for (int i = 0; i < HeaderColumn.Length; i++)
            {
                DataGridPerusahaan.Columns[i].HeaderText = HeaderColumn[i];
                DataGridPerusahaan.Columns[i].ReadOnly = true;
            }
        }
        
        // Function for Button Clear
        private void Btn1_Click(object sender, EventArgs e)
        {
            ClearInformation ();
        }

        // Function for Button Save
        public void SaveData()
        {
            GetValueFromTxt ();

            connection.Open ();

            string query  = "UPDATE Perusahaan SET Nama_Perusahaan = @nama, NPWP_Perusahaan = @npwp, Kontak_1_Perusahaan = @kontak1, Kontak_2_Perusahaan = @kontak2, Domisili_Perusahaan = @domisili, Alamat_Perusahaan = @alamat WHERE ID_Perusahaan = @id";
            string query1 = query;

            using (MySqlCommand command = new MySqlCommand(query, connection)){
                command.Parameters.AddWithValue("@id"      , Kalimat[0]);
                command.Parameters.AddWithValue("@nama"    , string.IsNullOrEmpty(Kalimat[1]) ? (object)DBNull.Value : Kalimat[1]);
                command.Parameters.AddWithValue("@npwp"    , string.IsNullOrEmpty(Kalimat[2]) ? (object)DBNull.Value : Kalimat[2]);
                command.Parameters.AddWithValue("@kontak1" , string.IsNullOrEmpty(Kalimat[3]) ? (object)DBNull.Value : Kalimat[3]);
                command.Parameters.AddWithValue("@kontak2" , string.IsNullOrEmpty(Kalimat[4]) ? (object)DBNull.Value : Kalimat[4]);
                command.Parameters.AddWithValue("@domisili", string.IsNullOrEmpty(Kalimat[5]) ? (object)DBNull.Value : Kalimat[5]);
                command.Parameters.AddWithValue("@alamat"  , string.IsNullOrEmpty(Kalimat[6]) ? (object)DBNull.Value : Kalimat[6]);

                command.ExecuteNonQuery();
            }

            ChangeFormatQuery ();

            using (MySqlCommand command1 = new MySqlCommand(query1, connection)){
                command1.Parameters.AddWithValue("@id"      , Kalimat[0]);
                command1.Parameters.AddWithValue("@nama"    , Kalimat[1]);
                command1.Parameters.AddWithValue("@npwp"    , Kalimat[2]);
                command1.Parameters.AddWithValue("@kontak1" , Kalimat[3]);
                command1.Parameters.AddWithValue("@kontak2" , Kalimat[4]);
                command1.Parameters.AddWithValue("@domisili", Kalimat[5]);
                command1.Parameters.AddWithValue("@alamat"  , Kalimat[6]);

                string HistoryQuery = query1;

                // Replace setiap parameter dengan value-nya
                foreach (MySqlParameter parameter in command1.Parameters)
                {
                    if (parameter.Value == null) HistoryQuery = HistoryQuery.Replace(parameter.ParameterName, "NULL"); 
                    else                         HistoryQuery = HistoryQuery.Replace(parameter.ParameterName, parameter.Value.ToString());
                }

                InsertHistory (HistoryQuery);
            }

            connection.Close();

            Txt7 .Text = Txt1.Text;
            Txt8 .Text = Txt2.Text;
            Txt9 .Text = Txt3.Text;
            Txt10.Text = Txt4.Text;
            Txt11.Text = Txt5.Text;
            Txt12.Text = Txt6.Text;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            SaveData();
            RefreshDataGrid ();

            UnenabledBtnInformation ();
            UnenabledTxtInformation ();

            ClearInformation();
            EnabledBtnCrud();
        }
    
        // Function for Button Insert
        private string CreateNewID()
        {
            string lastID = "";
            string query = "SELECT ID_Perusahaan FROM Perusahaan ORDER BY ID_Perusahaan DESC LIMIT 1";
            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lastID = reader["ID_Perusahaan"].ToString();
                }
                reader.Close();
            }
            string newID = "PE0001";
            if (!string.IsNullOrEmpty(lastID))
            {
                int lastNum = int.Parse(lastID.Substring(2));
                newID = "PE" + (lastNum + 1).ToString("D4");
            }
            return newID;
        }

        public void InsertData()
        {
            // Mengambil ID_Perusahaan terakhir dan menambahkan 1
            string newId = CreateNewID();

            // Koneksi ke database
            connection.Open();

            // Query untuk memasukkan data baru
            
            string query  = "INSERT INTO Perusahaan (ID_Perusahaan, Nama_Perusahaan, NPWP_Perusahaan, Kontak_1_Perusahaan, Kontak_2_Perusahaan, Domisili_Perusahaan, Alamat_Perusahaan) " +
                            "VALUES (@id, NULL, NULL, NULL, NULL, NULL, NULL)";
            string query1 = query ;

            // Membuat command untuk query
           using(MySqlCommand cmd = new MySqlCommand(query, connection))
           { 
                // Menambahkan parameter ke command
                cmd.Parameters.AddWithValue("@id", newId);

                // Menjalankan query
                cmd.ExecuteNonQuery();

                Kalimat [0] = newId;
           }

            ChangeFormatQuery ();

            using(MySqlCommand command1 = new MySqlCommand(query1, connection))
            {
                command1.Parameters.AddWithValue("@id"      , Kalimat[0]);

                string HistoryQuery = query1;

                // Replace setiap parameter dengan value-nya
                foreach (MySqlParameter parameter in command1.Parameters)
                {
                    if (parameter.Value == null) HistoryQuery = HistoryQuery.Replace(parameter.ParameterName, "NULL"); 
                    else                         HistoryQuery = HistoryQuery.Replace(parameter.ParameterName, parameter.Value.ToString());
                }

                InsertHistory (HistoryQuery);
            }

            // Menutup koneksi
            connection.Close();

            Txt0.Text = newId ;
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            InsertData ();
            RefreshDataGrid ();

            Btn3.Enabled = false ;
            Btn5.Enabled = true  ;

            EnabledBtnInformation ();
            EnabledTxtInformation ();
        }
    
        // Function for Button View
        private void DataGridPerusahaan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Mengecek apakah tombol "View" yang di klik
            if (e.ColumnIndex == 7)
            {
                // Menampilkan data pada TextBox sesuai dengan kolom yang dipilih di DataGridPerusahaan
                Txt0 .Text = DataGridPerusahaan.Rows[e.RowIndex].Cells[0].Value.ToString();
                Txt7 .Text = DataGridPerusahaan.Rows[e.RowIndex].Cells[1].Value.ToString();
                Txt8 .Text = DataGridPerusahaan.Rows[e.RowIndex].Cells[2].Value.ToString();
                Txt9 .Text = DataGridPerusahaan.Rows[e.RowIndex].Cells[3].Value.ToString();
                Txt10.Text = DataGridPerusahaan.Rows[e.RowIndex].Cells[4].Value.ToString();
                Txt11.Text = DataGridPerusahaan.Rows[e.RowIndex].Cells[5].Value.ToString();
                Txt12.Text = DataGridPerusahaan.Rows[e.RowIndex].Cells[6].Value.ToString();

                EnabledBtnCrud ();
            }
        }

        // Function for Button Update
        private void Btn4_Click(object sender, EventArgs e)
        {
            Txt1.Text = Txt7 .Text;
            Txt2.Text = Txt8 .Text;
            Txt3.Text = Txt9 .Text;
            Txt4.Text = Txt10.Text;
            Txt5.Text = Txt11.Text;
            Txt6.Text = Txt12.Text;

            EnabledBtnInformation ();
            UnenabledBtnCrud      ();
            EnabledTxtInformation ();

            Btn1.Enabled = false ;

        }
    
        // Function for Button Delete
        private void DeleteData()
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    Kalimat [0] = Txt0.Text;

                    // Query SQL untuk menghapus data berdasarkan ID_Perusahaan
                    string query  = "DELETE FROM Perusahaan WHERE ID_Perusahaan = @id";
                    string query1 = query;

                    // Membuat objek MySqlCommand untuk menjalankan query
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Mengisi parameter @id dengan nilai dari TextBox "Txt0"
                        cmd.Parameters.AddWithValue("@id", Txt0.Text);

                        // Menjalankan query SQL untuk menghapus data
                        cmd.ExecuteNonQuery();

                        // Menampilkan pesan berhasil ketika data berhasil dihapus
                        MessageBox.Show("Data berhasil dihapus!");

                        ClearView ();
                    }

                    ChangeFormatQuery ();

                    using (MySqlCommand command1 = new MySqlCommand (query1, connection))
                    {
                        command1.Parameters.AddWithValue("@id"      , Kalimat[0]);

                        string HistoryQuery = query1;

                        // Replace setiap parameter dengan value-nya
                        foreach (MySqlParameter parameter in command1.Parameters)
                        {
                            if (parameter.Value == null) HistoryQuery = HistoryQuery.Replace(parameter.ParameterName, "NULL"); 
                            else                         HistoryQuery = HistoryQuery.Replace(parameter.ParameterName, parameter.Value.ToString());
                        }

                        InsertHistory (HistoryQuery);
                    }
                }
            }
            catch (Exception ex)
            {
                // Menampilkan pesan error jika terjadi kesalahan
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            DeleteData ();
            RefreshDataGrid ();

            ClearID ();
            ClearInformation();
            ClearView ();

            UnenabledBtnCrud  ();
            Btn3.Enabled = true;
        }

        // Function for Button Cancel
        private void Btn6_Click(object sender, EventArgs e)
        {
            ClearView ();
            ClearID   ();

            UnenabledBtnCrud ();
            Btn3.Enabled = true;
        }

        // Function for Table History 
        public void InsertHistory(string query)
        {
            string insertQuery = "INSERT INTO History (Query_History) VALUES (@query)";
            MySqlCommand command1 = new MySqlCommand(insertQuery, connection);
            command1.Parameters.AddWithValue("@query", query);

            command1.ExecuteNonQuery();
        }

        //Exit
        private void button5_Click(object sender, EventArgs e){
        }
    }
}
