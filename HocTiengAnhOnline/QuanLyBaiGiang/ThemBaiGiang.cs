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

namespace HocTiengAnhOnline.QuanLyBaiGiang
{
    public partial class ThemBaiGiang : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public ThemBaiGiang()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowBaiGiang();
            tblKhoaHoc.DataSource = dt;
        }

        private void ThemBaiGiang_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mabg = txtMaBG.Text;
            string tenbg = txtTenBG.Text;
            string noidungbg = txtNDBG.Text;
            if (mabg == "" || tenbg == "" || noidungbg == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.ThemBaiGiang(mabg, tenbg, noidungbg);
                getData();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaBG.Text="";
             txtTenBG.Text="";
            txtNDBG.Text="";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
