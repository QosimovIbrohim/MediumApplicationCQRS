using Mediaum.Domain.Entities;
using Medium.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Infrastructure.Persistance
{
    public class MediumDbContext : DbContext, IApplicationDbContext
    {
        public MediumDbContext(DbContextOptions<MediumDbContext> ops)
           : base(ops)
        { }
        public DbSet<User> Users { get; set; }
    }
}
