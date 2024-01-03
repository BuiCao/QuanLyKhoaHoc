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

namespace HocTiengAnhOnline.QuanLyCauHoi
{
    public partial class ThemCauHoi : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public ThemCauHoi()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowCauHoi();
            tblCauHoi.DataSource = dt;
        }
        private void ThemCauHoics_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mach = txtMaCH.Text;
            string makh = txtMaKH.Text;
            string noidungch = txtNDCH.Text;
            if (mach == "" || makh == "" || noidungch == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.ThemCauHoi(mach, makh, noidungch);
                getData();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaCH.Text="";
            txtMaKH.Text="";
            txtNDCH.Text="";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
