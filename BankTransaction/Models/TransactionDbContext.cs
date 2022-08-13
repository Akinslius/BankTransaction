using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankTransaction.Models
{
    public partial class TransactionDBContext : DbContext
    {
        public TransactionDBContext()
        {
        }

        public TransactionDBContext(DbContextOptions<TransactionDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.AccountNumber).HasMaxLength(12);

                entity.Property(e => e.BankName).HasMaxLength(100);

                entity.Property(e => e.BeneficiaryName).HasMaxLength(100);

                entity.Property(e => e.Swiftcode)
                    .HasMaxLength(11)
                    .HasColumnName("SWIFTCode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
