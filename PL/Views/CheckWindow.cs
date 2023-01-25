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
            foreach (var order in orderController.GetUsersOrders())
            {
                foreach (var pricelist in order.pricelistViewModels)
                {
                    listBoxOrders.Items.Add(pricelist.Dish.DishName);
                }
                //listBoxOrders.Items.Add(item);
            }

        }

        private void listBoxOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
