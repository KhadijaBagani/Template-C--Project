

//Nombre del módulo
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using VideoGame.Inventory;

namespace Linq{

    /// <summary>
    /// Sirve como nexo del módulo
    /// </summary>
    public class Module
    {

        /// <summary>
        /// Punto de entrada para ejecutar el módulo
        /// </summary>
        public static void Execute()
        {

            {
                string[] numbers = ["1", "2", "3", "4"];
                var result = (from number in numbers
                              select "numbers: " + number);
                Console.WriteLine(string.Join(", ", result));

            }
            {
                int[] numbers = [1, 2, 3, 4];
                var result = from number in numbers
                             select new string('A', number);
                Console.WriteLine(string.Join(", ", result));
            }
            {
                string?[] nombres = ["Sofia", "Andres", "Khadija", null, "David"];
                var result = from nombre in nombres
                             select nombre ?? "Sin nombre";
                Console.WriteLine(string.Join(", ", result));

            }
            {
                string?[] nombres = ["Sofia", "Andres", "Khadija", null, "David"];
                var result = nombres.Select(nombre => nombre ?? "Sin nombre");
                Console.WriteLine(string.Join(", ", result));

            }

            {
                int[] numbers = [1, 2, -2, 3, 4];
                var result = from number in numbers
                             where number >= 0
                             select new string('A', number);
                Console.WriteLine(string.Join(", ", result));
            }

            {
                string[] nombres = ["Sofia", "Andres", "Andres", "Khadija", "David"];
                var result = nombres
                            .Where(nombre => nombre.StartsWith("A"))
                            .Distinct();

                Console.WriteLine(string.Join(", ", result));

            }

            {
                new HealingPotion("", null, 5);
                Item[] items = [new HealingPotion("", null, 5),
                    new Armor("", 0.3f),
                    new SpellScroll(null, 6, null),
                    new MagicWand(null, 4, null),
                    ];
                var result = items.OfType<Potion>();
                Console.WriteLine(string.Join(", ", result));
            }

            {
                new HealingPotion("", null, 5);
                Item[] items = [new HealingPotion("", null, 5),
                    new Armor("", 0.3f),
                    new SpellScroll(null, 6, null),
                    new MagicWand(null, 4, null),
                    ];
                var result = items.OfType<Potion>()
                            .Where(item => item.Remaining > 0)
                            .Count();
                Console.WriteLine(result);
            }
            {
                new HealingPotion("", null, 5);
                Item[] items = [
                    //new HealingPotion("", null, 5),
                    new Armor("", 0.3f),
                    new SpellScroll(null, 6, null),
                    new MagicWand(null, 4, null),
                   //new HealingPotion("", null, 4)
                    ];
                var result = items.OfType<Potion>()
                            .Where(item => item.Remaining > 0)
                            .FirstOrDefault();
                Console.WriteLine(result);
            }

            {
                new HealingPotion("", null, 5);
                Item[] items = [new HealingPotion("", null, 5),
                    new Armor("", 0.3f),
                    new SpellScroll(null, 6, null),
                    new MagicWand(null, 4, null),
                    ];
                var result = items.OfType<Potion>()
                            .Where(item => item.Remaining > 0)
                            .Sum(Potion => Potion.Remaining);
                Console.WriteLine(result);
            }
            
            {
                new HealingPotion("", null, 5);
                Item[] items = [new HealingPotion("", null, 5),
                    new Armor("", 0.3f),
                    new SpellScroll(null, 6, null),
                    new MagicWand(null, 4, null),
                    new HealingPotion("", null, 3)
                    ];
                var result = items.OfType<Potion>()
                            .Where(item => item.Remaining > 0)
                            .MaxBy(Potion=>Potion.Remaining);
                Console.WriteLine(result);
            }
        }
        

    }
    

}




