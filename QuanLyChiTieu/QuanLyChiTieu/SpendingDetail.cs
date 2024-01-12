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
    public partial class SpendingDetail : Form
    {
        public SpendingDetail()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string maChi = txtBoxMaChi.Text;
            string tenChi = txtBoxTenKhoanChi.Text;
            string soTien = txtBoxSoTien.Text;
            string maLoaiChi = bunifuTextBox1.Text;
            string date = datetimepicker1.Text;
            string maVi = bunifuDropdown2.Text;
            if (SpendingDAO.Instance.Add)
            MessageBox.Show("Thêm mới dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}
