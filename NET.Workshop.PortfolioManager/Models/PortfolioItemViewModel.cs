namespace NET.Workshop.PortfolioManager.Models
{
    public class PortfolioItemViewModel
    {
        public int ItemId { get; set; }

        public int LocalItemId { get; set; }

        public int UserId { get; set; }

        public string Symbol { get; set; }

        public int SharesNumber { get; set; }

        public PortfolioItemStatus Status { get; set; }

        public enum PortfolioItemStatus
        {
            None,
            Add,
            Delete,
            Update
        }
    }

   
}