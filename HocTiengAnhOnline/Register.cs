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
    public partial class Register : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public Register()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }

    

        private void btnTroLai_Click_1(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }

        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            string taikhoan = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            string xacnhanmatkhau = txtXacNhanMatKhau.Text;

            if (taikhoan == "" || matkhau == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }

            if (taikhoan != "" && matkhau != "")
            {
                if (xacnhanmatkhau == matkhau)
                {
                    Boolean KiemTraTonTaiTaiKhoan = ct.KiemTraTonTaiTaiKhoan(taikhoan);
                    if (KiemTraTonTaiTaiKhoan == true)
                    {
                        ct.DangKy(taikhoan, matkhau);                        

                        Boolean KiemTraDangKy = ct.KiemTraDangKy(taikhoan, matkhau);
                        if (KiemTraDangKy == true)
                        {
                            MessageBox.Show("Đăng ký thành công!");
                            txtTaiKhoan.Text = "";
                            txtMatKhau.Text = "";
                            txtXacNhanMatKhau.Text = "";

                            // thêm thông tin học viên vào bảng hv huy dz :V                            
                            try
                            {
                                // đk tài khoản thành công thì thêm thông tin mặc định cho học viên
                                string sql = string.Format("insert into HocVien(MaHV, HoTen, NgaySinh, GioiTinh, DiaChi) values('{0}','{1}','1/1/1990', 'Nam', ' ')", taikhoan, taikhoan);
                                ct.ExecuteNonQuery(sql);
                            }
                            catch (Exception ex)
                            {
                                // thêm thất bại khi học viên đã tồn tại nma koSaO :vvvvvvv
                                ex.ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại!");
                            txtTaiKhoan.Text = "";
                            txtMatKhau.Text = "";
                            txtXacNhanMatKhau.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại!");
                        txtTaiKhoan.Text = "";
                        txtMatKhau.Text = "";
                        txtXacNhanMatKhau.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp!");
                    txtMatKhau.Text = "";
                    txtXacNhanMatKhau.Text = "";
                }

            }

        }
    }
}
