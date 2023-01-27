using System;
using System.Windows.Forms;

namespace PL.Views
{
    public partial class LoginView : Form
    {
        public event EventHandler LoginEvent;
        public event EventHandler LoggedEvent;
        public LoginView()
        {
            InitializeComponent();

            buttonSignIn.Click += delegate
            {
                LoginEvent?.Invoke(this, EventArgs.Empty);
                LoggedEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public string Username
        {
            get => loginTextBox.Text;
            set => loginTextBox.Text = value;
        }

        public string Password
        {
            get => passwordTextBox.Text;
            set => passwordTextBox.Text = value;
        }
    }
}
