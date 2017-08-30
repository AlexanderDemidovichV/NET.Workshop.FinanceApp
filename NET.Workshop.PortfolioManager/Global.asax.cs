using FluentScheduler;
using NET.Workshop.PortfolioManager.Synchronization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace NET.Workshop.PortfolioManager
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            JobManager.Initialize(new SchedulerRegistry());
        }
    }
}
