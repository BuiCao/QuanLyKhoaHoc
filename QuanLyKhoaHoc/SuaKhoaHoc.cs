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

namespace HocTiengAnhOnline.QuanLyKhoaHoc
{
    public partial class SuaKhoaHoc : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public SuaKhoaHoc()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }

        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowKhoaHoc();
            tblKhoaHoc.DataSource = dt;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string makh = txtMaKH.Text;
            string tenkh = txtTenKH.Text;
            string magv = txtMaGV.Text;
            if (makh == "" || tenkh == "" || magv == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.SuaKhoaHoc(makh, tenkh, magv);
                getData();
            }


        }

        private void tblKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblKhoaHoc.Rows[e.RowIndex];

                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtTenKH.Text = row.Cells[1].Value.ToString();
                txtMaGV.Text = row.Cells[2].Value.ToString();

                
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtMaGV.Text = "";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void SuaKhoaHoc_Load(object sender, EventArgs e)
        {
            getData();
        }
    }
    
}
