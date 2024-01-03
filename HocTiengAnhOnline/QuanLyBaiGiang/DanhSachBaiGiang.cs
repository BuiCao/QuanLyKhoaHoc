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

namespace HocTiengAnhOnline.QuanLyBaiGiang
{
    public partial class DanhSachBaiGiang : Form
    {

        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public DanhSachBaiGiang()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowBaiGiang();
            tblKhoaHoc.DataSource = dt;
        }

        private void DanhSachBaiGiang_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
