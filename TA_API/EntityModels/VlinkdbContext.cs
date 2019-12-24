using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TA_API.EntityModels
{
    public partial class VlinkdbContext : DbContext
    {
        public VlinkdbContext()
        {
        }

        public VlinkdbContext(DbContextOptions<VlinkdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CandidateProfile> CandidateProfile { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<JobApplied> JobApplied { get; set; }
        public virtual DbSet<NewJob> NewJob { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=vlinkedstc.database.windows.net;Database=Vlinkdb;User ID=vlinkedstc;Password=vlink@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("PK__Candidat__290C88E437098087");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentCompany)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentCtc).HasColumnName("CurrentCTC");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DesiredLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExpectedCtc).HasColumnName("ExpectedCTC");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Resumeattachment).IsUnicode(false);

                entity.Property(e => e.Skills)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasKey(e => e.DesgnId)
                    .HasName("PK__Designat__69F80A41A08C8C7F");

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JobApplied>(entity =>
            {
                entity.HasKey(e => e.JobApplId)
                    .HasName("PK__JobAppli__E4CE0E7DDE9CF304");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NewJob>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("PK__NewJob__056690C263F0CFA3");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ctc)
                    .HasColumnName("CTC")
                    .HasColumnType("money");

                entity.Property(e => e.JobType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastmodifiedDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoticePeriod)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Positions).HasColumnName("positions");

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SkillSet)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE1A1E6CE9F8");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Users__1797D024C3905916");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImg).IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
