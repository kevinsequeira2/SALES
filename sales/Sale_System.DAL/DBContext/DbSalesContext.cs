using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sale_system.MODEL.DAL.DBContext;

public partial class DbSalesContext : DbContext
{
    public DbSalesContext()
    {
    }

    public DbSalesContext(DbContextOptions<DbSalesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Documentsale> Documentsales { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Saledetail> Saledetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-RR8UJ9E\\SQLEXPRESS; DataBase=DB_SALES; Trusted_Connection=True; \nTrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__CATEGORY__79D361B66C45D48B");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.DateRegister)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegister");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Documentsale>(entity =>
        {
            entity.HasKey(e => e.IdDocument).HasName("PK__DOCUMENT__E3A0F08E5D843296");

            entity.ToTable("DOCUMENTSALES");

            entity.Property(e => e.IdDocument).HasColumnName("idDocument");
            entity.Property(e => e.DateRegister)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegister");
            entity.Property(e => e.LastDocument).HasColumnName("lastDocument");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__MENU__C26AF4838BF402F4");

            entity.ToTable("MENU");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__menuRol__9D6D61A445E48902");

            entity.ToTable("menuRol");

            entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__menuRol__idMenu__4E88ABD4");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__menuRol__idRol__4F7CD00D");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdPproduct).HasName("PK__PRODUCT__CFCD4B9B58F01A83");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.IdPproduct).HasColumnName("idPProduct");
            entity.Property(e => e.DateRegister)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegister");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__PRODUCT__idCateg__5AEE82B9");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROL__3C872F7630602DD0");

            entity.ToTable("ROL");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.DateRegister)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_register");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("PK__SALES__C4AEB19871E88D99");

            entity.ToTable("SALES");

            entity.Property(e => e.IdSale).HasColumnName("idSale");
            entity.Property(e => e.DateRegister)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegister");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TypePay)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typePay");
        });

        modelBuilder.Entity<Saledetail>(entity =>
        {
            entity.HasKey(e => e.IdSaleDetail).HasName("PK__SALEDETA__B23385CDAD3C4C6A");

            entity.ToTable("SALEDETAIL");

            entity.Property(e => e.IdSaleDetail).HasColumnName("idSaleDetail");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdSale).HasColumnName("idSale");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Saledetails)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__SALEDETAI__idPro__66603565");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.Saledetails)
                .HasForeignKey(d => d.IdSale)
                .HasConstraintName("FK__SALEDETAI__idSal__656C112C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__3717C9824E6D7814");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.DateRegister)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateRegister");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.NameCompleted)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nameCompleted");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Users__idRol__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
