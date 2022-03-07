namespace SSToolkit.Infrastructure.EntityFrameworkCore.Extensions
{
    using System.Linq;
    using SSToolkit.Domain.Repositories;
    using SSToolkit.Domain.Repositories.Model;

    public static partial class EntityFrameworkExtensions
    {
        /// <summary>
        /// Order by if orders have been provided to <see cref="IFindOptions<T>"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderByIf<T>(
            this IQueryable<T> source,
            IFindOptions<T> options)
            where T : class, IEntity
        {
            if (source == null)
            {
                return Enumerable.Empty<T>() as IOrderedQueryable<T>;
            }

            if (options == null || !options.HasOrders())
            {
                return source as IOrderedQueryable<T>;
            }

            IOrderedQueryable<T> result = null;
            foreach (var order in options.GetOrders())
            {
                result = result == null
                        ? order.Direction == OrderByDirection.Asc
                            ? Queryable.OrderBy(source, order.Expression)
                            : Queryable.OrderByDescending(source, order.Expression)
                        : order.Direction == OrderByDirection.Asc
                            ? result.ThenBy(order.Expression)
                            : result.ThenByDescending(order.Expression);
            }

            return result;
        }
    }
}
