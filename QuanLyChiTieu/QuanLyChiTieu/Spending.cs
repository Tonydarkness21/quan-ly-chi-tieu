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
using System.Windows.Input;

namespace QuanLyChiTieu
{
    public partial class Spending : Form
    {
        public Spending()
        {
            InitializeComponent(); 
            LoadSpendingList();
        }

        void LoadSpendingList()
        {
            List <SpendingDTO> list = SpendingDAO.Instance.LoadSpendingList();
            foreach (SpendingDTO item in list)
            {
                ListViewItem lvItem = new ListViewItem(item.MaChi, ToString());
                lvItem.SubItems.Add(item.TenMucChi);
                lvItem.SubItems.Add(item.MaLoaiChi);
            }
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

        private void Spending_Load(object sender, EventArgs e)
        {
            ListViewItem lvItem = new ListViewItem("Học phí");
            lvItem.SubItems.Add("16000000");
            lvItem.SubItems.Add("V02");
            listView1.Items.Add(lvItem);
        }
    }
}
