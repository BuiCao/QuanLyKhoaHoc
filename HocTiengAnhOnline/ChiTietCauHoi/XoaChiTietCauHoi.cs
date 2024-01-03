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
    public partial class XoaChiTietCauHoi : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public XoaChiTietCauHoi()
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
        private void XoaChiTietCauHoi_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void tblKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblKhoaHoc.Rows[e.RowIndex];

                txtMaCH.Text = row.Cells[0].Value.ToString();
                txtMaDA.Text = row.Cells[1].Value.ToString();
                txtDung.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mach = txtMaCH.Text;
            string mada = txtMaDA.Text;
            int dung=int.Parse(txtDung.Text);
            if (mach == "" || mada == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.XoaChiTietCauHoi(mach, mada);
                getData();
            }
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
