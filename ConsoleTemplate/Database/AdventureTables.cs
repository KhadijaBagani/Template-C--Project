using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Xml;
using Database.Tables.Person;
using Microsoft.EntityFrameworkCore;

namespace Database.Tables.Sales {

    [Table("SalesTaxRate", Schema = "Sales")]
    public class SalesTaxRate {
        // TODO: implement fully

        [Required]
        public string Name {
            get;
            set;
        } = "";

        [Key]
        public int SalesTaxRateId {
            get;
            set;
        }


        public int StateProvinceId {
            get;
            set;
        }

        [Required]
        [ForeignKey("StateProvinceId")]
        public StateProvince? StateProvince {
            get;
            set;
        }

    }
    [Table("SalesTerritory", Schema = "Sales")]
    public class SalesTerritory {
        // TODO: implement fully
        [Required]
        public string Name {
            get;
            set;
        } = "";

        [Key]
        public int TerritoryId {
            get;
            set;
        }

        public string CountryRegionCode {
            get;
            set;
        }="";
        public string Group {
            get;
            set;
        } = "";
        public decimal SalesYTD {
            get;
            set;
        } 
        public decimal SalesLastYear {
            get;
            set;
        } 
        public decimal CostYTD {
            get;
            set;
        } 
        public decimal CostLastYear {
            get;
            set;
        } 
        public Guid RowGuid {
            get;
            set;
        }
        public DateTime ModifiedDate {
            get;
            set;
        } 



        [Required]
        [ForeignKey("CountryRegionCode")]
        public CountryRegion? CountryRegion {
            get;
            set;
        }



    }

}

namespace Database.Tables.Person {

    [Table("StateProvince", Schema = "Person")]
    public class StateProvince {
        // TODO: implement fully

        [Key]
        [Required]
        public int StateProvinceId {
            get;
            set;
        }

        public string StateProvinceRegion {
            get;
            set;
        }= "";
        public string CountryRegionCode {
            get;
            set;
        } = "";
        public long IsOnlyStateProvinceFlag {
            get;
            set;
        }
        public string Name {
            get;
            set;
        }= "";
        public int TerritoryId {
            get;
            set;
        }
        public Guid RowGuide {
            get;
            set;
        }
        public DateTime ModifiedDate {
            get;
            set;
        }




        [Required]
        [ForeignKey("CountryRegionCode")]
        public CountryRegion? CountryRegion {
            get;
            set;
        }

        public ICollection<Sales.SalesTaxRate> SalesTaxRates {
            get;
            set;
        } = new List<Sales.SalesTaxRate>();
        // public ICollection<Sales.SalesTerritory> SalesTerritory {
        //     get;
        //     set;
        // } = new List<Sales.SalesTerritory>();



    }

    [Table("CountryRegion", Schema = "Person")]
    public class CountryRegion {
        // TODO: implement fully

        [Key]
        [Required]
        public string CountryRegionCode {
            get;
            set;
        } = "";


        public ICollection<Sales.SalesTerritory> SalesTerritory {
            get;
            set;
        } = new List<Sales.SalesTerritory>();
    }


}



