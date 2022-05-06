using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BDProjetSession.Models
{
    public partial class H22_4D5_Projet_sessionContext : DbContext
    {
        public H22_4D5_Projet_sessionContext()
        {
        }

        public H22_4D5_Projet_sessionContext(DbContextOptions<H22_4D5_Projet_sessionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Disponibilite> Disponibilites { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Photographe> Photographes { get; set; }
        public virtual DbSet<Propriete> Proprietes { get; set; }
        public virtual DbSet<RendezVou> RendezVous { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;Trusted_Connection=true;Database=H22_4D5_Projet_session");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Disponibilite>(entity =>
            {
                entity.ToTable("Disponibilite", "Disponibilites");

                entity.HasIndex(e => e.RendezVousId, "IX_dispo_photographeID");

                entity.HasIndex(e => e.RendezVousId, "IX_dispo_rdvID");

                entity.HasIndex(e => new { e.PhotographeId, e.DateDisponibilite, e.HeureDebut }, "UC_photographe_date_heure")
                    .IsUnique();

                entity.Property(e => e.DisponibiliteId).HasColumnName("disponibiliteID");

                entity.Property(e => e.DateDisponibilite).HasColumnName("dateDisponibilite");

                entity.Property(e => e.HeureDebut).HasColumnName("heureDebut");

                entity.Property(e => e.HeureFin).HasComputedColumnSql("([Disponibilites].[ufnCalcHeureFin]([heureDebut]))", false);

                entity.Property(e => e.PhotographeId).HasColumnName("photographeID");

                entity.Property(e => e.RendezVousId).HasColumnName("rendezVousID");

                entity.Property(e => e.Statut)
                    .HasMaxLength(30)
                    .HasColumnName("statut");

                entity.HasOne(d => d.Photographe)
                    .WithMany(p => p.Disponibilites)
                    .HasForeignKey(d => d.PhotographeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_photographeID");

                entity.HasOne(d => d.RendezVous)
                    .WithMany(p => p.Disponibilites)
                    .HasForeignKey(d => d.RendezVousId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_rendezVousID");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo", "Photos");

                entity.HasIndex(e => e.RendezVousId, "IX_Photo_RendezVousID");

                entity.Property(e => e.PhotoId).HasColumnName("photoID");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nom");

                entity.Property(e => e.RendezVousId).HasColumnName("rendezVousID");

                entity.HasOne(d => d.RendezVous)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.RendezVousId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_RendezVousID");
            });

            modelBuilder.Entity<Photographe>(entity =>
            {
                entity.ToTable("Photographes", "Utilisateurs");

                entity.Property(e => e.PhotographeId).HasColumnName("photographeID");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nom");
            });

            modelBuilder.Entity<Propriete>(entity =>
            {
                entity.ToTable("Propriete", "Proprietes");

                entity.Property(e => e.ProprieteId).HasColumnName("proprieteID");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("adresse");

                entity.Property(e => e.NomProprio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomProprio");

                entity.Property(e => e.TelProprio)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("telProprio");

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("ville");
            });

            modelBuilder.Entity<RendezVou>(entity =>
            {
                entity.HasKey(e => e.RendezVousId)
                    .HasName("PK_rendezVousID");

                entity.ToTable("RendezVous", "Disponibilites");

                entity.HasIndex(e => e.proprieteID, "IX_rv_proprieteID");

                entity.Property(e => e.RendezVousId).HasColumnName("rendezVousID");

                entity.Property(e => e.commentaire)
                    .HasMaxLength(250)
                    .HasColumnName("commentaire");

                entity.Property(e => e.commentairePhotos)
                    .HasMaxLength(250)
                    .HasColumnName("commentairePhotos");

                entity.Property(e => e.dateRendezvous).HasColumnName("dateRendezVous");

                entity.Property(e => e.heureDebut).HasColumnName("heureDebut");

                entity.Property(e => e.HeureFin).HasComputedColumnSql("([Disponibilites].[ufnCalcHeureFin]([heureDebut]))", false);

                entity.Property(e => e.justification)
                    .HasMaxLength(250)
                    .HasColumnName("justification");

                entity.Property(e => e.proprieteID).HasColumnName("proprieteID");

                entity.Property(e => e.statutPhoto)
                    .HasMaxLength(30)
                    .HasColumnName("statutPhoto")
                    .HasDefaultValueSql("('Aucune')");

                entity.HasOne(d => d.Propriete)
                    .WithMany(p => p.RendezVous)
                    .HasForeignKey(d => d.proprieteID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_proprieteID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
