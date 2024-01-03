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
    public partial class SuaTaiKhoan : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public SuaTaiKhoan()
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
        private void SuaTaiKhoan_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void tblKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblKhoaHoc.Rows[e.RowIndex];
                txtAccount_id.Text = row.Cells[0].Value.ToString();
                txtUsername.Text = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                txtAuthority_id.Text = row.Cells[3].Value.ToString();


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int account_id = int.Parse(txtAccount_id.Text);
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int authority_id =int.Parse(txtAuthority_id.Text);
            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.SuaAccount(username, password, authority_id,account_id);
                getData();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtAccount_id.Text = "";
            txtUsername.Text="";
            txtPassword.Text="";
           txtAuthority_id.Text="";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
