using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DataAccess.Concrete
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SystemStaff> SystemStaffs { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostTemplates> PostTemplates { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserAllergies> UserAllergies { get; set; }
        public DbSet<UserMedications> UserMedications { get; set; }
        public DbSet<UserMedicalHistories> UserMedicalHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=MELIH\\SQLEXPRESS;Database=EmergencyApplicationDatabase; Trusted_Connection=True; TrustServerCertificate=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Categories").HasKey(k => k.Id);
                e.Property(c => c.Id).HasColumnName("Id");
                e.Property(c => c.CategoryName).HasColumnName("CategoryName");
                e.HasMany(c => c.Posts);
                e.HasMany(c => c.PostTemplates);
            });

            modelBuilder.Entity<Contact>(e =>
            {
                e.ToTable("Contacts").HasKey(k => k.Id);
                e.Property(c => c.Id).HasColumnName("Id");
                e.Property(c => c.UserId).HasColumnName("UserId");
                e.Property(c => c.ContactId).HasColumnName("ContactId");
                e.Property(c => c.ContactRelation).HasColumnName("ContactRelation");
                e.HasOne(c => c.User).WithMany(u => u.Contacts).HasForeignKey(u => u.UserId);
                e.HasOne(c => c.ContactUser).WithMany(u => u.ContactUsers).HasForeignKey(u => u.ContactId);
            });

            modelBuilder.Entity<MedicalHistory>(e =>
            {
                e.ToTable("MedicalHistories").HasKey(k => k.Id);
                e.Property(m => m.Id).HasColumnName("Id");
                e.Property(m => m.Name).HasColumnName("Name");
                e.Property(m => m.Description).HasColumnName("Description");
                e.HasMany(m => m.UserMedicalHistories);
            });


            modelBuilder.Entity<UserAllergies>(e =>
            {
                e.ToTable("UserAllergies").HasKey(k => k.Id);
                e.Property(u => u.Id).HasColumnName("Id");
                e.Property(u => u.UserId).HasColumnName("UserId");
                e.Property(u => u.AllergyId).HasColumnName("AllergyId");
                e.HasOne(u => u.UserProfile).WithMany(u => u.UserAllergies).HasForeignKey(u => u.UserId);
                e.HasOne(u => u.Allergy).WithMany(u => u.UserAllergies).HasForeignKey(u => u.AllergyId);
            });

            modelBuilder.Entity<UserMedicalHistories>(e =>
            {
                e.ToTable("UserMedicalHistories").HasKey(k => k.Id);
                e.Property(u => u.Id).HasColumnName("Id");
                e.Property(u => u.UserId).HasColumnName("UserId");
                e.Property(u => u.MedicalHistoryId).HasColumnName("MedicalHistoryId");
                e.HasOne(u => u.UserProfile).WithMany(u => u.UserMedicalHistories).HasForeignKey(u => u.UserId);
                e.HasOne(u => u.MedicalHistory).WithMany(u => u.UserMedicalHistories).HasForeignKey(u => u.MedicalHistoryId);
            });

            modelBuilder.Entity<UserMedications>(e =>
            {
                e.ToTable("UserMedications").HasKey(k => k.Id);
                e.Property(u => u.Id).HasColumnName("Id");
                e.Property(u => u.UserId).HasColumnName("UserId");
                e.Property(u => u.MedicationId).HasColumnName("MedicationId");
                e.HasOne(u => u.UserProfile).WithMany(u => u.UserMedications).HasForeignKey(u => u.UserId);
                e.HasOne(u => u.Medication).WithMany(u => u.UserMedications).HasForeignKey(u => u.MedicationId);
            });

            modelBuilder.Entity<Medication>(e =>
            {
                e.ToTable("Medications").HasKey(k => k.Id);
                e.Property(m => m.Id).HasColumnName("Id");
                e.Property(m => m.Name).HasColumnName("Name");
                e.Property(m => m.Description).HasColumnName("Description");
                e.HasMany(m => m.UserMedications);
            });

            modelBuilder.Entity<Post>(e =>
            {
                e.ToTable("Posts").HasKey(k => k.Id);
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.UserId).HasColumnName("UserId");
                e.Property(p => p.CategoryId).HasColumnName("CategoryId");
                e.Property(p => p.Description).HasColumnName("Description");
                e.Property(p => p.Date).HasColumnName("Date");
                e.Property(p => p.Latitude).HasColumnName("Latitude");
                e.Property(p => p.Longitude).HasColumnName("Longitude");
                e.Property(p => p.Title).HasColumnName("Title");
                e.HasMany(p => p.Sources);
                e.HasOne(p => p.User).WithMany(u => u.Posts).HasForeignKey(u => u.UserId);
                e.HasOne(p => p.Category).WithMany(u => u.Posts).HasForeignKey(c => c.CategoryId);
            });

            modelBuilder.Entity<Source>(e =>
            {
                e.ToTable("Sources").HasKey(k => k.Id);
                e.Property(s => s.Id).HasColumnName("Id");
                e.Property(s => s.PostId).HasColumnName("PostId");
                e.Property(s => s.SourcePath).HasColumnName("SourcePath");
                e.Property(s => s.Date).HasColumnName("Date");
                e.Property(s => s.SourceCategory).HasColumnName("SourceCategory");
                e.HasOne(s => s.Post).WithMany(p => p.Sources).HasForeignKey(p => p.PostId);
            });

            modelBuilder.Entity<SystemStaff>(e =>
            {
                e.ToTable("SystemStaffs").HasKey(k => k.Id);
                e.Property(s => s.Id).HasColumnName("Id");
                e.Property(s => s.UserId).HasColumnName("UserId");
                e.Property(s => s.StaffNumber).HasColumnName("StaffNumber");
                e.Property(s => s.StaffStatus).HasColumnName("StaffStatus");
                e.HasOne(s => s.User).WithOne(u => u.SystemStaff).HasForeignKey<SystemStaff>(s => s.UserId);
            });

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(u => u.Id).HasColumnName("Id");
                a.Property(u => u.Email).HasColumnName("Email");
                a.Property(u => u.FirstName).HasColumnName("FirstName");
                a.Property(u => u.LastName).HasColumnName("LastName");
                a.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                a.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(u => u.BirthDate).HasColumnName("BirthDate");
                a.Property(u => u.IdentityNumber).HasColumnName("IdentityNumber");
                a.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
                a.Property(u => u.Status).HasColumnName("Status");
                a.HasMany(u => u.RefreshTokens);
                a.HasMany(u => u.UserOperationClaims);
                a.HasMany(u => u.Posts);
            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(u => u.Id).HasColumnName("Id");
                a.Property(u => u.UserId).HasColumnName("UserId");
                a.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");
                a.HasOne(u => u.User).WithMany(u => u.UserOperationClaims).HasForeignKey(u => u.UserId);
                a.HasOne(u => u.OperationClaim).WithMany(o => o.UserOperationClaims)
                    .HasForeignKey(o => o.OperationClaimId);
            });

            modelBuilder.Entity<UserProfile>(e =>
            {
                e.ToTable("UserProfiles").HasKey(k => k.Id);
                e.Property(u => u.Id).HasColumnName("Id");
                e.Property(u => u.UserId).HasColumnName("UserId");
                e.Property(u => u.BloodType).HasColumnName("BloodType");
                e.Property(u => u.Height).HasColumnName("Height");
                e.Property(u => u.Weight).HasColumnName("Weight");
                e.Property(u => u.Address).HasColumnName("Address");
                e.Property(u => u.PhoneNumber).HasColumnName("PhoneNumber");
                e.Property(u => u.ProfilePicture).HasColumnName("ProfilePicture");
                e.HasOne(u => u.User).WithOne(u => u.UserProfile).HasForeignKey<UserProfile>(u => u.UserId);
                e.HasMany(u => u.UserMedicalHistories);
                e.HasMany(u => u.UserMedications);
                e.HasMany(u => u.UserAllergies);
            });

            modelBuilder.Entity<RefreshToken>(a =>
            {
                a.ToTable("RefreshTokens").HasKey(k => k.Id);
                a.Property(u => u.Id).HasColumnName("Id");
                a.Property(r => r.UserId).HasColumnName("UserId");
                a.Property(r => r.Created).HasColumnName("Created");
                a.Property(r => r.CreatedByIp).HasColumnName("CreatedByIp");
                a.Property(r => r.Expires).HasColumnName("Expires");
                a.Property(r => r.ReasonRevoked).HasColumnName("ReasonRevoked");
                a.Property(r => r.ReplacedByToken).HasColumnName("ReplacedByToken");
                a.Property(r => r.Revoked).HasColumnName("Revoked");
                a.Property(r => r.RevokedByIp).HasColumnName("RevokedByIp");
                a.Property(r => r.Token).HasColumnName("Token");
                a.HasOne(r => r.User).WithMany(u => u.RefreshTokens).HasForeignKey(u => u.UserId);
            });


            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(o => o.Id).HasColumnName("Id");
                a.Property(o => o.Name).HasColumnName("Name");
                a.HasMany(u => u.UserOperationClaims);
            });

            modelBuilder.Entity<PostTemplates>(a =>
            {
                a.ToTable("PostTemplates").HasKey(k => k.Id);
                a.Property(o => o.Id).HasColumnName("Id");
                a.Property(o => o.CategoryId).HasColumnName("CategoryId");
                a.Property(o => o.Description).HasColumnName("Description");
                a.Property(o => o.Title).HasColumnName("Title");
                a.HasOne(o => o.Category).WithMany(c => c.PostTemplates).HasForeignKey(c => c.CategoryId);
            });

        }
    }
}