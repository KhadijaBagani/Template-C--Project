namespace VideoGame.Inventory
{


    /// <summary>
    /// Subclase Armor
    /// <summary>
    public class Armor : Item
    {
        private readonly float _dmgReduction;

        public Armor(string name, float dmgReduction) : base(name)
        {
            if (dmgReduction < 0f || dmgReduction > 1f)
                throw new ArgumentOutOfRangeException(nameof(dmgReduction), "La reducción de daño debe estar entre 0 y 1.");
            _dmgReduction = dmgReduction;
        }

        public int ReduceDMG(int baseDamage)
        {
            int reducedDamage = (int)(baseDamage * (1 - _dmgReduction));
            Console.WriteLine($"Damage reduced from {baseDamage} to {reducedDamage}.");
            return reducedDamage;
        }
    }

    /// <summary>
    ///subclase HealingPotion
    /// <summary>
    public class HealingPotion : Potion
    {
        public int Size { get; }
        public int UsesRemaining { get; protected set; }

        public HealingPotion(string name, int? precioVenta, int uses) : base(name, precioVenta, uses)

        {
            PrecioVenta = precioVenta;
        }

        public override void ApplyEffect(Player player)
        {
        }


        /// <summary>
        /// Método para usar la poción
        /// <summary>
        public void Use()
        {
            if (UsesRemaining > 0)
            {
                UsesRemaining--;
                Console.WriteLine("Healing");
            }
            else
            {
            }
        }
    }
}