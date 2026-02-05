using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VendingMachinesApi26.Models;

public partial class VendingMachines26Context : DbContext
{
    public VendingMachines26Context()
    {
        Database.EnsureCreated();
    }

    public VendingMachines26Context(DbContextOptions<VendingMachines26Context> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VendingMachine> VendingMachines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=GoblinsComp3;Initial Catalog=VendingMachines26;User ID=sa;Password=1234;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasKey(e => e.IdMaintenance).HasName("PK__Maintena__392C4697777267AD");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IdUser).HasMaxLength(300);
            entity.Property(e => e.IdVendingMachine).HasMaxLength(300);
            entity.Property(e => e.IssuesFound).HasColumnType("ntext");
            entity.Property(e => e.WorkDescription).HasColumnType("ntext");

            entity.HasOne(d => d.IdVendingMachineNavigation).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.IdVendingMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maintenances_VendingMachines");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Products__2E8946D445457980");

            entity.Property(e => e.IdProduct).HasMaxLength(300);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.VendingMachineId).HasMaxLength(300);

            entity.HasOne(d => d.VendingMachine).WithMany(p => p.Products)
                .HasForeignKey(d => d.VendingMachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_VendingMachines");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("PK__Sales__A04F9B37A49AFBC8");

            entity.Property(e => e.IdProduct).HasMaxLength(300);
            entity.Property(e => e.PaymentMethod).HasMaxLength(100);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Products");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__B7C92638EE014ED5");

            entity.Property(e => e.IdUser).HasMaxLength(300);
            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.FullName).HasMaxLength(500);
            entity.Property(e => e.Login).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(100);
        });

        modelBuilder.Entity<VendingMachine>(entity =>
        {
            entity.HasKey(e => e.IdVendingMachine).HasName("PK__VendingM__4677EA1A2418383B");

            entity.HasIndex(e => e.SerialNumber, "UQ__VendingM__048A0008D9316629").IsUnique();

            entity.HasIndex(e => e.InventNumber, "UQ__VendingM__94A3577838C8C513").IsUnique();

            entity.Property(e => e.IdVendingMachine).HasMaxLength(300);
            entity.Property(e => e.Company).HasMaxLength(200);
            entity.Property(e => e.Coordinates).HasColumnType("ntext");
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CriticalThresholdTemplate).HasMaxLength(200);
            entity.Property(e => e.Engineer).HasMaxLength(300);
            entity.Property(e => e.IdUser).HasMaxLength(300);
            entity.Property(e => e.InstallDate).HasColumnType("datetime");
            entity.Property(e => e.InventarizationDate).HasColumnType("datetime");
            entity.Property(e => e.KitOnlineId).HasMaxLength(200);
            entity.Property(e => e.LastMaintenanceDate).HasColumnType("datetime");
            entity.Property(e => e.Location).HasColumnType("ntext");
            entity.Property(e => e.Manager).HasMaxLength(300);
            entity.Property(e => e.Model).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.NextMaintenanceDate).HasColumnType("datetime");
            entity.Property(e => e.NextVerificationDate)
                .HasComputedColumnSql("(case when [LastMaintenanceDate] IS NOT NULL AND [VerificationIntervalMonths] IS NOT NULL then dateadd(month,[VerificationIntervalMonths],[LastMaintenanceDate])  end)", false)
                .HasColumnType("datetime");
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.NotificationTemplate).HasMaxLength(50);
            entity.Property(e => e.Operator).HasMaxLength(100);
            entity.Property(e => e.Payment).HasMaxLength(50);
            entity.Property(e => e.Place).HasMaxLength(100);
            entity.Property(e => e.RfidCash).HasMaxLength(100);
            entity.Property(e => e.RfidLoading).HasMaxLength(100);
            entity.Property(e => e.RfidService).HasMaxLength(100);
            entity.Property(e => e.ServicePriority).HasMaxLength(200);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Technician).HasMaxLength(300);
            entity.Property(e => e.Timezone).HasMaxLength(40);
            entity.Property(e => e.TotalIncome).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.WorkMode).HasMaxLength(100);
            entity.Property(e => e.WorkingHours).HasMaxLength(50);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_VendingMachines_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
