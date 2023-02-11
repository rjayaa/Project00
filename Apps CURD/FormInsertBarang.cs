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
    public partial class FormInsertBarang : Form
    {
        MySqlConnection Koneksi = new MySqlConnection("server = localhost; uid = root; database = taeyoung");
        DataTable dataTable     = new DataTable();
        public FormInsertBarang()
        {
            InitializeComponent();
        }

        public DataTable getDataTable(){
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

            DataGridViewButtonColumn colEdit    = new DataGridViewButtonColumn();
            colEdit.UseColumnTextForButtonValue = true                          ;
            colEdit.Text                        = "View"                        ;
            colEdit.Name                        = ""                            ;
            DataGridBarang.Columns.Add(colEdit) ;

            DataGridBarang.Columns[0].ReadOnly  = true;
            DataGridBarang.Columns[1].ReadOnly  = true;

            DisableInsertUpdate();
            Koneksi.Close();
        }

        public void DisableInsertUpdate(){
            txtID1.Enabled  =   false;
            txtNB1.Enabled  =   false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        public void EnableInsertUpdate(){
            txtNB.Enabled       =   false;
            btnSave.Enabled     =   false;
            btnClear.Enabled    =   false;
            txtID1.Enabled      =   false;
            txtNB1.Enabled      =   true;
            btnCancel.Enabled   = true;
            btnDelete.Enabled   = true;
            btnUpdate.Enabled   = true;
        }
        
        public void ClearInsert(){
            txtNB.Text = "";
            txtID1.Text="";
            txtNB1.Text="";
        }
        
        public void ClearInsertv2()
        {
            txtID1.Text = "";
            txtNB1.Text = "";
        }
        public void EnableInsertUpdatev2(){
            txtNB.Enabled       = true;
            btnClear.Enabled    = true;
            btnSave.Enabled     = true;
            ClearInsertv2();

        }
        public void tempAfterInsertUpdate()
        {
            txtNB1.Enabled = true;
            btnCancel.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;

        }

        public void tempAfterDeletion()
        {
            txtNB.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
        }
        private void FormInsertBarang_Load(object sender, EventArgs e)
        {
            fillData();
        }

        public void viewData(){
            EnableInsertUpdate();

            int selectedRowIndex = DataGridBarang.CurrentCell.RowIndex;
            txtID1.Text  = DataGridBarang.Rows[selectedRowIndex].Cells[0].Value.ToString();
            txtNB1.Text  = DataGridBarang.Rows[selectedRowIndex].Cells[1].Value.ToString();
        }
        private void ViewEventHandler(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2) viewData();
        }

        public string LastID()
        {
            Koneksi.Open();

            string       Query = "SELECT ID_Barang FROM Barang ORDER BY ID_Barang DESC LIMIT 1;";
            MySqlCommand Cmd   = new MySqlCommand (Query, Koneksi)                              ;

            string LastID = Convert.ToString (Cmd.ExecuteScalar())  ;
            int    IntId  = 0                                       ;

            if (LastID == "") IntId = 1 ;
            else {
                string subString = LastID.Substring(LastID.Length - 4, 4)   ;
                IntId            = Convert.ToInt32(subString) + 1           ;
            }

            Koneksi.Close();

            string ID = "BA";

            if      (IntId < 10)                    ID = string.Concat(ID, "000",   IntId.ToString());
            else if (IntId < 100 && IntId >= 10)    ID = string.Concat(ID, "00",    IntId.ToString());
            else if (IntId < 1000 && IntId >= 100)  ID = string.Concat(ID, "0",     IntId.ToString());
            else                                    ID = string.Concat(ID,          IntId.ToString());
            

            return ID;
        }

        
        public void InsertData(){
            string temp1 = LastID();
            string temp2 = txtNB.Text;

            Koneksi.Open();

            MySqlCommand Cmd = Koneksi.CreateCommand();
            Cmd.CommandText  = "INSERT INTO Barang VALUE (@temp1,@temp2);";

            Cmd.Parameters.AddWithValue("@temp1" , temp1);
            Cmd.Parameters.AddWithValue("@temp2" , temp2);

            Cmd.ExecuteNonQuery ();
            Koneksi.Close       ();

            DataGridBarang.Columns.Clear();
            dataTable.Clear();
            fillData();
            ClearInsert();

        }

        public void DeleteData(){
            string temp1 = txtID1.Text;
            
            Koneksi.Open();

            MySqlCommand Cmd = Koneksi.CreateCommand();
            Cmd.CommandText  = "DELETE FROM Barang WHERE ID_Barang = @temp1;";

            Cmd.Parameters.AddWithValue("@temp1" , temp1);

            Cmd.ExecuteNonQuery ();
            Koneksi.Close       ();

            DataGridBarang.Columns.Clear();
            dataTable.Clear ();
            fillData        ();
            tempAfterDeletion();
            ClearInsert();
        }
        
        public void UpdateData(){
            string temp1 = txtID1.Text;
            string temp2 = txtNB1.Text;

            Koneksi.Open();

            MySqlCommand Cmd = Koneksi.CreateCommand();
            Cmd.CommandText  = "UPDATE Barang SET Nama_Barang = @temp2 WHERE Id_Barang = @temp1;";
            Cmd.Parameters.AddWithValue("@temp1" , temp1);
            Cmd.Parameters.AddWithValue("@temp2" , temp2);

            Cmd.ExecuteNonQuery ();
            Koneksi.Close       ();

            DataGridBarang.Columns.Clear();

            dataTable.Clear ();
            fillData        ();
            //  ClearInsert     ();

            tempAfterInsertUpdate();
           // ClearInsertv2();
            //EnableInsertUpdatev2();
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableInsertUpdate();
            EnableInsertUpdatev2();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInsert();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}
