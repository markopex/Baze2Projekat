using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestApp2
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Elektricar> Elektricars { get; set; }
        public virtual DbSet<Kvar> Kvars { get; set; }
        public virtual DbSet<Ocitavanje> Ocitavanjes { get; set; }
        public virtual DbSet<Odsustvo> Odsustvos { get; set; }
        public virtual DbSet<Oprema> Opremas { get; set; }
        public virtual DbSet<Popravlja> Popravljas { get; set; }
        public virtual DbSet<Potrosac> Potrosacs { get; set; }
        public virtual DbSet<Racun> Racuns { get; set; }
        public virtual DbSet<Radnik> Radniks { get; set; }
        public virtual DbSet<Strujomer> Strujomers { get; set; }
        public virtual DbSet<Zaduzuje> Zaduzujes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Elektricar>(entity =>
            {
                entity.HasKey(e => e.Jmbg)
                    .HasName("PK_ELEKTRICAR");

                entity.ToTable("Elektricar");

                entity.Property(e => e.Jmbg)
                    .ValueGeneratedNever()
                    .HasColumnName("JMBG");

                entity.HasOne(d => d.JmbgNavigation)
                    .WithOne(p => p.Elektricar)
                    .HasForeignKey<Elektricar>(d => d.Jmbg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Elektricar_fk0");
            });

            modelBuilder.Entity<Kvar>(entity =>
            {
                entity.HasKey(e => e.BrojKv)
                    .HasName("PK_KVAR");

                entity.ToTable("Kvar");

                entity.Property(e => e.BrojKv)
                    .ValueGeneratedNever()
                    .HasColumnName("BROJ_KV");

                entity.Property(e => e.DatumPr)
                    .HasColumnType("datetime")
                    .HasColumnName("DATUM_PR");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPIS");

                entity.Property(e => e.PotId).HasColumnName("POT_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("STATUS")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Pot)
                    .WithMany(p => p.Kvars)
                    .HasForeignKey(d => d.PotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Kvar_fk0");
            });

            modelBuilder.Entity<Ocitavanje>(entity =>
            {
                entity.HasKey(e => e.Datum)
                    .HasName("PK_OCITAVANJE");

                entity.ToTable("Ocitavanje");

                entity.Property(e => e.Datum)
                    .HasColumnType("datetime")
                    .HasColumnName("DATUM");

                entity.Property(e => e.Elektricar).HasColumnName("ELEKTRICAR");

                entity.Property(e => e.Kwh)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("KWH");

                entity.Property(e => e.Strujomer).HasColumnName("STRUJOMER");

                entity.HasOne(d => d.ElektricarNavigation)
                    .WithMany(p => p.Ocitavanjes)
                    .HasForeignKey(d => d.Elektricar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ocitavanje_fk1");

                entity.HasOne(d => d.StrujomerNavigation)
                    .WithMany(p => p.Ocitavanjes)
                    .HasForeignKey(d => d.Strujomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ocitavanje_fk0");
            });

            modelBuilder.Entity<Odsustvo>(entity =>
            {
                entity.HasKey(e => e.OdsId)
                    .HasName("PK_ODSUSTVO");

                entity.ToTable("Odsustvo");

                entity.Property(e => e.OdsId)
                    .ValueGeneratedNever()
                    .HasColumnName("ODS_ID");

                entity.Property(e => e.DatumDo)
                    .HasColumnType("datetime")
                    .HasColumnName("DATUM_DO");

                entity.Property(e => e.DatumOd)
                    .HasColumnType("datetime")
                    .HasColumnName("DATUM_OD");

                entity.Property(e => e.Placeno).HasColumnName("PLACENO");

                entity.Property(e => e.RadnikJmbg).HasColumnName("RADNIK_JMBG");

                entity.Property(e => e.Razlog)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RAZLOG");

                entity.HasOne(d => d.RadnikJmbgNavigation)
                    .WithMany(p => p.Odsustvos)
                    .HasForeignKey(d => d.RadnikJmbg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Odsustvo_fk0");
            });

            modelBuilder.Entity<Oprema>(entity =>
            {
                entity.HasKey(e => e.OprId)
                    .HasName("PK_OPREMA");

                entity.ToTable("Oprema");

                entity.Property(e => e.OprId)
                    .ValueGeneratedNever()
                    .HasColumnName("OPR_ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAZIV");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPIS");
            });

            modelBuilder.Entity<Popravlja>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Popravlja");

                entity.Property(e => e.BrojKv).HasColumnName("BROJ_KV");

                entity.Property(e => e.Datum)
                    .HasColumnType("datetime")
                    .HasColumnName("DATUM");

                entity.Property(e => e.Radnik).HasColumnName("RADNIK");

                entity.HasOne(d => d.BrojKvNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.BrojKv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Popravlja_fk0");

                entity.HasOne(d => d.RadnikNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Radnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Popravlja_fk1");
            });

            modelBuilder.Entity<Potrosac>(entity =>
            {
                entity.HasKey(e => e.PotId)
                    .HasName("PK_POTROSAC");

                entity.ToTable("Potrosac");

                entity.HasIndex(e => e.Naziv, "UQ__Potrosac__A371AEE08CF8CE07")
                    .IsUnique();

                entity.Property(e => e.PotId)
                    .ValueGeneratedNever()
                    .HasColumnName("POT_ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAZIV");

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SIFRA");
            });

            modelBuilder.Entity<Racun>(entity =>
            {
                entity.HasKey(e => e.BrojRacuna)
                    .HasName("PK_RACUN");

                entity.ToTable("Racun");

                entity.Property(e => e.BrojRacuna)
                    .ValueGeneratedNever()
                    .HasColumnName("BROJ_RACUNA");

                entity.Property(e => e.Datum)
                    .HasColumnType("datetime")
                    .HasColumnName("DATUM");

                entity.Property(e => e.Iznos)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("IZNOS");

                entity.Property(e => e.Kwh)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("KWH");

                entity.Property(e => e.Mesec).HasColumnName("MESEC");

                entity.Property(e => e.StrujomerBroj).HasColumnName("STRUJOMER_BROJ");

                entity.HasOne(d => d.StrujomerBrojNavigation)
                    .WithMany(p => p.Racuns)
                    .HasForeignKey(d => d.StrujomerBroj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Racun_fk0");
            });

            modelBuilder.Entity<Radnik>(entity =>
            {
                entity.HasKey(e => e.Jmbg)
                    .HasName("PK_RADNIK");

                entity.ToTable("Radnik");

                entity.Property(e => e.Jmbg)
                    .ValueGeneratedNever()
                    .HasColumnName("JMBG");

                entity.Property(e => e.DatumRodj)
                    .HasColumnType("datetime")
                    .HasColumnName("DATUM_RODJ");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IME");

                entity.Property(e => e.Plata).HasColumnName("PLATA");

                entity.Property(e => e.RadnoMesto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RADNO_MESTO");
            });

            modelBuilder.Entity<Strujomer>(entity =>
            {
                entity.HasKey(e => e.Broj)
                    .HasName("PK_STRUJOMER");

                entity.ToTable("Strujomer");

                entity.Property(e => e.Broj)
                    .ValueGeneratedNever()
                    .HasColumnName("BROJ");

                entity.Property(e => e.Potrosac).HasColumnName("POTROSAC");

                entity.Property(e => e.Snaga)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("SNAGA");

                entity.Property(e => e.Tip).HasColumnName("TIP");

                entity.Property(e => e.TrKwh)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("TR_KWH");

                entity.Property(e => e.UkupnoKwh)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("UKUPNO_KWH");

                entity.HasOne(d => d.PotrosacNavigation)
                    .WithMany(p => p.Strujomers)
                    .HasForeignKey(d => d.Potrosac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Strujomer_fk0");
            });

            modelBuilder.Entity<Zaduzuje>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Zaduzuje");

                entity.Property(e => e.Datum)
                    .HasColumnType("datetime")
                    .HasColumnName("DATUM");

                entity.Property(e => e.ElektricarId).HasColumnName("ELEKTRICAR_ID");

                entity.Property(e => e.OprId).HasColumnName("OPR_ID");

                entity.HasOne(d => d.Elektricar)
                    .WithMany()
                    .HasForeignKey(d => d.ElektricarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zaduzuje_fk0");

                entity.HasOne(d => d.Opr)
                    .WithMany()
                    .HasForeignKey(d => d.OprId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zaduzuje_fk1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
