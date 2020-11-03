using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DigitalWare.Model.Models
{
    public partial class BillingContext : DbContext
    {
        public BillingContext()
        {
        }

        public BillingContext(DbContextOptions<BillingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesClient> SalesClient { get; set; }
        public virtual DbSet<SalesProduct> SalesProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VK4N18O\\SQLEXPRESS;Database=Billing;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.IdentificationNumber).HasColumnName("identification_number");

                entity.Property(e => e.NameClient)
                    .HasColumnName("name_client")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone).HasColumnName("telephone");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.IdInventory);

                entity.Property(e => e.IdInventory).HasColumnName("id_inventory");

                entity.Property(e => e.IdProduc).HasColumnName("id_produc");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdProducNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.IdProduc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__id_pr__38996AB5");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.IdProduc);

                entity.Property(e => e.IdProduc).HasColumnName("id_produc");

                entity.Property(e => e.DescriptionProduc)
                    .HasColumnName("description_produc")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameProduct)
                    .HasColumnName("name_product")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PriceProduct).HasColumnName("price_product");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.IdSales);

                entity.Property(e => e.IdSales).HasColumnName("id_sales");

                entity.Property(e => e.DateSales)
                    .HasColumnName("date_sales")
                    .HasColumnType("date");

                entity.Property(e => e.IdInventory).HasColumnName("id_inventory");

                entity.Property(e => e.StoreName)
                    .HasColumnName("store_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValueTotal).HasColumnName("value_total");
            });

            modelBuilder.Entity<SalesClient>(entity =>
            {
                entity.HasKey(e => e.IdSalesClient);

                entity.ToTable("Sales_Client");

                entity.Property(e => e.IdSalesClient).HasColumnName("id_sales_client");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdSales).HasColumnName("id_sales");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.SalesClient)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK__Sales_Cli__id_cl__403A8C7D");

                entity.HasOne(d => d.IdSalesNavigation)
                    .WithMany(p => p.SalesClient)
                    .HasForeignKey(d => d.IdSales)
                    .HasConstraintName("FK__Sales_Cli__id_sa__3F466844");
            });

            modelBuilder.Entity<SalesProduct>(entity =>
            {
                entity.HasKey(e => e.IdSalesProduct);

                entity.ToTable("Sales_Product");

                entity.Property(e => e.IdSalesProduct).HasColumnName("id_sales_product");

                entity.Property(e => e.IdProduc).HasColumnName("id_produc");

                entity.Property(e => e.IdSales).HasColumnName("id_sales");

                entity.Property(e => e.Quantify).HasColumnName("quantify");

                entity.HasOne(d => d.IdProducNavigation)
                    .WithMany(p => p.SalesProduct)
                    .HasForeignKey(d => d.IdProduc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales_Pro__id_pr__440B1D61");

                entity.HasOne(d => d.IdSalesNavigation)
                    .WithMany(p => p.SalesProduct)
                    .HasForeignKey(d => d.IdSales)
                    .HasConstraintName("FK__Sales_Pro__id_sa__4316F928");
            });
        }
    }
}
