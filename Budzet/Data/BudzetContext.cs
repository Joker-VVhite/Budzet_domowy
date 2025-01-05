﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Budzet.Models;

namespace Budzet.Data
{
    public class BudzetContext : DbContext
    {
        public BudzetContext (DbContextOptions<BudzetContext> options)
            : base(options)
        {
        }

        public DbSet<Budzet.Models.Transaction> Transaction { get; set; } = default!;
    }
}