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

namespace QuanLyChiTieu
{
    public partial class WalletDetail : Form
    {
        private int status = 0;
        public WalletDetail()
        {
            InitializeComponent();
            status = 0;
        }

        public WalletDetail(string walletName,string balance)
        {
            InitializeComponent();
            status = 1;
            txtBoxTenVi.Text = walletName;
            txtBoxSoDu.Text = balance;
        }

        private void WalletDetail_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string walletName = txtBoxTenVi.Text;
            string balance = txtBoxSoDu.Text;
            if (this.status == 0)
            {
                DataProvider.Instance.ExecuteNonQuery("USP_AddWallet @TenVi , @TenTK , @SoDu", new object[] { walletName, Form1.currUser, balance });
            }
            else
            {
                DataProvider.Instance.ExecuteNonQuery("USP_UpdateWallet @TenVi , @SoDu , @TenTK", new object[] { walletName,  balance ,Form1.currUser});
            }
            this.Close();
        }
    }
}
