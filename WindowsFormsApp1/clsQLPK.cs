using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    internal class clsQLPK
    {
        SqlConnection ketnoi = new SqlConnection();
        public clsQLPK()
        {
            ketnoi.ConnectionString = "Data Source=LAPTOP-SSQHP7GE\\SQLEXPRESS; Initial Catalog=PhongKham;Integrated Security=True";
            ketnoi.Open();
        }
        public DataSet getDataSet(string tenbang)
        {
            string sql;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            sql = "select * from " + tenbang;
            da = new SqlDataAdapter(sql, ketnoi);
            da.Fill(ds, tenbang);
            return ds;
        }

        public DataSet getAllDataSet()
        {

            SqlDataAdapter daBacSi;
            SqlDataAdapter daBenhNhan;
            SqlDataAdapter daPhong;
            SqlDataAdapter daDuocPham;
            SqlDataAdapter daThongKe;
            SqlDataAdapter daNhanVien;

            DataSet ds = new DataSet();
            daBacSi = new SqlDataAdapter("select * from BACSI", ketnoi);
            daBacSi.Fill(ds, "BACSI");
            daBenhNhan = new SqlDataAdapter("select * from BENHNHAN", ketnoi);
            daBenhNhan.Fill(ds, "BENHNHAN");
            daPhong = new SqlDataAdapter("select * from PHONG", ketnoi);
            daPhong.Fill(ds, "PHONG");
            daDuocPham = new SqlDataAdapter("select * from DUOCPHAM", ketnoi);
            daDuocPham.Fill(ds, "DUOCPHAM");
            daThongKe = new SqlDataAdapter("select * from THONGKE", ketnoi);
            daThongKe.Fill(ds, "THONGKE");
            daNhanVien = new SqlDataAdapter("select * from NHANVIEN", ketnoi);
            daNhanVien.Fill(ds, "NHANVIEN");
            return ds;
        }
        public DataTable GetDataTable(string tblName)
        {
            string sql;
            DataTable tbl = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            sql = "select * from " + tblName;
            da = new SqlDataAdapter(sql, ketnoi);
            da.Fill(ds, tblName);
            tbl = ds.Tables[0];
            return tbl;
        }
        public DataSet GetDataSetTable(string tblName)
        {
            string sql;
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            sql = "select * from " + tblName;
            da = new SqlDataAdapter(sql, ketnoi);
            da.Fill(ds, tblName);
            return ds;

        }
        public DataRow TimRow(DataTable tbl, String TenCot, String strGiaTriTim)
        {
            DataRow drw;
            DataColumn[] myColArray = new DataColumn[1]; 
            myColArray[0] = tbl.Columns[TenCot];
            tbl.PrimaryKey = myColArray;
            drw = tbl.Rows.Find(strGiaTriTim);
            return drw;
        }
        public void CapnhatBang(DataSet ds, string Tenbang)
        {
            try
            {
                string sql;
                SqlDataAdapter da;
                SqlCommandBuilder cbd = new SqlCommandBuilder();
                sql = "Select * from " + Tenbang;
                da = new SqlDataAdapter(sql, ketnoi);
                cbd.DataAdapter = da;
                da.Update(ds, Tenbang);
                ds.AcceptChanges();
            }
            catch
            {
                throw new Exception("Loi Cap Nhat khong thanh cong");
            }
        }

    }
}
