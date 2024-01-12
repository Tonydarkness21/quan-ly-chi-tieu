using QuanLyChiTieu.DAO;
using QuanLyChiTieu.DTO;
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
        public WalletDetail()
        {
            InitializeComponent();
        }

        public WalletDetail(string mavi)
        {
            InitializeComponent();
            txtBoxMaVi.Text = mavi;
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
            WalletDTO wallet = new WalletDTO(txtBoxMaVi.Text, txtBoxTenVi.Text, txtBoxTenTK.Text, txtBoxSoDu.Text);

            if (string.IsNullOrEmpty(wallet.TenVi) || string.IsNullOrEmpty(wallet.MaVi) || 
                string.IsNullOrEmpty(wallet.TenTK) || string.IsNullOrEmpty(wallet.SoDu) )
            {
                errorProvider1.SetError(txtBoxMaVi, "Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                errorProvider1.Clear();
                if (WalletDAO.Instance.AddWallet(wallet))
                {
                    MessageBox.Show("Thêm mới ví thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm mới ví thất bại, vui lòng kiểm tra lại thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
