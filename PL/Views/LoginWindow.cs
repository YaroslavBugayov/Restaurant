using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.Views
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {

        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            this.Close();
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }
    }
}
