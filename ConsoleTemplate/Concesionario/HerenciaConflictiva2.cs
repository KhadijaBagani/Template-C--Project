namespace Concesionario
{
    public abstract class PowerSystem
    {
        /// <summary>
        /// Nos permite saber si un PowerSystem es de un tipo concreto
        /// </summary>
        public virtual T? GetSystem<T>() where T : PowerSystem
        {
            return this as T;
        }
    }

    public class FuelPower : PowerSystem
    {
        /// <summary>
        /// Litros de combustible en el depósito
        /// </summary>
        public float fuelInTank;

        /// <summary>
        /// Capacidad máxima del depósito
        /// </summary>
        public readonly float maxFuelInTank = 50;

        public float Refuel(float liters)
        {
            fuelInTank += liters;
            return maxFuelInTank - fuelInTank;
        }
    }

    public class ManPower : PowerSystem
    {

    }

    public class ElectricPower : PowerSystem
    {
        /// <summary>
        /// Porcentaje de batería entre 0 y 1
        /// </summary>
        public decimal batteryLevel;

        /// <summary>
        /// Velocidad de carga en % de batería por hora
        /// </summary>
        public decimal chargeSpeed = 0.125m;

        public bool Recharge(float time)
        {
            this.batteryLevel += (decimal)time * this.chargeSpeed;
            return batteryLevel >= 1;
        }
    }
    
    public class HybridPower : PowerSystem {
    public readonly List<PowerSystem> modes = new List<PowerSystem>();

        public HybridPower(params PowerSystem[] args){
            modes.AddRange(args);
        }

        public override T GetSystem<T>(){
            return modes.OfType<T>()
                .FirstOrDefault();
        }

    }
}