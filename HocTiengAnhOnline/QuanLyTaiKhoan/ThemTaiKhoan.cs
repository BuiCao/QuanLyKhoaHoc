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

namespace HocTiengAnhOnline.QuanLyTaiKhoan
{
    public partial class ThemTaiKhoan : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public ThemTaiKhoan()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowAccount();
            tblKhoaHoc.DataSource = dt;
        }
        private void ThemTaiKhoan_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int authority_id = int.Parse(txtAuthority_id.Text);
            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.ThemAccount(username, password, authority_id);
                getData();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
           txtUsername.Text="";
             txtPassword.Text="";
            txtAuthority_id.Text="";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
