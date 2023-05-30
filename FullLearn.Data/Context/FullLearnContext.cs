using FullLearn.Data.Entities.Course;
using FullLearn.Data.Entities.Permissions;
using FullLearn.Data.Entities.User;
using FullLearn.Data.Entities.Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLearn.Data.Context
{
    public class FullLearnContext : DbContext
    {
        public FullLearnContext(DbContextOptions<FullLearnContext> options) : base(options)
        {

        }
        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion
        #region Wallet
        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        #endregion
        #region Permission
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        #endregion
        #region Course
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEpisode> CourseEpisodes { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<CourseStatus> CourseStatuses { get; set; }
        public DbSet<CourseGroup> CourseGroups { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasOne<CourseGroup>(f => f.CourseGroup)
                .WithMany(g => g.Courses).HasForeignKey(f => f.GroupId);

            modelBuilder.Entity<Course>().HasOne<CourseGroup>(f => f.Group)
                .WithMany(g => g.SubGroup).HasForeignKey(f => f.SubGroup);

            modelBuilder.Entity<Course>().HasQueryFilter(c => !c.IsDelete);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDelete);
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<CourseGroup>().HasQueryFilter(g => !g.IsDelete);
            base.OnModelCreating(modelBuilder);
        }
    }
}
