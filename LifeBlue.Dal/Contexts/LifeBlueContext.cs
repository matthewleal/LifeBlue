using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using LifeBlue.Dal.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LifeBlue.Dal.Contexts
{
    public class LifeBlueContext : DbContext
    {
        public LifeBlueContext(DbContextOptions<LifeBlueContext> options)
            : base(options)
        {
        }

        public DbSet<VisitorInformation> VisitorInformation { get; set; }
    }
}
