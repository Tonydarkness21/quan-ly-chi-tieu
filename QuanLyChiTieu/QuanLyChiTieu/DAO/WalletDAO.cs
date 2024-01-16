using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        
        public void DeleteWallet(string MaVi)
        {
            DataProvider.Instance.ExecuteQuery("USP_DeleteWallet @MAVI", new object[] { MaVi });
        }

        public List<string> GetWallets() 
        {
            List<string> result = new List<string>();
            string query = "USP_GetWallet @TenTK= "+Form1.currUser;
            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionSTR))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string value = reader.GetString(0); // Lấy giá trị của cột

                        result.Add(value); // Thêm giá trị vào List<string>
                    }
                }
            }

            return result;
        }
    }
}
