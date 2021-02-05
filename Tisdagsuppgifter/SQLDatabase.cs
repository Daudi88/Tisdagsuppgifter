using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tisdagsuppgifter
{
    internal class SQLDatabase
    {
        public string ConnectionString { get; set; } = @"Data Source = .\SQLExpress; Integrated Security = true; database = {0}";
        public string DatabaseName { get; set; }

        public SQLDatabase(string databaseName = "master")
        {
            DatabaseName = databaseName;
        }

        public void CreateDatabase(string databaseName)
        {
            var sql = $"CREATE DATABASE {databaseName}";
            ExecuteSQL(sql);
        }

        public void CreateTable(string tableName, string fields)
        {
            var sql = $"CREATE TABLE {tableName} ({fields})";
            ExecuteSQL(sql);
        }

        public void AlterTable(string table, string field)
        {
            var sql = $"ALTER TABLE {table} {field}";
            ExecuteSQL(sql);
        }

        public void RenameColumn(string table, string oldColumnName, string newColumnName)
        {
            var sql = $"EXEC sp_rename '{table}.{oldColumnName}', '{newColumnName}'";
            ExecuteSQL(sql);
        }

        public int ExecuteSQL(string sql, params (string, string)[] parameters)
        {
            var connectionString = string.Format(ConnectionString, DatabaseName);
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Item1, item.Item2);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        internal void DropDatabase(string databaseName)
        {
            DatabaseName = "master";
            // took it from https://docs.microsoft.com/en-us/sql/relational-databases/databases/set-a-database-to-single-user-mode?view=sql-server-ver15
            ExecuteSQL($"ALTER DATABASE {databaseName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            ExecuteSQL($"DROP DATABASE {databaseName}");
        }

        public void DropTable(string tableName)
        {
            var sql = $"DROP TABLE {tableName}";
            ExecuteSQL(sql);
        }

        public DataTable GetDataTable(string sql, params (string, string)[] parameters)
        {
            var dataTable = new DataTable();
            var connectionString = string.Format(ConnectionString, DatabaseName);
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Item1, parameter.Item2);
                    }

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        public List<string> GetFilePath()
        {
            var list = new List<string>();
            var dt = GetDataTable("SELECT physical_name FROM sys.database_files");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["physical_name"].ToString());
            }
            return list;
        }

        public List<string> GetDatabases()
        {
            var list = new List<string>();
            var dt = GetDataTable("SELECT name FROM sys.databases");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["name"].ToString());
            }
            return list;
        }
    }
}