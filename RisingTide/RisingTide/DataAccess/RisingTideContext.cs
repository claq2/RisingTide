using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using RisingTide.Models;
using System.Web.Security;

namespace RisingTide.DataAccess
{
    public class RisingTideContext : DbContext, IDomainContext
    {
        /// <summary>
        /// Initializes a new instance of the LcboDrinkLocatorContext class.
        /// </summary>
        public RisingTideContext()
            : this(true)
        {
        }

        public RisingTideContext(bool enableChangeTracking)
            : base("ApplicationServices")
        {
            this.Configuration.AutoDetectChangesEnabled = enableChangeTracking;
            //this.Configuration.LazyLoadingEnabled = false;
        }

        static RisingTideContext()
        {
            QueryableExtensions.Includer = new DbIncluder();
        }

        private class DbIncluder : QueryableExtensions.IIncluder
        {
            public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path)
                where T : class
            {
                return DbExtensions.Include(source, path);
            }
        }

        public virtual DbSet<ScheduledPayment> ScheduledPayments { get; set; }

        IQueryable<ScheduledPayment> IDomainContext.ScheduledPayments
        {
            get { return this.ScheduledPayments.Where(x => !x.IsDeleted); }
        }

        public virtual DbSet<User> Users { get; set; }

        IQueryable<User> IDomainContext.Users
        {
            get { return this.Users.Where(x => !x.IsDeleted); }
        }

        public virtual DbSet<Recurrence> Recurrences { get; set; }

        IQueryable<Recurrence> IDomainContext.Recurrences
        {
            get { return this.Recurrences.Where(x => !x.IsDeleted); }
        }

        public virtual DbSet<PaymentType> PaymentTypes { get; set; }

        IQueryable<PaymentType> IDomainContext.PaymentTypes
        {
            get { return this.PaymentTypes.Where(x => !x.IsDeleted); }
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Store>().Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //modelBuilder.Entity<Store>().Ignore(s => s.UsedByUser);
            //modelBuilder.Entity<Store>().Ignore(s => s.Distance);

            //modelBuilder.Entity<Product>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //modelBuilder.Entity<Product>().Ignore(p => p.Name);
            //modelBuilder.Entity<Product>().Ignore(p => p.UsedByUser);

            //modelBuilder.Entity<User>().HasMany(u => u.Stores).WithMany(s => s.Users).Map(c =>
            //{
            //    c.MapLeftKey("UserId");
            //    c.MapRightKey("StoreId");
            //    c.ToTable("StoresAndUsers");
            //});

            //modelBuilder.Entity<User>().HasMany(u => u.Products).WithMany(p => p.Users).Map(c =>
            //{
            //    c.MapLeftKey("UserId");
            //    c.MapRightKey("ProductId");
            //    c.ToTable("ProductsAndUsers");
            //});

            //modelBuilder.Entity<User>().HasMany(u => u.PersonalLocations).WithMany(pl => pl.Users).Map(c =>
            //{
            //    c.MapLeftKey("UserId");
            //    c.MapRightKey("PersonalLocationId");
            //    c.ToTable("PersonalLocationsAndUsers");
            //});

            //modelBuilder.Entity<PersonalLocation>().Property(pl => pl.Latitude).HasPrecision(18, 13);
            //modelBuilder.Entity<PersonalLocation>().Property(pl => pl.Longitude).HasPrecision(18, 13);

            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            base.OnModelCreating(modelBuilder);
        }

        void IDomainContext.SaveChanges()
        {
            this.SaveChanges();
        }

        void IDomainContext.Save<T>(T entity)
        {
            this.Set<T>().Add(entity);
        }

        void IDomainContext.Delete<T>(int id)
        {
            T entityToDelete = this.Set<T>().Find(id);
            entityToDelete.IsDeleted = true;
        }
    }
}