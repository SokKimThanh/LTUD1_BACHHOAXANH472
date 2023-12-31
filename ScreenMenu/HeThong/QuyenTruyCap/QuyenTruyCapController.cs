﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LTUD1_BACHHOAXANH472
{
    public class QuyenTruyCapController : MyController
    {
        public QuyenTruyCapController(string connectionString) : base(connectionString)
        {

        }

        public override void Delete(object id)
        {
            // Mở kết nối
            SqlConnection conn = OpenConnection();

            // Tạo một đối tượng SqlCommand
            Sql = new SqlCommand("sp_quyentruycap_delete", conn);
            Sql.CommandType = CommandType.StoredProcedure;
            // Thêm tham số vào SqlCommand
            Sql.Parameters.AddWithValue("@maQTC", id);
            // Thực thi SqlCommand
            if (Sql.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Xóa Thành công");
            }
            // Đóng kết nối
            CloseConnection();
        }

        public override object FromDataRow(DataRow row)
        {
            QuyenTruyCap o = new QuyenTruyCap();
            o.Maqtc = row.Field<string>("MAQTC");
            o.Tenqtc = row.Field<string>("TENQTC");
            return o;
        }

        public override void Insert(object sender)
        {
            try
            {
                QuyenTruyCap o = (QuyenTruyCap)sender;
                // Mở kết nối
                SqlConnection conn = OpenConnection();

                // Tạo một đối tượng SqlCommand
                Sql = new SqlCommand("sp_quyentruycap_insert", conn);
                Sql.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào SqlCommand
                Sql.Parameters.AddWithValue("@maqtc", o.Maqtc);
                Sql.Parameters.AddWithValue("@tenqtc", o.Tenqtc);
                // Thực thi SqlCommand
                if (Sql.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm Thành công");
                }

                // Đóng kết nối
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Đóng kết nối
                CloseConnection();
            }
        }

        public override void SelectAll()
        {
            try
            {
                // Mở kết nối
                SqlConnection conn = OpenConnection();

                // Tạo một đối tượng SqlCommand
                Sql = new SqlCommand("sp_quyentruycap_select_all", conn);
                Sql.CommandType = CommandType.StoredProcedure;

                // Tạo một đối tượng SqlDataAdapter
                Adapter = new SqlDataAdapter(Sql);

                // Tạo một đối tượng DataTable để lưu trữ dữ liệu
                DataSource = new DataTable();

                // Đổ dữ liệu vào DataTable
                Adapter.Fill(DataSource);

                // Đóng kết nối
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Đóng kết nối
                CloseConnection();
            }
        }

        public override DataTable SelectByID(object id)
        {
            try
            {
                // Mở kết nối
                SqlConnection conn = OpenConnection();

                // Tạo một đối tượng SqlCommand
                Sql = new SqlCommand("sp_quyentruycap_select_one", conn);
                Sql.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào SqlCommand
                Sql.Parameters.AddWithValue("@maqtc", id);

                // Tạo một đối tượng SqlDataAdapter
                Adapter = new SqlDataAdapter(Sql);

                // Tạo một đối tượng DataTable để lưu trữ dữ liệu
                DataSource = new DataTable();

                // Đổ dữ liệu vào DataTable
                Adapter.Fill(DataSource);

                // Đóng kết nối
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Đóng kết nối
                CloseConnection();
            }
            // Trả về DataTable
            return DataSource;
        }

        public override void Update(object sender)
        {
            try
            {
                QuyenTruyCap o = (QuyenTruyCap)sender;
                // Mở kết nối
                SqlConnection conn = OpenConnection();

                // Tạo một đối tượng SqlCommand
                Sql = new SqlCommand("sp_quyentruycap_update", conn);
                Sql.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào SqlCommand
                Sql.Parameters.AddWithValue("@maqtc", o.Maqtc);
                Sql.Parameters.AddWithValue("@tenqtc", o.Tenqtc);


                // Thực thi SqlCommand
                if (Sql.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật Thành công");
                }

                // Đóng kết nối
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Đóng kết nối
                CloseConnection();
            }
        }
    }

}


