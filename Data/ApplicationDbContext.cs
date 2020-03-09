using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EF_CoreApp.Models;

namespace EF_CoreApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostsToUser> PostsToUser { get; set; }
        public DbSet<PostsToCategory> PostsToCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//Обязательно вставьте при добавлении новых таблиц в БД

            modelBuilder.Entity<PostsToUser>(b =>
            {
                b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");
                b.Property<int>("PostId")
                        .HasColumnType("int");
                b.HasKey("UserId", "PostId");
                b.HasIndex("PostId");
                b.ToTable("PostsToUser");

            });

            modelBuilder.Entity<PostsToCategory>(b =>
            {
                b.Property<int>("CategoryId")
                        .HasColumnType("int");
                b.Property<int>("PostId")
                        .HasColumnType("int");
                b.HasKey("CategoryId", "PostId");
                b.HasIndex("PostId");
                b.ToTable("PostsToCategory");
            });
        }

    }
}

