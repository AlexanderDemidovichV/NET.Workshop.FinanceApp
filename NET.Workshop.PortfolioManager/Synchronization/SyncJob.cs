using FluentScheduler;
using NET.Workshop.PortfolioManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace NET.Workshop.PortfolioManager.Synchronization
{
    public class SyncJob : IJob, IRegisteredObject
    {
        private readonly object _lock = new object();

        private bool _shuttingDown;

        public SyncJob()
        {
            // Register this job with the hosting environment.
            // Allows for a more graceful stop of the job, in the case of IIS shutting down.
            HostingEnvironment.RegisterObject(this);
        }

        public void Execute()
        {
            lock (_lock)
            {
                if (_shuttingDown)
                    return;

                PortfolioItemsStorage.Instance.Synchronize();
                // Do work, son!
            }
        }

        public void Stop(bool immediate)
        {
            // Locking here will wait for the lock in Execute to be released until this code can continue.
            lock (_lock)
            {
                _shuttingDown = true;
            }

            HostingEnvironment.UnregisterObject(this);
        }
    }
}