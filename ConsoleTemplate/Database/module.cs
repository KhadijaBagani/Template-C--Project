


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
                var taxes = context.StateProvince
                .Take(10)
                .ToList();


                var narnia = context.SalesTerritory
                    .Where(row => row.Name == "Narnia2")
                    .First();

                Console.WriteLine(narnia);

                // SalesTerritory nuevo = new SalesTerritory() {
                //     Name = "Narnia2",
                //     CountryRegionCode = "FR",
                //     TerritoryId = 1000,
                //     ModifiedDate = DateTime.Now,

                // };

                var Canadian_GST = context.SalesTaxRate
                    .Where(row => row.Name == "Canadian GST")
                    .First();

                Console.WriteLine(Canadian_GST);

                var Alberta = context.StateProvince
                    .Where(row => row.Name == "Alberta")
                    .First();

                Console.WriteLine(Alberta);


                var Andorra = context.CountryRegion
                    .Where(row => row.Name == "Andorra")
                    .First();

                Console.WriteLine(Andorra);

                string folder = Environment.CurrentDirectory; //Obtiene la Dirección de ejecución
                string filename = "Tablas.txt"; //Nombre del archivo


                //Crear y rellenar el archivo en la dirección de ejecución  JSON
                // using (StreamWriter outputFile = new StreamWriter(Path.Combine(folder, filename))) {
                //     var stateProvinces = context.StateProvince.Take(10).ToList();
                //     outputFile.WriteLine("=== StateProvinces ===");

                //     foreach (var province in stateProvinces) {
                //         //No usa Console, escribe en el outputFile
                //         outputFile.WriteLine(province.ToString());
                //     }

                //     var taxRates = context.SalesTaxRate.Take(10).ToList();

                //     outputFile.WriteLine("=== SalesTaxRates ===");
                //     foreach (var taxRate in taxRates) {
                //         outputFile.WriteLine(taxRate.ToString());
                //     }

                //     var territories = context.SalesTerritory.Take(10).ToList();
                //     outputFile.WriteLine("=== SalesTerritories ===");
                //     foreach (var territory in territories) {
                //         outputFile.WriteLine(territory.ToString());
                //     }
                // }

                //Crear archivo CSV
                var provinces = context.StateProvince.Take(10).ToList();
                string pathProvince = Path.Combine(folder, "StateProvince.csv");
                using (StreamWriter writer = new StreamWriter(pathProvince)) {
                    if (provinces.Any())
                        writer.WriteLine(provinces[0].ToCSVHeaders());

                    foreach (var p in provinces)
                        writer.WriteLine(p.ToCSV());
                }

                var taxRates = context.SalesTaxRate.Take(10).ToList();
                string pathTax = Path.Combine(folder, "SalesTaxRate.csv");
                using (StreamWriter writer = new StreamWriter(pathTax)) {
                    if (taxRates.Any())
                        writer.WriteLine(taxRates[0].ToCSVHeaders());

                    foreach (var rate in taxRates)
                        writer.WriteLine(rate.ToCSV());
                }
                       
                 var territories = context.SalesTerritory.Take(10).ToList();
                string pathTerritory = Path.Combine(folder, "SalesTerritory.csv");
                using (StreamWriter writer = new StreamWriter(pathTerritory))
                {
                    if (territories.Any())
                        writer.WriteLine(territories[0].ToCSVHeaders());

                    foreach (var t in territories)
                        writer.WriteLine(t.ToCSV());
                }        
                
                

 
                // context.SalesTerritory.Add(nuevo);

                // using (var transaction = context.Database.BeginTransaction()) {
                //     context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Sales.SalesTerritory ON;");
                //     context.SaveChanges();
                //     context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Sales.SalesTerritory OFF;");
                //     transaction.Commit();
                // }



            }

        }

    }
    

}


