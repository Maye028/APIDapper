using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace MyFirstDapper.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        IDbConnection connection;
        private object p;
        private object _connection;
        readonly string connectionString = "SERVER=(LocalDb)\\MSSQLLocalDb; Database=myfirstdapper; Trusted_Connection=True; MultipleActiveResultSets=true ";
        public GenericRepository()
        {
            connection = new SqlConnection(connectionString);
        }

        public T GetbyId(int id)
        {
            return null;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }



        public bool Add(T entity)
        {
            string tableName = GetTableName();
            string columns = GetColumnNames();
            string values = GetColumnValues();
            string query = $"INSERT INTO {tableName} {columns}) VALUES ({values}) ";

            int affectedRow = 0;
            affectedRow = connection.Execute(query, entity);

            return affectedRow == 1;
        }

        public string GetTableName()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTableName(int id)
        {
            string tableName = "";
            var type = typeof(T);
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            if (tableAttr != null)
            {
                tableName = tableAttr.Name;
            }

            return tableName;
        }

        public string GetColumnNames(bool excludeKey = false)
        {
            string columnNames = "";
            var type = typeof(T);
            var columns = string.Join(",", type.GetProperties()
                .Where(p => !excludeKey || !p.IsDefined(typeof(KeyAttribute)))
                .Select(p =>
                {
                    var columnAttr = p.GetCustomAttribute<ColumnAttribute>();
                    return columnAttr != null ? columnAttr.Name : p.Name;
                }));
            return columns;
        }

        public string GetColumnValues(bool excludeKey = false)
        {
            var columnValues = typeof(T).GetProperties()
            .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);
            var values = string.Join(",", columnValues.Select(p =>
            {
                return $"@{p.Name}";
            }));

            return values;
        }
    }
}