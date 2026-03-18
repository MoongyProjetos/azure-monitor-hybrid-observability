using System;
using System.Collections.Generic;
using func_monitor.Models;
using Microsoft.EntityFrameworkCore;

namespace func_monitor.DB;

public partial class AdventureWorksDBContext : DbContext
{
    public AdventureWorksDBContext()
    {
    }

    public AdventureWorksDBContext(DbContextOptions<AdventureWorksDBContext> options) : base(options) { }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BuildVersion> BuildVersions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }

    public virtual DbSet<ProductModel> ProductModels { get; set; }

    public virtual DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Address_AddressID");

            entity.ToTable("Address", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_Address_rowguid").IsUnique();

            entity.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvince, e.PostalCode, e.CountryRegion }, "IX_Address_AddressLine1_AddressLine2_City_StateProvince_PostalCode_CountryRegion");

            entity.HasIndex(e => e.StateProvince, "IX_Address_StateProvince");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressLine1).HasMaxLength(60);
            entity.Property(e => e.AddressLine2).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(30);
            entity.Property(e => e.CountryRegion).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_Address_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.PostalCode).HasMaxLength(15);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())", "DF_Address_rowguid")
                .HasColumnName("rowguid");
            entity.Property(e => e.StateProvince).HasMaxLength(50);
        });

        modelBuilder.Entity<BuildVersion>(entity =>
        {
            entity.HasKey(e => e.SystemInformationId).HasName("PK__BuildVer__35E58ECA24A5375D");

            entity.ToTable("BuildVersion");

            entity.Property(e => e.SystemInformationId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SystemInformationID");
            entity.Property(e => e.DatabaseVersion)
                .HasMaxLength(25)
                .HasColumnName("Database Version");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_BuildVersion_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.VersionDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_Customer_CustomerID");

            entity.ToTable("Customer", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_Customer_rowguid").IsUnique();

            entity.HasIndex(e => e.EmailAddress, "IX_Customer_EmailAddress");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CompanyName).HasMaxLength(128);
            entity.Property(e => e.EmailAddress).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_Customer_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Phone).HasMaxLength(25);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())", "DF_Customer_rowguid")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalesPerson).HasMaxLength(256);
            entity.Property(e => e.Suffix).HasMaxLength(10);
            entity.Property(e => e.Title).HasMaxLength(8);
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.AddressId }).HasName("PK_CustomerAddress_CustomerID_AddressID");

            entity.ToTable("CustomerAddress", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_CustomerAddress_rowguid").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressType).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_CustomerAddress_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())", "DF_CustomerAddress_rowguid")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.Address).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.ErrorLogId).HasName("PK_ErrorLog_ErrorLogID");

            entity.ToTable("ErrorLog");

            entity.Property(e => e.ErrorLogId).HasColumnName("ErrorLogID");
            entity.Property(e => e.ErrorMessage).HasMaxLength(4000);
            entity.Property(e => e.ErrorProcedure).HasMaxLength(126);
            entity.Property(e => e.ErrorTime)
                .HasDefaultValueSql("(getdate())", "DF_ErrorLog_ErrorTime")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(128);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product_ProductID");

            entity.ToTable("Product", "SalesLT");

            entity.HasIndex(e => e.Name, "AK_Product_Name").IsUnique();

            entity.HasIndex(e => e.ProductNumber, "AK_Product_ProductNumber").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_Product_rowguid").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Color).HasMaxLength(15);
            entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");
            entity.Property(e => e.ListPrice).HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_Product_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.ProductNumber).HasMaxLength(25);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())", "DF_Product_rowguid")
                .HasColumnName("rowguid");
            entity.Property(e => e.SellEndDate).HasColumnType("datetime");
            entity.Property(e => e.SellStartDate).HasColumnType("datetime");
            entity.Property(e => e.Size).HasMaxLength(5);
            entity.Property(e => e.StandardCost).HasColumnType("money");
            entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);
            entity.Property(e => e.Weight).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products).HasForeignKey(d => d.ProductCategoryId);

            entity.HasOne(d => d.ProductModel).WithMany(p => p.Products).HasForeignKey(d => d.ProductModelId);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK_ProductCategory_ProductCategoryID");

            entity.ToTable("ProductCategory", "SalesLT");

            entity.HasIndex(e => e.Name, "AK_ProductCategory_Name").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_ProductCategory_rowguid").IsUnique();

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_ProductCategory_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ParentProductCategoryId).HasColumnName("ParentProductCategoryID");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())", "DF_ProductCategory_rowguid")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.ParentProductCategory).WithMany(p => p.InverseParentProductCategory)
                .HasForeignKey(d => d.ParentProductCategoryId)
                .HasConstraintName("FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID");
        });

        modelBuilder.Entity<ProductDescription>(entity =>
        {
            entity.HasKey(e => e.ProductDescriptionId).HasName("PK_ProductDescription_ProductDescriptionID");

            entity.ToTable("ProductDescription", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_ProductDescription_rowguid").IsUnique();

            entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_ProductDescription_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())", "DF_ProductDescription_rowguid")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.ProductModelId).HasName("PK_ProductModel_ProductModelID");

            entity.ToTable("ProductModel", "SalesLT");

            entity.HasIndex(e => e.Name, "AK_ProductModel_Name").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_ProductModel_rowguid").IsUnique();

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.CatalogDescription).HasColumnType("xml");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_ProductModel_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())", "DF_ProductModel_rowguid")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<ProductModelProductDescription>(entity =>
        {
            entity.HasKey(e => new { e.ProductModelId, e.ProductDescriptionId, e.Culture }).HasName("PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture");

            entity.ToTable("ProductModelProductDescription", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_ProductModelProductDescription_rowguid").IsUnique();

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");
            entity.Property(e => e.Culture)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_ProductModelProductDescription_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())", "DF_ProductModelProductDescription_rowguid")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.ProductDescription).WithMany(p => p.ProductModelProductDescriptions)
                .HasForeignKey(d => d.ProductDescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductModel).WithMany(p => p.ProductModelProductDescriptions)
                .HasForeignKey(d => d.ProductModelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId }).HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

            entity.ToTable("SalesOrderDetail", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_SalesOrderDetail_rowguid").IsUnique();

            entity.HasIndex(e => e.ProductId, "IX_SalesOrderDetail_ProductID");

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.SalesOrderDetailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SalesOrderDetailID");
            entity.Property(e => e.LineTotal)
                .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false)
                .HasColumnType("numeric(38, 6)");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_SalesOrderDetail_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())", "DF_SalesOrderDetail_rowguid")
                .HasColumnName("rowguid");
            entity.Property(e => e.UnitPrice).HasColumnType("money");
            entity.Property(e => e.UnitPriceDiscount).HasColumnType("money");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.SalesOrderDetails).HasForeignKey(d => d.SalesOrderId);
        });

        modelBuilder.Entity<SalesOrderHeader>(entity =>
        {
            entity.HasKey(e => e.SalesOrderId).HasName("PK_SalesOrderHeader_SalesOrderID");

            entity.ToTable("SalesOrderHeader", "SalesLT");

            entity.HasIndex(e => e.SalesOrderNumber, "AK_SalesOrderHeader_SalesOrderNumber").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_SalesOrderHeader_rowguid").IsUnique();

            entity.HasIndex(e => e.CustomerId, "IX_SalesOrderHeader_CustomerID");

            entity.Property(e => e.SalesOrderId)
                .HasDefaultValueSql("(NEXT VALUE FOR [SalesLT].[SalesOrderNumber])", "DF_SalesOrderHeader_OrderID")
                .HasColumnName("SalesOrderID");
            entity.Property(e => e.AccountNumber).HasMaxLength(15);
            entity.Property(e => e.BillToAddressId).HasColumnName("BillToAddressID");
            entity.Property(e => e.CreditCardApprovalCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())", "DF_SalesOrderHeader_ModifiedDate")
                .HasColumnType("datetime");
            entity.Property(e => e.OnlineOrderFlag).HasDefaultValue(true, "DF_SalesOrderHeader_OnlineOrderFlag");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())", "DF_SalesOrderHeader_OrderDate")
                .HasColumnType("datetime");
            entity.Property(e => e.PurchaseOrderNumber).HasMaxLength(25);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())", "DF_SalesOrderHeader_rowguid")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalesOrderNumber)
                .HasMaxLength(25)
                .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID],(0)),N'*** ERROR ***'))", false);
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.ShipMethod).HasMaxLength(50);
            entity.Property(e => e.ShipToAddressId).HasColumnName("ShipToAddressID");
            entity.Property(e => e.Status).HasDefaultValue((byte)1, "DF_SalesOrderHeader_Status");
            entity.Property(e => e.SubTotal).HasColumnType("money");
            entity.Property(e => e.TaxAmt).HasColumnType("money");
            entity.Property(e => e.TotalDue)
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", false)
                .HasColumnType("money");

            entity.HasOne(d => d.BillToAddress).WithMany(p => p.SalesOrderHeaderBillToAddresses)
                .HasForeignKey(d => d.BillToAddressId)
                .HasConstraintName("FK_SalesOrderHeader_Address_BillTo_AddressID");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrderHeaders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ShipToAddress).WithMany(p => p.SalesOrderHeaderShipToAddresses)
                .HasForeignKey(d => d.ShipToAddressId)
                .HasConstraintName("FK_SalesOrderHeader_Address_ShipTo_AddressID");
        });

        modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
