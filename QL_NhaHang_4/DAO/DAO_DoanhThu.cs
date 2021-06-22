using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_DoanhThu
    {
        private SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable loadDoanhThuNam(int nam)
        {
            SQLDatabase.OpenConnection(conn);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_LayDoanhThuTungThang", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@nam", SqlDbType.Int);
            par1.Value = nam;
            cmd.Parameters.Add(par1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SQLDatabase.CloseConnection(conn);
            return dt;
        }
        public DataTable loadHoaDonTheoNgay(int ngay, int thang, int nam)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_TienBanNgay", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@ngay", SqlDbType.Int);
                par1.Value = ngay;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
            return dt;
        }
        public DTO_PhanTrang loadHoaDonTheoNgayPhanTrang(int ngay, int thang, int nam, int pageIndex, int PageSize)
        {
            using (SqlCommand cmd = new SqlCommand("sp_HienThiDanhSachHoaDonPaging", conn))
            {
                //Truyền vào các tham số PageIndex, PageSize cho Stored Procedure
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@ngay", SqlDbType.Int);
                par1.Value = ngay;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                cmd.Parameters.AddWithValue("@PageSize", PageSize);
                //Lấy ra tham số RecordCount của Store Procedured
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                SQLDatabase.OpenConnection(conn);
                //Thực thi câu lệnh truy vấn và gán cho đối tượng DataTable
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                SQLDatabase.CloseConnection(conn);
                int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                DTO_PhanTrang phanTrang = new DTO_PhanTrang(dt, recordCount);
                return phanTrang;
            }
        }
        public DataTable loadHoaDonTheoThang(int thang, int nam)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_TienBanThang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { SQLDatabase.CloseConnection(conn); }
            return dt;
        }
        public int layDoanhThuNgay(int ngay, int thang, int nam)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_TongDoanhThuNgay", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@ngay", SqlDbType.Int);
                par1.Value = ngay;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@DoanhThu", SqlDbType.Int);
                par4.Direction = ParameterDirection.Output;
                par4.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return (int)par4.Value;
            }
            catch { return 0; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public int layDoanhThuNgayTheoBan(int idBan, int ngay, int thang, int nam)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_TongDoanhThuNgayTheoBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par0 = new SqlParameter("@idBan", SqlDbType.Int);
                par0.Value = idBan;
                SqlParameter par1 = new SqlParameter("@ngay", SqlDbType.Int);
                par1.Value = ngay;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@DoanhThu", SqlDbType.Int);
                par4.Direction = ParameterDirection.Output;
                par4.Value = kq;
                cmd.Parameters.Add(par0);
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return (int)par4.Value;
            }
            catch { return 0; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public int layDoanhThuThang(int thang, int nam)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_TongDoanhThuThang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@DoanhThu", SqlDbType.Int);
                par4.Direction = ParameterDirection.Output;
                par4.Value = kq;
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return (int)par4.Value;
            }
            catch { return 0; }
            finally { SQLDatabase.CloseConnection(conn); }
        }

        public int layDoanhThuNam(int nam)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_TongDoanhThuNam", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@DoanhThu", SqlDbType.Int);
                par4.Direction = ParameterDirection.Output;
                par4.Value = kq;
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return (int)par4.Value;
            }
            catch { return 0; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public DataTable layDSTongLuongThang(int nam)
        {
            DataTable dt = new DataTable();
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_TongLuongNhanVienThang", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
            par3.Value = nam;
            cmd.Parameters.Add(par3);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SQLDatabase.CloseConnection(conn);
            return dt;
        }
        public bool themDoanhThuDuBao(DateTime ngayThem, decimal soTien, int idNguoiDung)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_ThemDoanhThuDuBao", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par2 = new SqlParameter("@NgayThem", SqlDbType.Date);
                par2.Value = ngayThem.Date;
                SqlParameter par3 = new SqlParameter("@SoTien", SqlDbType.Money);
                par3.Value = soTien;
                SqlParameter par4 = new SqlParameter("@IDNguoiDung", SqlDbType.Int);
                par4.Value = idNguoiDung;
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public DataTable layTop5DuBaoDT()
        {
            DataTable dt = new DataTable();
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_LayTop5DuBaoDT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SQLDatabase.CloseConnection(conn);
            return dt;
        }
    }
}
