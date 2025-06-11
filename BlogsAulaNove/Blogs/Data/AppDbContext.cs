﻿using Blogs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Blogs.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }

    }

}