

using System.Text.Json;
using DBTables.Overflow;


//Nombre del módulo
namespace DBtables{

    /// <summary>
    /// Sirve como nexo del módulo
    /// </summary>
    public class Module{

        /// <summary>
        /// Punto de entrada para ejecutar el módulo
        /// </summary>
        public static void Execute(){
            
            /*
                funcionalidades del módulo
            */
            var list = new List<Comment>(){new Comment("texto prueba")};
            var listInt = new List<int>() {1,2,3,4};
            listInt.Insert(1,2);
            var comment = new Comment(1, new DateTime(2025,05,08), 1, "Texto comentario",2, 12);
            var comment2 = new Comment(2, new DateTime(2025,05,08) , 3, "Otra cosa", 5,14);
            var json = JsonSerializer.Serialize(comment);
             Console.WriteLine();
        }

    }
    

}