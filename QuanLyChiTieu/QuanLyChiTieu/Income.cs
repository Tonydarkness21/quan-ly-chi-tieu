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
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            IncomeDetail detail = new IncomeDetail();
            detail.ShowDialog();
            IncomeLoadData();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                List<Object> list = new List<Object>();
                foreach (DataGridViewCell i in selectedRow.Cells)
                {
                    list.Add(i.Value);
                }

                DateTime day = DateTime.Parse(selectedRow.Cells["ThoiGian"].Value.ToString());

                IncomeDetail incomeDetail = new IncomeDetail(list[0].ToString(), list[1].ToString(), list[2].ToString(), list[3].ToString(), list[5].ToString(), day);
                incomeDetail.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hay chon mot khoan chi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            IncomeLoadData();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            IncomeDetail detail = new IncomeDetail();
            detail.ShowDialog();
        }

        private void Income_Load(object sender, EventArgs e)
        {
            bunifuDatePicker1.Value = DateTime.Now;
            IncomeLoadData();
        }

        private void IncomeLoadData()
        {
            //load datagridview
            DateTime day = bunifuDatePicker1.Value.Date;
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetIncomeTable @ThoiGian , @TENTK", new object[] { day, Form1.currUser });
            dataGridView1.DataSource = data;
            //label
            int total = (int)DataProvider.Instance.ExecuteScalar("USP_GetTotalIncome @ThoiGian , @TENTK", new object[] { day, Form1.currUser });
            label3.Text = total.ToString();

            //graph
            // Tạo và cấu hình Series
            List<int> values = IncomeDAO.Instance.GetWeekIncome();
            Series series = new Series("ThuNhap");
            series.ChartType = SeriesChartType.Column; // Loại biểu đồ cột
            series.Points.DataBindY(values); // Gán giá trị từ danh sách vào Series

            // Thêm Series vào Chart
            chart1.Series.Clear();
            chart1.Series.Add(series);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int maKhoanThu = int.Parse(selectedRow.Cells["MaKhoanThu"].Value.ToString());
                string query = @"USP_DeleteIncome @MaKhoanThu";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { maKhoanThu });
                IncomeLoadData();

            }
            else
            {
                MessageBox.Show("Hay chon mot khoan thu", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
