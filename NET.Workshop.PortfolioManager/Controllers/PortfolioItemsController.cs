using NET.Workshop.PortfolioManager.Models;
using NET.Workshop.PortfolioManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NET.Workshop.PortfolioManager.Controllers
{
    /// <summary>
    /// Processes portfolio item requests.
    /// </summary>
    public class PortfolioItemsController : ApiController
    {
        private readonly UsersService _usersService = new UsersService();

        /// <summary>
        /// Returns all portfolio items for the current user.
        /// </summary>
        /// <returns>The list of portfolio items.</returns>
        public IList<PortfolioItemViewModel> Get()
        {
            var userId = _usersService.GetOrCreateUser();
            return PortfolioItemsStorage.Instance.GetPortfolioItems(userId);
        }

        /// <summary>
        /// Updates the existing portfolio item.
        /// </summary>
        /// <param name="portfolioItem">The portfolio item to update.</param>
        public void Put(PortfolioItemViewModel portfolioItem)
        {
            portfolioItem.UserId = _usersService.GetOrCreateUser();
            PortfolioItemsStorage.Instance.Update(portfolioItem);
        }

        /// <summary>
        /// Deletes the specified portfolio item.
        /// </summary>
        /// <param name="id">The portfolio item identifier.</param>
        public void Delete(int id)
        {
            PortfolioItemsStorage.Instance.Remove(id);
        }

        /// <summary>
        /// Creates a new portfolio item.
        /// </summary>
        /// <param name="portfolioItem">The portfolio item to create.</param>
        public void Post(PortfolioItemViewModel portfolioItem)
        {
            portfolioItem.UserId = _usersService.GetOrCreateUser();
            PortfolioItemsStorage.Instance.Add(portfolioItem);
        }
    }
}
