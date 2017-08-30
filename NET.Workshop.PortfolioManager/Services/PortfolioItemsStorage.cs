using NET.Workshop.PortfolioManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using static NET.Workshop.PortfolioManager.Models.PortfolioItemViewModel;
using NET.Workshop.PortfolioManager.Infrastructure;


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
            return Instance.portfolioItems.FindAll(p => (p.UserId == userId) && (p.Status != PortfolioItemStatus.Delete));
        }

        public void UpdateUserPortfolio(int userId)
        {
            _instance.Value.portfolioItems.AddRange(_portfolioItemsService.GetItems(userId).Select(i => i.ToStoragePortfolioItem()));
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
            item.Status = PortfolioItemStatus.Add;
            item.LocalItemId = Guid.NewGuid().GetHashCode();
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
            item.Status = PortfolioItemStatus.Update;
            Instance.portfolioItems.RemoveAt(index);
            Instance.portfolioItems.Add(item);
            return true;
        }

        public void Remove(int id)
        {
            var item = portfolioItems.Find(e => e.LocalItemId == id);
            item.Status = PortfolioItemStatus.Delete;

        }

        public void Synchronize()
        {
            var users = UserStorage.Instance.GetUsers();

            foreach (UserViewModel user in users)
            {
                IList<PortfolioItemViewModel> bufferStorage = PortfolioItemsStorage.Instance.GetContacts(user.Id);


                foreach (var item in bufferStorage)
                {
                    switch (item.Status)
                    {
                        case PortfolioItemStatus.Add:
                            _portfolioItemsService.CreateItem(item.ToModelPortfolioItem());
                            item.Status = PortfolioItemStatus.None;
                            break;
                        case PortfolioItemStatus.Update:
                            _portfolioItemsService.UpdateItem(item.ToModelPortfolioItem());
                            item.Status = PortfolioItemStatus.None;
                            break;
                        case PortfolioItemStatus.Delete:
                            if (item.ItemId == 0)
                                break;
                            _portfolioItemsService.DeleteItem(item.ItemId);
                            portfolioItems.Remove(item);
                            break;
                    }
                }
            }
        }

        private class PortfolioItemViewModelComparer : IEqualityComparer<PortfolioItemViewModel>
        {
            public bool Equals(PortfolioItemViewModel x, PortfolioItemViewModel y)
            {
                if ((x.SharesNumber == y.SharesNumber) && (x.Symbol == y.Symbol) && (x.UserId == y.UserId))
                {
                    return true;
                }
                return false;
            }

            public int GetHashCode(PortfolioItemViewModel obj)
            {
                return obj.UserId.GetHashCode();
            }
        }
    }
}