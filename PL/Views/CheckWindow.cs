using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using Ninject;
using PL.Controllers;
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
    public partial class CheckWindow : Form
    {
        private static IOrderService orderService;
        private static OrderController orderController;
        public CheckWindow()
        {
            InitializeComponent();
            NinjectModule dependencies = new NinjectDependenciesModule();
            IKernel ninjectKernel = new StandardKernel(dependencies);
            orderService = ninjectKernel.Get<IOrderService>();
            orderController = new OrderController(orderService);
        }

        private void CheckWindow_Load(object sender, EventArgs e)
        {
            dataGridViewOrders.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            foreach (var order in orderController.GetUsersOrders())
            {
                string output = "";
                foreach (var pricelist in order.pricelistViewModels)
                {
                    output += (string.Format("{0}, {1}, {2}\n", 
                        pricelist.Size.SizeName, pricelist.Dish.DishName, pricelist.Price));
                }
                dataGridViewOrders.Rows.Add(string.Format("{0}\nSummary price: {1}", output, order.Price));
            }

        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
