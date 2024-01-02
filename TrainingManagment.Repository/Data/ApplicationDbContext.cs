using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TrainingManagement.Domain.Models;
using TrainingManagment.Domain.Models;
using static System.Collections.Specialized.BitVector32;

namespace TrainingManagment.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
 
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading
        //}
        public DbSet<Session> Session { get; set; }
        public DbSet<Lookup> Lookup { get; set; }
        public DbSet<LookupCategory> LookupCategory { get; set; }
        public DbSet<User> User { get; set; }

        //public DbSet<Trainer> Trainers { get; set; }

        //public DbSet<Topics> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasDefaultSchema("TPS"); // to change the the name of the schema
 
            // Rename the table names
            modelBuilder.Entity<User>().ToTable("Users", "Security");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "Security");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Security");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Security");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Security");

            // Define primary keys
            modelBuilder.Entity<Lookup>().HasKey(e => e.Id);
            modelBuilder.Entity<LookupCategory>().HasKey(e => e.CategoryId);


            //modelBuilder.Entity<Trainer>().HasKey(e => e.TrainerId);
            //modelBuilder.Entity<Topics>().HasKey(e => e.TopicId);

            // Your model configurations...
            modelBuilder.Entity<Session>()
           .HasOne(s => s.TrainingTopic)
           .WithMany()
           .HasForeignKey(s => s.TrainingTopicId);

            modelBuilder.Entity<Session>()
         .HasOne(s => s.TrainingType)
         .WithMany()
         .HasForeignKey(s => s.TrainingTypeId);

            modelBuilder.Entity<Session>()
         .HasOne(s => s.TrainerName)
         .WithMany()
         .HasForeignKey(s => s.TrainerNameId);

            //modelBuilder.Entity<Trainer>()
            //   .HasMany(s => s.Topics)  
            //   .WithMany(c => c.Trainers)  
            //   .UsingEntity(j => j.ToTable("TrainerTopics"));
            // Seed data
             SeedData(modelBuilder);



         }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed data for LookupCategories
            modelBuilder.Entity<LookupCategory>().HasData(
                new LookupCategory { CategoryId = 100, Code = 1, NameEn = "Training Type", 
                    NameAr = "نوع التدريب", CreatedBy = "Malek Hamdan", IsActive = true, IsDeleted = false, 
                    CreatedOn = DateTime.Now, ModifyBy = null, Description = "Training Type That TPS Provided"
                },
                new LookupCategory { CategoryId = 200, Code = 2, NameEn = "Training Topics", NameAr = "موضوعات التدريب",
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = "Training Topics That TPS Provided"
                },
                new LookupCategory { CategoryId = 300, Code = 3, NameEn = "Training Status", NameAr = "حالة التدريب",
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = "Training Status"
                },
                new LookupCategory { CategoryId = 400, Code = 4, NameEn = "Training Result", NameAr = "نتيجة التدريب",
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = "Training Result"
                },
                new LookupCategory { CategoryId = 500, Code = 5, NameEn = "Trainer Name", NameAr = "أسم المدرب",
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = "Trainer Name"
                },
                new LookupCategory { CategoryId = 600, Code = 6, NameEn = "Year", NameAr = "السنة",
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = "Training Year That TPS Provided"
                }
            );

            // Seed data for Lookups using enum values
            modelBuilder.Entity<Lookup>().HasData(
                // Training Type Lookups
                new Lookup { Id = 1, Code = 1, NameEn = "Work", NameAr = "عمل", LookupCategoryId = 100,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 2, Code = 2, NameEn = "University", NameAr = "جامعة", LookupCategoryId = 100,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },

                // Training Topics Lookups
                new Lookup { Id = 3, Code = 1, NameEn = "Dot Net", NameAr = ".Net", LookupCategoryId = 200,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 4, Code = 2, NameEn = "Business Analyst", NameAr = "محلل أعمال", LookupCategoryId = 200,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 5, Code = 3, NameEn = "Quality Control", NameAr = "مراقبة الجودة", LookupCategoryId = 200,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 6, Code = 4, NameEn = "Infrastructure", NameAr = "بنية الأنظمة", LookupCategoryId = 200,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 7, Code = 5, NameEn = "UI UX", NameAr = "واجهة المستخدم وتجربة المستخدم", LookupCategoryId = 200,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 8, Code = 6, NameEn = "Human Resources", NameAr = "الموارد البشرية", LookupCategoryId = 200,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 9, Code = 7, NameEn = "Finance", NameAr = "المالية", LookupCategoryId = 200,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 10, Code = 8, NameEn = "AI", NameAr = "الذكاء الاصطناعي", LookupCategoryId = 200,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },

                // Training Status Lookups
                new Lookup { Id = 11, Code = 1, NameEn = "Active", NameAr = "نشط", LookupCategoryId = 300,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 12, Code = 2, NameEn = "Pending", NameAr = "قيد الانتظار", LookupCategoryId = 300,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 13, Code = 3, NameEn = "Finished", NameAr = "مكتمل", LookupCategoryId = 300,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },

                // Training Result Lookups
                new Lookup { Id = 14, Code = 1, NameEn = "Joining TPS Team", NameAr = "الانضمام إلى فريق TPS", LookupCategoryId = 400,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 15, Code = 2, NameEn = "On Hold", NameAr = "معلق", LookupCategoryId = 400,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 16, Code = 3, NameEn = "Rejected", NameAr = "مرفوض", LookupCategoryId = 400,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 17, Code = 4, NameEn = "Quit", NameAr = "استقال", LookupCategoryId = 400,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },

                // Trainer Lookups

                new Lookup { Id = 18, Code = 1, NameEn = "Khalid Salameh", NameAr = "خالد سلامة", LookupCategoryId = 500,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 19, Code = 2, NameEn = "Lamees Hourani", NameAr = "لميس حوراني", LookupCategoryId = 500,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 20, Code = 3, NameEn = "Mariam AlSadawi", NameAr = "مريم السعداوي", LookupCategoryId = 500,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 21, Code = 4, NameEn = "Mohammad Hamad", NameAr = "محمد حماد", LookupCategoryId = 500,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 22, Code = 5, NameEn = "Mohammad Ibdah", NameAr = "محمد عبده", LookupCategoryId = 500,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 23, Code = 6, NameEn = "Safaa", NameAr = "صفاء", LookupCategoryId = 500,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 24, Code = 7, NameEn = "Zakaria Lafi", NameAr = "زكريا لافي", LookupCategoryId = 500,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 25, Code = 8, NameEn = "Ahmed Sweilem", NameAr = "أحمد سويلم", LookupCategoryId = 500,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },

                // Year Lookups
                new Lookup { Id = 26, Code = 2023, NameEn = "2023", NameAr = "2023", LookupCategoryId = 600,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 27, Code = 2024, NameEn = "2024", NameAr = "2024", LookupCategoryId = 600,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 28, Code = 2025, NameEn = "2025", NameAr = "2025", LookupCategoryId = 600,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 29, Code = 2026, NameEn = "2026", NameAr = "2026", LookupCategoryId = 600,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 30, Code = 2027, NameEn = "2027", NameAr = "2027", LookupCategoryId = 600,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 31, Code = 2028, NameEn = "2028", NameAr = "2028", LookupCategoryId = 600,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 32, Code = 2029, NameEn = "2029", NameAr = "2029", LookupCategoryId = 600,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 33, Code = 2030, NameEn = "2030", NameAr = "2030", LookupCategoryId = 600,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                },
                new Lookup { Id = 34, Code = 2031   , NameEn = "2031", NameAr = "2031", LookupCategoryId = 600,
                    CreatedBy = "Malek Hamdan",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    Description = ""
                }


            );
        }
    }
}
