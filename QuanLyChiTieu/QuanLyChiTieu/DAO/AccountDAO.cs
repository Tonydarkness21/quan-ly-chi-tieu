using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }

        private AccountDAO() { }

        public bool LoginCheck(string username, string password)
        {
            string query = "SELECT * FROM TAI_KHOAN WHERE TENTK = '" + username + "' AND MATKHAU = '" + password + "' ";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public bool AddAccount(string username, string password)
        {
            string query = "USP_AddAccount @TENTK , @MATKHAU";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {username, password});
            return result > 0;
        }
    }
}
