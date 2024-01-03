﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HocTiengAnhOnline.ChiTietDeThi
{
    public partial class XoaChiTietDeThi : Form
    {

        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public XoaChiTietDeThi()
        {

            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowChiTietDeThi();
            tblKhoaHoc.DataSource = dt;
        }
        private void XoaChiTietDeThi_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void tblKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblKhoaHoc.Rows[e.RowIndex];

                txtMaDT.Text = row.Cells[0].Value.ToString();
                txtMaCH.Text = row.Cells[1].Value.ToString();


            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string madt = txtMaDT.Text;
            string mach = txtMaCH.Text;
            if (madt == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.XoaChiTietDeThi(madt);
                getData();
            }
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
