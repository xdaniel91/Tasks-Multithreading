
//var result = Parallel.For(0, 99, (i) => Processar(i));

var result = Parallel.For(0, 99, (int i, ParallelLoopState state) =>
{
    if (i == 75)
    {
        state.Break();
    }
    Processar(i);
}
);

Console.WriteLine($"\n completou sem interrupção? {result.IsCompleted}");
Console.WriteLine($"\n quantos itens foram processados? {result.LowestBreakIteration}");

static void Processar(object item)
{
    Console.WriteLine("Começando a trabalhar com: " + item);
    Thread.Sleep(100);
    Console.WriteLine("Terminando a trabalhar com: " + item);
}