using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HocTiengAnhOnline
{
    public class Controll
    {
        ConnectSQL con = new ConnectSQL();
        //kiểm tra có tồn tại tài khoản với tk và mk đã nhập hay không
        public Boolean DangNhap(string taikhoan, string matkhau)
        {
            string query = $"select count(*) from Account where username='{taikhoan}' and password='{matkhau}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            int check = (int)cmd.ExecuteScalar();
            if (check == 1)
            {
                return true;
            }
            else return false;
            conn.Close();

        }

        //kiểm tra truyền truy cập
        public int KiemTraQuyenTruyCap(string taikhoan, string matkhau)
        {
            string query = $"select authority_id from Account where username='{taikhoan}' and password='{matkhau}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            int authority_id = (int)cmd.ExecuteScalar();
            return authority_id;
            conn.Close();
        }

        //đăng ký tài khoản mới với quyền truy cập mặc định là học sinh
        public void DangKy(string taikhoan, string matkhau)
        {
            string query = $"insert into Account(username,password,authority_id) values('{taikhoan}','{matkhau}','2')";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //kiểm tra có bị trùng tên tài khoản hay không
        public Boolean KiemTraTonTaiTaiKhoan(string taikhoan)
        {
            string query = $"select count(*) from Account where username='{taikhoan}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            int check = (int)cmd.ExecuteScalar();
            if (check == 1)
            {
                return false;
            }
            else return true;
            conn.Close();

        }

        //kiểm tra đã đăng ký tài khoản được hay chưa
        public Boolean KiemTraDangKy(string taikhoan, string matkhau)
        {
            string query = $"select count(*) from Account where username='{taikhoan}' and password='{matkhau}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            int check = (int)cmd.ExecuteScalar();
            if (check == 1)
            {
                return true;
            }
            else return false;
            conn.Close();

        }
        
        //hiển thị các khóa học
        public DataTable ShowKhoaHoc()
        {
            string query = $"select * from KhoaHoc";
            DataTable dt = new DataTable();
            SqlConnection conn = con.connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }

        //thêm khóa học
        public void ThemKhoaHoc(string makh,string tenkh, string tengv)
        {
            string query = $"insert into KhoaHoc(MaKH,TenKH,MaGV) values('{makh}',N'{tenkh}','{tengv}')";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Sửa khóa học
        public void SuaKhoaHoc(string makh, string tenkh, string magv)
        {
            string query = $"update KhoaHoc set TenKH=N'{tenkh}', MaGV='{magv}' where MaKH='{makh}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Xóa khóa học
        public void XoaKhoaHoc(string makh, string tenkh, string magv)
        {
            string query = $"delete from KhoaHoc where MaKH='{makh}' and TenKH=N'{tenkh}' and MaGV='{magv}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }



        //hiển thị các bài giảng
        public DataTable ShowBaiGiang()
        {
            string query = $"select * from BaiGiang";
            DataTable dt = new DataTable();
            SqlConnection conn = con.connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }


        //thêm bài giảng
        public void ThemBaiGiang(string mabg, string tenbg, string noidungbg)
        {
            string query = $"insert into BaiGiang values(N'{mabg}',N'{tenbg}',N'{noidungbg}')";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Sửa bài giảng
        public void SuaBaiGiang(string mabg, string tenbg, string noidungbg)
        {
            string query = $"update BaiGiang set TenBG=N'{tenbg}', NoiDungBG=N'{noidungbg}' where MaBG=N'{mabg}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Xóa bài giảng
        public void XoaBaiGiang(string mabg, string tenbg )
        {
            string query = $"delete from BaiGiang where MaBG=N'{mabg}' and TenBG=N'{tenbg}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        //hiển thị Chi tiết khóa học
        public DataTable ShowChiTietKhoaHoc()
        {
            string query = $"select * from ChiTietKhoaHoc";
            DataTable dt = new DataTable();
            SqlConnection conn = con.connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }
        //thêm chi tiết khóa học
        public void ThemChiTietKhoaHoc(string makh, string mabg)
        {
            string query = $"insert into ChiTietKhoaHoc(MaKH,MaBG) values('{makh}',N'{mabg}')";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Sửa chi tiet khóa học
        public void SuaChiTietKhoaHoc(string makh,  string mabg)
        {
            string query = $"update ChiTietKhoaHoc set  MaBG='{mabg}' where MaKH='{makh}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Xóa chi tiet khóa học
        public void XoaChiTietKhoaHoc(string makh,  string mabg)
        {
            string query = $"delete from ChiTietKhoaHoc where MaKH='{makh}'  and MaBG='{mabg}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //hiển thị câu hỏi
        public DataTable ShowCauHoi()
        {
            string query = $"select * from CauHoi";
            DataTable dt = new DataTable();
            SqlConnection conn = con.connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }

        //thêm câu hỏi
        public void ThemCauHoi(string mach, string makh, string noidungch)
        {
            string query = $"insert into CauHoi(MaCH,MaKH,NoiDungCH) values(N'{mach}',N'{makh}',N'{noidungch}')";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Sửa câu hỏi
        public void SuaCauHoi(string mach, string makh, string noidungch)
        {
            string query = $"update CauHoi set MaKH=N'{makh}', NoiDungCH=N'{noidungch}' where MaCH=N'{mach}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Xóa câu hỏi
        public void XoaCauHoi(string mach, string makh)
        {
            string query = $"delete from CauHoi where MaCH=N'{mach}' and MaKH=N'{makh}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //hiển thị đáp án
        public DataTable ShowDapAn()
        {
            string query = $"select * from DapAn";
            DataTable dt = new DataTable();
            SqlConnection conn = con.connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }


        //thêm đáp án
        public void ThemDapAn(string mada,  string noidungda)
        {
            string query = $"insert into DapAn(MaDA,NoiDungDA) values(N'{mada}',N'{noidungda}')";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Sửa đáp án
        public void SuaDapAn(string mada,  string noidungda)
        {
            string query = $"update DapAn set NoiDungDA=N'{noidungda}' where MaDA=N'{mada}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Xóa đáp án
        public void XoaDapAn(string mada)
        {
            string query = $"delete from DapAn where MaDA=N'{mada}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //hiển thị Chi tiết câu hỏi
        public DataTable ShowChiTietCauHoi()
        {
            string query = $"select * from ChiTietCauHoi";
            DataTable dt = new DataTable();
            SqlConnection conn = con.connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }


        //thêm chi tiết câu hỏi
        public void ThemChiTietCauHoi(string mach, string mada , int dung)
        {
            string query = $"insert into ChiTietCauHoi(MaCH,MaDA,Dung) values(N'{mach}',N'{mada}','{dung}')";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Sửa chi tiết câu hỏi
        public void SuaChiTietCauHoi(string mach, string mada, int dung)
        {
            string query = $"update ChiTietCauHoi set MaDA=N'{mada}', Dung='{dung}' where MaCH=N'{mach}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Xóa chi tiết câu hỏi
        public void XoaChiTietCauHoi(string mach, string mada)
        {
            string query = $"delete from ChiTietCauHoi where MaCH=N'{mach}' and MaDA='{mada}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //hiển thị đề thi
        public DataTable ShowDeThi()
        {
            string query = $"select * from DeThi";
            DataTable dt = new DataTable();
            SqlConnection conn = con.connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }

        //thêm đề thi
        public void ThemDeThi(string madt, string tendt, string makh)
        {
            string query = $"insert into DeThi(MaDT,TenDT,MaKH) values(N'{madt}',N'{tendt}','{makh}')";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Sửa đề thi
        public void SuaDeThi(string madt, string tendt, string makh)
        {
            string query = $"update DeThi set TenDT=N'{tendt}', MaKH='{makh}' where MaDT=N'{madt}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Xóa đề thi
        public void XoaDeThi(string madt)
        {
            string query = $"delete from DeThi where MaDT=N'{madt}' ";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }



        //hiển thị chi tiết đề thi
        public DataTable ShowChiTietDeThi()
        {
            string query = $"select * from ChiTietDeThi";
            DataTable dt = new DataTable();
            SqlConnection conn = con.connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }
        //thêm chi tiết đề thi
        public void ThemChiTietDeThi(string madt, string mach)
        {
            string query = $"insert into ChiTietDeThi(MaDT,MaCH) values(N'{madt}',N'{mach}')";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Sửa chi tiết đề thi
        public void SuaChiTietDeThi(string mach,  string madt)
        {
            string query = $"update ChiTietDeThi set MaCH='{mach}' where MaDT=N'{madt}'";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        //Xóa chi tiết đề thi
        public void XoaChiTietDeThi(string madt)
        {
            string query = $"delete from ChiTietDeThi where MaDT=N'{madt}' ";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        //hiển thị tai khoan
        public DataTable ShowAccount()
        {
            string query = $"select * from Account";
            DataTable dt = new DataTable();
            SqlConnection conn = con.connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }

        //thêm tai khoan
        public void ThemAccount(string username, string password, int authority_id)
        {
            string query = $"insert into Account(username,password,authority_id) values(N'{username}',N'{password}','{authority_id}')";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Sửa tai khoan
        public void SuaAccount(string username, string password, int authority_id, int account_id)
        {
            string query = $"update Account set username='{username}' , password=N'{password}', authority_id='{authority_id}' where account_id='{account_id}' ";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Xóa tai khoan
        public void XoaAccount(int account_id)
        {
            string query = $"delete from Account where account_id='{account_id}' ";
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        // Phần của huy
        public DataTable ExecuteQuery(string sql)
        {
            SqlConnection conn = con.connection();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            adt.Fill(dt);
            return dt;

        }

        public void ExecuteNonQuery(string sql)
        {
            SqlConnection conn = con.connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        // End Huy
    }
}

