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
    public partial class XoaChiTietKH : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public XoaChiTietKH()
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

        private void XoaChiTietKH_Load(object sender, EventArgs e)
        {
            getData();

        }

        private void btnXoa_Click(object sender, EventArgs e)
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
                ct.XoaChiTietKhoaHoc(makh, mabg);
                getData();
            }
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }


        private void tblKhoaHoc_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblKhoaHoc.Rows[e.RowIndex];

                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtMaBG.Text = row.Cells[1].Value.ToString();
            }
        }
    }
}
