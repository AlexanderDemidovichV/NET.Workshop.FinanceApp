using NET.Workshop.PortfolioManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace NET.Workshop.PortfolioManager.Services
{
    public class PortfolioItemsStorage
    {
        private static readonly Lazy<PortfolioItemsStorage> _instance = new Lazy<PortfolioItemsStorage>(() => new PortfolioItemsStorage(), LazyThreadSafetyMode.PublicationOnly);

        private static PortfolioItemsService _portfolioItemsService = new PortfolioItemsService();
        private static UsersService _usersService = new UsersService();

        private List<PortfolioItemViewModel> portfolioItems = new List<PortfolioItemViewModel>();

        PortfolioItemsStorage()
        { }

        static PortfolioItemsStorage()
        {

        }

        public static PortfolioItemsStorage Instance { get { return _instance.Value; } }

        public List<PortfolioItemViewModel> GetContacts(int userId)
        {
            return Instance.portfolioItems.FindAll(p => p.UserId == userId);
        }

        public void UpdateUserPortfolio(int userId)
        {
            _instance.Value.portfolioItems.AddRange(_portfolioItemsService.GetItems(userId));
        }

        public int GetContactsCount()
        {
            return Instance.portfolioItems.Count;
        }

        public PortfolioItemViewModel Add(PortfolioItemViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("newContact");
            }
            Instance.portfolioItems.Add(item);
            return item;
        }

        public bool Update(PortfolioItemViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("newContact");
            }
            int index = Instance.portfolioItems.FindIndex(p => p.ItemId == item.ItemId);
            if (index == -1)
            {
                return false;
            }
            Instance.portfolioItems.RemoveAt(index);
            Instance.portfolioItems.Add(item);
            return true;
        }

        public void Remove(int id)
        {
            Instance.portfolioItems.RemoveAll(p => p.ItemId == id);
        }
    }
}