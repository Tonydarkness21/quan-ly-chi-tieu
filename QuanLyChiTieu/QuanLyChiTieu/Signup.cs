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
    public partial class Signup : Form
    {
        private string _username;
        private string _password;

        public string Username { get; set; }
        public string Password { get; set; }
        public Signup()
        {
            InitializeComponent();
        }


        private void label2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Login2 login2 = new Login2();
            login2.TopLevel = false;
            login2.Parent = this.panel2 as Panel;
            login2.Dock = DockStyle.Fill;
            panel2.Controls.Add(login2);
            login2.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string passsword = txtBoxCreatePassword.Text;
            string confirmPassword = txtBoxConfirmPassword.Text;

            if (passsword != confirmPassword)
            {
                errorProvider1.SetError(txtBoxUsername, "Mật khẩu không trùng nhau!");
                errorProvider1.SetIconAlignment(txtBoxUsername, ErrorIconAlignment.MiddleRight);
            }
            else
            {
                errorProvider1.Clear();
                Username = txtBoxUsername.Text;
                Password = txtBoxConfirmPassword.Text;
                
                if (AccountDAO.Instance.AddAccount(Username, Password))
                {
                    MessageBox.Show("Đăng ký tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void txtBoxConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.Focus();
            }
        }

        private void txtBoxCreatePassword_Enter(object sender, EventArgs e)
        {
            // Add a layer of security by hiding the password on the interface
            txtBoxCreatePassword.UseSystemPasswordChar = true;
        }

        private void txtBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            // Add a layer of security by hiding the password on the interface
            txtBoxConfirmPassword.UseSystemPasswordChar = true;
        }

        private void txtBoxCreatePassword_Leave(object sender, EventArgs e)
        {
            // If user leaves password empty, return to show placeholder text
            if (string.IsNullOrEmpty(txtBoxCreatePassword.Text))
            {
                txtBoxCreatePassword.UseSystemPasswordChar = false;
            }
        }

        private void txtBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            // If user leaves password empty, return to show placeholder text
            if (string.IsNullOrEmpty(txtBoxConfirmPassword.Text))
            {
                txtBoxConfirmPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnShowPasswordConfirm_Click(object sender, EventArgs e)
        {
            txtBoxConfirmPassword.UseSystemPasswordChar = false;
        }

        private void btnShowPasswordCreate_Click(object sender, EventArgs e)
        {
            txtBoxCreatePassword.UseSystemPasswordChar = false;
        }
    }
}
