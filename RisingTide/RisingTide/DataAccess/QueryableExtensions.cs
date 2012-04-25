using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;

namespace RisingTide.DataAccess
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Include<T>
                (this IQueryable<T> sequence, string path)
        {
            var objectQuery = sequence as ObjectQuery<T>;
            if (objectQuery != null)
            {
                return objectQuery.Include(path);
            }

            return sequence;
        }

        internal static IIncluder Includer = new NullIncluder();

        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
        {
            return Includer.Include(source, path);
        }

        public interface IIncluder
        {
            IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class;
        }

        internal class NullIncluder : IIncluder
        {
            public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
            {
                return source;
            }
        }
    }
}
