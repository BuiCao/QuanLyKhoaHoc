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

namespace HocTiengAnhOnline.ChiTietKhoaHoc
{
    public partial class SuaChiTietKH : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public SuaChiTietKH()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowChiTietKhoaHoc();
            tblKhoaHoc.DataSource = dt;
        }

        private void SuaChiTietKH_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string makh = txtMaKH.Text;
            string mabg = txtMaBG.Text;
            if (makh == ""  || mabg == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.SuaChiTietKhoaHoc(makh, mabg);
                getData();
            }
        }

        private void tblKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblKhoaHoc.Rows[e.RowIndex];

                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtMaBG.Text = row.Cells[1].Value.ToString();

               
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtMaBG.Text = "";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
