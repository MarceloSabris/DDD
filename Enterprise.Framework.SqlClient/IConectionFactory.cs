using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Framework.SqlClient
{
   public  interface IConectionFactory
    {
        IDbConnection GetConnection(DatabaseConnection databaseConnection);

    }
}
