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
    public partial class FormSuratJalan : Form
    {
        MySqlConnection Koneksi = new MySqlConnection("server = localhost; uid = root; database = taeyoung");
        DataTable dataTable     = new DataTable();
        public FormSuratJalan()
        {
            InitializeComponent();
        }
            
    }
}
