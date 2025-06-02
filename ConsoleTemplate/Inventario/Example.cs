
//Nombre del módulo
namespace VideoGame.Inventory{

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
            var player = new Player();
            var potion = new MasterPotion("Healing", null, 5);
            var healing = MasterPotion.CreateManaPotion(2);
            var healingBig = MasterPotion.CreateHealingPotion(10);
            healing.ApplyEffect(player);
            healingBig.ApplyEffect(player);
            
        }

    }
}




    

