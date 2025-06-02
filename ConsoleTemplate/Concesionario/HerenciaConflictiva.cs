
namespace Concesionario
{

    /// <summary>
    /// Coche completamente eléctrico
    /// </summary>
    public class ElectricCar : Car
    {

        /// <summary>
        /// Porcentaje de batería entre 0 y 1
        /// </summary>
        public decimal batteryLevel;

        /// <summary>
        /// Velocidad de carga en % de batería por hora
        /// </summary>
        public decimal chargeSpeed = 0.125m;

        public ElectricCar(string model, string paint, string? plateNum = null, float km = 0) : base(model, paint, plateNum, km)
        {
            power = new ElectricPower();
        }
        /// <summary>
        /// Pone a cargar la batería del coche durante cierto tiempo
        /// </summary>
        /// <param name="time">tiempo que pasa cargando en horas</param>
        /// <returns>Si ha acabado de cargarse</returns>
        public bool Recharge(float time)
        {
            this.batteryLevel += (decimal)time * this.chargeSpeed;
            return batteryLevel >= 1;
        }
    }

    /// <summary>
    /// Coche tradicional con motor de combustión
    /// </summary>
    public class CombustionCar : Car
    {

        /// <summary>
        /// Litros de combustible en el depósito
        /// </summary>
        public float fuelInTank;

        /// <summary>
        /// Capacidad máxima del depósito
        /// </summary>
        public readonly float maxFuelInTank = 50;

        public CombustionCar(string model, string paint, string? plateNum = null, float km = 0) : base(model, paint, plateNum, km)
        {
            power = new FuelPower();
        }
        /// <summary>
        /// Rellena el depósito con litros de combustible
        /// </summary>
        /// <param name="liters">Litros a rellenar</param>
        /// <returns>Litros sobrantes en el depósito. Negativo si sobra combustible.</returns>
        public float Refuel(float liters)
        {
            fuelInTank += liters;
            return  maxFuelInTank - fuelInTank;
        }
    }
    public class HybridCar : Car
    {

        /// <summary>
        /// Litros de combustible en el depósito
        /// </summary>
        public float fuelInTank;

        /// <summary>
        /// Capacidad máxima del depósito
        /// </summary>
        public readonly float maxFuelInTank = 50;

        /// <summary>
        /// Porcentaje de batería entre 0 y 1
        /// </summary>
        public decimal batteryLevel;

        /// <summary>
        /// Velocidad de carga en % de batería por hora
        /// </summary>
        public decimal chargeSpeed = 0.125m;

        public HybridCar(string model, string paint, string? plateNum = null, float km = 0) : base(model, paint, plateNum, km)
        {
            power = new HybridPower(new ElectricPower(), new FuelPower());
        }
        /// <summary>
    /// Pone a cargar la batería del coche durante cierto tiempo
    /// </summary>
    /// <param name="time">tiempo que pasa cargando en horas</param>
    /// <returns>Si ha acabado de cargarse</returns>
    public bool Recharge(float time){
        this.batteryLevel += (decimal)time * this.chargeSpeed;
        return batteryLevel >= 1;
    }
    /// <summary>
    /// Rellena el depósito con litros de combustible
    /// </summary>
    /// <param name="liters">Litros a rellenar</param>
    /// <returns>Litros sobrantes en el depósito. Negativo si sobra combustible.</returns>
    public float Refuel(float liters){
        fuelInTank += liters;
        return  maxFuelInTank - fuelInTank;
    }
    }
}