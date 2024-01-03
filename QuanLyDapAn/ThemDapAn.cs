using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HocTiengAnhOnline.QuanLyDapAn
{
    public partial class ThemDapAn : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public ThemDapAn()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowDapAn();
            tblDapAn.DataSource = dt;
        }
        private void ThemDapAn_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mada = txtMaDA.Text;
            string noidungda = txtNDDA.Text;
            if (mada == "" || noidungda == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.ThemDapAn(mada, noidungda);
                getData();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaDA.Text = "";
            txtNDDA.Text = "";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
