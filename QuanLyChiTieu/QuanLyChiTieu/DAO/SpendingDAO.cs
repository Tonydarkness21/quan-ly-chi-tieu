﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public List<string> GetSpendingTypeList()
        {
            //lay datatable
            string query = @"Select TenLoaiChi from LoaiChi";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<string> list = data.Rows.OfType<DataRow>().Select(dr => (string)dr["TENLOAICHI"]).ToList();
           // List<string> result = new List<string>();
            //foreach(DataRow row in data.Rows)
            //{
            //    result.Add(row.ToString());
            //}
            return list;
        }

        public List<int> GetWeekSpending()
        {
            DateTime date = DateTime.Now.Date;
            List<int> list = new List<int>();
            for (int i = 0; i < 7; i++)
            {
                int inDay = (int)DataProvider.Instance.ExecuteScalar("USP_GetTotalSpending @ThoiGian , @TENTK", new object[] { date, Form1.currUser });
                list.Add(inDay);

                date = date.AddDays(-1);
            }
            list.Reverse();
            return list;    
        }
    }
}
