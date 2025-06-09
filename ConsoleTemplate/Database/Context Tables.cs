
using Database.Tables.Person;
using Database.Tables.Sales;
using Microsoft.EntityFrameworkCore;



namespace Database {
    public partial class LocalDbContext : DbContext {

        public DbSet<StateProvince> StateProvince { get; set; }
        public DbSet<SalesTaxRate> SalesTaxRate { get; set; }

        public DbSet<SalesTerritory> SalesTerritory { get; set; }
        public DbSet<CountryRegion> CountryRegion { get; set; }
        
    }
}

