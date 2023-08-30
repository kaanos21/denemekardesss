using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace denemekardesss.Models
{
    public partial class StajProjectContext : DbContext
    {
        public StajProjectContext()
        {
        }

        public StajProjectContext(DbContextOptions<StajProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<MenuName> MenuNames { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderList> OrderLists { get; set; } = null!;
        public virtual DbSet<OrderSituation> OrderSituations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
		public object StajProject { get; internal set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=StajProject;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.Explanition).HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Food_Category");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_Food_MenuName");
            });

            modelBuilder.Entity<MenuName>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("MenuName");

                entity.Property(e => e.MenuName1)
                    .HasMaxLength(50)
                    .HasColumnName("MenuName");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Time).HasColumnType("smalldatetime");

                entity.HasOne(d => d.OrderSituation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderSituationId)
                    .HasConstraintName("FK_Order_OrderSituation");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderList>(entity =>
            {
                entity.ToTable("OrderList");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.OrderLists)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_OrderList_Food");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLists)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderList_Order");
            });

            modelBuilder.Entity<OrderSituation>(entity =>
            {
                entity.ToTable("OrderSituation");

                entity.Property(e => e.Situation)
                    .HasMaxLength(50)
                    .HasColumnName("situation");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserPassword).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
