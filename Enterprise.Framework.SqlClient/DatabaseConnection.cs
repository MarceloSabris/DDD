using Enterprise.Framework.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Framework.SqlClient
{
    public enum DatabaseConnection
    {
        Loja,
        Corporativo
    }

    
    public static class DatabaseConnectionExtension
    {
        public static string ToConnectionString(this DatabaseConnection database, ParsableNameValueCollection connectionString)
        {
            var databaseKeyString = string.Format("ConnectionSettings:{0}DbConnectionString", database.ToString()); 

            var databaseConnectionString = connectionString.TryGetAndParse<string>(databaseKeyString).ParsedValue;
            if (string.IsNullOrEmpty(databaseConnectionString))
                throw new Exception("ConnectionString não configurado para Database "+ database.ToString());

            return databaseConnectionString;
        }
    }
}
