using NET.Workshop.PortfolioManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static NET.Workshop.PortfolioManager.Models.PortfolioItemViewModel;

namespace NET.Workshop.PortfolioManager.Infrastructure
{
    public static class PortfolioItemMapper
    {
        public static PortfolioItemViewModel ToStoragePortfolioItem(this PortfolioItemModel portfolioItem)
        {
            if (portfolioItem == null)
            {
                return null;
            }
            var portfolioItemViewModel = new PortfolioItemViewModel()
            {
                LocalItemId = portfolioItem.ItemId.GetHashCode(),
                ItemId = portfolioItem.ItemId,
                SharesNumber = portfolioItem.SharesNumber,
                Symbol = portfolioItem.Symbol,
                UserId = portfolioItem.UserId,
                Status = PortfolioItemStatus.None
        };

            return portfolioItemViewModel;
        }

        public static PortfolioItemModel ToModelPortfolioItem(this PortfolioItemViewModel portfolioItemViewModel)
        {
            if (portfolioItemViewModel == null)
            {
                return null;
            }

            var portfolioItem = new PortfolioItemModel()
            {
                
                ItemId = portfolioItemViewModel.ItemId,
                SharesNumber = portfolioItemViewModel.SharesNumber,
                Symbol = portfolioItemViewModel.Symbol,
                UserId = portfolioItemViewModel.UserId
            };

            return portfolioItem;
        }
    }
}