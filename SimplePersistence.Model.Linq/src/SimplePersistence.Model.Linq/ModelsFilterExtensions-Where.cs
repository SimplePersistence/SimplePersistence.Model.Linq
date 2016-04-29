namespace SimplePersistence.Model.Linq
{
    using System;
    using System.Collections.Generic;
#if !NET20
    using System.Linq;
#endif

    public static partial class ModelsFilterExtensions
    {
        /// <summary>
        /// Filters a given entities collection using the given identity
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <typeparam name="TId">The identity type</typeparam>
        /// <param name="entities">The entities to be filtered</param>
        /// <param name="id">The identity to be used</param>
        /// <returns>The entities with applied filter</returns>
        /// <exception cref="ArgumentNullException"></exception>
#if NET20
        public static IEnumerable<TEntity> WhereId<TEntity, TId>(IEnumerable<TEntity> entities, TId id)
            where TEntity : IEntity<TId>
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var result = new List<TEntity>();
            foreach (var entity in entities)
            {
                if(entity.Id.Equals(id))
                    result.Add(entity);
            }

            return result;
        }
#else
        public static IEnumerable<TEntity> WhereId<TEntity, TId>(this IEnumerable<TEntity> entities, TId id)
            where TEntity : IEntity<TId>
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            return entities.Where(e => e.Id.Equals(id));
        }
        
        /// <summary>
        /// Filters a given entities collection using the given identity
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <typeparam name="TId">The identity type</typeparam>
        /// <param name="entities">The entities to be filtered</param>
        /// <param name="id">The identity to be used</param>
        /// <returns>The entities with applied filter</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IQueryable<TEntity> WhereId<TEntity, TId>(this IQueryable<TEntity> entities, TId id)
            where TEntity : IEntity<TId>
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            return entities.Where(e => e.Id.Equals(id));
        }
#endif
    }
}
