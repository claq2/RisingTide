using System;
using System.Collections.Generic;
using System.Linq;
using RisingTide.Models;

namespace RisingTide.DataAccess
{
    public interface IDomainContext : IDisposable
    {
        void SaveChanges();

        void Save<T>(T entity) where T : class, IEntity;

        void Delete<T>(int id) where T : class, IEntity;

        IQueryable<ScheduledPayment> ScheduledPayments { get; }
        IQueryable<User> Users { get; }
    }
}
