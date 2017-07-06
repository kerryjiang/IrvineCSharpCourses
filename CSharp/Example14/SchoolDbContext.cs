using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace Example14
{
    class SchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;user id=root;password=123456;persistsecurityinfo=True;database=School;");
        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
