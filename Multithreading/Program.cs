using System.Diagnostics;
using System.Threading.Tasks;


//TAREFA 1: Cozinhar e refogar EM SÉRIE
//TAREFA 2: Cozinhar e refogar EM PARALELO
//TAREFA 3: Medir o tempo dos 2 procedimentos

//CozinharMacarrao();
//RefogarMolho();

RefogarCozinhar();

void RefogarCozinhar()
{
    var watch = new Stopwatch();
    watch.Start();
    Parallel.Invoke(() => CozinharMacarrao(), () => RefogarMolho());
    watch.Stop();
    Console.WriteLine("tempo total para regofar e cozinhar! " + watch.ElapsedMilliseconds / 1000.0 + "s");
}

void CozinharMacarrao()
{
    var watch = new Stopwatch();
    watch.Start();
    Console.WriteLine("Cozinhando macarrão...");
    Thread.Sleep(1000);
    watch.Stop();
    Console.WriteLine("Macarrão já está cozido! tempo decorrido = " + watch.ElapsedMilliseconds / 1000.0 + "s");
    Console.WriteLine();
}

void RefogarMolho()
{
    var watch = new Stopwatch();
    watch.Start();
    Console.WriteLine("Refogando molho...");
    Thread.Sleep(2000);
    watch.Stop();
    Console.WriteLine("Molho já está refogado! tempo decorrido = " + watch.ElapsedMilliseconds / 1000.0 + "s");
    Console.WriteLine();
}