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

namespace HocTiengAnhOnline
{
    public partial class Login : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public Login()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            Boolean Login = ct.DangNhap(taikhoan, matkhau);
            if (Login == true)
            {
                this.Hide();
                int authority_id = ct.KiemTraQuyenTruyCap(taikhoan, matkhau);
                if (authority_id == 1)
                {
                    AdminHome frm = new AdminHome();
                    frm.ShowDialog();
                }
                if (authority_id == 2)
                {
                    string LuuTaiKhoan = taikhoan;
                    string LuuMatKhau = matkhau;
                    GiaoDienChinh frm = new GiaoDienChinh(LuuTaiKhoan, LuuMatKhau);                    
                    frm.ShowDialog();
                }                   
                this.Show();
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            Register frm = new Register();
            frm.Show();
            this.Hide();
        }

        private void cbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool hienthimatkhau = cbHienThiMatKhau.Checked;
            if (hienthimatkhau == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
    }
}
