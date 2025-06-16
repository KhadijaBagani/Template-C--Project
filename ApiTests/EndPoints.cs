

using Database;

/// <summary>
/// Gestiona la inicialización de los endpoints
/// </summary>
public class ApiEndpoints {

    /// <summary>
    /// Referencia al objeto que gestiona la conexión y la aplicación web
    /// </summary>
    public readonly WebApplication app;

    /// <summary>
    /// Referencia al objeto que gestiona los datos del servidor
    /// </summary>
    public readonly ServerData data;

    /// <summary>
    /// Crea los EndPoints para una app específica
    /// </summary>
    /// <param name="app"></param>
    public ApiEndpoints(WebApplication app, ServerData data) {

        this.app = app ?? throw new ArgumentNullException("App can't be null");
        this.data = data ?? throw new ArgumentNullException("ServerData can't be null");
    }

    /// <summary>
    /// Añade todos los endpoints a swagger
    /// </summary>
    public void SetUp() {

        MyEndpoints();
        ExampleGetEndpoints();
        ExamplePostEndpoint();
    }

    /// <summary>
    /// Endpoints que hemos hecho nosotros
    /// </summary>
    private void MyEndpoints() {
        var summaries = data.weatherOptions;
        app.MapGet("prueba1", () => {
            using (var context = new LocalDbContext()) {
                Console.WriteLine("Me estoy ejecutando");
                var Alberta = context.StateProvince
                    .Where(row => row.Name == "Alberta")
                    .First();

                return Alberta;
            }
        })
        .WithName("prueba1")
        .WithDescription("Ejemplo de endpoint get básico")
        .WithTags("Pruebas");
    }


    /// <summary> 
    /// Añade endpoints Get de ejemplo. Comentar si deja de usarse
    /// </summary>
    private void ExampleGetEndpoints() {

        var summaries = data.weatherOptions;
        app.MapGet("weatherforecast", () => {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (   
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Count)]
                ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithDescription("Ejemplo de endpoint get básico")
        .WithTags("Examples");

        app.MapGet("/weatheroption/{index:int}", (int index) => summaries[index])
        .WithName("GetWeatherOption")
        .WithDescription("Ejemplo de endpoint get que recibe un parámetro")
        .WithTags("Examples");

        app.MapGet("/allweatheroptions/", () => summaries)
        .WithName("GetAllWeatherOptions")
        .WithDescription("Ejemplo de endpoint get que devuelve una colección")
        .WithTags("Examples");

        app.MapGet("/sampleobject/", () => new { // * Esto es un "tipo anónimo"
            Id = 1,
            Name = "Objeto",
            obj = new {
                Name = "Sub-Objeto",
                Valores = new int[]{1, 2, 3, 4},
            }
        })
        .WithName("GetSampleObject")
        .WithDescription("Ejemplo de endpoint get que devuelve un objeto")
        .WithTags("Examples");
    }


    /// <summary>
    /// Estructura de la request quer recibe el post
    /// CUIDADO: han de ser propiedades
    /// </summary>
    public class WeatherInsertRequest {
        /// <summary>
        /// Posición en la que insertar
        /// </summary>
        public int? index { get; set; }
        /// <summary>
        /// Texto a insertar
        /// </summary>
        public string description { get; set; } = "";
    }

    /// <summary>
    /// Añade endpoints Post de ejemplo. Comentar si deja de usarse
    /// </summary>
    private void ExamplePostEndpoint() {


        app.MapPost("/setweather", (WeatherInsertRequest request) => {
            request.index ??= data.weatherOptions.Count;
            data.weatherOptions.Insert((int)request.index, request.description);

        })
        .WithName("SetWeatherForecast")
        .WithTags("Examples");
    }
}