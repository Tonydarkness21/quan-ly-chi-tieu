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
    public partial class Login2 : Form
    {
        public Login2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Signup signup = new Signup();
            signup.TopLevel = false;
            signup.Parent = this.panel2 as Panel;
            signup.Dock = DockStyle.Fill;
            panel2.Controls.Add(signup);
            signup.Show();
        }
    }
}
