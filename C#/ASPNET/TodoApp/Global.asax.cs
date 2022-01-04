using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using TodoApp.Migrations;
using TodoApp.Models;

namespace TodoApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Configuration.Seed()Ç™ÉRÅ[ÉãÇ≥ÇÍÇÈÇÊÇ§Ç…Ç»ÇÈ
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ToDoItemContext, Configuration>());
        }
    }
}
