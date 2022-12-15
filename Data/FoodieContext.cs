﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodieBlog.Models;

    public class FoodieContext : DbContext
    {
        public FoodieContext (DbContextOptions<FoodieContext> options)
            : base(options)
        {
        }

        public DbSet<FoodieBlog.Models.Recipe> Recipe { get; set; }
    }
