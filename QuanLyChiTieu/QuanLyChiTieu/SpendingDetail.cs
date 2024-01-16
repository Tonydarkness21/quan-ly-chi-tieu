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
        private int status = 0;
        public SpendingDetail()
        {
            InitializeComponent();
            status = 0;
            SpendingDetailLoad();
        }
        public SpendingDetail(string maKhoanChi,string tenKhoanChi,string soTien,string tenLoaiChi,string tenVi,DateTime ngay)
        {
            InitializeComponent();
            status = 1;
            bunifuTextBox1.Text = maKhoanChi;
            txtBoxTenKhoanChi.Text = tenKhoanChi;
            txtBoxSoTien.Text = soTien;
            bunifuDropdown2.Text = tenLoaiChi;
            bunifuDropdown1.Text = tenVi;
            datetimepicker1.Value = ngay;
            SpendingDetailLoad();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            string tenKhoanChi = txtBoxTenKhoanChi.Text;
            int soTien = int.Parse(txtBoxSoTien.Text);
            string tenLoaiChi = bunifuDropdown2.Text;
            string tenVi = bunifuDropdown1.Text;
            DateTime ngay = datetimepicker1.Value.Date;

            if(status == 0)
            {
                string query = @"USP_AddSpending @TenKhoanChi , @SoTien , @TenLoaiChi , @Ngay , @TenVi , @TenTK";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenKhoanChi, soTien, tenLoaiChi, ngay, tenVi, Form1.currUser });
            }
            else
            {
                int maKhoanChi = int.Parse(bunifuTextBox1.Text);
                string query = @"USP_UpdateSpending @MaKhoanChi , @TenKhoanChi , @SoTien , @TenLoaiChi , @Ngay , @TenVi , @TenTK";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { maKhoanChi,tenKhoanChi, soTien, tenLoaiChi, ngay, tenVi, Form1.currUser });

            }
            this.Close();
        }

        private void SpendingDetail_Load(object sender, EventArgs e)
        {
        }

        public void SpendingDetailLoad()
        {
            if(status == 0)
            {
                datetimepicker1.Value = DateTime.Now;

                List<string> listType = SpendingDAO.Instance.GetSpendingTypeList();
                bunifuDropdown2.Items.AddRange(listType.ToArray());
            }
            else
            {

            }
            List<string> walletList = WalletDAO.Instance.GetWallets();
            bunifuDropdown1.Items.AddRange(walletList.ToArray());
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
