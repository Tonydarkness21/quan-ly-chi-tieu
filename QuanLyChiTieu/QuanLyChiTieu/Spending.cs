using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu
{
    public partial class Spending : Form
    {
        public Spending()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            SpendingDetail spendingDetail = new SpendingDetail();
            spendingDetail.ShowDialog();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            SpendingDetail spendingDetail = new SpendingDetail();
            spendingDetail.ShowDialog();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            SpendingDetail spendingDetail = new SpendingDetail();
            spendingDetail.ShowDialog();
        }
    }
}
