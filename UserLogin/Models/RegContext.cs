using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserLogin.Models
{
    public class RegContext : DbContext
    {
        public RegContext(DbContextOptions<RegContext> options) : base(options)
        {

        }
        //dbset
     
        public DbSet<Registration> Registration { get; set; }

       
    }
}
