using Extensions.Swagger;



/// <summary>
/// ! NO TOCAR EL PROGRAM EN ESTE PROYECTO, 
/// HACER LAS COSAS EN <see cref="ApiEndpoints"/>
/// </summary>
internal class Program {
    static void Main(string[] args) {
        RunApi(args);
    }

    /// <summary>
    /// Inicializa la API y la ejecuta
    /// ! NO TOCAR
    /// </summary>
    /// <param name="args">parámetros de ejecución</param>
    static void RunApi(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddOpenApi();
        builder.Services.AddSwagger();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment()) {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI Modified V.2");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();

        new ApiEndpoints(app,new ServerData()).SetUp();

        app.Run();
    }
}


record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary) {
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
