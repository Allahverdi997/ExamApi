using Application.Abstraction.Context;
using Domain.Concrete.Core;
using Domain.Concrete.Core.Application;
using Domain.Concrete.Core.Auth;
using Domain.Concrete.Core.Exam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistance.EF.DBContext
{
    public class ApplicationDbContext : DbContext,ISqlDbContext
    {
        public readonly Dictionary<Type, object> DbSets;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            DbSets = new Dictionary<Type, object>();
        }

        //Application

        public DbSet<ExceptionNotification> ExceptionNotifications { get; set; }
        public DbSet<Configuration> Configurations { get; set; }


        

        // Auth
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserPrivs { get; set; }

        //Exam
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonInfo> LessonInfos { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        EntityEntry ISqlDbContext.Entry<T>(T entity)
        {
            return Entry(entity);
        }

        DbSet<TEntity> ISqlDbContext.GetDbSet<TEntity>()
        {
            if (DbSets.ContainsKey(typeof(TEntity)))
                return (DbSet<TEntity>)DbSets[typeof(TEntity)];

            DbSets.Add(typeof(TEntity), Set<TEntity>());

            return Set<TEntity>();
        }

        void ISqlDbContext.SaveChanges()
        {
            SaveChanges();
        }

        public async Task DisposeContext()
        {
            await DisposeAsync();
        }

        public async Task SaveChangesAsync()
        {
            await SaveChangesAsync();
        }
    }
}
