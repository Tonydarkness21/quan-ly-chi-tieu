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
using System.Windows.Input;
using Utilities.BunifuCheckBox.Transitions;

namespace QuanLyChiTieu
{
    public partial class Spending : Form
    {
        public Spending()
        {
            InitializeComponent(); 
            LoadSpendingList();
        }

        void LoadSpendingList()
        {
          
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            SpendingDetail spendingDetail = new SpendingDetail();
            spendingDetail.ShowDialog();
            SpendingLoadData();


        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                List<Object> list = new List<Object>();
                foreach( DataGridViewCell i in selectedRow.Cells)
                {
                    list.Add(i.Value);
                }

                DateTime day = DateTime.Parse(selectedRow.Cells["ThoiGian"].Value.ToString());

                SpendingDetail spendingDetail = new SpendingDetail(list[0].ToString(), list[1].ToString(), list[2].ToString(),list[3].ToString(), list[5].ToString(), day);
                spendingDetail.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hay chon mot khoan chi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SpendingLoadData();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            SpendingDetail spendingDetail = new SpendingDetail();
            spendingDetail.ShowDialog();
        }

        private void Spending_Load(object sender, EventArgs e)
        {
            bunifuDatePicker1.Value = DateTime.Now;
            SpendingLoadData();
        }
        private void SpendingLoadData()
        { 
            //load datagridview
            DateTime day = bunifuDatePicker1.Value.Date;
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetSpendingTable @ThoiGian , @TENTK", new object[] { day, Form1.currUser });
            dataGridView1.DataSource = data;
            //label
            int total = (int)DataProvider.Instance.ExecuteScalar("USP_GetTotalSpending @ThoiGian , @TENTK", new object[] { day , Form1.currUser });
            label3.Text = total.ToString();
            //graph



            // Tạo và cấu hình Series
            List<int> values = SpendingDAO.Instance.GetWeekSpending();
            Series series = new Series("ChiTieu");
            series.ChartType = SeriesChartType.Column; // Loại biểu đồ cột
            series.Points.DataBindY(values); // Gán giá trị từ danh sách vào Series

            // Thêm Series vào Chart
            chart1.Series.Clear();
            chart1.Series.Add(series);
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            SpendingLoadData();
        }

        private void btnIncomeDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int maKhoanChi = int.Parse(selectedRow.Cells["MaKhoanChi"].Value.ToString());
                string query = @"USP_DeleteSpending @MaKhoanChi";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] {maKhoanChi });
                SpendingLoadData();

            }
            else
            {
                MessageBox.Show("Hay chon mot khoan chi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
