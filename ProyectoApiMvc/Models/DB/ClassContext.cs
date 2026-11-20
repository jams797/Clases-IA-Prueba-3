using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoApiMvc.Models.DB;

public partial class ClassContext : DbContext
{
    public ClassContext()
    {
    }

    public ClassContext(DbContextOptions<ClassContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PersonDB> Persons { get; set; }

    public virtual DbSet<PetDB> Pets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=clase;Username=admin;Password=Admin123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonDB>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Input).HasColumnName("input");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<PetDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Persons_1");

            entity.ToTable("pets");

            entity.HasIndex(e => e.PersonId, "pets_person_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Person).WithMany(p => p.Pets)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pets_persons_fk");
        });
        modelBuilder.HasSequence("Pet_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
