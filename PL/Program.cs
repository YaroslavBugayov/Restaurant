using PL.Presenters;
using System;
using System.Windows.Forms;

namespace PL
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var restaurantPresenter = new RestaurantPresenter(new RestaurantView());
            restaurantPresenter.Run();
        }
    }
}
