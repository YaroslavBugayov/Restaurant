using PL.Presenters;
using System;
using System.Windows.Forms;

namespace PL
{
    public partial class RestaurantView : Form
    {

        public event EventHandler LoadEvent;
        public event EventHandler SignOutEvent;
        public event EventHandler SignInEvent;
        public event EventHandler SignUpEvent;
        public event EventHandler AddOrderEvent;
        public event EventHandler RemoveOrderEvent;
        public event EventHandler IndexChangedEvent;
        public event EventHandler SendOrderEvent;
        public event EventHandler PreviousOrdersEvent;

        public RestaurantView()
        {
            InitializeComponent();

            Load += delegate
            {
                LoadEvent?.Invoke(this, EventArgs.Empty);
                buttonSignOut.Hide();
                panelOrder.Hide();
                buttonPreviousOrders.Hide();
            };

            buttonSignOut.Click += delegate
            {
                SignOutEvent?.Invoke(this, EventArgs.Empty);
                buttonSignIn.Show();
                buttonSignUp.Show();
                buttonSignOut.Hide();
                buttonPreviousOrders.Show();
            };

            buttonSignIn.Click += delegate
            {
                SignInEvent?.Invoke(this, EventArgs.Empty);
            };

            buttonSignUp.Click += delegate
            {
                SignUpEvent?.Invoke(this, EventArgs.Empty);
            };

            buttonCreateOrder.Click += delegate
            {
                panelOrder.Show();
            };

            buttonAddOrder.Click += delegate
            {
                AddOrderEvent?.Invoke(this, EventArgs.Empty);
                panelOrder.Hide();
            };

            buttonRemoveOrder.Click += delegate
            {
                RemoveOrderEvent?.Invoke(this, EventArgs.Empty);
            };

            comboBoxDishes.SelectedIndexChanged += delegate
            {
                IndexChangedEvent?.Invoke(this, EventArgs.Empty);
            };

            buttonPreviousOrders.Click += delegate
            {
                PreviousOrdersEvent?.Invoke(this, EventArgs.Empty);
            };

            buttonSendOrders.Click += delegate
            {
                SendOrderEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public new void Show()
        {
            Application.Run(this);
        }

        public string Username { set => labelUserName.Text = value; }

        public string ComboBoxDishesItem
        {
            set => comboBoxDishes.Items.Add(value);
            get => comboBoxDishes.SelectedItem.ToString();
        }

        public int ComboBoxDishesIndex
        {
            get => comboBoxDishes.SelectedIndex;
        }

        public void ListBoxOrdersClear()
        {
            listBoxOrders.Items.Clear();
        }

        public string ListBoxOrdersItem
        {
            set => listBoxOrders.Items.Add(value);
            get => listBoxOrders.SelectedItem.ToString();
        }

        public int ListBoxOrdersIndex
        {
            get => listBoxOrders.SelectedIndex;
        }

        public int ListBoxOrdersRemoveIndex
        {
            set => listBoxOrders.Items.RemoveAt(ListBoxOrdersIndex);
        }

        public int Price
        {
            set => labelPrice.Text = value.ToString();
            get => int.Parse(labelPrice.Text);
        }

        public string ResultOrder
        {
            set => labelResultOrder.Text = value;
        }

        public void loggedIntoAccount()
        {
            buttonSignIn.Hide();
            buttonSignUp.Hide();
            buttonSignOut.Show();
            buttonPreviousOrders.Show();
        }
    }
}
