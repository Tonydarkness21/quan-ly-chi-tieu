using QuanLyChiTieu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.DAO
{
    public class WalletDAO
    {
        private WalletDAO() { }
        private static WalletDAO instance;

        public static WalletDAO Instance
        {
            get { if (instance == null) instance = new WalletDAO(); return instance; }
            private set => instance = value;
        }
        
        public List <WalletDTO> LoadWalletList()
        {
            List <WalletDTO > list = new List <WalletDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LoadWallet");
            foreach (DataRow row in data.Rows)
            {
                WalletDTO item = new WalletDTO (row);
                list.Add (item);
            }
            return list;
        }

        public bool AddWallet (WalletDTO wallet)
        {
            string query = "EXEC USP_AddWallet @MAVI , @TENVI , @TENTK , @SODU";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                wallet.MaVi, wallet.TenVi, wallet.TenTK, wallet.SoDu
            });
            return result > 0;
        }

        public bool UpdateWallet(WalletDTO wallet)
        {
            string query = "EXEC USP_UpdateWallet @MAVI , @TENVI , @TENTK , @SODU";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                wallet.MaVi, wallet.TenVi, wallet.TenTK, wallet.SoDu
            });
            return result > 0;
        }

        public void DeleteWallet(string MaVi)
        {
            DataProvider.Instance.ExecuteQuery("USP_DeleteWallet @MAVI", new object[] { MaVi });
        }
    }
}
