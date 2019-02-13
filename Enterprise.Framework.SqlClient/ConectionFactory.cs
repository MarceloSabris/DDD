
using Enterprise.Framework.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Framework.SqlClient
{
	public class ConectionFactory : IConectionFactory
    {
        private  ParsableNameValueCollection _connectionSettings;
        
        public ConectionFactory(ParsableNameValueCollection connectionString)
        {
            this._connectionSettings = connectionString;
        }


        public IDbConnection GetConnection(DatabaseConnection databaseConnection)
		{
            var databaseString = databaseConnection.ToConnectionString(this._connectionSettings);
            
            var conn = new System.Data.SqlClient.SqlConnection(databaseString);			                                                          
			conn.Open();
			return conn;			
		}

	}
}
