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

namespace HocTiengAnhOnline.ChiTietDeThi
{
    public partial class ThemChiTietDeThi : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public ThemChiTietDeThi()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowChiTietDeThi();
            tblKhoaHoc.DataSource = dt;
        }
        private void ThemChiTietDeThi_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string madt = txtMaDT.Text;
            string mach= txtMaCH.Text;
            if (madt == "" || mach == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.ThemChiTietDeThi(madt, mach);
                getData();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
             txtMaDT.Text="";
             txtMaCH.Text="";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
