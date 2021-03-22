using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChetuProject.Models;

namespace ChetuProject.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("con") { }

        public DbSet<UserAccount> userAccounts { get; set; }

    }
}