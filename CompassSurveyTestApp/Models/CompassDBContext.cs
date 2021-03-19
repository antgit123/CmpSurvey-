﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CompassSurveyTestApp.Models
{
    public partial class CompassDBContext : DbContext
    {
        public CompassDBContext()
        {
        }

        public CompassDBContext(DbContextOptions<CompassDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*IConfigurationRoot configuration = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build */
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=CompassDB;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer()
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Options>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OptionId)
                    .IsRequired()
                    .HasColumnName("optionId")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.OptionText)
                    .IsRequired()
                    .HasColumnName("optionText")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Options__questio__4CA06362");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("createdBy")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDataTime)
                    .HasColumnName("createdDataTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.QuestionType).HasColumnName("questionType");

                entity.Property(e => e.Subtitle)
                    .HasColumnName("subtitle")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SurveyId).HasColumnName("surveyId");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Questions__surve__49C3F6B7");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
