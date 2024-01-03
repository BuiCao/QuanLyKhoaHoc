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
    public partial class KhoaHoc : Form
    {

        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public KhoaHoc()
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

        private void KhoaHoc_Load(object sender, EventArgs e)
        {
            getData();

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
