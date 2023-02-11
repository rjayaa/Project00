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
    public partial class Form3CURDbarang : Form
    {
        MySqlConnection conn  = new MySqlConnection("server = localhost; uid = root; database = taeyoung; password=Enyoi321!");
        DataTable dataTable   = new DataTable();

        public Form3CURDbarang()
        {
            InitializeComponent();
        }

        public DataTable getDataTable(){
            dataTable.Reset();
            dataTable = new DataTable();

            using (MySqlCommand command = new MySqlCommand("SELECT * FROM `detail_barang`", conn))
            {
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
            }

            return dataTable;

        }

        public void fillData(){
            DataGridBarang.DataSource = getDataTable();

            DataGridBarang.Columns[0].AutoSizeMode  = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridBarang.Columns[3].AutoSizeMode  = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridBarang.Columns[4].AutoSizeMode  = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridBarang.Columns[5].AutoSizeMode  = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridBarang.Columns[6].AutoSizeMode  = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridBarang.Columns[7].AutoSizeMode  = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridBarang.Columns[8].AutoSizeMode  = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridBarang.Columns[9].AutoSizeMode  = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridBarang.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewButtonColumn colEdit    = new DataGridViewButtonColumn();
            colEdit.UseColumnTextForButtonValue = true                          ;
            colEdit.Text                        = "Edit"                        ;
            colEdit.Name                        = ""                            ;
            DataGridBarang.Columns.Add(colEdit)                                 ;

            DataGridViewButtonColumn colDelete      = new DataGridViewButtonColumn()    ;
            colDelete.UseColumnTextForButtonValue   = true                              ;
            colDelete.Text                          = "Delete"                          ;
            colDelete.Name                          = ""                                ;
            DataGridBarang.Columns.Add(colDelete)                                       ;

            DataGridBarang.Columns[0].ReadOnly  = true;
            DataGridBarang.Columns[1].ReadOnly  = true;
            DataGridBarang.Columns[2].ReadOnly  = true;
            DataGridBarang.Columns[3].ReadOnly  = true;
            DataGridBarang.Columns[4].ReadOnly  = true;
            DataGridBarang.Columns[5].ReadOnly  = true;
            DataGridBarang.Columns[6].ReadOnly  = true;
            DataGridBarang.Columns[7].ReadOnly  = true;
            DataGridBarang.Columns[8].ReadOnly  = true;
            DataGridBarang.Columns[9].ReadOnly  = true;
            DataGridBarang.Columns[10].ReadOnly = true;

            TxtIdBarang.Enabled = false;

            conn.Close();
        }

        private void Form3CURDbarang_Load(object sender, EventArgs e)
        {
            fillData();
            ValuesComboBox();
            LastIdBarang();
        }

        public void ClearTextBox()
        {
            TxtIdBarang.Text        = "";

            Txt1Nama.Text           = "" ;
            Txt2Alias.Text          = "" ;
            Txt3ReqUnit.Text        = "" ;
            Txt4ReqSize.Text        = "" ;
            Txt5BeratKotor.Text     = "" ;
            Txt6BeratBersih.Text    = "" ;
            Txt7Warna.Text          = "" ;
            Txt8UkuranJadi.Text     = "" ;
            Txt9HargaBarang.Text    = "" ;

            TxtKompUnit1.Text       = "" ;
            TxtKompUnit2.Text       = "" ;
            TxtKompUnit3.Text       = "" ;
            TxtKompUnit4.Text       = "" ;
            TxtKompUnit5.Text       = "" ;
            TxtKompUnit6.Text       = "" ;
            TxtKompUnit7.Text       = "" ;
            TxtKompUnit8.Text       = "" ;
            TxtKompUnit9.Text       = "" ;
            TxtKompUnit10.Text      = "" ;

            CbKomponen1 .Items.Clear();
            CbKomponen2 .Items.Clear();
            CbKomponen3 .Items.Clear();
            CbKomponen4 .Items.Clear();
            CbKomponen5 .Items.Clear();
            CbKomponen6 .Items.Clear();
            CbKomponen7 .Items.Clear();
            CbKomponen8 .Items.Clear();
            CbKomponen9 .Items.Clear();
            CbKomponen10.Items.Clear();
        }

        public void ValuesComboBox(){

            string query        = "SELECT Nama_Komponen FROM Komponen ORDER BY Nama_Komponen ASC;"  ;
            MySqlCommand    cmd = new MySqlCommand(query, conn)                                     ;
            MySqlDataReader dr                                                                      ;

            try{
                conn.Open ();
                dr = cmd.ExecuteReader();

                CbKomponen1.Items.Add("");
                CbKomponen2.Items.Add("");
                CbKomponen3.Items.Add("");
                CbKomponen4.Items.Add("");
                CbKomponen5.Items.Add("");
                CbKomponen6.Items.Add("");
                CbKomponen7.Items.Add("");
                CbKomponen8.Items.Add("");
                CbKomponen9.Items.Add("");
                CbKomponen10.Items.Add("");

                while(dr.Read()){
                    string Nama = dr.GetString("Nama_Komponen");

                    CbKomponen1.Items.Add(Nama);
                    CbKomponen2.Items.Add(Nama);
                    CbKomponen3.Items.Add(Nama);
                    CbKomponen4.Items.Add(Nama);
                    CbKomponen5.Items.Add(Nama);
                    CbKomponen6.Items.Add(Nama);
                    CbKomponen7.Items.Add(Nama);
                    CbKomponen8.Items.Add(Nama);
                    CbKomponen9.Items.Add(Nama);
                    CbKomponen10.Items.Add(Nama);
                }
                conn.Close();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        public string LastIdBarang(){
            conn.Open();

            string query = "SELECT ID_Barang FROM Barang ORDER BY ID_Barang DESC LIMIT 1;";
            MySqlCommand    cmd = new MySqlCommand(query, conn) ;

            string LastID = Convert.ToString(cmd.ExecuteScalar());

            int IntId = 0;

            if(LastID == "")
            {
                IntId = 1;
            }
            else
            {
                string subString = LastID.Substring(LastID.Length - 4, 4);
                IntId = Convert.ToInt32(subString) + 1;
               
            }

            

            conn.Close();

            string ID_Barang = "BA";

            if      (IntId < 10)                    ID_Barang = string.Concat(ID_Barang, "000", IntId.ToString());
            else if (IntId < 100 && IntId >= 10)    ID_Barang = string.Concat(ID_Barang, "00", IntId.ToString() );
            else if (IntId < 1000 && IntId >= 100)  ID_Barang = string.Concat(ID_Barang, "0", IntId.ToString()  );
            else                                    ID_Barang = string.Concat(ID_Barang, IntId.ToString()       );
            

            return ID_Barang;

        }

        public string LastIdDetailBarang(){
            conn.Open();

            string query = "SELECT ID_Detail_Barang FROM Barang ORDER BY ID_Detail_Barang DESC LIMIT 1;";
            MySqlCommand    cmd = new MySqlCommand(query, conn) ;

            string LastID = Convert.ToString(cmd.ExecuteScalar());

            int IntId = 0;

            if(LastID == "")
            {
                IntId = 1;
            }
            else
            {
                string subString = LastID.Substring(LastID.Length - 4, 4);
                IntId = Convert.ToInt32(subString) + 1;
               
            }

            conn.Close();

            string ID_Barang = "DB";

            if      (IntId < 10)                    ID_Barang = string.Concat(ID_Barang, "000", IntId.ToString());
            else if (IntId < 100 && IntId >= 10)    ID_Barang = string.Concat(ID_Barang, "00", IntId.ToString() );
            else if (IntId < 1000 && IntId >= 100)  ID_Barang = string.Concat(ID_Barang, "0", IntId.ToString()  );
            else                                    ID_Barang = string.Concat(ID_Barang, IntId.ToString()       );
            

            MessageBox.Show(ID_Barang);
            return ID_Barang;

        }

        public string IDKomponen(string data){
            
            conn.Open();
            string query = "SELECT ID_Komponen FROM Komponen WHERE Nama_Komponen = '" + data + "';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            string IDKomponen = Convert.ToString(cmd.ExecuteScalar());

            conn.Close();
            return IDKomponen ;

        }

        public void InsertTableBarang (string ID_Barang, string ID_Detail_Barang){

            string ID_Komponen1  = IDKomponen(CbKomponen1.GetItemText (CbKomponen1.SelectedItem ));
            string ID_Komponen2  = IDKomponen(CbKomponen2.GetItemText (CbKomponen2.SelectedItem ));
            string ID_Komponen3  = IDKomponen(CbKomponen3.GetItemText (CbKomponen3.SelectedItem ));
            string ID_Komponen4  = IDKomponen(CbKomponen4.GetItemText (CbKomponen4.SelectedItem ));
            string ID_Komponen5  = IDKomponen(CbKomponen5.GetItemText (CbKomponen5.SelectedItem ));
            string ID_Komponen6  = IDKomponen(CbKomponen6.GetItemText (CbKomponen6.SelectedItem ));
            string ID_Komponen7  = IDKomponen(CbKomponen7.GetItemText (CbKomponen7.SelectedItem ));
            string ID_Komponen8  = IDKomponen(CbKomponen8.GetItemText (CbKomponen8.SelectedItem ));
            string ID_Komponen9  = IDKomponen(CbKomponen9.GetItemText (CbKomponen9.SelectedItem ));
            string ID_Komponen10 = IDKomponen(CbKomponen10.GetItemText(CbKomponen10.SelectedItem));

            string Unit_Komponen1  = TxtKompUnit1.Text  ;
            string Unit_Komponen2  = TxtKompUnit2.Text  ;
            string Unit_Komponen3  = TxtKompUnit3.Text  ;
            string Unit_Komponen4  = TxtKompUnit4.Text  ;
            string Unit_Komponen5  = TxtKompUnit5.Text  ;
            string Unit_Komponen6  = TxtKompUnit6.Text  ;
            string Unit_Komponen7  = TxtKompUnit7.Text  ;
            string Unit_Komponen8  = TxtKompUnit8.Text  ;
            string Unit_Komponen9  = TxtKompUnit9.Text  ;
            string Unit_Komponen10 = TxtKompUnit10.Text ;

            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Barang VALUE (@ID_Barang, @ID_Detail_Barang, @ID_Komponen1, @ID_Komponen2, @ID_Komponen3, @ID_Komponen4, @ID_Komponen5, @ID_Komponen6, @ID_Komponen7, @ID_Komponen8, @ID_Komponen9, @ID_Komponen10, @Unit_Komponen1, @Unit_Komponen2, @Unit_Komponen3, @Unit_Komponen4, @Unit_Komponen5, @Unit_Komponen6, @Unit_Komponen7, @Unit_Komponen8, @Unit_Komponen9, @Unit_Komponen10)";

            cmd.Parameters.AddWithValue("@ID_Barang"         , ID_Barang        );
            cmd.Parameters.AddWithValue("@ID_Detail_Barang"  , ID_Detail_Barang );

            cmd.Parameters.AddWithValue("@ID_Komponen1", (ID_Komponen1 == "") ? (object)DBNull.Value : ID_Komponen1);
            cmd.Parameters.AddWithValue("@ID_Komponen2", (ID_Komponen2 == "") ? (object)DBNull.Value : ID_Komponen2);
            cmd.Parameters.AddWithValue("@ID_Komponen3", (ID_Komponen3 == "") ? (object)DBNull.Value : ID_Komponen3);
            cmd.Parameters.AddWithValue("@ID_Komponen4", (ID_Komponen4 == "") ? (object)DBNull.Value : ID_Komponen4);
            cmd.Parameters.AddWithValue("@ID_Komponen5", (ID_Komponen5 == "") ? (object)DBNull.Value : ID_Komponen5);
            cmd.Parameters.AddWithValue("@ID_Komponen6", (ID_Komponen6 == "") ? (object)DBNull.Value : ID_Komponen6);
            cmd.Parameters.AddWithValue("@ID_Komponen7", (ID_Komponen7 == "") ? (object)DBNull.Value : ID_Komponen7);
            cmd.Parameters.AddWithValue("@ID_Komponen8", (ID_Komponen8 == "") ? (object)DBNull.Value : ID_Komponen8);
            cmd.Parameters.AddWithValue("@ID_Komponen9", (ID_Komponen9 == "") ? (object)DBNull.Value : ID_Komponen9);
            cmd.Parameters.AddWithValue("@ID_Komponen10", (ID_Komponen10 == "") ? (object)DBNull.Value : ID_Komponen10);

            cmd.Parameters.AddWithValue("@Unit_Komponen1" , Unit_Komponen1 );
            cmd.Parameters.AddWithValue("@Unit_Komponen2" , Unit_Komponen2 );
            cmd.Parameters.AddWithValue("@Unit_Komponen3" , Unit_Komponen3 );
            cmd.Parameters.AddWithValue("@Unit_Komponen4" , Unit_Komponen4 );
            cmd.Parameters.AddWithValue("@Unit_Komponen5" , Unit_Komponen5 );
            cmd.Parameters.AddWithValue("@Unit_Komponen6" , Unit_Komponen6 );
            cmd.Parameters.AddWithValue("@Unit_Komponen7" , Unit_Komponen7 );
            cmd.Parameters.AddWithValue("@Unit_Komponen8" , Unit_Komponen8 );
            cmd.Parameters.AddWithValue("@Unit_Komponen9" , Unit_Komponen9 );
            cmd.Parameters.AddWithValue("@Unit_Komponen10", Unit_Komponen10);
            
            cmd.ExecuteNonQuery ();
            conn.Close          ();

            DataGridBarang.Columns.Clear();

            dataTable.Clear ();
            fillData        ();
            ClearTextBox    ();
        }

        public void InsertTableDetailBarang (string ID_Detail_Barang){
            
            string Nama_Barang          = Txt1Nama.Text         ;
            string Alias_Barang         = Txt2Alias.Text        ;
            int    Req_Unit             = Convert.ToInt32(Txt3ReqUnit.Text      );
            int    Req_Ukuran           = Convert.ToInt32(Txt4ReqSize.Text      );
            int    Harga_Dasar          = Convert.ToInt32(Txt5BeratKotor.Text   );
            int    Berat_Kotor          = Convert.ToInt32(Txt6BeratBersih.Text  );
            int    Berat_Bersih         = Convert.ToInt32(Txt7Warna.Text        );
            string Warna                = Txt8UkuranJadi.Text   ;
            int    Ukuran_Jadi          = Convert.ToInt32(Txt9HargaBarang.Text  );
            int    Total_Harga_Barang   = 15000;

            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Detail_Barang VALUE ( @ID_Detail_Barang, @Nama_Barang, @Alias_Barang, @Req_Unit, @Req_Ukuran, @Harga_Dasar, @Berat_Kotor, @Berat_Bersih, @Warna, @Ukuran_Jadi, @Total_Harga_Barang)";

            cmd.Parameters.AddWithValue("@ID_Detail_Barang"  , ID_Detail_Barang );

            cmd.Parameters.AddWithValue("@Nama_Barang"          , Nama_Barang           );
            cmd.Parameters.AddWithValue("@Alias_Barang"         , Alias_Barang          );
            cmd.Parameters.AddWithValue("@Req_Unit"             , Req_Unit              );
            cmd.Parameters.AddWithValue("@Req_Ukuran"           , Req_Ukuran            );
            cmd.Parameters.AddWithValue("@Harga_Dasar"          , Harga_Dasar           );
            cmd.Parameters.AddWithValue("@Berat_Kotor"          , Berat_Kotor           );
            cmd.Parameters.AddWithValue("@Berat_Bersih"         , Berat_Bersih          );
            cmd.Parameters.AddWithValue("@Warna"                , Warna                 );
            cmd.Parameters.AddWithValue("@Ukuran_Jadi"          , Ukuran_Jadi           );
            cmd.Parameters.AddWithValue("@Total_Harga_Barang"   , Total_Harga_Barang    );
            
            cmd.ExecuteNonQuery ();
            conn.Close          ();

            DataGridBarang.Columns.Clear();

            dataTable.Clear ();
            fillData        ();
            ClearTextBox    ();

        }

        private void BtnSave_Click(object sender, EventArgs e){
            
            string ID_Barang        = LastIdBarang          ();
            string ID_Detail_Barang = LastIdDetailBarang    ();

            InsertTableDetailBarang (ID_Detail_Barang           );
            InsertTableBarang       (ID_Barang, ID_Detail_Barang);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
