using PL.Models;

namespace PL.Presenters
{
    internal static class AuthorizedUserPresenter
    {
        private static UserModel user;
        public static UserModel Get()
        {
            return user;
        }

        public static void Set(UserModel userModel) 
        {
            user = userModel;
        }
    }
}
