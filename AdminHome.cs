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
using HocTiengAnhOnline.QuanLyKhoaHoc;
using HocTiengAnhOnline.QuanLyBaiGiang;
using HocTiengAnhOnline.ChiTietKhoaHoc;
using HocTiengAnhOnline.QuanLyCauHoi;
using HocTiengAnhOnline.QuanLyDapAn;
using HocTiengAnhOnline.ChiTietCauHoi;
using HocTiengAnhOnline.QuanLyDeThi;
using HocTiengAnhOnline.ChiTietDeThi;
using HocTiengAnhOnline.QuanLyTaiKhoan;

namespace HocTiengAnhOnline
{
    public partial class AdminHome : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
      
        public AdminHome()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }


        static int KiemTraTonTai(TabControl TabControlName, string TabName)
        {
            int temp = -1;
            for (int i = 0; i < TabControlName.TabPages.Count; i++)
            {
                if (TabControlName.TabPages[i].Text == TabName)
                {
                    temp = i;
                    break;
                }
            }
            return temp;
        }

        public void TabCreating(TabControl TabControl, string Text, Form Form)
        {
            int Index = KiemTraTonTai(TabControl, Text);
            if (Index >= 0)
            {
                TabControl.SelectedTab = TabControl.TabPages[Index];
                TabControl.SelectedTab.Text = Text;

            }
            else
            {
                TabPage TabPage = new TabPage { Text = Text };
                TabControl.TabPages.Add(TabPage);
                TabControl.SelectedTab = TabPage;

                Form.TopLevel = false;
                Form.Parent = TabPage;
                //  Form.MdiParent = this;
                Form.Show();
                Form.Dock = DockStyle.Fill;
            }
        }

        public void CloseTabControl(TabControl TabControl)
        {
            int number_TabPage = TabControl.TabPages.Count;
            if (number_TabPage > 0)
            {
                for (int i = 0; i < number_TabPage; i++)
                {
                    
                    TabControl.TabPages.Remove(TabControl.SelectedTab);
                   
                }
            }
        }


        private void AdminHome_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }

        private void btnQuanLyKhoaHoc_Click(object sender, EventArgs e)
        {
            CloseTabControl(LayoutMain);

            KhoaHoc KhoaHoc = new KhoaHoc();
            TabCreating(LayoutMain, "Home", KhoaHoc);

            ThemKhoaHoc ThemKhoaHoc = new ThemKhoaHoc();
            TabCreating(LayoutMain, "Thêm", ThemKhoaHoc);

            SuaKhoaHoc SuaKhoaHoc = new SuaKhoaHoc();
            TabCreating(LayoutMain, "Sửa", SuaKhoaHoc);

            XoaKhoaHoc XoaKhoaHoc = new XoaKhoaHoc();
            TabCreating(LayoutMain, "Xóa", XoaKhoaHoc);

            LayoutMain.SelectTab(0);

        }

        private void btnQuanLyBaiGiang_Click(object sender, EventArgs e)
        {           
            CloseTabControl(LayoutMain);

            DanhSachBaiGiang DanhSachBaiGiang = new DanhSachBaiGiang();
            TabCreating(LayoutMain, "Home", DanhSachBaiGiang);

            ThemBaiGiang ThemBaiGiang = new ThemBaiGiang();
            TabCreating(LayoutMain, "Thêm", ThemBaiGiang);


            SuaBaiGiang SuaBaiGiang = new SuaBaiGiang();
            TabCreating(LayoutMain, "Sửa", SuaBaiGiang);

            XoaBaiGiang XoaBaiGiang = new XoaBaiGiang();
            TabCreating(LayoutMain, "Xóa", XoaBaiGiang);

            LayoutMain.SelectTab(0);

        }

        


        private void btnChiTietKhoaHoc_Click(object sender, EventArgs e)
        {
            CloseTabControl(LayoutMain);

            DanhSachChiTietKhoaHoc DanhSachChiTietKhoaHoc = new DanhSachChiTietKhoaHoc();
            TabCreating(LayoutMain, "Home", DanhSachChiTietKhoaHoc);

            ThemChiTietKH ThemChiTietKH = new ThemChiTietKH();
            TabCreating(LayoutMain, "Thêm", ThemChiTietKH);

            SuaChiTietKH SuaChiTietKH = new SuaChiTietKH();
            TabCreating(LayoutMain, "Sửa", SuaChiTietKH);

            XoaChiTietKH XoaChiTietKH = new XoaChiTietKH();
            TabCreating(LayoutMain, "Xóa", XoaChiTietKH);

            LayoutMain.SelectTab(0);
        }

     

        private void btnDangXuat2_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }

      

        private void btnQuanLyCauHoi_Click_1(object sender, EventArgs e)
        {
            CloseTabControl(LayoutMain);


            DanhSachCauHoi DanhSachCauHoi = new DanhSachCauHoi();
            TabCreating(LayoutMain, "Home", DanhSachCauHoi);

            ThemCauHoi ThemCauHoi = new ThemCauHoi();
            TabCreating(LayoutMain, "Thêm", ThemCauHoi);

            SuaCauHoi SuaCauHoi = new SuaCauHoi();
            TabCreating(LayoutMain, "Sửa", SuaCauHoi);

            XoaCauHoi XoaCauHoi = new XoaCauHoi();
            TabCreating(LayoutMain, "Xóa", XoaCauHoi);

            LayoutMain.SelectTab(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseTabControl(LayoutMain);


            DanhSachDapAn DanhSachDapAn = new DanhSachDapAn();
            TabCreating(LayoutMain, "Home", DanhSachDapAn);

            ThemDapAn ThemDapAn = new ThemDapAn();
            TabCreating(LayoutMain, "Thêm", ThemDapAn);

            SuaDapAn SuaDapAn = new SuaDapAn();
            TabCreating(LayoutMain, "Sửa", SuaDapAn);

            XoaDapAn XoaDapAn = new XoaDapAn();
            TabCreating(LayoutMain, "Xóa", XoaDapAn);

            LayoutMain.SelectTab(0);
        }

        private void btnChiTietCauHoi_Click(object sender, EventArgs e)
        {
            CloseTabControl(LayoutMain);


            DSChiTietCauHoi DSChiTietCauHoi = new DSChiTietCauHoi();
            TabCreating(LayoutMain, "Home", DSChiTietCauHoi);

            ThemChiTietCauHoi ThemChiTietCauHoi = new ThemChiTietCauHoi();
            TabCreating(LayoutMain, "Thêm", ThemChiTietCauHoi);

            SuaChiTietCauHoi SuaChiTietCauHoi = new SuaChiTietCauHoi();
            TabCreating(LayoutMain, "Sửa", SuaChiTietCauHoi);

            XoaChiTietCauHoi XoaChiTietCauHoi = new XoaChiTietCauHoi();
            TabCreating(LayoutMain, "Xóa", XoaChiTietCauHoi);

            LayoutMain.SelectTab(0);
        }

        private void btnQuanLyDeThi_Click(object sender, EventArgs e)
        {
            CloseTabControl(LayoutMain);


            DSQuanLyDeThi DSQuanLyDeThi = new DSQuanLyDeThi();
            TabCreating(LayoutMain, "Home", DSQuanLyDeThi);

            ThemDeThi ThemDeThi = new ThemDeThi();
            TabCreating(LayoutMain, "Thêm", ThemDeThi);

            SuaDeThi SuaDeThi = new SuaDeThi();
            TabCreating(LayoutMain, "Sửa", SuaDeThi);

            XoaDeThi XoaDeThi = new XoaDeThi();
            TabCreating(LayoutMain, "Xóa", XoaDeThi);



            LayoutMain.SelectTab(0);
        }

        private void btnChiTietDeThi_Click(object sender, EventArgs e)
        {
            CloseTabControl(LayoutMain);


            DSChiTietDeThi DSChiTietDeThi = new DSChiTietDeThi();
            TabCreating(LayoutMain, "Home", DSChiTietDeThi);

            ThemChiTietDeThi ThemChiTietDeThi = new ThemChiTietDeThi();
            TabCreating(LayoutMain, "Thêm", ThemChiTietDeThi);

            SuaChiTietDeThi SuaChiTietDeThi = new SuaChiTietDeThi();
            TabCreating(LayoutMain, "Sửa", SuaChiTietDeThi);

            XoaChiTietDeThi XoaChiTietDeThi = new XoaChiTietDeThi();
            TabCreating(LayoutMain, "Xóa", XoaChiTietDeThi);



            LayoutMain.SelectTab(0);
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            CloseTabControl(LayoutMain);


            DanhSachTaiKhoan DanhSachTaiKhoan = new DanhSachTaiKhoan();
            TabCreating(LayoutMain, "Home", DanhSachTaiKhoan);

            ThemTaiKhoan ThemTaiKhoan = new ThemTaiKhoan();
            TabCreating(LayoutMain, "Thêm", ThemTaiKhoan);

            SuaTaiKhoan SuaTaiKhoan = new SuaTaiKhoan();
            TabCreating(LayoutMain, "Sửa", SuaTaiKhoan);

            XoaTaiKhoan XoaTaiKhoan = new XoaTaiKhoan();
            TabCreating(LayoutMain, "Xóa", XoaTaiKhoan);



            LayoutMain.SelectTab(0);
        }
    }
}
