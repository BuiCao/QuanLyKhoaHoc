using Microsoft.SqlServer.Server;
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
    public partial class GiaoDienChinh : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public GiaoDienChinh()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
            // load data
            loadTableKhoaHoc();
            tabControl1.SelectedTab = tabPageChonKhoaHoc;
        }
        // chọn khóa học
        public void loadTableKhoaHoc()
        {
            string sql = string.Format(@"
                select KhoaHoc.MaKH, KhoaHoc.TenKH, GiaoVien.HoTen as 'TenGV', QBG.SoBG, QDT.SoDeThi
                from KhoaHoc, GiaoVien, (select MaKH, count(*) as 'SoBG' from ChiTietKhoaHoc group by MaKH) as QBG, (select MaKH, count(*) as 'SoDeThi' from DeThi group by MaKH) as QDT
                where KhoaHoc.MaGV = GiaoVien.MaGV and KhoaHoc.MaKH = QBG.MaKH and KhoaHoc.MaKH = QDT.MaKH and GiaoVien.HoTen like N'%{0}%' and KhoaHoc.TenKH like '%{1}%'
            ", txtTimGVinChonKH.Text, txtTimKHinChonKH.Text);
            dgvKhoaHocInChonKH.DataSource = ct.ExecuteQuery(sql);
            dgvKhoaHocInChonKH.Columns["MaKH"].Width = 50;
            dgvKhoaHocInChonKH.Columns["TenKH"].Width = 200;
            dgvKhoaHocInChonKH.Columns["TenGV"].Width = 100;
            dgvKhoaHocInChonKH.Columns["SoBG"].Width = 50;
            dgvKhoaHocInChonKH.Columns["SoDeThi"].Width = 50;
        }

        private void btnChonKHinChonKH_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageChiTietKhoaHoc;
            // show form chi tiết khóa học
            loadTableBaiGiang();
            loadTableDeThi();
        }

        private void btnTimKHinChonKH_Click(object sender, EventArgs e)
        {
            loadTableKhoaHoc();
        }

        private void dgvKhoaHocInChonKH_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            if (dgvKhoaHocInChonKH.SelectedRows.Count <= 0)
            {
                return;
            }
            txtMaKH.Text = dgvKhoaHocInChonKH.SelectedRows[0].Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgvKhoaHocInChonKH.SelectedRows[0].Cells["TenKH"].Value.ToString();
            txtGiangVien.Text = dgvKhoaHocInChonKH.SelectedRows[0].Cells["TenGV"].Value.ToString();
            txtSoBG.Text = dgvKhoaHocInChonKH.SelectedRows[0].Cells["SoBG"].Value.ToString();
            txtSoDeThi.Text = dgvKhoaHocInChonKH.SelectedRows[0].Cells["SoDeThi"].Value.ToString();
        }

        // chi tiết khóa học
        public void loadTableBaiGiang()
        {
            
            string sql = string.Format(@"
                select BaiGiang.*
                from ChiTietKhoaHoc, BaiGiang
                where ChiTietKhoaHoc.MaBG = BaiGiang.MaBG and ChiTietKhoaHoc.MaKH = '{0}'
            ", txtMaKH.Text);
            dgvDanhSachBaiGiang.DataSource = ct.ExecuteQuery(sql);
            dgvDanhSachBaiGiang.Columns["MaBG"].Width = 50;
            dgvDanhSachBaiGiang.Columns["TenBG"].Width = 200;
            dgvDanhSachBaiGiang.Columns["NoiDungBG"].Width = 350;
            
        }

        private void btnXemBaiGiang_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageXemBaiGiang;            
        }

        private void dgvDanhSachBaiGiang_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            if (dgvDanhSachBaiGiang.SelectedRows.Count <= 0)
            {
                return;
            }
            txtTenBGInXemBG.Text = dgvDanhSachBaiGiang.SelectedRows[0].Cells["TenBG"].Value.ToString();
            txtNoiDungBGinXemBG.Text = dgvDanhSachBaiGiang.SelectedRows[0].Cells["NoiDungBG"].Value.ToString();            
        }

        private void btnBackInXemBaiGiang_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageChiTietKhoaHoc;
        }

        public void loadTableDeThi()
        {

            string sql = string.Format(@"
                select DeThi.MaDT, DeThi.TenDT, QSCH.SoCauHoi
                from KhoaHoc, DeThi, (select MaDT, count(*) as 'SoCauHoi' from ChiTietDeThi group by MaDT ) as QSCH
                where KhoaHoc.MaKH = DeThi.MaKH and DeThi.MaKH = '{0}' and QSCH.MaDT = DeThi.MaDT
            ", txtMaKH.Text);
            dgvDeThi.DataSource = ct.ExecuteQuery(sql);
            dgvDeThi.Columns["MaDT"].Width = 50;
            dgvDeThi.Columns["TenDT"].Width = 200;
            dgvDeThi.Columns["SoCauHoi"].Width = 80;

        }
        private DataTable DanhSachCauHoi;
        private int CauHoiHienTai;
        private DataTable DanhSachDapAn;
        private int SoCauDung;

        private void ShowCauHoi()
        {
            string sql;
            DataTable dt;
            CauHoiHienTai++;
            if(CauHoiHienTai >= DanhSachCauHoi.Rows.Count)
            {
                // het de thi
                tmCount.Stop();

                // MessageBox.Show("Bạn đã hoàn thành bài thi"+ Environment.NewLine + "Số câu dúng: "+ SoCauDung + "/" + DanhSachCauHoi.Rows.Count);
                tabControl1.SelectedTab = tabPageKetQuaThi;
                
                txtSCHInKetQuaThi.Text = DanhSachCauHoi.Rows.Count.ToString();
                txtTenDTInKetQuaThi.Text = dgvDeThi.SelectedRows[0].Cells["TenDT"].Value.ToString();
                txtSCDungInKetQuaThi.Text = SoCauDung.ToString();
                txtSCSaiInKetQuaThi.Text = (DanhSachCauHoi.Rows.Count - SoCauDung).ToString();
                txtDiemThi.Text = ((float) SoCauDung / DanhSachCauHoi.Rows.Count * 10).ToString();
                return;
            }

            DataRow CauHoi = DanhSachCauHoi.Rows[CauHoiHienTai];
            string MaCH = CauHoi["MaCH"].ToString();
            string NoiDungCH = CauHoi["NoiDungCH"].ToString();
            txtNDCauHoiInLamDeThi.Text = NoiDungCH;
            sql = string.Format(@"
                select DapAn.*, ChiTietCauHoi.Dung 
                from DapAn, ChiTietCauHoi 
                where ChiTietCauHoi.MaDA = DapAn.MaDA and ChiTietCauHoi.MaCH = '{0}'
            ", MaCH);
            DanhSachDapAn = ct.ExecuteQuery( sql );

            if(DanhSachDapAn.Rows.Count != 4)
            {
                MessageBox.Show("Bủh :V");
                return;
            }

            DataRow DapAn1 = DanhSachDapAn.Rows[0];
            DataRow DapAn2 = DanhSachDapAn.Rows[1];
            DataRow DapAn3 = DanhSachDapAn.Rows[2];
            DataRow DapAn4 = DanhSachDapAn.Rows[3];

            txtDapAn1.Text = DapAn1["NoiDungDA"].ToString();
            txtDapAn2.Text = DapAn2["NoiDungDA"].ToString();
            txtDapAn3.Text = DapAn3["NoiDungDA"].ToString();
            txtDapAn4.Text = DapAn4["NoiDungDA"].ToString();



        }
        private void btnLamDeThi_Click(object sender, EventArgs e)
        {
            if(dgvDeThi.SelectedRows.Count <= 0)
            {
                return;
            }
            DataGridViewCellCollection data = dgvDeThi.SelectedRows[0].Cells;
            string MaDT = data["MaDT"].Value.ToString();
            
            tabControl1.SelectedTab = tabPageLamDeThi;
            Timer();

            string sql = string.Format(@"
                select NoiDungCH, MaDT, CauHoi.MaCH
                from ChiTietDeThi, CauHoi 
                where ChiTietDeThi.MaCH = CauHoi.MaCH and ChiTietDeThi.MaDT = '{0}'
            ", MaDT);

            DanhSachCauHoi = ct.ExecuteQuery(sql);
            CauHoiHienTai = -1;
            SoCauDung = 0;

            sql = string.Format(@"
                select * from DeThi where MaDT = '{0}'
            ", MaDT);
            ShowCauHoi();

        }

        private void dgvDeThi_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            if (dgvDeThi.SelectedRows.Count <= 0)
            {
                return;
            }
            txtMaDTinLamDT.Text = dgvDeThi.SelectedRows[0].Cells["MaDT"].Value.ToString();
            txtTenDTinLamDeThi.Text = dgvDeThi.SelectedRows[0].Cells["TenDT"].Value.ToString();
            txtSCHinLamDeThi.Text = dgvDeThi.SelectedRows[0].Cells["SoCauHoi"].Value.ToString();
        }
        private int count = 0;
        private int min = 45;
        private void Timer()
        {
            tmCount.Start();
        }

        private void tmCount_Tick(object sender, EventArgs e)
        {
            count--;            
            if(count <= 0)
            {
                min--;
                lbMin.Text = min.ToString();
                count = 59;
            }
            lbSec.Text = count.ToString();
        }

        private void btnChonDapAn1_Click(object sender, EventArgs e)
        {
            DataRow DapAn1 = DanhSachDapAn.Rows[0];
            if (DapAn1["Dung"].ToString().Equals("1"))
            {
                SoCauDung += 1;
            }
            ShowCauHoi();

        }

        private void btnChonDapAn2_Click(object sender, EventArgs e)
        {
            DataRow DapAn2 = DanhSachDapAn.Rows[1];
            if (DapAn2["Dung"].ToString().Equals("1"))
            {
                SoCauDung += 1;
            }
            ShowCauHoi();

        }

        private void btnChonDapAn3_Click(object sender, EventArgs e)
        {
            DataRow DapAn3 = DanhSachDapAn.Rows[2];
            if (DapAn3["Dung"].ToString().Equals("1"))
            {
                SoCauDung += 1;
            }
            ShowCauHoi();

        }

        private void btnChonDapAn4_Click(object sender, EventArgs e)
        {
            DataRow DapAn4 = DanhSachDapAn.Rows[3];
            if (DapAn4["Dung"].ToString().Equals("1"))
            {
                SoCauDung += 1;
            }
            ShowCauHoi();
        }

        private void btnNopBai_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn nộp bài không!", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CauHoiHienTai = DanhSachCauHoi.Rows.Count;
                ShowCauHoi();
            }
            
        }

        private void btnKetThucInKQThi_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageChiTietKhoaHoc;
        }
    }
}
