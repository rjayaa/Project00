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

namespace Apps_CURD
{
    public partial class Form4Barang : Form
    {
        MySqlConnection Koneksi = new MySqlConnection("server = localhost; uid = root; database = taeyoung");
        DataTable dataTable = new DataTable();

        public Form4Barang()
        {
            InitializeComponent();
        }

        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (MySqlCommand command = new MySqlCommand("SELECT barang.ID_Barang, barang.Nama_Barang, perusahaan.ID_Perusahaan, perusahaan.Nama_Perusahaan, Harga_Barang.Harga_Barang FROM Harga_Barang INNER JOIN barang ON Harga_Barang.ID_Barang = barang.ID_Barang INNER JOIN perusahaan ON Harga_Barang.ID_Perusahaan = perusahaan.ID_Perusahaan;;", Koneksi))
            {
                Koneksi.Open();
                MySqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
            }

            return dataTable;
        }

        public void fillData()
        {
            DataGridHargaBarang.DataSource = getDataTable();

            DataGridViewButtonColumn colEdit = new DataGridViewButtonColumn();
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Text = "View";
            colEdit.Name = "";
            DataGridHargaBarang.Columns.Add(colEdit);

            DataGridHargaBarang.Columns[0].ReadOnly = true;
            DataGridHargaBarang.Columns[1].ReadOnly = true;
            DataGridHargaBarang.Columns[2].ReadOnly = true;
            DataGridHargaBarang.Columns[3].ReadOnly = true;
            DataGridHargaBarang.Columns[4].ReadOnly = true;

            Koneksi.Close();
        }

        public void ValuesComboBoxPerusahaan()
        {

            Koneksi.Open();

            string query = "SELECT Nama_Perusahaan, ID_Perusahaan FROM Perusahaan ORDER BY Nama_Perusahaan ASC;";

            MySqlCommand cmd = new MySqlCommand(query, Koneksi);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            Combo1.DataSource = dt;
            Combo1.DisplayMember = "Nama_Perusahaan";
            Combo1.ValueMember = "ID_Perusahaan";
            Combo1.Text = "Select Perusahaan";

            Koneksi.Close();
        }

        private void Combo1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Txt1.Text = Combo1.GetItemText(Combo1.SelectedValue);
        }

        public void ValuesComboBoxBarang()
        {

            string query = "SELECT Nama_Barang FROM Barang ORDER BY Nama_Barang ASC;";
            MySqlCommand cmd = new MySqlCommand(query, Koneksi);
            MySqlDataReader dr;

            try
            {
                Koneksi.Open();
                dr = cmd.ExecuteReader();
                Combo2.Items.Add("");

                while (dr.Read())
                {
                    string Nama = dr.GetString("Nama_Barang");
                    Combo2.Items.Add(Nama);
                }
                Koneksi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form4Barang_Load(object sender, EventArgs e)
        {
            fillData();
            ValuesComboBoxPerusahaan();
            ValuesComboBoxBarang();
        }

        // Insert Harga Barang




    }
}
