using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSql
    {
        public class MySqlTcp
        {
            public static MySqlConnectionStringBuilder NewMysqlTCPConnectionString()
            {
                // Equivalent connection string:
                // "Uid=<DB_USER>;Pwd=<DB_PASS>;Host=<INSTANCE_HOST>;Database=<DB_NAME>;"
                var connectionString = new MySqlConnectionStringBuilder()
                {
                    // Note: Saving credentials in environment variables is convenient, but not
                    // secure - consider a more secure solution such as
                    // Cloud Secret Manager (https://cloud.google.com/secret-manager) to help
                    // keep secrets safe.
                    Server = "arctic-cyclist-378618:us-central1:mysql-editorial-db",   // e.g. '127.0.0.1'
                                                                                    // Set Host to 'cloudsql' when deploying to App Engine Flexible environment
                    UserID = "root",   // e.g. 'my-db-user'
                    Password = "Pablo161718!", // e.g. 'my-db-password'
                    Database = "editorial_db", // e.g. 'my-database'

                    // The Cloud SQL proxy provides encryption between the proxy and instance.
                    SslMode = MySqlSslMode.Disabled,
                };
                connectionString.Pooling = true;
                // Specify additional properties here.
                return connectionString;

            }
        }
    }
