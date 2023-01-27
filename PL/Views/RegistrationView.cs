using PL.Presenters;
using PL.Models;
using BLL.Interfaces;
using System;
using System.Windows.Forms;
using Ninject;
using Ninject.Modules;
using BLL.Infrastructure;

namespace PL.Views
{
    public partial class RegistrationView : Form
    {
        public event EventHandler RegistrationEvent;
        public RegistrationView()
        {
            InitializeComponent();

            buttonSignUp2.Click += delegate
            {
                RegistrationEvent?.Invoke(this, EventArgs.Empty);
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
