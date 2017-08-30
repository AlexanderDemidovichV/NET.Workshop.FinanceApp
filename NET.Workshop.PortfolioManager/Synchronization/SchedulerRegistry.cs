using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET.Workshop.PortfolioManager.Synchronization
{
    public class SchedulerRegistry : Registry
    {
        private static readonly int defaultSyncTime = 60;

        public SchedulerRegistry()
        {
            Schedule<SyncJob>().ToRunEvery(defaultSyncTime).Seconds();
        }
    }
}