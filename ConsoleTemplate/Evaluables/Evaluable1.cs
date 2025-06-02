using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace VideoGame.Inventory
{
    /*Usad un placeholder para estas clases*/
    public class Player { }
    public abstract class Spell
    {
        
     }


    /// <summary>
    /// Clase base Item
    /// <summary>
    public abstract class Item
    {
        public string? Name { get; set; }

        protected Item(string name)
        {
            Name = name;
        }

        public int? PrecioVenta { get;  set; }
        // Constructor que inicializa el precio de venta
        public Item(int? precioVenta)
        {
            PrecioVenta = precioVenta;
        }
        // Método que verifica si el artículo se puede vender
        public bool SePuedeVender()
        {
            return PrecioVenta.HasValue;
        }


    }

    /// <summary>
    ///  Arma cuerpo a cuerpo.
    /// </summary>
    public class Sword : Item, Weapon, Equipable
    {
        public Sword(int? precioVenta) : base(precioVenta)
        {
        }
        public bool Equip(Player player)
    {
        Console.WriteLine($"La espada {Name} ha sido equipada por el jugador {player}.");
        return true;
    }

    }

    /// <summary>
    /// Arma a distancia que requiere flechas
    /// </summary>
    public class Bow : Item, AmmoWeapon
    {
        private int remainingAmmo; // Variable para almacenar la munición restante.
        private float maxRange;

    /// <summary>
    /// Constructor de la clase Bow.
    /// </summary>
    public Bow(int? precioVenta, int initialAmmo, float range) : base(precioVenta)
    {
        remainingAmmo = initialAmmo; // Asignamos el número inicial de flechas.
        maxRange = range;            // Establecemos el alcance máximo del arco.
    }

    /// <summary>
    /// Implementación de la propiedad `Remaining` de la interfaz `AmmoWeapon`.
    /// </summary>
    public int Remaining => remainingAmmo;

    /// <summary>
    /// Implementación de la propiedad `MaxRange` de la interfaz `RangedWeapon`.
    /// </summary>
    public float MaxRange => maxRange;

    /// <summary>
    /// Método para equipar el arco a un jugador.
    /// </summary>
    public bool Equip(Player player)
    {
        
        Console.WriteLine($"El jugador {player} ha equipado el arco {Name}.");
        return true;
    }

    }

    /// <summary>
    /// Lanza un hechizo concreto
    /// Arma a distancia
    /// Un solo uso (se destruye)
    /// </summary>
    public class SpellScroll : Item, RangedWeapon, LimitedUse, SpellCaster
    {
        public int Remaining { get; private set; }
        public float MaxRange { get; private set; }
        public Spell Spell { get; private set; }

        public SpellScroll(int? precioVenta, float maxRange, Spell spell) : base(precioVenta)
        {
            Remaining = 1; // Solo tiene un uso
            MaxRange = maxRange;
            Spell = spell;
        }
     public bool Equip(Player player)
    {
        
        Console.WriteLine($"El jugador {player} ha equipado el arco {Name}.");
        return true;
    }
       
    }

    /// <summary>
    /// Arma a distancia para magos
    /// Lanza un hechizo concreto
    /// Usos ilimitados pero gasta magia
    /// </summary>
    public class MagicWand : Item, RangedWeapon, SpellCaster, Weapon
    {
        public Spell Spell { get; private set; }
        public float MaxRange { get; private set; }

        public MagicWand(int? precioVenta, float maxRange, Spell spell) : base(precioVenta)
        {
            MaxRange = maxRange;
            Spell = spell;
        }

        // <summary>
        /// Permite al jugador equipar la varita.
        /// </summary>
        public bool Equip(Player player)
        {
            Console.WriteLine($"El jugador ha equipado la varita {Name}.");
            return true;
        }
    
    }

    /// <summary>
    /// Incluye Weapons y Armors
    /// </summary>
    public interface Equipable 
    {
        /// <summary>
        /// Intenta equipar el objeto a un jugador.
        /// </summary>
        /// <param name="player">El jugador al que se intenta equipar</param>
        /// <returns>True si se ha podido equipar, false en caso contrario</returns>
        bool Equip(Player player) { return true; }

    }

    /// <summary>
    /// Interfaz para todos los objetos considerados armas.
    /// </summary>
    public interface Weapon : Equipable
    {
    }

    /// <summary>
    /// Engloba todos los items que se gastan tras cierta cantidad de usos.
    /// </summary>
    public interface LimitedUse
    {
        /// <summary>
        /// Número de usos restantes del objeto.
        /// </summary>
        int Remaining { get; }
    }

    /// <summary>
    /// Engloba todos los items que lanzan hechizos
    /// </summary>
    public interface SpellCaster 
    {
        /// <summary>
        /// Hechizo que lanza el objeto.
        /// </summary>
        Spell Spell { get; }
    }

    /// <summary>
    ///Engloba todos los objetos que se usan a distancia.
    /// </summary>
    public interface RangedWeapon : Weapon
    {
        /// <summary>
        /// Rango máximo del arma.
        /// </summary>
        float MaxRange { get; }
    }

    /// <summary>
    /// Engloba a las armas que necesitan munición.
    /// </summary>
    public interface AmmoWeapon : RangedWeapon
    {
        /// <summary>
        /// Munición restante del arma.
        /// </summary>
        int Remaining { get; }
    }

    public abstract class Potion : Item
    {
        /// <summary>
        /// Número de usos restantes.
        /// </summary>
        public int Remaining { get; protected set; }

        public Potion(string name, int? precioVenta, int uses) : base(name)
        {
            Remaining = uses;
        }

        /// <summary>
        /// Método abstracto para aplicar el efecto de la poción al jugador.
        /// </summary>
        public abstract void ApplyEffect(Player player);

    }
    /// <summary>
    /// Se añade subclase StaminaPotion.
    /// </summary>
    public class StaminaPotion : Potion
    {
        public StaminaPotion(string name, int? precioVenta, int uses)
            : base(name, precioVenta, uses)
        {
        }

        public override void ApplyEffect(Player player)
        {
            if (Remaining <= 0)
            {
                Console.WriteLine($"{Name} no tiene usos restantes.");
                return;
            }

            Remaining--;
            Console.WriteLine("Recovering");
        }
    }

     /// <summary>
    /// Se añade subclase ManaPotion.
    /// </summary>
    public class ManaPotion : Potion
    {
        public ManaPotion(string name, int? precioVenta, int uses)
            : base(name, precioVenta, uses)
        {
        }

        public override void ApplyEffect(Player player)
        {
            if (Remaining <= 0)
            {
                Console.WriteLine($"{Name} no tiene usos restantes.");
                return;
            }

            Remaining--;
            Console.WriteLine("Recharging");
        }
    }

    /// <summary>
    /// Se añade subclase RestoreAll.
    /// </summary>
    public class RestoreAll : Potion
    {
        public int HealAmount { get; private set; }

        public RestoreAll(string name, int? sellPrice, int uses, int healAmount)
            : base(name, sellPrice, uses)
        {
            HealAmount = healAmount;
        }

        public override void ApplyEffect(Player player)
        {
            if (Remaining <= 0)
            {
                Console.WriteLine($"{Name} no tiene usos restantes.");
                return;
            }

            Remaining--;
            Console.WriteLine("Healing");
            Console.WriteLine("Recovering");
            Console.WriteLine("Recharging");
        }
    }
    
}