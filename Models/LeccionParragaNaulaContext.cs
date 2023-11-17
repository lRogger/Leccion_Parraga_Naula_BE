using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leccion_Parraga_Naula_BE.Models;

public partial class LeccionParragaNaulaContext : DbContext
{
    public LeccionParragaNaulaContext()
    {
    }

    public LeccionParragaNaulaContext(DbContextOptions<LeccionParragaNaulaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<MaterialesUtilizado> MaterialesUtilizados { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Reparacione> Reparaciones { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Leccion_Parraga_Naula;User Id=sa;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A7341007F7");

            entity.Property(e => e.ClienteId)
                .ValueGeneratedNever()
                .HasColumnName("ClienteID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F014077BA0");

            entity.Property(e => e.EmpleadoId)
                .ValueGeneratedNever()
                .HasColumnName("EmpleadoID");
            entity.Property(e => e.Cargo).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<MaterialesUtilizado>(entity =>
        {
            entity.HasKey(e => new { e.ReparacionId, e.Material }).HasName("PK__Material__8219E475072B3583");

            entity.Property(e => e.ReparacionId).HasColumnName("ReparacionID");
            entity.Property(e => e.Material).HasMaxLength(100);

            entity.HasOne(d => d.Reparacion).WithMany(p => p.MaterialesUtilizados)
                .HasForeignKey(d => d.ReparacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Materiale__Repar__534D60F1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Producto");

            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Reparacione>(entity =>
        {
            entity.HasKey(e => e.ReparacionId).HasName("PK__Reparaci__A2BA9F6AA04069D3");

            entity.Property(e => e.ReparacionId)
                .ValueGeneratedNever()
                .HasColumnName("ReparacionID");
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Reparaciones)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Reparacio__Vehic__4E88ABD4");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehiculo__AA0886204EE24AF0");

            entity.Property(e => e.VehiculoId)
                .ValueGeneratedNever()
                .HasColumnName("VehiculoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Vehiculos__Clien__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
