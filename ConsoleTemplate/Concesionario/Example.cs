
//Nombre del módulo
namespace Concesionario{

    /// <summary>
    /// Sirve como nexo del módulo
    /// </summary>
    public abstract class Module{

        /// <summary>
        /// Punto de entrada para ejecutar el módulo
        /// </summary>
        public static void Execute()
        {

            /*
                funcionalidades del módulo
            */

            // Crear una lista de vehículos vacía
            List<Vehicle> lista = new List<Vehicle>();

            // Agregar vehículos de cada tipo a la lista
            lista.Add(new Car("Toyota", "50"));         // Un coche con 50 litros de combustible
            lista.Add(new ElectricScooter("Xiaomi", 80)); // Un patinete eléctrico con 80% de batería
            lista.Add(new Bike("Bianchi"));           // Una bicicleta (sin necesidad de combustible)

            // Iterar sobre la lista
            foreach (Vehicle v in lista)
            {
                Console.WriteLine(v.model); //Muestra el modelo
                Console.WriteLine(v); //Muestra la clase del objeto
            }
            var coche = new ElectricCar("", "", null, 1000);
            coche.plateNumber = "1234ABC";
            coche.kmTraveled.AddKm(100);
            Console.Write(coche.plateNumber);

            Bike bici = new Bike("Mountain Bike");
            Vehicle copia = bici;
            // Console.WriteLine(bici.model); //Da Error
            // Console.WriteLine(bici.vehicleModel); //Da Mountain Bike
            // Console.WriteLine(copia.model); //Da Mountain Bike  

            Console.WriteLine(coche.power.GetSystem<FuelPower>() != null);
            var fp = coche.power.GetSystem<FuelPower>();
            if (fp != null)
            {
                Console.WriteLine(fp.fuelInTank);
            }

            var ep = coche.power.GetSystem<ElectricPower>();
            if (ep != null)
            {
                Console.WriteLine(ep.chargeSpeed);
            }

        }
           

    }
}




    

