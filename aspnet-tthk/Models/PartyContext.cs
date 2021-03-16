using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace aspnet_tthk.Models
{
    public class PartyContext : DbContext
    {
        public DbSet<Party> Parties { get; set; }
    }
}