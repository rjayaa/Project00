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
    public partial class Form4InsertBarang : Form
    {
        MySqlConnection Koneksi = new MySqlConnection("server = localhost; uid = root; database = taeyoung");
        DataTable dataTable     = new DataTable();

        public Form4InsertBarang()
        {
            InitializeComponent();
        }

        
        public DataTable getDataTable(){
            dataTable.Reset();
            dataTable = new DataTable();

            using(MySqlCommand command = new MySqlCommand("SELECT * FROM Barang", Koneksi))
            {
                Koneksi.Open();
                MySqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
            }
            return dataTable;
        }
        
    
        public void fillData(){
            DataGridBarang1.DataSource=getDataTable();
            DataGridViewButtonColumn colEdit    = new DataGridViewButtonColumn();
            colEdit.UseColumnTextForButtonValue = true                          ;
            colEdit.Text                        = "View"                        ;
            colEdit.Name                        = ""                            ;
            DataGridBarang1.Columns.Add(colEdit);

            DataGridBarang1.Columns[0].ReadOnly = true;
            DataGridBarang1.Columns[1].ReadOnly = true;

            
            Koneksi.Close();
        }
        
        
        private void Form4Barang_Load(object sender, EventArgs e)
        {
            fillData();
        }
        public void InsertData(){
            string tID = LastID();
            string tNama = txtNB.Text;

            Koneksi.Open();
             MySqlCommand Cmd = Koneksi.CreateCommand();
             Cmd.CommandText = "INSERT INTO Barang VALUE (@tID,@tNama)";

             Cmd.Parameters.AddWithValue("@tID", tID);
             Cmd.Parameters.AddWithValue("@tNama", tNama);

            Cmd.ExecuteNonQuery ();
            Koneksi.Close       ();
            
            DataGridBarang1.Columns.Clear();

            dataTable.Clear();
            fillData();
           
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

        private void Form4InsertBarang_Load(object sender, EventArgs e)
        {
            fillData();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
           // EditData();
        }

        public void viewData(){
          
           int selectedRowIndex = DataGridBarang1.CurrentCell.RowIndex;
            
           txtID1.Text   = DataGridBarang1.Rows[selectedRowIndex].Cells[0].Value.ToString();
           txtNB1.Text   = DataGridBarang1.Rows[selectedRowIndex].Cells[1].Value.ToString();
        }

        public void DataGridBarang1_CellClick(object sender, DataGridViewCellEventArgs e){
            if(e.ColumnIndex == 2) viewData();
        }
    }
         
}
