﻿using System;

namespace LTUD1_BACHHOAXANH472
{
    public class HoaDon
    {
        private string maHD, maNV, maKH;
        private DateTime ngayHD;
        private decimal tongTien;
        public HoaDon() { }
        public HoaDon(string maHD, string maNV, string maKH, DateTime ngayHD, decimal tongTien)
        {
            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(maKH))
            {
                throw new ArgumentException("Mã hóa đơn, mã nhân viên và mã khách hàng không được để trống");
            }

            this.MaHD = maHD;
            this.MaNV = maNV;
            this.MaKH = maKH;
            this.NgayHD = ngayHD;
            this.TongTien = tongTien;
        }


        public string MaHD { get => maHD; set => maHD = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public DateTime NgayHD { get => ngayHD; set => ngayHD = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
    }

}

