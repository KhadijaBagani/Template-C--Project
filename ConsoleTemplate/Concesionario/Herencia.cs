
namespace Concesionario {

    /// <summary>
    /// Clase abstracta de vehículo
    /// </summary>
    public abstract class Vehicle
    {
        public readonly string model;

        public Vehicle(string model)
        {
            this.model = model;
        }

        /// <summary>
        /// Indica si el vehículo tiene el combustible necesario para continuar
        /// </summary>
        public abstract bool HasFuel { get; }
        
        public PowerSystem power {
            get;
            protected set; //Para que los hijos lo puedan modificar
        }
    }


    /// <summary>
    /// Patinete eléctrico
    /// </summary>
    class ElectricScooter : Vehicle {
         private int batteryPercentage;
        public ElectricScooter(string model, int batteryPercentage = 100) : base(model)
        {
            this.batteryPercentage = batteryPercentage;
            power = new ElectricPower();
        }

        /// <summary>
        /// Implementación de HasFuel para el patinete eléctrico
        /// </summary>
        public override bool HasFuel => batteryPercentage > 0; // Tiene combustible si la batería no está vacía
    }


    /// <summary>
    /// Bici
    /// </summary>
    class Bike : Vehicle {
        public Bike(string model) : base(model) {
            power = new ManPower();
        }
        public string vehicleModel => base.model;
         /// <summary>
        /// Implementación de HasFuel para la bicicleta
        /// </summary>
        public override bool HasFuel => true; // La bici siempre puede funcionar, no necesita combustible
    }




    
}
     