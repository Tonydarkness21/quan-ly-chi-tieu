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
    public partial class IncomeDetail : Form
    {

        private int status = 0;
        public IncomeDetail()
        {
            InitializeComponent();
            status = 0;
            IncomeDetailLoad();
        }

        public IncomeDetail(string maKhoanChi, string tenKhoanChi, string soTien, string tenLoaiChi, string tenVi, DateTime ngay)
        {
            InitializeComponent();
            status = 1;
            bunifuTextBox1.Text = maKhoanChi;
            txtBoxTenKhoanThu.Text = tenKhoanChi;
            txtBoxSoTien.Text = soTien;
            bunifuDropdown2.Text = tenLoaiChi;
            bunifuDropdown1.Text = tenVi;
            datetimepicker1.Value = ngay;
            IncomeDetailLoad();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IncomeDetail_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string tenKhoanThu = txtBoxTenKhoanThu.Text;
            int soTien = int.Parse(txtBoxSoTien.Text);
            string tenLoaiThu = bunifuDropdown2.Text;
            string tenVi = bunifuDropdown1.Text;
            DateTime ngay = datetimepicker1.Value.Date;

            if (status == 0)
            {
                string query = @"USP_AddIncome @TenKhoanThu , @SoTien , @TenLoaiThu , @Ngay , @TenVi , @TenTK";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenKhoanThu, soTien, tenLoaiThu, ngay, tenVi, Form1.currUser });
            }
            else
            {
                int maKhoanChi = int.Parse(bunifuTextBox1.Text);
                string query = @"USP_UpdateIncome @MaKhoanThu , @TenKhoanThu , @SoTien , @TenLoaiThu , @Ngay , @TenVi , @TenTK";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { maKhoanChi, tenKhoanThu, soTien, tenLoaiThu, ngay, tenVi, Form1.currUser });

            }
            this.Close();
        }

        public void IncomeDetailLoad()
        {   
            if (status == 0)
            {
                datetimepicker1.Value = DateTime.Now;

                List<string> listType = IncomeDAO.Instance.GetIncomeTypeList();
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

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            string tenKhoanThu = txtBoxTenKhoanThu.Text;
            int soTien = int.Parse(txtBoxSoTien.Text);
            string tenLoaiThu = bunifuDropdown2.Text;
            string tenVi = bunifuDropdown1.Text;
            DateTime ngay = datetimepicker1.Value.Date;

            if (status == 0)
            {
                string query = @"USP_AddIncome @TenKhoanThu , @SoTien , @TenLoaiThu , @Ngay , @TenVi , @TenTK";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenKhoanThu, soTien, tenLoaiThu, ngay, tenVi, Form1.currUser });
            }
            else
            {
                int maKhoanThu = int.Parse(bunifuTextBox1.Text);
                string query = @"USP_UpdateIncome @MaKhoanThu , @TenKhoanThu , @SoTien , @TenLoaiThu , @Ngay , @TenVi , @TenTK";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { maKhoanThu, tenKhoanThu, soTien, tenLoaiThu, ngay, tenVi, Form1.currUser });

            }
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
