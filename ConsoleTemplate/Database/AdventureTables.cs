using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Tables.Person;

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
        public StateProvince StateProvince {
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
        public ICollection<Sales.SalesTaxRate> SalesTaxRates {
            get;
            set;
        } = new List<Sales.SalesTaxRate>();
    }

}

