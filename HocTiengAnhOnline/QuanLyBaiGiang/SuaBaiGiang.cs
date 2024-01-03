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

namespace HocTiengAnhOnline.QuanLyBaiGiang
{
    public partial class SuaBaiGiang : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public SuaBaiGiang()
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

        private void SuaBaiGiang_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mabg = txtMaBG.Text;
            string tenbg = txtTenBG.Text;
            string noidungbg = txtNDBG.Text;
            if (mabg == "" || tenbg == "" || noidungbg == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.SuaBaiGiang(mabg, tenbg, noidungbg);
                getData();
            }
        }

        private void tblKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tblKhoaHoc.Rows[e.RowIndex];

                txtMaBG.Text = row.Cells[0].Value.ToString();
                txtTenBG.Text = row.Cells[1].Value.ToString();
                txtNDBG.Text = row.Cells[2].Value.ToString();

            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaBG.Text = "";
            txtTenBG.Text = "";
            txtNDBG.Text = "";
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
