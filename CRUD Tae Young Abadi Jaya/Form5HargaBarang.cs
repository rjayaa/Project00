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
    public partial class Form5HargaBarang : Form
    {   
        MySqlConnection connection = new MySqlConnection("server = localhost; uid = root; database = taeyoung");

        string[] HeaderColumn = new string[] {"ID HargaBarang", "Nama Perusahaan", "Nama Barang", "Harga Barang"};

        public Form5HargaBarang()
        {
            InitializeComponent();
        }

        public void FillComboBoxPerusahaan (){
            connection.Open ();

            string query = "SELECT Nama_Perusahaan, ID_Perusahaan From Perusahaan;";

            using (MySqlCommand command = new MySqlCommand(query, connection)){
                
                MySqlDataAdapter adapter = new MySqlDataAdapter (command) ;

                DataTable dataTable  = new DataTable ();

                adapter.Fill (dataTable) ;

                Combo1.DataSource    =  dataTable          ;
                Combo1.DisplayMember = "Nama_Perusahaan"   ;
                Combo1.ValueMember   = "ID_Perusahaan"     ;
                Combo1.Text          = "Select Perusahaan" ;

            }

            connection.Close ();
        }

        public void FillComboBoxBarang (){
            connection.Open ();

            string query = "SELECT Nama_Barang, ID_Barang From Barang;";

            using (MySqlCommand command = new MySqlCommand(query, connection)){
                
                MySqlDataAdapter adapter = new MySqlDataAdapter (command) ;

                DataTable dataTable  = new DataTable ();

                adapter.Fill (dataTable) ;

                Combo2.DataSource    =  dataTable      ;
                Combo2.DisplayMember = "Nama_Barang"   ;
                Combo2.ValueMember   = "ID_Barang"     ;
                Combo2.Text          = "Select Barang" ;

            }

            connection.Close ();
        }
        
        public void FillDataGridPerusahaan()
        {
            try
            {
                connection.Open();

                string query =  "SELECT Harga_Barang.ID_HargaBarang, Perusahaan.Nama_Perusahaan, Barang.Nama_Barang, Harga_Barang.Harga_Barang " +
                                "FROM Harga_Barang " +
                                "INNER JOIN Barang ON Harga_Barang.ID_Barang = Barang.ID_Barang " +
                                "INNER JOIN Perusahaan ON Harga_Barang.ID_Perusahaan = Perusahaan.ID_Perusahaan";

                MySqlCommand command = new MySqlCommand(query, connection);

                DataTable dataTable = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                DataGridHargaBarang.Columns.Clear();
                DataGridHargaBarang.DataSource = dataTable;
                
                DataGridViewButtonColumn viewButton = new DataGridViewButtonColumn();
                viewButton.HeaderText = "View";
                viewButton.Text = "View";
                viewButton.UseColumnTextForButtonValue = true;
                DataGridHargaBarang.Columns.Add(viewButton);

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

        private void Form5HargaBarang_Load(object sender, EventArgs e)
        {
            FillComboBoxPerusahaan ();
            FillComboBoxBarang     ();
            FillDataGridPerusahaan ();

            for (int i = 0; i < HeaderColumn.Length; i++)
            {
                DataGridHargaBarang.Columns[i].HeaderText = HeaderColumn[i];
                DataGridHargaBarang.Columns[i].ReadOnly = true;
            }
        }

        private void Combo1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Txt0.Text = Combo1.GetItemText(Combo1.SelectedValue);
        }

        private void Combo2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Txt1.Text = Combo2.GetItemText(Combo2.SelectedValue);
        }
    }
}
