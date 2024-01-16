using QuanLyChiTieu.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyChiTieu
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            IncomeDetail detail = new IncomeDetail();
            detail.ShowDialog();
            HomeLoadData();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSpendingAdd_Click(object sender, EventArgs e)
        {
            SpendingDetail spendingDetail = new SpendingDetail();
            spendingDetail.ShowDialog();
            //label
            HomeLoadData();
        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            HomeLoadData();
        }
        private void HomeLoadData()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetWalletInfo @TENTK", new object[] { Form1.currUser });
            dataGridView1.DataSource = data;

            DataTable money = DataProvider.Instance.ExecuteQuery("USP_GetAccountMoney @TENTK", new object[] { Form1.currUser });
            label13.Text = money.Rows[0][0].ToString();
            //label spending
            int total = (int)DataProvider.Instance.ExecuteScalar("USP_GetTotalSpending @ThoiGian , @TENTK", new object[] { DateTime.Now.Date, Form1.currUser });
            label5.Text = total.ToString();
            //label Income
            //label
            int total2 = (int)DataProvider.Instance.ExecuteScalar("USP_GetTotalIncome @ThoiGian , @TENTK", new object[] { DateTime.Now.Date, Form1.currUser });
            label4.Text = total2.ToString();

            //graph
            GraphLoad();
        }

        private void GraphLoad()
        {
            // Tạo và cấu hình Series
            List<int> values = SpendingDAO.Instance.GetWeekSpending();
            Series series = new Series("ChiTieu");
            series.ChartType = SeriesChartType.Column; // Loại biểu đồ cột
            series.Points.DataBindY(values); // Gán giá trị từ danh sách vào Series

            // Thêm Series vào Chart
            chart1.Series.Clear();
            chart1.Series.Add(series);
        }
    }
}
