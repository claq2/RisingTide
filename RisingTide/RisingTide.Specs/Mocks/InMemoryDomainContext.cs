using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RisingTide.DataAccess;
using System.Collections;
using RisingTide.Models;

namespace RisingTide.Specs.Mocks
{
    internal class InMemoryDomainContext : IDomainContext
    {
        public bool Saved { get; private set; }
        public bool Disposed { get; private set; }

        private readonly HashSet<ScheduledPayment> scheduledPaymentSet;
        private readonly HashSet<User> userSet;
        private readonly HashSet<Recurrence> recurrenceSet;
        private readonly HashSet<PaymentType> paymentTypeSet;

        private readonly Dictionary<int, ScheduledPayment> scheduledPaymentDict;
        private readonly Dictionary<int, User> userDict;
        private readonly Dictionary<int, Recurrence> recurrenceDict;
        private readonly Dictionary<int, PaymentType> paymentTypeDict;

        private readonly Dictionary<Type, IDictionary> dicts;

        private readonly Dictionary<Type, IEnumerable> sets;

        /// <summary>
        /// Initializes a new instance of the InMemoryDomainContext class.
        /// </summary>
        public InMemoryDomainContext()
        {
            this.scheduledPaymentSet = new HashSet<ScheduledPayment>();
            this.userSet = new HashSet<User>();
            this.recurrenceSet = new HashSet<Recurrence>();
            this.paymentTypeSet = new HashSet<PaymentType>();

            this.sets = new Dictionary<Type, IEnumerable>();
            this.sets.Add(typeof(ScheduledPayment), this.scheduledPaymentSet);
            this.sets.Add(typeof(User), this.userSet);
            this.sets.Add(typeof(Recurrence), this.recurrenceSet);
            this.sets.Add(typeof(PaymentType), this.paymentTypeSet);

            this.scheduledPaymentDict = new Dictionary<int, ScheduledPayment>();
            this.userDict = new Dictionary<int, User>();
            this.recurrenceDict = new Dictionary<int, Recurrence>();
            this.paymentTypeDict = new Dictionary<int, PaymentType>();

            this.dicts = new Dictionary<Type, IDictionary>();
            this.dicts.Add(typeof(ScheduledPayment), this.scheduledPaymentDict);
            this.dicts.Add(typeof(User), this.userDict);
            this.dicts.Add(typeof(Recurrence), this.recurrenceDict);
            this.dicts.Add(typeof(PaymentType), this.paymentTypeDict);
        }

        public void Populate<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            HashSet<T> set = this.LocateSetFor<T>();
            set.Clear();
            foreach (T entity in entities)
            {
                set.Add(entity);
            }
        }

        public void PopulateDictionary<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            Dictionary<int, T> dictionary = this.LocateDictionaryFor<T>();
            dictionary.Clear();
            foreach (T entity in entities)
            {
                dictionary.Add(entity.Id, entity);
            }
        }

        public void SaveChanges()
        {
            this.Saved = true;
        }

        public void Save<T>(T entity) where T : class, IEntity
        {
            if (!this.LocateSetFor<T>().Add(entity))
            {
                throw new ArgumentException("Entity already added to hashset");
            };

            this.LocateDictionaryFor<T>().Add(entity.Id, entity);
        }

        public void Delete<T>(int id) where T : class, IEntity
        {
            this.LocateSetFor<T>().FirstOrDefault(x => x.Id == id).IsDeleted = true;
            this.LocateDictionaryFor<T>()[id].IsDeleted = true;
        }

        public IQueryable<ScheduledPayment> ScheduledPayments
        {
            get { return this.scheduledPaymentSet.AsQueryable(); }
        }

        public IQueryable<User> Users
        {
            get { return this.userSet.AsQueryable(); }
        }

        public IQueryable<Recurrence> Recurrences
        {
            get { return this.recurrenceSet.AsQueryable(); }
        }

        public IQueryable<PaymentType> PaymentTypes
        {
            get { return this.paymentTypeSet.AsQueryable(); }
        }

        public void Dispose()
        {
            this.Disposed = true;
        }

        private Dictionary<int, T> LocateDictionaryFor<T>() where T : class, IEntity
        {
            IDictionary dict;
            this.dicts.TryGetValue(typeof(T), out dict);
            Dictionary<int, T> result = dict as Dictionary<int, T>;
            return result;
        }

        private HashSet<T> LocateSetFor<T>() where T : class, IEntity
        {
            IEnumerable set;
            this.sets.TryGetValue(typeof(T), out set);
            HashSet<T> result = set as HashSet<T>;
            return result;

            //if (typeof(T) == typeof(ScheduledPayment))
            //{
            //    return this.scheduledPaymentSet as HashSet<T>;
            //}
            //else if (typeof(T) == typeof(User))
            //{
            //    return this.userSet as HashSet<T>;
            //}
            //else if (typeof(T) == typeof(Recurrence))
            //{
            //    return this.recurrenceSet as HashSet<T>;
            //}
            //else if (typeof(T) == typeof(PaymentType))
            //{
            //    return this.paymentTypeSet as HashSet<T>;
            //}
            //else
            //{
            //    throw new ArgumentException(String.Format("No set defined for entity of type{0}", typeof(T)));
            //}
        }
    }
}
