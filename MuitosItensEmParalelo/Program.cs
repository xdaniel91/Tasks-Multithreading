
using System.Diagnostics;


Parallel.Invoke(() => ProcessarItensEmSerie(), () => ProcessarParalelo(), () => ParaleloForEach());

//ProcessarItensEmSerie();
//ProcessarParalelo();
//ParaleloForEach();

#region methods
void ProcessarItensEmSerie()
{
    var watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < 100; i++)
    {
        Processar(i);
    }
    watch.Stop(); 
    Console.WriteLine("\n" + "Em serie::  " + watch.ElapsedMilliseconds / 1000 + "sec");
}

void ParaleloForEach()
{
    var itens = Enumerable.Range(0, 100);
    var watch = new Stopwatch();
    watch.Start();
    Parallel.ForEach(itens, i => Processar(i));
    watch.Stop();
    Console.WriteLine("\n" + "foreach::  "+ watch.ElapsedMilliseconds / 1000 + "sec");
}

void ProcessarParalelo()
{
    var watch = new Stopwatch();
    watch.Start();
    Parallel.For(0, 100, (i) => Processar(i));
    watch.Stop();
    Console.WriteLine("\n"  + "paralelo::  " + watch.ElapsedMilliseconds / 1000 + "sec");
}

static void Processar(object item)
{

    Console.WriteLine("Começando a trabalhar com: " + item);
    Thread.Sleep(100);
    Console.WriteLine("Terminando a trabalhar com: " + item);

}
#endregion