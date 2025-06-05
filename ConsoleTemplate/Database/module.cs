


//Nombre del módulo
using Database.Tables.Person;
using Database.Tables.Sales;
using Microsoft.EntityFrameworkCore;

namespace Database{

    /// <summary>
    /// Sirve como nexo del módulo
    /// </summary>
    public class Module{

        /// <summary>
        /// Punto de entrada para ejecutar el módulo
        /// </summary>
        public static void Execute() {

            /*
                funcionalidades del módulo

            */
            using (var context = new LocalDbContext()) {
                var taxes = context.SalesTaxRate
                .Take(10)
                .ToList();


                var narnia = context.SalesTerritory
                    .Where(row => row.Name == "Narnia2")
                    .First();


                // SalesTerritory nuevo = new SalesTerritory() {
                //     Name = "Narnia2",
                //     CountryRegionCode = "FR",
                //     TerritoryId = 1000,
                //     ModifiedDate = DateTime.Now,

                // };


                // context.SalesTerritory.Add(nuevo);

                using (var transaction = context.Database.BeginTransaction()) {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Sales.SalesTerritory ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Sales.SalesTerritory OFF;");
                    transaction.Commit();
                }
    
                

            }

        }

    }
    

}


