using System;
using System.Windows.Forms;

namespace PL.Views
{
    public partial class RegistrationView : Form
    {
        public event EventHandler RegistrationEvent;
        public event EventHandler LoggedEvent;
        public RegistrationView()
        {
            InitializeComponent();

            buttonSignUp2.Click += delegate
            {
                RegistrationEvent?.Invoke(this, EventArgs.Empty);
                LoggedEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public string Username
        {
            get => textBoxUsername.Text;
            set => textBoxUsername.Text = value;
        }

        public string Password
        {
            get => textBoxPassword.Text;
            set => textBoxPassword.Text = value;
        }

        public string Email
        {
            get => textBoxEmail.Text;
            set => textBoxEmail.Text = value;
        }

        public string FirstName
        {
            get => textBoxFirstName.Text;
            set => textBoxFirstName.Text = value;
        }

        public string LastName
        {
            get => textBoxLastName.Text;
            set => textBoxLastName.Text = value;
        }

    }
}
