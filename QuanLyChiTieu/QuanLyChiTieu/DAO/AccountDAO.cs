using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace QuanLyChiTieu.DAO
{
    public class AccountDAO
    {
        private AccountDAO() { }
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }


        public bool LoginCheck(string username, string password)
        {
            string query = "SELECT * FROM TAIKHOAN WHERE TENTK = '" + username + "' AND MATKHAU = '" + password + "' ";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public bool AddAccount(string username, string password)
        {
            string query = "USP_AddAccount @TENTK , @MATKHAU";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {username, password});
            return result > 0;
        }

        public List<int> GetBalanceInWeek()
        {
            List<int> result = new List<int>();
            //today
            DataTable money = DataProvider.Instance.ExecuteQuery("USP_GetAccountMoney @TENTK", new object[] { Form1.currUser });
            result.Add(int.Parse(money.Rows[0][0].ToString()));

            //6day ago
            DateTime date = DateTime.Now.Date;
            date = date.AddDays(-1);
            for (int i = 0; i < 6; i++)
            {
                int inDay = (int)DataProvider.Instance.ExecuteScalar("USP_GetBalance @ThoiGian , @TENTK", new object[] { date, Form1.currUser });
                result.Add(inDay);

                date = date.AddDays(-1);
            }
            result.Reverse();
            return result;
        }
    }
}
