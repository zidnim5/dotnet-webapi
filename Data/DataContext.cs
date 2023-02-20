using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet_webapi.Models;

namespace dotnet_webapi.Data
{
     public class DataContext : DbContext
     {
          public DataContext(DbContextOptions<DataContext> options) : base(options)
          {

          }

          public DbSet<Character> Characters { get; set; }
     }
}