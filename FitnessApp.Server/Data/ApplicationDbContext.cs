using FitnessApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Définissez vos DbSet ici. Par exemple :
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Name=DefaultConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abonnement>(entity =>
            {
                entity.ToTable("Abonnement");

                entity.Property(e => e.AbonnementId)
                    .ValueGeneratedNever()
                    .HasColumnName("abonnement_id");
                entity.Property(e => e.AbonnementDuree)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("abonnement_duree");
                entity.Property(e => e.AbonnementPrix)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("abonnement_prix");
                entity.Property(e => e.AbonnementType)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("abonnement_type");
            });

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.ToTable("Coach");

                entity.Property(e => e.CoachId)
                    .ValueGeneratedNever()
                    .HasColumnName("coach_id");
                entity.Property(e => e.CoachFirstname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("coach_firstname");
                entity.Property(e => e.CoachLastname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("coach_lastname");
                entity.Property(e => e.CoachSpecialite)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("coach_specialite");
            });

            modelBuilder.Entity<Cours>(entity =>
            {
                entity.HasKey(e => e.CoursId);

                entity.Property(e => e.CoursId)
                    .ValueGeneratedNever()
                    .HasColumnName("cours_id");
                entity.Property(e => e.CoachId).HasColumnName("coach_id");
                entity.Property(e => e.CoursDate).HasColumnName("cours_date");
                entity.Property(e => e.CoursHeureDebut).HasColumnName("cours_heure_debut");
                entity.Property(e => e.CoursHeureFin).HasColumnName("cours_heure_fin");
                entity.Property(e => e.CoursName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("cours_name");

                entity.HasOne(d => d.Coach).WithMany(p => p.Cours)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cours_Coach");
            });

            modelBuilder.Entity<Membre>(entity =>
            {
                entity.ToTable("Membre");

                entity.HasIndex(e => e.MembreEmail, "AK_Membre").IsUnique();

                entity.Property(e => e.MembreId)
                    .ValueGeneratedNever()
                    .HasColumnName("membre_id");
                entity.Property(e => e.AbonnementId).HasColumnName("abonnement_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.MembreEmail)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("membre_email");
                entity.Property(e => e.MembreFirstname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("membre_firstname");
                entity.Property(e => e.MembreLastname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("membre_lastname");
                entity.Property(e => e.MembrePhonenumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("membre_phonenumber");
                entity.Property(e => e.MembreStatutAbonnement)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("membre_statut_abonnement");

                entity.HasOne(d => d.Abonnement).WithMany(p => p.Membres)
                    .HasForeignKey(d => d.AbonnementId)
                    .HasConstraintName("FK_Membre_Abonnement");
            });

            modelBuilder.Entity<Paiement>(entity =>
            {
                entity.ToTable("Paiement");

                entity.Property(e => e.PaiementId)
                    .ValueGeneratedNever()
                    .HasColumnName("paiement_id");
                entity.Property(e => e.MembreId).HasColumnName("membre_id");
                entity.Property(e => e.PaiementDate).HasColumnName("paiement_date");
                entity.Property(e => e.PaiementMontant)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("paiement_montant");
                entity.Property(e => e.PaiementStatut)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("paiement_statut");

                entity.HasOne(d => d.Membre).WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.MembreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paiement_Membre");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId)
                    .ValueGeneratedNever()
                    .HasColumnName("reservation_id");
                entity.Property(e => e.CoursId).HasColumnName("cours_id");
                entity.Property(e => e.MembreId).HasColumnName("membre_id");
                entity.Property(e => e.ReservationDate).HasColumnName("reservation_date");

                entity.HasOne(d => d.Cours).WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CoursId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Cours");

                entity.HasOne(d => d.Membre).WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.MembreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Membre");
            });
        }
    }
}