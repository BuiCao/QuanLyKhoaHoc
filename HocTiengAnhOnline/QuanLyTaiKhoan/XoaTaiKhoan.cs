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
    public partial class XoaTaiKhoan : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public XoaTaiKhoan()
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
        private void XoaTaiKhoan_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int account_id = int.Parse(txtAccount_id.Text);
            string username = txtUsername.Text;
 
            
                SqlConnection conn = new SqlConnection();
                ct.XoaAccount(account_id);
                getData();
            
        }

        private void tblKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblKhoaHoc.Rows[e.RowIndex];
                txtAccount_id.Text = row.Cells[0].Value.ToString();
                txtUsername.Text = row.Cells[1].Value.ToString();


            }
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
