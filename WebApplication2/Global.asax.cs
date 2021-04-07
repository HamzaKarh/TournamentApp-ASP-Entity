﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication2.Models;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            using (DBmodel db = new DBmodel())
            {
                if (db.userRoles.Count() == 0)
                {
                    var userRole1 = new userRole();
                    var userRole2 = new userRole();

                    userRole1.role_name = "user";
                    userRole2.role_name = "admin";

                    db.userRoles.Add(userRole1);
                    db.userRoles.Add(userRole2);
                    db.SaveChanges();

                }
            }
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<DBmodel>(new DropCreateDatabaseIfModelChanges<DBmodel>());
        }
    }
}
