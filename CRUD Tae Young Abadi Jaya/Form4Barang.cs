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
    public partial class Form4Barang : Form
    {
        MySqlConnection connection = new MySqlConnection("server = localhost; uid = root; database = taeyoung");

        string[] HeaderColumn = new string[] { "ID Barang", "Nama Barang"};

        string[] Kalimat      = new string[2];

        public Form4Barang()
        {
            InitializeComponent();
        }
    
        public void GetValueFromTxt ()
        {
            // Mengisi array Kalimat dengan value dari textbox Txt0 hingga Txt6
            Kalimat[0] = Txt0.Text;
            Kalimat[1] = Txt1.Text;
        }

        public void ClearInformation ()
        {
            Txt1.Text = "";
        }

        public void ClearView ()
        {
            Txt2.Text = "";
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
        }

        public void UnenabledTxtInformation(){
            Txt1.Enabled = false ;
        }
        
        public void RefreshDataGrid (){
            DataGridBarang.Columns.Clear();

            FillDataGridBarang() ;
        }

        public void ChangeFormatQuery (){
            if (string.IsNullOrEmpty(Kalimat [0])) Kalimat [0] = "NULL";
            else                                   Kalimat [0] = "'" + Kalimat [0] + "'";
            if (string.IsNullOrEmpty(Kalimat [1])) Kalimat [1] = "NULL";
            else                                   Kalimat [1] = "'" + Kalimat [1] + "'";
        }

        public void FillDataGridBarang()
        {
            try
            {
                connection.Open();

                string query = "SELECT * FROM Barang";
                MySqlCommand command = new MySqlCommand(query, connection);

                DataTable dataTable = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                DataGridBarang.Columns.Clear();
                DataGridBarang.DataSource = dataTable;
                
                DataGridViewButtonColumn viewButton = new DataGridViewButtonColumn();
                viewButton.HeaderText = "View";
                viewButton.Text = "View";
                viewButton.UseColumnTextForButtonValue = true;
                DataGridBarang.Columns.Add(viewButton);

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
        
        private void Form4Barang_Load(object sender, EventArgs e)
        {
            Txt2.Enabled = false;
            Txt0.Enabled = false;
            FillDataGridBarang();
            //for (int i = 0; i < HeaderColumn.Length; i++)
            //{
            //DataGridBarang.Columns[i].HeaderText = HeaderColumn[i];
            //DataGridBarang.Columns[i].ReadOnly = true;
            //}
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            ClearInformation ();
        }

        public void InsertHistory(string query)
        {
            string insertQuery = "INSERT INTO History (Query_History) VALUES (@query)";
            MySqlCommand command1 = new MySqlCommand(insertQuery, connection);
            command1.Parameters.AddWithValue("@query", query);

            command1.ExecuteNonQuery();
        }

        public void SaveData()
        {
            GetValueFromTxt ();

            connection.Open ();

            string query  = "UPDATE Barang SET Nama_Barang = @nama WHERE ID_Barang = @id";
            string query1 = query;

            using (MySqlCommand command = new MySqlCommand(query, connection)){
                command.Parameters.AddWithValue("@id"      , Kalimat[0]);
                command.Parameters.AddWithValue("@nama"    , string.IsNullOrEmpty(Kalimat[1]) ? (object)DBNull.Value : Kalimat[1]);

                command.ExecuteNonQuery();
            }

            ChangeFormatQuery ();

            using (MySqlCommand command1 = new MySqlCommand(query1, connection)){
                command1.Parameters.AddWithValue("@id"      , Kalimat[0]);
                command1.Parameters.AddWithValue("@nama"    , Kalimat[1]);

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

            Txt2 .Text = Txt1.Text;
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

        private string CreateNewID()
        {
            string lastID = "";
            string query = "SELECT ID_Barang FROM Barang ORDER BY ID_Barang DESC LIMIT 1";
            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lastID = reader["ID_Barang"].ToString();
                }
                reader.Close();
            }
            string newID = "BA0001";
            if (!string.IsNullOrEmpty(lastID))
            {
                int lastNum = int.Parse(lastID.Substring(2));
                newID = "BA" + (lastNum + 1).ToString("D4");
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
            
            string query  = "INSERT INTO Barang (ID_Barang, Nama_Barang) " +
                            "VALUES (@id, NULL)";
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

        private void DataGridBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Mengecek apakah tombol "View" yang di klik
            if (e.ColumnIndex == 2)
            {
                // Menampilkan data pada TextBox sesuai dengan kolom yang dipilih di DataGridBarang
                Txt0 .Text = DataGridBarang.Rows[e.RowIndex].Cells[0].Value.ToString();
                Txt2 .Text = DataGridBarang.Rows[e.RowIndex].Cells[1].Value.ToString();

                EnabledBtnCrud ();
            }
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            Txt1.Text = Txt2.Text;

            EnabledBtnInformation ();
            UnenabledBtnCrud      ();
            EnabledTxtInformation ();

            Btn1.Enabled = false ;
        }

        private void DeleteData()
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    Kalimat [0] = Txt0.Text;

                    // Query SQL untuk menghapus data berdasarkan ID_Barang
                    string query  = "DELETE FROM Barang WHERE ID_Barang = @id";
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
    
        private void Btn6_Click(object sender, EventArgs e)
        {
            ClearView ();
            ClearID   ();

            UnenabledBtnCrud ();
            Btn3.Enabled = true;
        }
    

    }
}
