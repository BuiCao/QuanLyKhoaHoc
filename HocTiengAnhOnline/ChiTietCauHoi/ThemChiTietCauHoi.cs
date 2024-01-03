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
namespace HocTiengAnhOnline.ChiTietCauHoi
{
    public partial class ThemChiTietCauHoi : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public ThemChiTietCauHoi()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowChiTietCauHoi();
            tblKhoaHoc.DataSource = dt;
        }
        private void ThemChiTietCauHoi_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mach = txtMaCH.Text;
            string mada = txtMaDA.Text;
            int dung = int.Parse(txtDung.Text);
            if (mach == "" || mada == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.ThemChiTietCauHoi(mach, mada, dung);
                getData();
            }
        }
    }
}
