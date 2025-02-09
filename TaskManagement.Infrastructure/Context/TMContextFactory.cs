using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.Context
{
        public class TMContextFactory : IDesignTimeDbContextFactory<TMContext>
        {
            public TMContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<TMContext>();

                optionsBuilder.UseSqlServer("Server=.;Database=TaskManagementDb;Trusted_Connection=True;Encrypt=false");

                return new TMContext(optionsBuilder.Options);
            }
        }
}
