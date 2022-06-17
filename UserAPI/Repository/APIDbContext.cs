using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UserAPI.Repository.Models;

namespace UserAPI.Repository
{
    public partial class APIDbContext : DbContext
    {
        public APIDbContext()
        {
        }

        public APIDbContext(DbContextOptions<APIDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; } = null!;
        public virtual DbSet<ApartmentInterest> ApartmentInterests { get; set; } = null!;
        public virtual DbSet<ApartmentUserWant> ApartmentUserWants { get; set; } = null!;
        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<AreaInterest> AreaInterests { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<CustomerNeed> CustomerNeeds { get; set; } = null!;
        public virtual DbSet<House> Houses { get; set; } = null!;
        public virtual DbSet<HouseType> HouseTypes { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<PointOfInterest> PointOfInterests { get; set; } = null!;
        public virtual DbSet<PointOfInterestType> PointOfInterestTypes { get; set; } = null!;
        public virtual DbSet<PriceRange> PriceRanges { get; set; } = null!;
        public virtual DbSet<PriceRangeInterest> PriceRangeInterests { get; set; } = null!;
        public virtual DbSet<RentPost> RentPosts { get; set; } = null!;
        public virtual DbSet<RentPostType> RentPostTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public virtual DbSet<RoomTypeInterest> RoomTypeInterests { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=34.92.5.20;Initial Catalog=SWD;Persist Security Info=True;User ID=sqlserver;Password=iphone12");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApartmentInterest>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.ApartmentInterests)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApartmentInterest_Apartment");

                entity.HasOne(d => d.PointOfInterest)
                    .WithMany(p => p.ApartmentInterests)
                    .HasForeignKey(d => d.PointOfInterestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApartmentInterest_PointOfInterest");
            });

            modelBuilder.Entity<ApartmentUserWant>(entity =>
            {
                entity.HasOne(d => d.Apartment)
                    .WithMany()
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApartmentUserNeed_Apartment");

                entity.HasOne(d => d.CustomerNeed)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerNeedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApartmentUserNeed_CustomerNeed");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.AreaId).ValueGeneratedNever();
            });

            modelBuilder.Entity<AreaInterest>(entity =>
            {
                entity.HasOne(d => d.Area)
                    .WithMany()
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AreaInterest_Area");

                entity.HasOne(d => d.CustomerNeed)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerNeedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AreaInterest_CustomerNeed");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Building_Apartment");
            });

            modelBuilder.Entity<CustomerNeed>(entity =>
            {
                entity.Property(e => e.CustomerNeedId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CustomerNeeds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerNeed_User");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_House_Building");

                entity.HasOne(d => d.HouseType)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.HouseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_House_HouseType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_House_User");
            });

            modelBuilder.Entity<HouseType>(entity =>
            {
                entity.Property(e => e.HouseTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasOne(d => d.RentPost)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.RentPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Image_RentPost");
            });

            modelBuilder.Entity<PointOfInterest>(entity =>
            {
                entity.Property(e => e.PointOfInterestId).ValueGeneratedNever();

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.PointOfInterests)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_PointOfInterest_Area");

                entity.HasOne(d => d.PointOfInterestType)
                    .WithMany(p => p.PointOfInterests)
                    .HasForeignKey(d => d.PointOfInterestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PointOfInterest_PointOfInterestType");
            });

            modelBuilder.Entity<PointOfInterestType>(entity =>
            {
                entity.Property(e => e.PointOfInterestTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<PriceRange>(entity =>
            {
                entity.Property(e => e.PriceRangeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<PriceRangeInterest>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CustomerNeed)
                    .WithMany(p => p.PriceRangeInterests)
                    .HasForeignKey(d => d.CustomerNeedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriceRangeInterest_CustomerNeed");

                entity.HasOne(d => d.PriceRange)
                    .WithMany(p => p.PriceRangeInterests)
                    .HasForeignKey(d => d.PriceRangeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriceRangeInterest_PriceRange");
            });

            modelBuilder.Entity<RentPost>(entity =>
            {
                entity.HasOne(d => d.House)
                    .WithMany(p => p.RentPosts)
                    .HasForeignKey(d => d.HouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentPost_House");

                entity.HasOne(d => d.PriceRange)
                    .WithMany(p => p.RentPosts)
                    .HasForeignKey(d => d.PriceRangeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentPost_PriceRange");

                entity.HasOne(d => d.RentPostType)
                    .WithMany(p => p.RentPosts)
                    .HasForeignKey(d => d.RentPostTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentPost_RentPostType");
            });

            modelBuilder.Entity<RentPostType>(entity =>
            {
                entity.Property(e => e.RentPostTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).ValueGeneratedNever();

                entity.HasOne(d => d.HouseType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HouseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_HouseType1");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_RoomType");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.RoomTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<RoomTypeInterest>(entity =>
            {
                entity.HasOne(d => d.CustomerNeed)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerNeedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomTypeInterest_CustomerNeed");

                entity.HasOne(d => d.RoomType)
                    .WithMany()
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomTypeInterest_RoomType");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
