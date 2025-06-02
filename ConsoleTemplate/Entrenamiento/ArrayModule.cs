
//Nombre del módulo
namespace Arrays{

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


            //Usad este array como base para comprobar que funciona
            string[] letters = "abcdefghijklmnñopqrtuvwxyz"
                                .Select(c => c.ToString())
                                .ToArray();

            Console.WriteLine("Valores en posiciones pares (índice impar):");
            foreach (var item in letters.Select((value, index) => new { value, index })
                  .Where(x => x.index % 2 == 1))
            {
                Console.WriteLine(item.value);
            }

            Console.WriteLine("\nRecorrido desde fuera:");

            int i = 0;
            int j = letters.Length - 1;

            while (i <= j)
            {
                if (i == j)
                {
                    // Centro del array (cuando hay número impar de elementos)
                    Console.WriteLine(letters[i]);
                }
                else
                {
                    Console.WriteLine(letters[i]);
                    Console.WriteLine(letters[j]);
                }
                i++;
                j--;
            }

            // Llamar al método FibonacciArray con un tamaño de 10
            var fibonacciArray = FibonacciArray(10);
            Console.WriteLine("Fibonacci Array (size 10): " + string.Join(", ", fibonacciArray));

            // Llamar a FibonacciArray con una sobrecarga (empezando con 2 y 3)
            var fibonacciArrayWithCustomStart = FibonacciArray(10, 2, 3);
            Console.WriteLine("Fibonacci Array (size 10, custom start 2, 3): " + string.Join(", ", fibonacciArrayWithCustomStart));

            // Llamar al método PowersOfTwo con un límite de 100
            var powersOfTwo = PowersOfTwo(100);
            Console.WriteLine("Powers of Two (limit 100): " + string.Join(", ", powersOfTwo));
        }
        
        public static int[] FibonacciArray(int size)
        {
            if (size <= 0)
                return new int[0]; // Retorna un array vacío si el tamaño es 0 o negativo

            int[] fibonacci = new int[size];
            fibonacci[0] = 0;
            if (size > 1) fibonacci[1] = 1;

            for (int i = 2; i < size; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            return fibonacci;
        }

        // Sobrecarga de FibonacciArray para permitir valores de inicio personalizados
        public static int[] FibonacciArray(int size, int first, int second)
        {
            if (size <= 0)
                return new int[0]; // Retorna un array vacío si el tamaño es 0 o negativo

            int[] fibonacci = new int[size];
            fibonacci[0] = first;
            if (size > 1) fibonacci[1] = second;

            for (int i = 2; i < size; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            return fibonacci;

        }

        // Método PowersOfTwo que devuelve todas las potencias de 2 menores que el límite
        public static int[] PowersOfTwo(int limit)
        {
            // Si el límite es menor o igual a 1, devolvemos un array vacío
            if (limit <= 1)
                return new int[0];

            var powers = new System.Collections.Generic.List<int>();
            int power = 1;

            // Mientras la potencia actual sea menor que el límite, seguimos añadiendo
            while (power < limit)
            {
                powers.Add(power);
                power *= 2; // Multiplicamos por 2 en cada iteración
            }

            return powers.ToArray(); // Convertimos la lista a un array
        }

    }
    

}