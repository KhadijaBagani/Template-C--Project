
using System.Text.Json;

namespace Database.Tables {
    public abstract class BaseTable {
        public override string ToString() {
            var format = new JsonSerializerOptions() {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize((object)this, format);
            return $"{this.GetType().Name}:{json}";
        }

        /// <summary>
        /// Convierte el objeto en una lista de valores separada por comas
        /// </summary>
        public string ToCSV() {
            //Serializar
            using var document = JsonSerializer.SerializeToDocument(this, this.GetType());
            JsonElement root = document.RootElement;
            var builder = new System.Text.StringBuilder();
            
            //Añadir valores
            var row = root.EnumerateObject().Select(o => o.Value.ToString());
            builder.AppendJoin(',', row);
            
            return builder.ToString();
        }

        /// <summary>
        /// Convierte el objeto en una lista de nombres de campos separada por comas
        /// </summary>
        public string ToCSVHeaders() {
            //Serializar
            using var document = JsonSerializer.SerializeToDocument(this, this.GetType());
            JsonElement root = document.RootElement;
            var builder = new System.Text.StringBuilder();
            
            //Añadir valores
            var row = root.EnumerateObject().Select(o => o.Name);
            builder.AppendJoin(',', row);
            
            return builder.ToString();
        }

    }
}

