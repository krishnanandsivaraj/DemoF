using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace DemoF.Persistence.Repositories
{
    using Core.Repositories;
    using DemoF.Core.Contracts;
    using System.Data;
    using System.Data.SqlClient;

    public abstract class GenericRepositoryDapper<TEntity> : IGenericRepositoryDapper<TEntity> where TEntity : class
    {
        protected DemofContext _context = new DemofContext(new DbContextOptions<DemofContext>());
        protected readonly string _connectionString;
        protected readonly string _tableName;


        public GenericRepositoryDapper(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<TEntity>($"SELECT * FROM {_tableName}").AsQueryable();
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<TEntity>($"SELECT * FROM {_tableName}");
            }
        }

        public virtual TEntity Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<TEntity>($"SELECT * FROM {_tableName} WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var query = $"SELECT * FROM {_tableName} WHERE Id = @id";
                return (await db.QueryAsync<TEntity>(query, new { id })).FirstOrDefault();
            }
        }
        public virtual TEntity Add(TEntity entity)
        {
            throw new NotImplementedException("Add");

        }

        public virtual async Task<TEntity> AddAsyn(TEntity t)
        {
            throw new NotImplementedException("AddAsyn");
        }

        public virtual async Task<int> DeleteAsyn(TEntity entity)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"DELETE FROM {_tableName} WHERE Id = @id";
                return db.Execute(sqlQuery, entity);
            }
        }

        public virtual async Task<TEntity> UpdateAsyn(IUpdatableModel model, object key)
        {
            if (model == null)
                return null;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(model.GetUpdateQuery(), model);
            }

            return (TEntity)model;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
