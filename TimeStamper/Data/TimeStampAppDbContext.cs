using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TimeStamper.Data
{
    public partial class TimeStampAppDbContext : DbContext
    {
        public TimeStampAppDbContext()
        {
        }

        public TimeStampAppDbContext(DbContextOptions<TimeStampAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AljPerson> AljPeople { get; set; } = null!;
        public virtual DbSet<AljProject> AljProjects { get; set; } = null!;
        public virtual DbSet<AljProjectPerson> AljProjectPeople { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-5BIUKPJ;Initial Catalog=TimeStampApp;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AljPerson>(entity =>
            {
                entity.ToTable("alj_person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("person_name");
            });

            modelBuilder.Entity<AljProject>(entity =>
            {
                entity.ToTable("alj_project");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("project_name");
            });

            modelBuilder.Entity<AljProjectPerson>(entity =>
            {
                entity.ToTable("alj_project_person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Hours).HasColumnName("hours");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.AljProjectPeople)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_alj_person_project_person_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AljProjectPeople)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_alj_project_person_project_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
