using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ZStore_BLL.Models
{
    public partial class ZStore_SampleContext : DbContext
    {
        public ZStore_SampleContext()
        {
        }

        public ZStore_SampleContext(DbContextOptions<ZStore_SampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountRole> AccountRoles { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductInventory> ProductInventories { get; set; } = null!;
        public virtual DbSet<ProductVariant> ProductVariants { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public virtual DbSet<TokenType> TokenTypes { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<Variant> Variants { get; set; } = null!;
        public virtual DbSet<VariantValue> VariantValues { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasIndex(e => e.Mobile, "UQ__account__A32E2E1CCFAFE942")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__account__AB6E6164FAEE561C")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.DefaultAddressId).HasColumnName("default_address_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .HasColumnName("mobile");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(32)
                    .HasColumnName("password_hash");

                entity.Property(e => e.RegisteredAt)
                    .HasColumnType("datetime")
                    .HasColumnName("registered_at");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.DefaultAddress)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.DefaultAddressId)
                    .HasConstraintName("FK_Account_Address");
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.ToTable("accountRole");

                entity.Property(e => e.AccountRoleId).HasColumnName("account_role_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountRoles)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_AccountRole_Account");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AccountRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AccountRole_Role");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.Detail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("detail");

                entity.Property(e => e.District)
                    .HasMaxLength(255)
                    .HasColumnName("district");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("province");

                entity.Property(e => e.Ward)
                    .HasMaxLength(255)
                    .HasColumnName("ward");

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .HasColumnName("zip");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Address_Account");
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__auditLog__9E2397E08C89EAD1");

                entity.ToTable("auditLog");

                entity.Property(e => e.LogId).HasColumnName("log_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Action)
                    .HasMaxLength(255)
                    .HasColumnName("action")
                    .HasDefaultValueSql("(N'Default Action')");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content")
                    .HasDefaultValueSql("(N'Default Audit Log Content')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Entity)
                    .HasMaxLength(255)
                    .HasColumnName("entity")
                    .HasDefaultValueSql("(N'Default Entity')");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(255)
                    .HasColumnName("ip_address")
                    .HasDefaultValueSql("(N'0.0.0.0')");

                entity.Property(e => e.UserAgent)
                    .HasMaxLength(255)
                    .HasColumnName("user_agent")
                    .HasDefaultValueSql("(N'Default Browser')");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AuditLogs)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_AuditLog_Account");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content")
                    .HasDefaultValueSql("(N'Default Category Content')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(255)
                    .HasColumnName("metaTitle")
                    .HasDefaultValueSql("(N'Default Category Meta Title')");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");

                entity.Property(e => e.Sku)
                    .HasMaxLength(255)
                    .HasColumnName("sku")
                    .HasDefaultValueSql("(N'DEFAULTCATEGORY')");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug")
                    .HasDefaultValueSql("(N'default-category-slug')");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("(N'Default Category Title')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK_Category_ParentCategory");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("collection");

                entity.Property(e => e.CollectionId).HasColumnName("collection_id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content")
                    .HasDefaultValueSql("(N'Default Product Description')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(255)
                    .HasColumnName("metaTitle")
                    .HasDefaultValueSql("(N'Default Product Meta Title')");

                entity.Property(e => e.ProductCount)
                    .HasColumnName("product_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sku)
                    .HasMaxLength(255)
                    .HasColumnName("sku")
                    .HasDefaultValueSql("(N'PRD')");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug")
                    .HasDefaultValueSql("(N'default-collection-slug-title')");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("(N'Default Product Title')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ViewTime)
                    .HasColumnName("view_time")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permission");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CollectionId).HasColumnName("collection_id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content")
                    .HasDefaultValueSql("(N'Default Product Description')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image)
                    .HasColumnType("ntext")
                    .HasColumnName("image")
                    .HasDefaultValueSql("(N'example.com/default-product-image.png')");

                entity.Property(e => e.Images)
                    .HasColumnType("ntext")
                    .HasColumnName("images")
                    .HasDefaultValueSql("(N'example.com/default-product-image-1.png,example.com/default-product-image-2.png')");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(255)
                    .HasColumnName("metaTitle")
                    .HasDefaultValueSql("(N'Default Product Meta Title')");

                entity.Property(e => e.Sku)
                    .HasMaxLength(255)
                    .HasColumnName("sku")
                    .HasDefaultValueSql("(N'PRODUCT')");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug")
                    .HasDefaultValueSql("(N'product-item')");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SubCategoryId).HasColumnName("sub_category_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("(N'Default Product Title')");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.Property(e => e.ViewTime)
                    .HasColumnName("view_time")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CollectionId)
                    .HasConstraintName("FK_Product_Collection");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.ProductSubCategories)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_Product_SubCategory");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Product_Type");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_Product_Vendor");
            });

            modelBuilder.Entity<ProductInventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId)
                    .HasName("PK__productI__B59ACC493F4C8C9E");

                entity.ToTable("productInventory");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VariantCombination)
                    .HasMaxLength(255)
                    .HasColumnName("variant_combination")
                    .HasDefaultValueSql("(N'0-0-0-0-0')");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_productInventory_Product");
            });

            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.ToTable("productVariant");

                entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VariantId).HasColumnName("variant_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_productVariant_Product");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(d => d.VariantId)
                    .HasConstraintName("FK_productVariant_Variant");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokenId)
                    .HasName("PK__refreshT__CB3C9E17CDDBA3E3");

                entity.ToTable("refreshToken");

                entity.Property(e => e.TokenId).HasColumnName("token_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiresAt)
                    .HasColumnType("datetime")
                    .HasColumnName("expires_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_RefreshToken_Account");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_RefreshToken_TokenType");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("rolePermission");

                entity.Property(e => e.RolePermissionId).HasColumnName("role_permission_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK_RolePermission_Permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RolePermission_Role");
            });

            modelBuilder.Entity<TokenType>(entity =>
            {
                entity.ToTable("tokenType");

                entity.Property(e => e.TokenTypeId).HasColumnName("token_type_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title")
                    .HasDefaultValueSql("(N'Default Token Type Name')");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("type");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content")
                    .HasDefaultValueSql("(N'Default Product Type Description')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(255)
                    .HasColumnName("metaTitle")
                    .HasDefaultValueSql("(N'Default Product Type Meta Title')");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.Sku)
                    .HasMaxLength(255)
                    .HasColumnName("sku")
                    .HasDefaultValueSql("(N'PT')");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug")
                    .HasDefaultValueSql("(N'default-product-type')");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("(N'Default Product Type Title')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.ToTable("variant");

                entity.Property(e => e.VariantId).HasColumnName("variant_id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content")
                    .HasDefaultValueSql("(N'Default Variant Content')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("(N'Default Variant Title')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<VariantValue>(entity =>
            {
                entity.ToTable("variantValue");

                entity.Property(e => e.VariantValueId).HasColumnName("variant_value_id");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(255)
                    .HasColumnName("img_url")
                    .HasDefaultValueSql("('https://example.com/product-variant-image.png')");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("('Default Variant Value')");

                entity.Property(e => e.VariantId).HasColumnName("variant_id");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.VariantValues)
                    .HasForeignKey(d => d.VariantId)
                    .HasConstraintName("FK_VariantValue_Variant");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content")
                    .HasDefaultValueSql("(N'Default Vendor Description')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.Sku)
                    .HasMaxLength(255)
                    .HasColumnName("sku")
                    .HasDefaultValueSql("(N'VD')");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("(N'Default Vendor Title')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("voucher");

                entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code")
                    .HasDefaultValueSql("(N'VOUCHER-DEFAULT')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpiresAt)
                    .HasColumnType("datetime")
                    .HasColumnName("expires_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type");

                entity.Property(e => e.UsageLimit)
                    .HasColumnName("usage_limit")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UsedCount)
                    .HasColumnName("used_count")
                    .HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
