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
namespace HocTiengAnhOnline.QuanLyDapAn
{
    public partial class XoaDapAn : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public XoaDapAn()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowDapAn();
            tblDapAn.DataSource = dt;
        }
        private void XoaDapAn_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void tblDapAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblDapAn.Rows[e.RowIndex];

                txtMaDA.Text = row.Cells[0].Value.ToString();
                txtNDDA.Text = row.Cells[1].Value.ToString();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mada = txtMaDA.Text;
            string noidungda = txtNDDA.Text;
            if (mada == "" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.XoaDapAn(mada);
                getData();
            }
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
