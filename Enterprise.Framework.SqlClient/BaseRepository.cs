using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Framework.SqlClient
{
	public abstract class BaseRepository
	{ 
		IConectionFactory conectionFactory; 

		protected BaseRepository(IConectionFactory conectionFactory)
		{
			this.conectionFactory = conectionFactory;
		}

		
		protected async Task<T> WithConnection<T>(DatabaseConnection database, Func<IDbConnection, Task<T>> getData)
		{
			try
			{
				using (var connection = conectionFactory.GetConnection(database))
				{	 
					return await getData(connection); 
				}
			}
			catch (TimeoutException ex)
			{
				throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
			}
			catch (SqlException ex)
			{
				throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception ", GetType().FullName), ex);
			}
		}
		

	}
}
