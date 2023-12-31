﻿using System;
namespace LTUD1_BACHHOAXANH472
{
    public class QuyenTruyCap
    {
        string maqtc;
        string tenqtc;
        public QuyenTruyCap()
        {

        }
        public QuyenTruyCap(string maqtc, string tenqtc)
        {
            if (string.IsNullOrEmpty(maqtc))
            {
                throw new ArgumentException("Mã quyền truy cập phải không được để trống và không dài hơn 11 ký tự.");
            }

            if (string.IsNullOrEmpty(tenqtc) || tenqtc.Length > 30)
            {
                throw new ArgumentException("Tên quyền truy cập phải không được để trống và không dài hơn 30 ký tự.");
            }

            this.maqtc = maqtc;
            this.tenqtc = tenqtc;
        }


        public string Maqtc { get => maqtc; set => maqtc = value; }
        public string Tenqtc { get => tenqtc; set => tenqtc = value; }
    }
}
