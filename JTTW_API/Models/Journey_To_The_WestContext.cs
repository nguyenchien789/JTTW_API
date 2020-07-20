using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JTTW_API.Models
{
    public partial class Journey_To_The_WestContext : DbContext
    {
        public Journey_To_The_WestContext()
        {
        }

        public Journey_To_The_WestContext(DbContextOptions<Journey_To_The_WestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<ActorList> ActorList { get; set; }
        public virtual DbSet<Calamity> Calamity { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentList> EquipmentList { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:jouney.database.windows.net,1433;Initial Catalog=jttwdb;Persist Security Info=False;User ID=admin1;Password=123@admin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.ActorId).HasColumnName("actorId");

                entity.Property(e => e.ActorName)
                    .HasColumnName("actorName")
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ActorList>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActorId).HasColumnName("actorId");

                entity.Property(e => e.CalamityId).HasColumnName("calamityId");

                entity.Property(e => e.Character)
                    .HasColumnName("character")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorList)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorList_Actor");

                entity.HasOne(d => d.Calamity)
                    .WithMany(p => p.ActorList)
                    .HasForeignKey(d => d.CalamityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorList_Calamity");
            });

            modelBuilder.Entity<Calamity>(entity =>
            {
                entity.Property(e => e.CalamityId).HasColumnName("calamityId");

                entity.Property(e => e.CalamityName)
                    .HasColumnName("calamityName")
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(100);

                entity.Property(e => e.NumberOfFilming).HasColumnName("numberOfFilming");

                entity.Property(e => e.RoleSpecification)
                    .HasColumnName("roleSpecification")
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Calamity)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Calamity_Status");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.EquipmentId).HasColumnName("equipmentId");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EquipmentName)
                    .HasColumnName("equipmentName")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<EquipmentList>(entity =>
            {
                entity.HasKey(e => new { e.EquipmentId, e.CalamityId });

                entity.Property(e => e.EquipmentId).HasColumnName("equipmentId");

                entity.Property(e => e.CalamityId).HasColumnName("calamityId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Calamity)
                    .WithMany(p => p.EquipmentList)
                    .HasForeignKey(d => d.CalamityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentList_Calamity");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentList)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentList_Equipment");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActorId).HasColumnName("actorId");

                entity.Property(e => e.CalamityId).HasColumnName("calamityId");

                entity.Property(e => e.EquipmentId).HasColumnName("equipmentId");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_History_Actor");

                entity.HasOne(d => d.Calamity)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.CalamityId)
                    .HasConstraintName("FK_History_Calamity");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("FK_History_Equipment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_User");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.StatusName)
                    .HasColumnName("statusName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ActorId).HasColumnName("actorId");

                entity.Property(e => e.IsActice).HasColumnName("isActice");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_User_Actor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
