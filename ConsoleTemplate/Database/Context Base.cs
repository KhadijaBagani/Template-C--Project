// #define MYPC


using System.Text.RegularExpressions;
using Database.Tables.Sales;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Database{

    /// <summary>
    /// DB Context diseñado para acceder a la BD de AdventureWorks instalada localmente
    /// </summary>
    public partial class LocalDbContext : DbContext {
        // ! NO MODIFICAR ESTA PARTE DE LA CLASE!!! Modificad "Context Tables"
        const string DataSource = "(local)",
                UserID = "curso",
                Password = "curso",
                InitialCatalog = "AdventureWorks2022";
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(GetConnectionString());
            // optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.LogTo((x) => {

                x = x.Replace("\n", "\n\x1b[1;32m"); //Make all lines green
                x = Regex.Replace(x, @"^(\S+?:)", "$0\x1b[0;32m"); //Limit yellow to log level
                x = "\x1b[1;33m" + x + "\n"; //Make first line yellow
                Console.WriteLine(x);


            }, LogLevel.Information);

        }
        
        
        public static SqlConnection GetConnection() {
            return new SqlConnection(GetConnectionString());
        }

        public static string GetConnectionString() {
            var builder = new SqlConnectionStringBuilder {
                DataSource = DataSource,
#if MYPC
                IntegratedSecurity = true,
#else
                UserID = UserID,
                Password = Password,
#endif
                InitialCatalog = InitialCatalog,
                TrustServerCertificate = true
            };
            return builder.ConnectionString;
        }

    }
}