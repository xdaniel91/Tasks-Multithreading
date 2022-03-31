#pragma warning disable
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;

Tarefa8();

void Benchmark()
{
    var watch = new Stopwatch();
    watch.Start();
    Tarefa1();
    watch.Stop();
    Console.ForegroundColor = ConsoleColor.Yellow;
    var str1 = $"Tarefa1 = {watch.ElapsedMilliseconds / 1000.0} seconds";

    Console.ResetColor();
    watch.Restart();
    Tarefa2();
    watch.Stop();
    Console.ForegroundColor = ConsoleColor.Yellow;
    var str2 = $"Tarefa2 = {watch.ElapsedMilliseconds / 1000.0} seconds";

    Console.ResetColor();
    watch.Restart();
    Tarefa3();
    watch.Stop();
    Console.ForegroundColor = ConsoleColor.Yellow;
    var str3 = $"Tarefa3 = {watch.ElapsedMilliseconds / 1000.0} seconds";

    Console.ResetColor();
    watch.Restart();
    Tarefa4();
    watch.Stop();
    Console.ForegroundColor = ConsoleColor.Yellow;
    var str4 = $"Tarefa2 = {watch.ElapsedMilliseconds / 1000.0} seconds";

    Console.ResetColor();
    watch.Restart();
    Tarefa5();
    watch.Stop();
    Console.ForegroundColor = ConsoleColor.Yellow;
    var str5 = $"Tarefa5 = {watch.ElapsedMilliseconds / 1000.0} seconds";

    Console.ResetColor();
    watch.Restart();
    Tarefa6();
    watch.Stop();
    Console.ForegroundColor = ConsoleColor.Yellow;
    var str6 = $"Tarefa5 = {watch.ElapsedMilliseconds / 1000.0} seconds";

    Console.ResetColor();
    watch.Restart();
    Tarefa7();
    watch.Stop();
    Console.ForegroundColor = ConsoleColor.Yellow;
    var str7 = $"Tarefa7 = {watch.ElapsedMilliseconds / 1000.0} seconds";


    Console.WriteLine("\n\n\nresult");
    Console.ResetColor();
    var strings = new List<string> { str1, str2, str3, str4, str5, str6, str7 };
    foreach (var item in strings)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(item);
    }
    Console.ResetColor();
}


void Tarefa8()
{
    var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(File.ReadAllText("filmes.json"));
    var query = from f in filmes.AsParallel() where f.Genero == "Adventure" select f;
    query.ForAll(filme =>
    {
        Console.WriteLine(filme.Titulo);   
    }
    );
}

void Tarefa7()
{
    var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(File.ReadAllText("filmes.json"));
    var query = (from f in filmes.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism) where f.Genero == "Adventure" orderby f.Faturamento descending select f).Take(4);

    foreach (var item in query)
    {
        Console.WriteLine($"{item.Titulo,-62} |  {item.Genero,-20} | {item.Faturamento:c}");
        Console.WriteLine(new String('-', 82) + "|");
    }
}

void Tarefa6()
{
    var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(File.ReadAllText("filmes.json"));
    var query = from f in filmes.AsParallel().AsOrdered() where f.Genero == "Adventure" select f;

    foreach (var item in query)
    {
        Console.WriteLine($"{item.Titulo,-62} |  {item.Genero,-20}");
        Console.WriteLine(new String('-', 82) + "|");
    }
}

void Tarefa5()
{
    var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(File.ReadAllText("filmes.json"));
    var query = from f in filmes.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism).WithDegreeOfParallelism(4) where f.Genero == "Adventure" select f;

    foreach (var item in query)
    {
        Console.WriteLine($"{item.Titulo,-62} |  {item.Genero,-20}");
        Console.WriteLine(new String('-', 82) + "|");
    }
}

void Tarefa4()
{
    var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(File.ReadAllText("filmes.json"));
    var query = from f in filmes.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism) where f.Genero == "Adventure" select f;

    foreach (var item in query)
    {
        Console.WriteLine($"{item.Titulo,-62} |  {item.Genero,-20}");
        Console.WriteLine(new String('-', 82) + "|");
    }
}

void Tarefa3()
{
    var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(File.ReadAllText("filmes.json"));
    var query = from f in filmes.AsParallel().WithExecutionMode(ParallelExecutionMode.Default) where f.Genero == "Adventure" select f;

    foreach (var item in query)
    {
        Console.WriteLine($"{item.Titulo,-62} |  {item.Genero,-20}");
        Console.WriteLine(new String('-', 82) + "|");
    }
}

void Tarefa2()
{
    var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(File.ReadAllText("filmes.json"));
    var query = from f in filmes.AsParallel() where f.Genero == "Adventure" select f;

    foreach (var item in query)
    {
        Console.WriteLine($"{item.Titulo, -62} |  {item.Genero, -20}");
        Console.WriteLine(new String('-', 82) + "|");
    }
}

void Tarefa1()
{
    // seleciona todos os filmes cujo genero é adventure

    var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(File.ReadAllText("filmes.json"));

    var query = from f in filmes where f.Genero == "Adventure" select f;

    foreach (var item in query)
    {
        Console.WriteLine($"{item.Titulo,-62} |  {item.Genero,-20}");
        Console.WriteLine(new String('-', 82) + "|");
    }
}
    public class Filme
    {
        public string? Titulo { get; set; }
        public decimal? Faturamento { get; set; }
        public decimal? Orcamento { get; set; }
        public string? Distribuidor { get; set; }
        public string? Genero { get; set; }
        public string? Diretor { get; set; }
        public decimal Lucro { get; set; }
        public decimal LucroPorcentagem { get; set; }

        public int CompareTo(object obj)
        {
            Filme outro = obj as Filme;
            return this.Titulo.CompareTo(outro?.Titulo);
        }
    }

