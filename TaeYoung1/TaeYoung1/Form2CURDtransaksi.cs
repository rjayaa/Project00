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

namespace TaeYoung1
{
    public partial class Form2CURDtransaksi : Form
    {
        MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; database = taeyoung; password=Enyoi321!");
        DataTable dataTable  = new DataTable();

        public Form2CURDtransaksi()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form2CURD_Load_1(object sender, EventArgs e)
        {
            fillData();
        }

        public DataTable getDataTable()
        {
            dataTable.Reset();
            dataTable = new DataTable();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM detail_transaksi", conn))
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
            }

            return dataTable;

        }

        public void fillData()
        {
            DataGridPerusahaan.DataSource = getDataTable();

            DataGridPerusahaan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridPerusahaan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridPerusahaan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridPerusahaan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridPerusahaan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridPerusahaan.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridPerusahaan.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridPerusahaan.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridPerusahaan.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewButtonColumn colEdit    = new DataGridViewButtonColumn();
            colEdit.UseColumnTextForButtonValue = true                          ;
            colEdit.Text                        = "Edit"                        ;
            colEdit.Name                        = ""                            ;
            DataGridPerusahaan.Columns.Add(colEdit)                             ;

            DataGridViewButtonColumn colDelete      = new DataGridViewButtonColumn()    ;
            colDelete.UseColumnTextForButtonValue   = true                              ;
            colDelete.Text                          = "Delete"                          ;
            colDelete.Name                          = ""                                ;
            DataGridPerusahaan.Columns.Add(colDelete)                                   ;

            DataGridViewButtonColumn colBarang = new DataGridViewButtonColumn();
            colBarang.UseColumnTextForButtonValue = true;
            colBarang.Text = "Lihat Barang";
            colBarang.Name = "";
            DataGridPerusahaan.Columns.Add(colBarang);

            DataGridPerusahaan.Columns[0].ReadOnly = true; // Kirim Ke Jay
            DataGridPerusahaan.Columns[1].ReadOnly = true;
            DataGridPerusahaan.Columns[2].ReadOnly = true;
            DataGridPerusahaan.Columns[3].ReadOnly = true;
            DataGridPerusahaan.Columns[4].ReadOnly = true;
            DataGridPerusahaan.Columns[5].ReadOnly = true;
            DataGridPerusahaan.Columns[6].ReadOnly = true;
            DataGridPerusahaan.Columns[7].ReadOnly = true;
            DataGridPerusahaan.Columns[8].ReadOnly = true;

            TbDetailTransaksi.Enabled = false;  // Kirim Ke Jay
            TbSuratJalan1    .Enabled = false;
            TbPo1            .Enabled = false;
            TbInvoice1       .Enabled = false;
            TbFakturPajak1   .Enabled = false;
            TbKontrak1       .Enabled = false;
            TbPackingList1   .Enabled = false;
            TbKendaraan1     .Enabled = false;
            TbArticle1       .Enabled = false;
            BtnUpdate        .Enabled = false;

            conn.Close();
        }

        public void ClearTextBoxInsert()
        {
            TxtSuratJalan.Text  = "" ;
            TxtPO.Text          = "" ;
            TxtInvoice.Text     = "" ;
            TxtFakturPajak.Text = "" ;
            TxtKontrak.Text     = "" ;
            TxtPackingList.Text = "" ;
            TxtKendaraan.Text   = "" ;
            TxtArticle.Text     = "" ;
        }

        public void ClearTextBoxUpdate()
        {
            TbDetailTransaksi.Text  = ""; 
            TbSuratJalan1.Text      = "";
            TbPo1.Text              = "";
            TbInvoice1.Text         = "";
            TbFakturPajak1.Text     = "";
            TbKontrak1.Text         = "";
            TbPackingList1.Text     = "";
            TbKendaraan1.Text       = "";
            TbArticle1.Text         = "";
    }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            conn.Open();

            string No_Surat_Jalan   = this.TxtSuratJalan.Text   ;
            string No_PO            = this.TxtPO.Text           ;
            string No_Invoice       = this.TxtInvoice.Text      ;
            string No_Faktur_Pajak  = this.TxtFakturPajak.Text  ;
            string No_Kontrak       = this.TxtKontrak.Text      ;
            string No_Packing_List  = this.TxtPackingList.Text  ;
            string No_Kendaraan     = this.TxtKendaraan.Text    ;
            string Article          = this.TxtArticle.Text      ;


            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Detail_Transaksi ORDER BY id_Detail_Transaksi DESC LIMIT 1;";

            string LastID = Convert.ToString(cmd.ExecuteScalar());

            int IntId = 0;

            if(LastID == null)
            {
                IntId = 1;
            }
            else
            {
                string subString = LastID.Substring(LastID.Length - 4, 4);
                IntId = Convert.ToInt32(subString) + 1;
               
            }

            string ID_Transaksi_Detail = "DT";

            if(IntId < 10)
            {
                ID_Transaksi_Detail = string.Concat(ID_Transaksi_Detail, "000", IntId.ToString());
            }
            else if (IntId < 100 && IntId >= 10)
            {
                ID_Transaksi_Detail = string.Concat(ID_Transaksi_Detail, "00", IntId.ToString());
            }
            else if (IntId < 1000 && IntId >= 100)
            {
                ID_Transaksi_Detail = string.Concat(ID_Transaksi_Detail, "0", IntId.ToString());
            }
            else
            {
                ID_Transaksi_Detail = string.Concat(ID_Transaksi_Detail, IntId.ToString());
            }

            cmd.CommandText = "INSERT INTO detail_transaksi VALUE (@ID_Transaksi_Detail, @No_Surat_Jalan, @No_PO_PWI, @No_Invoice, @No_Faktur_Pajak, @No_Kontrak, @No_Packing_List, @No_Kendaraan, @Article)";

            cmd.Parameters.AddWithValue("@ID_Transaksi_Detail"  , ID_Transaksi_Detail   );
            cmd.Parameters.AddWithValue("@No_Surat_Jalan"       , No_Surat_Jalan        );
            cmd.Parameters.AddWithValue("@No_PO_PWI"            , No_PO                 );
            cmd.Parameters.AddWithValue("@No_Invoice"           , No_Invoice            );
            cmd.Parameters.AddWithValue("@No_Faktur_Pajak"      , No_Faktur_Pajak       );
            cmd.Parameters.AddWithValue("@No_Kontrak"           , No_Kontrak            );
            cmd.Parameters.AddWithValue("@No_Packing_List"      , No_Packing_List       );
            cmd.Parameters.AddWithValue("@No_Kendaraan"         , No_Kendaraan          );
            cmd.Parameters.AddWithValue("@Article"              , Article               );

            cmd.ExecuteNonQuery ();
            conn.Close          ();

            DataGridPerusahaan.Columns.Clear();

            dataTable.Clear ();
            fillData        ();

            ClearTextBoxInsert();
        }

        private void DataGridPerusahaan_CellClick(object sender, DataGridViewCellEventArgs e) //2
        {
            if(e.ColumnIndex == 9)
            {
                TbSuratJalan1    .Enabled = true; 
                TbPo1            .Enabled = true;
                TbInvoice1       .Enabled = true;
                TbFakturPajak1   .Enabled = true;
                TbKontrak1       .Enabled = true;
                TbPackingList1   .Enabled = true;
                TbKendaraan1     .Enabled = true;
                TbArticle1       .Enabled = true;
                BtnUpdate        .Enabled = true;

                int selectedRowIndex    = DataGridPerusahaan.CurrentCell.RowIndex;
                TbDetailTransaksi.Text  = DataGridPerusahaan.Rows[selectedRowIndex].Cells[0].Value.ToString(); 
                TbSuratJalan1.Text      = DataGridPerusahaan.Rows[selectedRowIndex].Cells[1].Value.ToString();
                TbPo1.Text              = DataGridPerusahaan.Rows[selectedRowIndex].Cells[2].Value.ToString();
                TbInvoice1.Text         = DataGridPerusahaan.Rows[selectedRowIndex].Cells[3].Value.ToString();
                TbFakturPajak1.Text     = DataGridPerusahaan.Rows[selectedRowIndex].Cells[4].Value.ToString();
                TbKontrak1.Text         = DataGridPerusahaan.Rows[selectedRowIndex].Cells[5].Value.ToString();
                TbPackingList1.Text     = DataGridPerusahaan.Rows[selectedRowIndex].Cells[6].Value.ToString();
                TbKendaraan1.Text       = DataGridPerusahaan.Rows[selectedRowIndex].Cells[7].Value.ToString();
                TbArticle1.Text         = DataGridPerusahaan.Rows[selectedRowIndex].Cells[8].Value.ToString();

            }

            if(e.ColumnIndex == 10)
            {
                int selectedRowIndex       = DataGridPerusahaan.CurrentCell.RowIndex;
                string ID_Transaksi_Detail = DataGridPerusahaan.Rows[selectedRowIndex].Cells[0].Value.ToString(); 

                MySqlCommand cmd;
                conn.Open();

                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Detail_transaksi WHERE id_detail_transaksi = @id_detail_transaksi";
                cmd.Parameters.AddWithValue("@id_detail_transaksi"  , ID_Transaksi_Detail);

                cmd.ExecuteNonQuery ();
                conn.Close          ();

                DataGridPerusahaan.Columns.Clear();

                dataTable.Clear ();
                fillData        ();
            }

            if (e.ColumnIndex == 11)
            {
                Form3CURDbarang formIns = new Form3CURDbarang();
                formIns.Show();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            conn.Open();

                string ID_Transaksi_Detail = TbDetailTransaksi.Text ;
                string No_Surat_Jalan      = TbSuratJalan1.Text     ;
                string No_PO               = TbPo1.Text             ;            
                string No_Invoice          = TbInvoice1.Text        ;
                string No_Faktur_Pajak     = TbFakturPajak1.Text    ;
                string No_Kontrak          = TbKontrak1.Text        ;
                string No_Packing_List     = TbPackingList1.Text    ;
                string No_Kendaraan        = TbKendaraan1.Text      ;
                string Article             = TbArticle1.Text        ;

                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE detail_transaksi SET No_Surat_Jalan = @No_Surat_Jalan, No_PO_PWI = @No_PO_PWI, No_Invoice = @No_Invoice, No_Faktur_Pajak = @No_Faktur_Pajak, No_Kontrak = @No_Kontrak, No_Packing_List = @No_Packing_List, No_Kendaraan = @No_Kendaraan, Article = @Article WHERE ID_Detail_Transaksi = @ID_Transaksi_Detail";

                cmd.Parameters.AddWithValue("@ID_Transaksi_Detail"  , ID_Transaksi_Detail);
                cmd.Parameters.AddWithValue("@No_Surat_Jalan"       , No_Surat_Jalan        );
                cmd.Parameters.AddWithValue("@No_PO_PWI"            , No_PO                 );
                cmd.Parameters.AddWithValue("@No_Invoice"           , No_Invoice            );
                cmd.Parameters.AddWithValue("@No_Faktur_Pajak"      , No_Faktur_Pajak       );
                cmd.Parameters.AddWithValue("@No_Kontrak"           , No_Kontrak            );
                cmd.Parameters.AddWithValue("@No_Packing_List"      , No_Packing_List       );
                cmd.Parameters.AddWithValue("@No_Kendaraan"         , No_Kendaraan          );
                cmd.Parameters.AddWithValue("@Article"              , Article               );

                cmd.ExecuteNonQuery ();
                conn.Close          ();

                DataGridPerusahaan.Columns.Clear();

                dataTable.Clear ();
                fillData        ();

                ClearTextBoxUpdate();
        }
    }
}
