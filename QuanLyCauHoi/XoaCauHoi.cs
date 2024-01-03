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

namespace HocTiengAnhOnline.QuanLyCauHoi
{
    public partial class XoaCauHoi : Form
    {
        ConnectSQL con;
        SqlConnection conn;
        Controll ct = new Controll();
        public XoaCauHoi()
        {
            con = new ConnectSQL();
            conn = con.connection();
            InitializeComponent();
        }
        public void getData()
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            dt = ct.ShowCauHoi();
            tblCauHoi.DataSource = dt;
        }
        private void XoaCauHoi_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void tblCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
               if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.tblCauHoi.Rows[e.RowIndex];

                txtMaCH.Text = row.Cells[0].Value.ToString();
                txtNDCH.Text = row.Cells[1].Value.ToString();
                txtMaKH.Text = row.Cells[2].Value.ToString();
                
                }
         }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mach = txtMaCH.Text;
            string makh = txtMaKH.Text;
            string noidungch = txtNDCH.Text;
            if (mach == "" || makh == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                ct.XoaCauHoi(mach, makh);
                getData();
            }
        }

        private void btnLamMoiBangDuLieu_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
