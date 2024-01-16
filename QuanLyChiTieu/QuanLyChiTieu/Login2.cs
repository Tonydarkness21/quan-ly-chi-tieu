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

        private void btnLogin_Click(object sender, EventArgs e)
        {
           string username = txtBoxUserName.Text;
           string password = txtBoxPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Validating if something is wrong with account, e.g can't find the account in the database
            else if (!LoginAuthorization(username, password))
            {
                MessageBox.Show("Không tìm thấy dữ liệu tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Else if everything succeeded, grant user the main form.
            else
            {    
                panel2.Controls.Clear();
                Form1 mainForm = new Form1();
                Form1.currUser = username;
                mainForm.UpdateBalance();
                mainForm.ShowDialog();
            }
        }

        bool LoginAuthorization(string username, string password)
        {
            return AccountDAO.Instance.LoginCheck(username, password);
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

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            // Click on button to show password
            txtBoxPassword.UseSystemPasswordChar = false;
        }

        private void txtBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }
    }
}
