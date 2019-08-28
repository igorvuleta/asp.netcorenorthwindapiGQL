using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Extensions;

namespace graphqldemo.Data.Models
{
    public interface IDatabaseMetadata
    {
        void ReloadMetadata();
        IEnumerable<TableMetadata> GetTableMetadatas();
    }

    public sealed class DatabaseMetadata : IDatabaseMetadata
    {
        private readonly NorthWindContext _dbContext;
        private readonly ITableNameLookup _tableNameLookup;

        private readonly string _databaseName;
        private IEnumerable<TableMetadata> _tables;

        public DatabaseMetadata(NorthWindContext dbContext, ITableNameLookup tableNameLookup)
        {
            _dbContext = dbContext;
            _tableNameLookup = tableNameLookup;
            _databaseName = _dbContext.Database.GetDbConnection().Database;


            if (_tables == null)
                ReloadMetadata();
        }

        public IEnumerable<TableMetadata> GetTableMetadatas()
        {
            if (_tables == null)
                return new List<TableMetadata>();

            return _tables;
        }

        public void ReloadMetadata()
        {
            _tables = FetchTableMetaData();
        }

        private IEnumerable<TableMetadata> FetchTableMetaData()
        {
            var metaTables = new List<TableMetadata>();

            foreach (var entityType in _dbContext.Model.GetEntityTypes())

            {

                var tableName = entityType.Relational().TableName;

                metaTables.Add(new TableMetadata
                {
                    TableName = tableName,
                    AssemblyFullName = entityType.ClrType.FullName,
                    Columns = GetColumnsMetadata(entityType)
                });
                _tableNameLookup.InsertKeyName(tableName);
            }
            return metaTables;
        }

        private IEnumerable<ColumnMetadata> GetColumnsMetadata(IEntityType entityType)
        {
            var tableColumns = new List<ColumnMetadata>();

            foreach(var propertyType in entityType.GetProperties())
            {
                var relational = propertyType.Relational();
                tableColumns.Add(new ColumnMetadata
                {
                    ColumnName = relational.ColumnName,
                    DataType = relational.ColumnType
                });
            }

            var navigations = entityType.GetNavigations();
            foreach (var nav  in navigations)
            {
                tableColumns.Add(new ColumnMetadata
                {
                    ColumnName = nav.Name,
                    DataType = nav.DeclaringEntityType.Name
                });
            }
            return tableColumns;
        }
    }
}
