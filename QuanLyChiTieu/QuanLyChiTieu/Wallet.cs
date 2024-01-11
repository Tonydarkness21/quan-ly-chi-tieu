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
    public partial class Wallet : Form
    {
        public Wallet()
        {
            InitializeComponent();
            //LoadWalletList();
        }

        void LoadWalletList()
        {
            string query = "EXEC USP_LoadWallet";
            dtgvWallet.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            WalletDetail walletDetail = new WalletDetail();
            walletDetail.ShowDialog();
        }
    }
}
