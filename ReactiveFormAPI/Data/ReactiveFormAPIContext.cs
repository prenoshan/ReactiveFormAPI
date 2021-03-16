using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReactiveFormAPI.Models;

namespace ReactiveFormAPI.Data
{
    public class ReactiveFormAPIContext : DbContext
    {
        public ReactiveFormAPIContext (DbContextOptions<ReactiveFormAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ReactiveFormAPI.Models.User> User { get; set; }
    }
}
