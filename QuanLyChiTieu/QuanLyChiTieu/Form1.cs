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
    public partial class Form1 : Form
    {
        int move;
        int moveX;
        int moveY;
        public static string currUser;
        public bool isMinimized = false;
        public Form1()
        {
            InitializeComponent();
            bunifuButton1.Select();
            EventArgs e = new EventArgs();
            bunifuButton1_Click(this, e);
        }

        private void x_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        { 

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuPanel1.Dock = DockStyle.None; // Un-dock
                bunifuPanel2.Dock = DockStyle.None;
                this.WindowState = FormWindowState.Minimized;
                isMinimized = true;
            }
            catch (Exception)
            {
                //...
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            
            bunifuPanel2.Controls.Clear();
            Home home = new Home();
            home.TopLevel = false;
            home.Parent = this.bunifuPanel2 as Panel;
            home.Dock = DockStyle.Fill;
            bunifuPanel2.Controls.Add(home);
            home.Show();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Controls.Clear();
            Wallet wallet = new Wallet();
            wallet.TopLevel = false;
            wallet.Parent = this.bunifuPanel2 as Panel;
            wallet.Dock = DockStyle.Fill;
            bunifuPanel2 .Controls.Add(wallet);
            wallet.Show();
        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            bunifuPanel2.Controls.Clear();
            Income income = new Income();
            income.TopLevel = false;
            income.Parent = this.bunifuPanel2 as Panel;
            income.Dock = DockStyle.Fill;
            bunifuPanel2.Controls.Add(income);
            income.Show();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Controls.Clear();
            Spending spending = new Spending();
            spending.TopLevel = false;
            spending.Parent = this.bunifuPanel2 as Panel;
            spending.Dock = DockStyle.Fill;
            bunifuPanel2.Controls.Add(spending);
            spending.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            moveX=e.X;
            moveY=e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(move == 1)
            {
                this.SetDesktopLocation(MousePosition.X-moveX, MousePosition.Y-moveY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
            move = 0;
            move = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        public void UpdateBalance()
        {
            DataProvider.Instance.ExecuteNonQuery("USP_UpdateBalance @TenTK", new object[] { currUser });
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
