using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.DTO
{
    public class SpendingDTO
    {
        public SpendingDTO(DataRow row)
        {
            _maChi = row["MACHI"].ToString();
            _tenMucChi = row["TENMUCCHI"].ToString();
            _soTien = row["SOTIEN"].ToString();
            _maLoaiChi = row["MALOAICHI"].ToString();
            _date = row["THOIGIAN"].ToString();
            _maVi = row["MAVI"].ToString();
            _soDu = row["SODU"].ToString();
        }

        private string _maChi;
        private string _tenMucChi;
        private string _soTien;
        private string _maLoaiChi;
        private string _date;
        private string _maVi;
        private string _soDu;

        public string MaChi { get { return _maChi; } set { _maChi = value; } }
        public string TenMucChi { get { return _tenMucChi; } set { _tenMucChi = value; } }
        public string MaLoaiChi { get { return _maLoaiChi; } set { _maLoaiChi = value;} }
        public string Date { get { return _date; } set { _date = value; } }
        public string SoDu { get { return _soDu; } set { _soDu = value; } }

    }
}
