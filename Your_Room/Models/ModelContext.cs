using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Your_Room.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Apartmentsad> Apartmentsads { get; set; }
        public virtual DbSet<Duration> Durations { get; set; }
        public virtual DbSet<Furniture> Furnitures { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID= JOR17_User163;PASSWORD=Test321;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JOR17_USER163")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Addresid)
                    .HasName("SYS_C00308356");

                entity.ToTable("ADDRESS");

                entity.Property(e => e.Addresid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ADDRESID");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CITY");
            });

            modelBuilder.Entity<Apartmentsad>(entity =>
            {
                entity.HasKey(e => e.Adid)
                    .HasName("SYS_C00308360");

                entity.ToTable("APARTMENTSADS");

                entity.Property(e => e.Adid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ADID");

                entity.Property(e => e.Addate)
                    .HasPrecision(6)
                    .HasColumnName("ADDATE");

                entity.Property(e => e.Address)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Adtitel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADTITEL");

                entity.Property(e => e.BuildingNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUILDING_NUMBER");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTIONS");

                entity.Property(e => e.Duration)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATION");

                entity.Property(e => e.Electricitybillprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ELECTRICITYBILLPRICE");

                entity.Property(e => e.Image1)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Image3)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE3");

                entity.Property(e => e.Image4)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE4");

                entity.Property(e => e.Image5)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE5");

                entity.Property(e => e.Image6)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE6");

                entity.Property(e => e.Image7)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE7");

                entity.Property(e => e.Image8)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE8");

                entity.Property(e => e.Numofbed)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMOFBED");

                entity.Property(e => e.Numofperson)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMOFPERSON");

                entity.Property(e => e.Numofroom)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMOFROOM");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STREET");

                entity.Property(e => e.Userinfo)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERINFO");

                entity.Property(e => e.Waterbillprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WATERBILLPRICE");

                entity.HasOne(d => d.AddressNavigation)
                    .WithMany(p => p.Apartmentsads)
                    .HasForeignKey(d => d.Address)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00308361");

                entity.HasOne(d => d.DurationNavigation)
                    .WithMany(p => p.Apartmentsads)
                    .HasForeignKey(d => d.Duration)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C00308362");

                entity.HasOne(d => d.UserinfoNavigation)
                    .WithMany(p => p.Apartmentsads)
                    .HasForeignKey(d => d.Userinfo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00308363");
            });

            modelBuilder.Entity<Duration>(entity =>
            {
                entity.ToTable("DURATIONS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Rentalduration)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RENTALDURATION");
            });

            modelBuilder.Entity<Furniture>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("SYS_C00308365");

                entity.ToTable("FURNITURES");

                entity.Property(e => e.Fid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FID");

                entity.Property(e => e.Address)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.BuildingNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUILDING_NUMBER");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTIONS");

                entity.Property(e => e.Fdate)
                    .HasPrecision(6)
                    .HasColumnName("FDATE");

                entity.Property(e => e.Ftitel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FTITEL");

                entity.Property(e => e.Image1)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Image3)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE3");

                entity.Property(e => e.Image4)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE4");

                entity.Property(e => e.Image5)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE5");

                entity.Property(e => e.Image6)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE6");

                entity.Property(e => e.Image7)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE7");

                entity.Property(e => e.Image8)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE8");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STREET");

                entity.Property(e => e.Userinfo)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERINFO");

                entity.HasOne(d => d.AddressNavigation)
                    .WithMany(p => p.Furnitures)
                    .HasForeignKey(d => d.Address)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00308366");

                entity.HasOne(d => d.UserinfoNavigation)
                    .WithMany(p => p.Furnitures)
                    .HasForeignKey(d => d.Userinfo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00308367");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00308354");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Age)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AGE");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenumber)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.UserImage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USER_IMAGE");

                entity.Property(e => e.Usertype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERTYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
