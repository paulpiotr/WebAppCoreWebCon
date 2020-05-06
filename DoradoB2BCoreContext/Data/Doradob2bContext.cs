﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using DoradoB2BCoreContext.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DoradoB2BCoreContext.Models;

namespace DoradoB2BCoreContext.Data
{
    public partial class Doradob2bContext : DbContext
    {
        public virtual DbSet<Audit> Audit { get; set; }
        public virtual DbSet<DataSendMail> DataSendMail { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }

        public Doradob2bContext(DbContextOptions<Doradob2bContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=demo2.isk.com.pl;Initial Catalog=DoradoB2B;Persist Security Info=True;User ID=sa;Password=ZAQ123wsx!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataSendMail>(entity =>
            {
                entity.Property(e => e.Data).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MailOdbiorca).IsUnicode(false);
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.Property(e => e.ErrAplikacja).HasDefaultValueSql("((1))");

                entity.Property(e => e.ErrCallStack).IsUnicode(false);

                entity.Property(e => e.ErrClass).IsUnicode(false);

                entity.Property(e => e.ErrDataUtwozenia).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErrFileTextContent).IsUnicode(false);

                entity.Property(e => e.ErrFuncion).IsUnicode(false);

                entity.Property(e => e.ErrMessage).IsUnicode(false);

                entity.Property(e => e.ErrSource).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}