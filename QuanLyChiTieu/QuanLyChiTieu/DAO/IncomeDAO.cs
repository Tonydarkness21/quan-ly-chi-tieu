using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.DAO
{
    internal class IncomeDAO
    {
        private IncomeDAO() { }

        private static IncomeDAO instance;

        public static IncomeDAO Instance
        {
            get { if (instance == null) instance = new IncomeDAO(); return instance; }
            private set => instance = value;
        }
        public List<string> GetIncomeTypeList()
        {
            //lay datatable
            string query = @"Select TenLoaiThu from LoaiThu";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<string> list = data.Rows.OfType<DataRow>().Select(dr => (string)dr["TENLOAITHU"]).ToList();
            // List<string> result = new List<string>();
            //foreach(DataRow row in data.Rows)
            //{
            //    result.Add(row.ToString());
            //}
            return list;
        }

        public List<int> GetWeekIncome()
        {
            DateTime date = DateTime.Now.Date;
            List<int> list = new List<int>();
            for (int i = 0; i < 7; i++)
            {
                int inDay = (int)DataProvider.Instance.ExecuteScalar("USP_GetTotalIncome @ThoiGian , @TENTK", new object[] { date, Form1.currUser });
                list.Add(inDay);

                date = date.AddDays(-1);
            }
            list.Reverse();
            return list;
        }
    }
}
