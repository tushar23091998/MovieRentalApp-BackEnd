using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MovieRentalApp.Models;

namespace MovieRentalApp.Data
{
    public partial class MovieRentalDBContext : DbContext
    {
        public MovieRentalDBContext()
        {
        }

        public MovieRentalDBContext(DbContextOptions<MovieRentalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblActor> TblActor { get; set; }
        public virtual DbSet<TblDirector> TblDirector { get; set; }
        public virtual DbSet<TblMovie> TblMovie { get; set; }
        public virtual DbSet<TblMovieActorMapping> TblMovieActorMapping { get; set; }
        public virtual DbSet<TblMovieDirectorMapping> TblMovieDirectorMapping { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=BEK-79277772\\SQLEXPRESS;Database=MovieRentalDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblActor>(entity =>
            {
                entity.HasKey(e => e.AActorId)
                    .HasName("PK__TBL_ACTO__E57717451B17F4D0");

                entity.Property(e => e.AActorName).IsUnicode(false);
            });

            modelBuilder.Entity<TblDirector>(entity =>
            {
                entity.HasKey(e => e.ADirectorId)
                    .HasName("PK__TBL_DIRE__06C68949C1C02EF7");

                entity.Property(e => e.ADirectorName).IsUnicode(false);
            });

            modelBuilder.Entity<TblMovie>(entity =>
            {
                entity.HasKey(e => e.AMovieId)
                    .HasName("PK__TBL_MOVI__086F093D5139C5A5");

                entity.Property(e => e.ADuration).IsUnicode(false);

                entity.Property(e => e.AGenre).IsUnicode(false);

                entity.Property(e => e.AImageLink).IsUnicode(false);

                entity.Property(e => e.AMovieDescription).IsUnicode(false);

                entity.Property(e => e.APrice).IsUnicode(false);

                entity.Property(e => e.APurchasePrice).IsUnicode(false);

                entity.Property(e => e.ATitle).IsUnicode(false);

                entity.Property(e => e.ATrailerLink).IsUnicode(false);

                entity.Property(e => e.AWideImage).IsUnicode(false);
            });

            modelBuilder.Entity<TblMovieActorMapping>(entity =>
            {
                entity.HasKey(e => new { e.AMovieId, e.AActorId });

                entity.HasOne(d => d.AActor)
                    .WithMany(p => p.TblMovieActorMapping)
                    .HasForeignKey(d => d.AActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_MOVIE_ACTOR_MAPPING_TBL_ACTOR");

                entity.HasOne(d => d.AMovie)
                    .WithMany(p => p.TblMovieActorMapping)
                    .HasForeignKey(d => d.AMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_MOVIE_ACTOR_MAPPING_TBL_MOVIE");
            });

            modelBuilder.Entity<TblMovieDirectorMapping>(entity =>
            {
                entity.HasKey(e => new { e.AMovieId, e.ADirectorId });

                entity.HasOne(d => d.ADirector)
                    .WithMany(p => p.TblMovieDirectorMapping)
                    .HasForeignKey(d => d.ADirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_MOVIE_DIRECTOR_MAPPING_TBL_DIRECTOR");

                entity.HasOne(d => d.AMovie)
                    .WithMany(p => p.TblMovieDirectorMapping)
                    .HasForeignKey(d => d.AMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_MOVIE_DIRECTOR_MAPPING_TBL_MOVIE");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.AOrderId)
                    .HasName("PK__TBL_ORDE__664FBDC2B0270F08");

                entity.HasOne(d => d.ACustomer)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.ACustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ORDER_TBL_USER");

                entity.HasOne(d => d.AMovie)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.AMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ORDER_TBL_MOVIE");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.ACustomerId)
                    .HasName("PK__TBL_USER__814FFED4BA073974");

                entity.Property(e => e.AAddress).IsUnicode(false);

                entity.Property(e => e.AEmail).IsUnicode(false);

                entity.Property(e => e.Aname).IsUnicode(false);

                entity.Property(e => e.AUsername).IsUnicode(false);

                entity.Property(e => e.APhone).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
