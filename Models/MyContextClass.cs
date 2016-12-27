using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularCRUD_Latest.Models
{
    public class MyContextClass : DbContext
    {
        public DbSet<Player> Players { get; set; }
    }
} 