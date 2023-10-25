using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BD_LAB2_PERSONAL;

public partial class HostelDataBaseContext : DbContext
{
    public HostelDataBaseContext()
    {
    }

    public HostelDataBaseContext(DbContextOptions<HostelDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<HotelRoom> HotelRooms { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data source = C:\\Users\\kanta\\БД\\HostelDataBase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmplId);

            entity.HasIndex(e => e.EmplId, "IX_Employees_emplId").IsUnique();

            entity.Property(e => e.EmplId).HasColumnName("emplId");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.FirstName).HasColumnName("firstName");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.LastName).HasColumnName("lastName");
            entity.Property(e => e.PassportDetails).HasColumnName("passportDetails");
            entity.Property(e => e.PositionsId).HasColumnName("positionsId");
            entity.Property(e => e.SecondName).HasColumnName("secondName");
            entity.Property(e => e.TelephoneNumber).HasColumnName("telephoneNumber");

            entity.HasOne(d => d.Positions).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionsId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<HotelRoom>(entity =>
        {
            entity.HasKey(e => e.NumberId);

            entity.HasIndex(e => e.NumberId, "IX_HotelRooms_numberId").IsUnique();

            entity.Property(e => e.NumberId).HasColumnName("numberId");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EmplsId).HasColumnName("emplsId");
            entity.Property(e => e.NumberName).HasColumnName("numberName");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Empls).WithMany(p => p.HotelRooms).HasForeignKey(d => d.EmplsId);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasIndex(e => e.PositionId, "IX_Positions_positionId").IsUnique();

            entity.Property(e => e.PositionId)
                .ValueGeneratedNever()
                .HasColumnName("positionId");
            entity.Property(e => e.Duties).HasColumnName("duties");
            entity.Property(e => e.PositionName).HasColumnName("positionName");
            entity.Property(e => e.Requirements).HasColumnName("requirements");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
