﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET.Workshop.PortfolioManager.Models
{
    public class PortfolioItemModel
    {
        public int ItemId { get; set; }

        public int UserId { get; set; }

        public string Symbol { get; set; }

        public int SharesNumber { get; set; }
    }
}