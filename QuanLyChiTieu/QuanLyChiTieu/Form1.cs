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
            Home home = new Home();
            home.TopLevel = false;
            home.Parent = this.bunifuPanel2 as Panel;
            home.Dock = DockStyle.Fill;
            bunifuPanel2.Controls.Add(home);
            home.Show();
        }
    }
}
