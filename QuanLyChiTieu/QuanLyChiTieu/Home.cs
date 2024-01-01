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
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSpendingAdd_Click(object sender, EventArgs e)
        {
            SpendingDetail spendingDetail = new SpendingDetail();
            spendingDetail.ShowDialog();
        }
    }
}
