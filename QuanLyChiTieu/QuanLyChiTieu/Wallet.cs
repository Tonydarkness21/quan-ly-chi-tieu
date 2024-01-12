using QuanLyChiTieu.DAO;
using QuanLyChiTieu.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyChiTieu
{
    public partial class Wallet : Form
    {
        public Wallet()
        {
            InitializeComponent();
            LoadWalletList();
        }

        void LoadWalletList()
        {
            int Tong = 0;
            List<WalletDTO> list = WalletDAO.Instance.LoadWalletList();
            foreach (WalletDTO wallet in list)
            {
                ListViewItem lvItem = new ListViewItem(wallet.MaVi, ToString());
                lvItem.SubItems.Add(wallet.TenVi.ToString());
                lvItem.SubItems.Add(wallet.SoDu.ToString());
                listView1.Items.Add(lvItem);
                Tong += (int)Convert.ToDouble(wallet.SoDu);
            }
            label4.Text = Tong.ToString();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            WalletDetail walletDetail = new WalletDetail();
            walletDetail.ShowDialog();
        }

        private void Wallet_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) { return; }
            listView1.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) { return; }
            string MaViCanXoa = listView1.SelectedItems[0].Text;
            WalletDAO.Instance.DeleteWallet(MaViCanXoa);
            MessageBox.Show("Đã xóa ví thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            listView1.Refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) { return; }
            string mavi = listView1.SelectedItems[0].Text;
            WalletDetail walletDetail = new WalletDetail(mavi);
            walletDetail.ShowDialog();
        }
    }
}
