using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RentoLibData.Models;

#nullable disable

namespace RentoLibData.Context
{
    public partial class RentoLibContext : DbContext
    {
        public RentoLibContext()
        {
        }

        public RentoLibContext(DbContextOptions<RentoLibContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductRequest> ProductRequests { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<RequestStatus> RequestStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserLocation> UserLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:juanc.database.windows.net,1433;Initial Catalog=RentoLib;Persist Security Info=False;User ID=juanc;Password=Juankis25!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CITY_COUNTRY");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PricePerDay)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price_per_day");

                entity.Property(e => e.ProductSubcategoryId).HasColumnName("product_subcategory_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ProductSubcategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductSubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PRODUCT_SUBCATEGORY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_USER");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("PRODUCT_CATEGORY");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ProductRequest>(entity =>
            {
                entity.ToTable("PRODUCT_REQUEST");

                entity.Property(e => e.ProductRequestId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("product_request_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("date_from");

                entity.Property(e => e.DateTo)
                    .HasColumnType("datetime")
                    .HasColumnName("date_to");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.MeetingPoint)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("meeting_point");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("message");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.RequestUserId).HasColumnName("request_user_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("unit_price");

                entity.HasOne(d => d.ProductRequestNavigation)
                    .WithOne(p => p.ProductRequest)
                    .HasForeignKey<ProductRequest>(d => d.ProductRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_REQUEST_PRODUCT");

                entity.HasOne(d => d.RequestUser)
                    .WithMany(p => p.ProductRequests)
                    .HasForeignKey(d => d.RequestUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_REQUEST_USER");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ProductRequests)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_REQUEST_REQUEST_STATUS");
            });

            modelBuilder.Entity<ProductSubcategory>(entity =>
            {
                entity.ToTable("PRODUCT_SUBCATEGORY");

                entity.Property(e => e.ProductSubcategoryId).HasColumnName("product_subcategory_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.ProductSubcategories)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_SUBCATEGORY_PRODUCT_CATEGORY");
            });

            modelBuilder.Entity<RequestStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("REQUEST_STATUS");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Picture)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("picture");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telephone");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserLocation>(entity =>
            {
                entity.ToTable("USER_LOCATION");

                entity.Property(e => e.UserLocationId).HasColumnName("user_location_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.AddressTwo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("address_two");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.ComplementAddressTwo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("complement_address_two");

                entity.Property(e => e.ComplemetAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("complemet_address");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ZipCode).HasColumnName("zip_code");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.UserLocations)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_LOCATION_CITY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLocations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_LOCATION_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
