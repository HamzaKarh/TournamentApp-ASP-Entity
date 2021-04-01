
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace WebApplication2.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication2.Models.DBmodel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}