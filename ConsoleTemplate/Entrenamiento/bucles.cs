
//Nombre del módulo
namespace Bucles
{

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

            /*
                funcionalidades del módulo
            */

            for (int count = 0; count <= 20; count++)
            {
                Console.WriteLine(count);
            }

            for (int count = 20; count >= 0; count--)
            {
                Console.WriteLine(count);
            }


            string? input;
            do
            {
                Console.WriteLine("Write R to repeat");
                input = Console.ReadLine();
            }
            while (input == "R");


            {
                int count = 0;
                while (count <= 20)
                {
                    Console.WriteLine(count);
                    count++;

                }
            }

            foreach (int count in Enumerable.Range(0, 21)) 
            {
                Console.WriteLine(count);
            }

        }

    }

}






