using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Example14
{
    class SchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
