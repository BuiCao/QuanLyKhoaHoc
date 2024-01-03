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

namespace HocTiengAnhOnline.ChiTietKhoaHoc
{
    public partial class ThemChiTietKH : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public ThemChiTietKH()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }

        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowChiTietKhoaHoc();
            tblKhoaHoc.DataSource = dt;
        }

        private void ThemDanhSachChiTietKH_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string makh = txtMaKH.Text;
            string mabg = txtMaBG.Text;
            if (makh == "" || mabg =="" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.ThemChiTietKhoaHoc(makh, mabg);
                getData();
            }
        }
    }
}
