using NET.Workshop.PortfolioManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace NET.Workshop.PortfolioManager.Services
{
    public class UserStorage
    {
        private static readonly Lazy<UserStorage> _instance = new Lazy<UserStorage>(() => new UserStorage(), LazyThreadSafetyMode.PublicationOnly);

        private static PortfolioItemsService _portfolioItemsService = new PortfolioItemsService();
        private static UsersService _usersService = new UsersService();

        private List<UserViewModel> users = new List<UserViewModel>();

        UserStorage()
        { }


        public static UserStorage Instance { get { return _instance.Value; } }

        public void Add(UserViewModel user)
        {
            users.Add(user);
        }

        public bool IsUserExist(int id)
        {
            if (users.Find(u => u.Id == id) == null)
                return false;
            return true;
        }

        public List<UserViewModel> GetUsers()
        {
            return new List<UserViewModel>(users);
        }
    }
}