using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PL.Views
{
    public partial class CheckView : Form
    {
        public event EventHandler FillDataGridEvent;
        public CheckView()
        {
            InitializeComponent();
            Load += delegate { FillDataGridEvent?.Invoke(this, EventArgs.Empty); };
        }

        public IEnumerable<string> DataGridView
        {
            set 
            {
                foreach (var item in value) 
                {
                    dataGridViewOrders.Rows.Add(item);
                }
            }
        }
        
    }
}
