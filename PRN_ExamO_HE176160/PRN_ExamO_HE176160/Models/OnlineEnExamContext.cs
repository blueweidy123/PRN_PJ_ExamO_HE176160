using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRN_ExamO_HE176160.Models
{
    public partial class OnlineEnExamContext : DbContext
    {
        public OnlineEnExamContext()
        {
        }

        public OnlineEnExamContext(DbContextOptions<OnlineEnExamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<Option> Options { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAnswer> UserAnswers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                          .SetBasePath(Directory.GetCurrentDirectory())
                                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.ExamId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ExamID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.OptionId).HasColumnName("OptionID");

                entity.Property(e => e.OptionText)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QuestionID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Options__Questio__2B3F6F97");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QuestionID");

                entity.Property(e => e.ExamId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ExamID");

                entity.Property(e => e.QuestionText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__Questions__ExamI__286302EC");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.ExamId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ExamID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__Requests__ExamID__628FA481");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Requests__Status__619B8048");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.Property(e => e.ResultId).HasColumnName("ResultID");

                entity.Property(e => e.ExamId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ExamID");

                entity.Property(e => e.Marks).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__Results__ExamID__34C8D9D1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Results__UserID__33D4B598");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAnswer>(entity =>
            {
                entity.Property(e => e.UserAnswerId).HasColumnName("UserAnswerID");

                entity.Property(e => e.ExamId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ExamID");

                entity.Property(e => e.QuestionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QuestionID");

                entity.Property(e => e.SelectedOptionId).HasColumnName("SelectedOptionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK__UserAnswe__ExamI__2F10007B");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__UserAnswe__Quest__300424B4");

                entity.HasOne(d => d.SelectedOption)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.SelectedOptionId)
                    .HasConstraintName("FK__UserAnswe__Selec__30F848ED");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserAnswe__UserI__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
