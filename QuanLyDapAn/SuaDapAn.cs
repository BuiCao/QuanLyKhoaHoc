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
    public partial class SuaDapAn : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public SuaDapAn()
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
        private void SuaDapAn_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mada = txtMaDA.Text;
            string noidungda = txtNDDA.Text;
            if (mada == ""  ||noidungda == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.SuaDapAn(mada, noidungda);
                getData();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaDA.Text = "";
            txtNDDA.Text = "";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            
            getData();
        }

      

        private void tblDapAn_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblDapAn.Rows[e.RowIndex];

                txtMaDA.Text = row.Cells[0].Value.ToString();
                txtNDDA.Text = row.Cells[1].Value.ToString();
              
                
            }
        }
    }
}
