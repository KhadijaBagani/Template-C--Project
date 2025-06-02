
using System.Runtime.InteropServices;

namespace VideoGame.Inventory
{
    public class MasterPotion : Potion
    {
        public Action<Player> UseEffect { get; set; }

        public MasterPotion(string name, int? precioVenta, int uses)
            : base(name, precioVenta, uses)
        {
            UseEffect = (Player player) => Console.WriteLine("Error: No se ha asignado ningún 'UseEffect'.");
        }

        // Implementación requerida del método abstracto
        public override void ApplyEffect(Player player)
        {
            if (Remaining <= 0)
            {
                Console.WriteLine($"{Name} no tiene usos restantes.");
                return;
            }

            Remaining--;
            UseEffect?.Invoke(player);
        }

        public static MasterPotion CreateHealingPotion(int uses)
        {
            var potion = new MasterPotion("HealingPotion", null, uses);
            potion.UseEffect = (Player player) => Console.WriteLine("Healing");
            return potion;
        }

        public static MasterPotion CreateManaPotion(int uses)
        {
            var potion = new MasterPotion("ManaPotion", null, uses);
            potion.UseEffect = (Player player) => Console.WriteLine("Recharging");
            return potion;
        }
    }

    public class Reward
    {
        private readonly Dictionary<string, double> _itemChances;
        private bool _hasRewardBeenGiven;
        private string? _rewardedItem;
         private static readonly Random _random = new Random();
        public Reward(Dictionary<string, double> itemChances)
        {
            if (itemChances == null || itemChances.Count == 0)
                throw new ArgumentException("Item chances must contain at least one item.");

            double totalChance = 0;
            foreach (var chance in itemChances.Values)
            {
                if (chance < 0 || chance > 1)
                    throw new ArgumentException("Item chances must be between 0 and 1.");
                totalChance += chance;
            }

            if (Math.Abs(totalChance - 1.0) > 0.001)
                throw new ArgumentException("The total probability must sum to 1.");

            _itemChances = new Dictionary<string, double>(itemChances);
            _hasRewardBeenGiven = false;
            _rewardedItem = null;
        }

        public string? GetReward()
        {
            if (_hasRewardBeenGiven)
                return _rewardedItem;

            if (_itemChances.Count == 0)
                throw new InvalidOperationException("No items available for reward.");

            double r = _random.NextDouble(); // Valor aleatorio entre 0.0 y 1.0
            double cumulative = 0.0;

            foreach (var kvp in _itemChances)
            {
                cumulative += kvp.Value;
                if (r <= cumulative)
                {
                    _rewardedItem = kvp.Key;
                    _hasRewardBeenGiven = true;
                    return _rewardedItem;
                }
            }
             _rewardedItem = new List<string>(_itemChances.Keys)[_itemChances.Count - 1];
            _hasRewardBeenGiven = true;
            return _rewardedItem;
        }
        public IReadOnlyDictionary<string, double> GetChances()
        {
            return new Dictionary<string, double>(_itemChances);
        }

        public double GetItemChance(string item)
        {
            throw new NotImplementedException();
        }
    }
}