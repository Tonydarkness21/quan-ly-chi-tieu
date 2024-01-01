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
        public bool LoginFlag { get; private set; }
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(txtBoxUserName.Text) && !string.IsNullOrEmpty(txtBoxPassword.Text))
           {
                LoginFlag = true;
                panel2.Controls.Clear();
                Form1 mainForm = new Form1();
                mainForm.ShowDialog();
           }
        }

        private void txtBoxPassword_Enter(object sender, EventArgs e)
        {
            txtBoxPassword.UseSystemPasswordChar = true;
        }

        private void txtBoxPassword_Leave(object sender, EventArgs e)
        {
            // if user leaves password empty, show the placeholder text instead
            if (string.IsNullOrEmpty(txtBoxPassword.Text))
            {
                txtBoxPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
