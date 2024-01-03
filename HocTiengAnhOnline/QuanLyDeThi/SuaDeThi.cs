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

namespace HocTiengAnhOnline.QuanLyDeThi
{
    public partial class SuaDeThi : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public SuaDeThi()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowDeThi();
            tblKhoaHoc.DataSource = dt;
        }
        private void SuaDeThi_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void tblKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblKhoaHoc.Rows[e.RowIndex];

                txtMaDT.Text = row.Cells[0].Value.ToString();
                txtTenDT.Text = row.Cells[1].Value.ToString();
                txtMaKH.Text = row.Cells[2].Value.ToString();


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string madt = txtMaDT.Text;
            string tendt = txtTenDT.Text;
            string makh = txtMaKH.Text;
            if (madt == "" || tendt == "" || makh == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.SuaDeThi(madt, tendt, makh);
                getData();
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {

            txtMaDT.Text = "";
            txtTenDT.Text = "";
            txtMaKH.Text ="";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
