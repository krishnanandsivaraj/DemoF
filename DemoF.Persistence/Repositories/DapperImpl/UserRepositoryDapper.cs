using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DemoF.Core.Domain;
using DemoF.Core.Repositories;
using Dapper;
using System.Linq;
using DemoF.Core.Contracts;

namespace DemoF.Persistence.Repositories
{
    public class UserRepositoryDapper : GenericRepositoryDapper<User>, IUserRepositoryDapper
    {
        public UserRepositoryDapper(string connectionString) : base(connectionString, "Users") {}

        public override User Add(User entity)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Users (FirstName, MiddleName, LastName, ValidFrom, ValidUntill) VALUES(@FirstName, @MiddleName, @LastName, @ValidFrom, @ValidUntill); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? userId = db.Query<int>(sqlQuery, entity).FirstOrDefault();
                entity.Id = userId.Value;
            }

            return entity;
        }

        public async override Task<User> AddAsyn(User entity)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Users (FirstName, MiddleName, LastName, ValidFrom, ValidUntill) VALUES(@FirstName, @MiddleName, @LastName, @ValidFrom, @ValidUntill); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? userId = (await db.QueryAsync<int>(sqlQuery, entity)).FirstOrDefault();
                entity.Id = userId.Value;
            }

            return entity;
        }
    }
}
