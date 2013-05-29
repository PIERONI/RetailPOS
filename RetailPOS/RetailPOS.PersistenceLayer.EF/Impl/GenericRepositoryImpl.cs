#region Using directives

using System;
using System.Data;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using RetailPOS.PersistenceLayer.Repository;
using RetailPOS.PersistenceLayer.Repository.Interfaces;

#endregion

namespace RetailPOS.PersistenceLayer.EF.Impl
{
    public class GenericRepositoryImpl<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Gets the base.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public EntitySetBase GetBase<T>(ObjectContext context)
        {
            EntityContainer container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
            EntitySetBase entitySet = container.BaseEntitySets.Where(item => item.ElementType.Name.Equals(typeof(TEntity).Name)).FirstOrDefault();
            return entitySet;
        }

        private ObjectContext GetObjectContext()
        {
            return Activator.CreateInstance<RetailPOS.PersistenceLayer.EF.EDMX.posEntities>();
        }

        /// <summary>
        /// This method is used to count total records in entity collection
        /// </summary>
        /// <returns>returns records count</returns>
        public int Count()
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().Count();
        }

        /// <summary>
        /// This method is used to count total records in entity collection on the basis of the lambda expression
        /// </summary>
        /// <param name="includeTableName">comma seprated list of tables to include</param>
        /// <param name="lambdaExpression">lambda expression</param>
        /// <returns>returns count</returns>
        public int Count(string includeTableName, Expression<Func<TEntity, bool>> lambdaExpression)
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().Include(includeTableName).Count(lambdaExpression);
        }

        /// <summary>
        /// This method is used to count total records in entity collection on the basis of the lambda expression
        /// </summary>
        /// <param name="lambdaExpression">lambda expression</param>
        /// <returns>returns count</returns>
        public int Count(Expression<Func<TEntity, bool>> lambdaExpression)
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().Count(lambdaExpression);
        }

        ///<summary>
        /// Mark entity to be deleted within the repository
        ///</summary>
        /// <param name="entity">The entity to delete</param>
        public bool Delete(TEntity entity)
        {
            object originalItem = null;
            ObjectContext edmxObject = GetObjectContext();

            EntityKey key = edmxObject.CreateEntityKey(GetBase<TEntity>(edmxObject).Name.ToString(), entity);

            if (edmxObject.TryGetObjectByKey(key, out originalItem))
            {
                edmxObject.ObjectStateManager.GetObjectStateEntry(key).Delete();
                edmxObject.SaveChanges();
            }
            else
            {
                edmxObject.DeleteObject(key);
                edmxObject.SaveChanges();
            }
            return true;
        }

        /// <summary>
        /// This method is used to get the list of available records in entity table from database
        /// </summary>
        /// <returns>returns list of entities</returns>
        public IQueryable<TEntity> GetList()
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>();
        }

        /// <summary>
        /// Gets the list of records with name of table which need to be included
        /// </summary>
        /// <param name="includeTableName">name of table to include</param>
        /// <returns>returns list of entity</returns>
        public IQueryable<TEntity> GetList(string includeTableName)
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().Include(includeTableName);
        }

        /// <summary>
        /// Gets the list of records on the basis of the criteria expression passed and name of table to include
        /// </summary>
        /// <param name="includeTableName">name of table to include</param>
        /// <param name="lambdaExpression">lambda expression for where clause</param>
        /// <returns>returns list of entities</returns>
        public IQueryable<TEntity> GetList(string includeTableName, Expression<Func<TEntity, bool>> lambdaExpression)
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().Include(includeTableName).Where(lambdaExpression);
        }

        /// <summary>
        /// Gets the list of records on the basis of the criteria expression passed
        /// </summary>
        /// <param name="lambdaExpression">lambda expression for where clause</param>
        /// <returns>returns list of entities</returns>
        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> lambdaExpression)
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().Where(lambdaExpression);
        }

        /// <summary>
        /// This method is used to get the list of records on the basis of the criteria expression passed
        /// </summary>
        /// <param name="lambdaExpression">lambda expression for where clause</param>
        /// <param name="orderbyexpr">The orderbyexpr.</param>
        /// <returns>
        /// returns list of entities
        /// </returns>
        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> lambdaExpression, Expression<Func<TEntity, int>> orderByexpr, bool orderByDesc = false)
        {
            ObjectContext edmxObject = GetObjectContext();
            
            if (orderByDesc)
            {
                return edmxObject.CreateObjectSet<TEntity>().Where(lambdaExpression).OrderByDescending(orderByexpr);
            }
            else
            {
                return edmxObject.CreateObjectSet<TEntity>().Where(lambdaExpression).OrderBy(orderByexpr);
            }
        }

        /// <summary>
        /// This method is used to get the single records from entity table 
        /// </summary>
        /// <returns>returns single entity</returns>
        public TEntity GetSingle()
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().FirstOrDefault();
        }

        /// <summary>
        /// Gets single records with entities of include table name, condition is included table name must have reference with calling entity
        /// </summary>
        /// <param name="lambdaExpression">lambda expression</param>
        /// <param name="includeTableName">name of table to include</param>
        /// <returns></returns>
        public TEntity GetSingle(string includeTableName, Expression<Func<TEntity, bool>> lambdaExpression)
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().Include(includeTableName).Where(lambdaExpression).FirstOrDefault();
        }

        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="whereCondition">where condition to search</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public TEntity GetSingle(Expression<Func<TEntity, bool>> whereCondition)
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().Where(whereCondition).FirstOrDefault();
        }

        /// <summary>
        /// Load entity from the repository (always query store)
        /// </summary>
        /// <param name="whereCondition">where condition</param>
        /// <returns>The loaded entity</returns>
        public TEntity Load(Expression<Func<TEntity, bool>> whereCondition)
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().Where(whereCondition).FirstOrDefault();
        }

        /// <summary>
        /// Loads the list.
        /// </summary>
        /// <param name="whereCondition">where condition.</param>
        /// <returns></returns>
        public IQueryable<TEntity> LoadList(Expression<Func<TEntity, bool>> whereCondition)
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.CreateObjectSet<TEntity>().Where(whereCondition);
        }

        ///<summary>
        /// Save entity to the repository
        ///</summary>
        /// <param name="entity">The entity to save</param>
        public bool Save(TEntity entity)
        {
            ObjectContext edmxObject = GetObjectContext();

            edmxObject.AddObject(GetBase<TEntity>(edmxObject).Name, entity);
            edmxObject.SaveChanges();
            return true;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            ObjectContext edmxObject = GetObjectContext();
            return edmxObject.SaveChanges(SaveOptions.DetectChangesBeforeSave);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public bool Update(TEntity entity)
        {
            ObjectContext edmxObject = GetObjectContext();

            object originalItem = null;
            EntityKey key = edmxObject.CreateEntityKey(GetBase<TEntity>(edmxObject).Name, entity);
            if (edmxObject.TryGetObjectByKey(key, out originalItem))
            {
                edmxObject.ApplyCurrentValues(key.EntitySetName, entity);
                edmxObject.SaveChanges(SaveOptions.DetectChangesBeforeSave);
            }
            return true;
        }
    }
}