using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace aspnet_tthk.Models
{
    public class PartyDbInitializer : CreateDatabaseIfNotExists<PartyContext>
    {
        protected override void Seed(PartyContext pdb)
        {
            base.Seed(pdb);
        }
    }
}