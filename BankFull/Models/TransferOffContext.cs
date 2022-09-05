using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankFull.Models
{
    public partial class TransferOffContext : DbContext
    {
       

        public TransferOffContext(DbContextOptions option) : base(option)
        {

        }

        public virtual DbSet<BankDetail> BankDetails { get; set; } = null!;
        public virtual DbSet<tblMessage> tblMessages { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> user { get; set; } = null!;
        public virtual DbSet<UserMessage> UserMessages { get; set; } = null!;
        public virtual DbSet<Assign> Assigns  { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server= DESKTOP-SC4NGQA\\SQLEXPRESS;Database=Transferv;Integrated Security=True");
            }
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankDetail>(entity =>
            {
                entity.ToTable("Bank Details");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AmountIn)
                    .HasMaxLength(100)
                    .HasColumnName("AmountIN")
                    .IsFixedLength();

                entity.Property(e => e.AmountOut)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionLimit)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BankDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Bank Details_User");
            });

            modelBuilder.Entity<tblMessage>(entity =>
            {
                entity.ToTable("tblMessage");

                entity.Property(e => e.Bank)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentPath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Messages)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Role1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.CrAmount).HasColumnName("Cr Amount");

                entity.Property(e => e.Date)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DrAmount).HasColumnName("Dr Amount");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Transaction_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.RoleId).HasColumnName("role_Id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });



            modelBuilder.Entity<UserMessage>(entity =>
            {


                entity.ToTable("User_Message");


                entity.Property(e => e.MessageId).HasColumnName("Message_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.tblMessage)
                    .WithMany(p => p.UserMessages)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("FK_User_Message_Message");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMessages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Message_User");

                //Latest added
               // entity.HasOne(d => d.User)
               //    .WithMany(p => p.UserMessages)
               //    .HasForeignKey(d => d.RecUserId)
               //    .HasConstraintName("FK_RecUser__User");

            });

                  modelBuilder.Entity<Assign>(entity =>
                  {
                      entity.ToTable("Assign");

                      entity.HasOne(d => d.TblMessage)
                          .WithMany(p => p.Assigns  )
                          .HasForeignKey(d => d.Messageid)
                          .HasConstraintName("FK_Assign_Message");
                  });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
