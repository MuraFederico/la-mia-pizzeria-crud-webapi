﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Areas.Identity.Data;

public class BlogContext : IdentityDbContext<IdentityUser>
{
    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<la_mia_pizzeria_static.Models.Category>? Category { get; set; }
}
