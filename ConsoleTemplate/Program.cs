// See https://aka.ms/new-console-template for more information


internal class Program
{
    static void Main(string[] args){
        Console.WriteLine("Hello World!");
        //Cómo llamar a un módulo concreto
       Database.Module.Execute();
    }
}
