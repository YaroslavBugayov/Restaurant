using BLL.Infrastructure;
using BLL.Services;
using Ninject;
using PL.Views;
using System;
using System.Collections.Generic;
using BLL.DTO;
using PL.Models;

namespace PL.Presenters
{
    internal class CheckPresenter
    {
        private CheckView view;
        private static IOrderService orderService;
        public CheckPresenter(CheckView view) 
        {
            this.view = view;
            IKernel ninjectKernel = new StandardKernel(new NinjectBindings());
            orderService = ninjectKernel.Get<IOrderService>();

            this.view.FillDataGridEvent += FillDataGrid;
            this.view.Show();
        }

        private void FillDataGrid(object sender, EventArgs e)
        {
            var ordersList = new List<string>();
            var orderModels = MapperPresenter
                .OrderDTOtoModelMapper
                .Map<IEnumerable<OrderDTO>, IEnumerable<OrderModel>>
                (orderService.GetUsersOrders(AuthorizedUserPresenter.Get().Id));

            foreach (var order in orderModels)
            {
                string output = "";
                foreach (var pricelist in order.pricelistModels)
                {
                    output += (string.Format("{0}, {1}, {2}\n",
                        pricelist.Size.SizeName, pricelist.Dish.DishName, pricelist.Price));
                }
                ordersList.Add(string.Format("{0}\nSummary price: {1}", output, order.Price));
            }

            view.DataGridView = ordersList;
        }
    }
}
