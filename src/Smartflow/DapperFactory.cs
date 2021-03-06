﻿/********************************************************************
 License: https://github.com/chengderen/Smartflow/blob/master/LICENSE 
 Home page: https://www.smartflow-sharp.com
 ********************************************************************
 */
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Smartflow.Enums;
using System.Data.OracleClient;
using System.Data.Common;

namespace Smartflow
{
    public class DapperFactory
    {
        public static IDbConnection CreateWorkflowConnection()
        {
            SmartflowConfiguration config = ConfigurationManager.GetSection("smartflowConfiguration") as
                SmartflowConfiguration;

            Assert.CheckNull(config, "SmartflowConfiguration");
            return DapperFactory.CreateConnection(config.ProviderName, config.ConnectionString);
        }

        public static IDbConnection CreateConnection(string providerName, string connectionString)
        {
            Assert.StringNull(connectionString, "ConnectionString");
            Assert.StringNull(providerName, "ProviderName");

            IDbConnection connection =
                DbProviderFactories.GetFactory(providerName).CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}
