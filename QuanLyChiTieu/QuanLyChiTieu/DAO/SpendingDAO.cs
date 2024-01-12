using QuanLyChiTieu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.DAO
{
    public class SpendingDAO
    {
        private SpendingDAO() { }
        private static SpendingDAO instance;

        public static SpendingDAO Instance
        {
            get { if (instance == null) instance = new SpendingDAO(); return instance; }
            private set => instance = value;
        }

        public List<SpendingDTO> LoadSpendingList()
        {
            List<SpendingDTO> list = new List<SpendingDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LoadSpending");
            foreach (DataRow row in data.Rows)
            {
                SpendingDTO item = new SpendingDTO(row);
                list.Add(item);
            }
            return list;
        }

        public bool AddSpending(SpendingDTO Spending)
        {
            string query = "EXEC USP_AddSpending @MACHI , @TENVI , @TENTK , @SODU";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                Spending.MaVi, Spending.TenVi, Spending.TenTK, Spending.SoDu
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
