using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.DTO
{
    public class WalletDTO
    {
        private string _maVi;
        private string _tenVi;
        private string _tenTK;
        private string _soDu;

        public string MaVi { get { return _maVi; } set { _maVi = value; } }
        public string TenVi { get { return _tenVi; } set { _tenVi = value; } }
        public string TenTK { get { return _tenTK; } set { _tenTK = value; } } 
        public string SoDu { get { return _soDu; } set { _soDu = value; } }

        public WalletDTO(string mavi, string tenvi, string tentk, string sodu)
        {
            _maVi = mavi;
            _tenVi = tenvi;
            _tenTK = tentk;
            _soDu = sodu;
        }

        public WalletDTO(DataRow row)
        {
            _maVi = row["MAVI"].ToString();
            _tenVi = row["TENVI"].ToString();
            _tenTK = row["TENTK"].ToString();
            _soDu = row["SODU"].ToString();
        }
    }
}
