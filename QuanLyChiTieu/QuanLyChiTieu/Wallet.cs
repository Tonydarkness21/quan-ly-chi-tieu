using QuanLyChiTieu.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyChiTieu
{
    public partial class Wallet : Form
    {
        public Wallet()
        {
            InitializeComponent();
         
        } 

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            WalletDetail walletDetail = new WalletDetail();
            walletDetail.ShowDialog();
            WalletLoadData();
        }

        private void Wallet_Load(object sender, EventArgs e)
        {
            WalletLoadData();
        }    

        public void WalletLoadData()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetWalletInFo @TENTK", new object[] { Form1.currUser });
            dataGridView1.DataSource = data;

            DataTable money = DataProvider.Instance.ExecuteQuery("USP_GetAccountMoney @TENTK", new object[] { Form1.currUser });
            label4.Text = money.Rows[0][0].ToString();

            //graph
            List<int> values = AccountDAO.Instance.GetBalanceInWeek();
            Series series = new Series("SoDu");
            series.ChartType = SeriesChartType.Column; // Loại biểu đồ cột
            series.Points.DataBindY(values); // Gán giá trị từ danh sách vào Series

            // Thêm Series vào Chart
            chartSoDu.Series.Clear();
            chartSoDu.Series.Add(series);

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string walletName = selectedRow.Cells["TenVi"].Value.ToString();
                DataProvider.Instance.ExecuteNonQuery("USP_DeleteWallet @TenVi , @TenTK", new object[] { walletName, Form1.currUser });
                WalletLoadData();
            }
            else
            {
                MessageBox.Show("Hay chon mot vi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string walletName = selectedRow.Cells["TenVi"].Value.ToString();
                string balance = selectedRow.Cells["SoDu"].Value.ToString();
                WalletDetail walletDetail = new WalletDetail(walletName,balance);
                walletDetail.ShowDialog();
                WalletLoadData();
            }
            else
            {
                MessageBox.Show("Hay chon mot vi","",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
