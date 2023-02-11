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

        public void NonAktifkan_View ()
        {
            View1ID.Enabled      = false ;
            View2Nama.Enabled    = false ;
            View3Npwp.Enabled    = false ;
            View4Kontak1.Enabled = false ;
            View5Kontak2.Enabled = false ;
            View6Alamat.Enabled  = false ;

            BtnEdit  .Enabled     = false ;
            BtnDelete.Enabled     = false ;
            BtnClearView.Enabled  = false ;
            BtnUpdate.Enabled     = false ;
        }

        public void Aktifkan_View ()
        {
            BtnEdit.Enabled       = true ;
            BtnDelete.Enabled     = true ;
            BtnClearView.Enabled  = true ;
        }

        public void fillData()
        {
            DataGridPerusahaan.DataSource = getDataTable();

            DataGridViewButtonColumn colEdit    = new DataGridViewButtonColumn();
            colEdit.UseColumnTextForButtonValue = true                          ;
            colEdit.Text                        = "View"                        ;
            colEdit.Name                        = ""                            ;
            DataGridPerusahaan.Columns.Add(colEdit)                             ;

            DataGridPerusahaan.Columns[0].ReadOnly  = true;
            DataGridPerusahaan.Columns[1].ReadOnly  = true;
            DataGridPerusahaan.Columns[2].ReadOnly  = true;
            DataGridPerusahaan.Columns[3].ReadOnly  = true;
            DataGridPerusahaan.Columns[4].ReadOnly  = true;
            DataGridPerusahaan.Columns[5].ReadOnly  = true;

            NonAktifkan_View ();

            Koneksi.Close ();
        }

        private void Form3Perusahaan_Load(object sender, EventArgs e)
        {
            fillData();
        }
    
        public void ClearInsert()
        {
            
            Txt1Nama   .Text = "" ;
            Txt2NPWP   .Text = "" ;
            Txt3Kontak1.Text = "" ;
            Txt4Kontak2.Text = "" ;

            Rt1Alamat  .Text = "" ;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ClearInsert();
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

        public void InsertData ()
        {
            string Text_0 = LastID ();
            string Text_1 = Txt1Nama   .Text;
            string Text_2 = Txt2NPWP   .Text;
            string Text_3 = Txt3Kontak1.Text;
            string Text_4 = Txt4Kontak2.Text;
            string Text_5 = Rt1Alamat  .Text;

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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            InsertData ();
        }

        public void ViewData()
        {

            Aktifkan_View ();

            int selectedRowIndex    = DataGridPerusahaan.CurrentCell.RowIndex;

            View1ID.Text      = DataGridPerusahaan.Rows[selectedRowIndex].Cells[0].Value.ToString();
            View2Nama.Text    = DataGridPerusahaan.Rows[selectedRowIndex].Cells[1].Value.ToString();
            View3Npwp.Text    = DataGridPerusahaan.Rows[selectedRowIndex].Cells[2].Value.ToString();
            View4Kontak1.Text = DataGridPerusahaan.Rows[selectedRowIndex].Cells[3].Value.ToString();
            View5Kontak2.Text = DataGridPerusahaan.Rows[selectedRowIndex].Cells[4].Value.ToString();
            View6Alamat.Text  = DataGridPerusahaan.Rows[selectedRowIndex].Cells[5].Value.ToString();

        }

        private void DataGridPerusahaan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6) ViewData ();
        }
    
        public void ClearViewData (){
            NonAktifkan_View ();

            View1ID.Text      = "";
            View2Nama.Text    = "";
            View3Npwp.Text    = "";
            View4Kontak1.Text = "";
            View5Kontak2.Text = "";
            View6Alamat.Text  = "";
        }

        private void BtnClearView_Click(object sender, EventArgs e)
        {
            ClearViewData();
        }
    
        public void DeleteData(){

            string Text_0 = View1ID     .Text ;

            Koneksi.Open();

            MySqlCommand Cmd = Koneksi.CreateCommand();
            Cmd.CommandText  = "DELETE FROM Perusahaan WHERE ID_Perusahaan = @Text_0;";

            Cmd.Parameters.AddWithValue("@Text_0" , Text_0);

            Cmd.ExecuteNonQuery ();
            Koneksi.Close       ();

            DataGridPerusahaan.Columns.Clear();

            dataTable.Clear ();
            fillData        ();
            ClearViewData   ();

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteData ();
        }
    
        public void UpdateData(){
            
            string Text_0 = View1ID    .Text;
            string Text_1 = Txt1Nama   .Text;
            string Text_2 = Txt2NPWP   .Text;
            string Text_3 = Txt3Kontak1.Text;
            string Text_4 = Txt4Kontak2.Text;
            string Text_5 = Rt1Alamat  .Text;

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
            ClearInsert     ();

            View1ID.Text      = Text_0 ;
            View2Nama.Text    = Text_1 ;
            View3Npwp.Text    = Text_2 ;
            View4Kontak1.Text = Text_3 ;
            View5Kontak2.Text = Text_4 ;
            View6Alamat.Text  = Text_5 ;

            BtnUpdate.Enabled = false ;
            BtnClear.Enabled  = true  ;
            BtnSave.Enabled   = true  ;

            Aktifkan_View ();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
    
        public void EditData(){

            Txt1Nama   .Text = View2Nama    .Text ;
            Txt2NPWP   .Text = View3Npwp    .Text ;
            Txt3Kontak1.Text = View4Kontak1 .Text ;
            Txt4Kontak2.Text = View5Kontak2 .Text ;
            Rt1Alamat  .Text = View6Alamat  .Text ;

            BtnClear.Enabled  = false ;
            BtnSave.Enabled   = false ;
            BtnUpdate.Enabled = true  ;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditData();
        }

        
    }
}
