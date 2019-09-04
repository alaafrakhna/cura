using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TriagingSystem.Models
{
    public partial class triagingDBContext : DbContext
    {
        public triagingDBContext()
        {
        }

        public triagingDBContext(DbContextOptions<triagingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Algorithm> Algorithm { get; set; }
        public virtual DbSet<BodyAlgorithm> BodyAlgorithm { get; set; }
        public virtual DbSet<BodyPart> BodyPart { get; set; }
        public virtual DbSet<InstructionCare> InstructionCare { get; set; }
        public virtual DbSet<KeyWordBody> KeyWordBody { get; set; }
        public virtual DbSet<KeywordAlgorithem> KeywordAlgorithem { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QustionAnswer> QustionAnswer { get; set; }
        public virtual DbSet<TrustedContact> TrustedContact { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserRecord> UserRecord { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-DQMKLIH; Database=triagingDB; Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Algorithm>(entity =>
            {
                entity.Property(e => e.FirstStep).HasMaxLength(100);

                entity.Property(e => e.InjeryOrillness).HasColumnName("InjeryORIllness");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<BodyAlgorithm>(entity =>
            {
                entity.HasKey(e => new { e.IdAlgorithm, e.IdBodyPart });

                entity.HasOne(d => d.IdAlgorithmNavigation)
                    .WithMany(p => p.BodyAlgorithm)
                    .HasForeignKey(d => d.IdAlgorithm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BodyAlgorithm_Algorithm");

                entity.HasOne(d => d.IdBodyPartNavigation)
                    .WithMany(p => p.BodyAlgorithm)
                    .HasForeignKey(d => d.IdBodyPart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BodyAlgorithm_BodyPart");
            });

            modelBuilder.Entity<BodyPart>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<InstructionCare>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlgorithmId).HasColumnName("algorithmID");

                entity.Property(e => e.InstructionCare1).HasColumnName("instructionCare");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.Algorithm)
                    .WithMany(p => p.InstructionCare)
                    .HasForeignKey(d => d.AlgorithmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_instruction_provider_Algorithm");
            });

            modelBuilder.Entity<KeyWordBody>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KeyWord)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdBodyPartNavigation)
                    .WithMany(p => p.KeyWordBody)
                    .HasForeignKey(d => d.IdBodyPart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KeyWordBody_BodyPart");
            });

            modelBuilder.Entity<KeywordAlgorithem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Keyword)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdAlgorithemNavigation)
                    .WithMany(p => p.KeywordAlgorithem)
                    .HasForeignKey(d => d.IdAlgorithem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlgorithemKeyword_Algorithm");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasColumnName("Question");

                entity.HasOne(d => d.IdAlgorithemNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.IdAlgorithem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Algorithm");
            });

            modelBuilder.Entity<QustionAnswer>(entity =>
            {
                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AnswerApproved).HasMaxLength(20);

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.QustionAnswer)
                    .HasForeignKey(d => d.IdQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_State_Question");

                entity.HasOne(d => d.IdRecordNavigation)
                    .WithMany(p => p.QustionAnswer)
                    .HasForeignKey(d => d.IdRecord)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QustionAnswer_Record");
            });

            modelBuilder.Entity<TrustedContact>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TrustedContact)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrustedContact_UserInfo");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('F')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<UserRecord>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_UserRecord");

                entity.Property(e => e.AlgorithmId).HasColumnName("algorithmID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Rating).HasMaxLength(10);

                entity.HasOne(d => d.Algorithm)
                    .WithMany(p => p.UserRecord)
                    .HasForeignKey(d => d.AlgorithmId)
                    .HasConstraintName("FK_UserRecord_Algorithm");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRecord)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRecord_UserInfo");
            });
        }
    }
}
