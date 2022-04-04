CancellationTokenSource cancellationTokenSource
               = new CancellationTokenSource();

Task contagem = new Task(()
    => ContagemRegressiva(cancellationTokenSource.Token));
contagem.Start();
Console.ReadKey();

if (contagem.IsCompleted)
{
    Console.WriteLine("A contagem foi completada.");
}
else
{
    try
    {
        cancellationTokenSource.Cancel();
        contagem.Wait();
    }
    catch (OperationCanceledException ex)
    {
        Console.WriteLine("A contagem foi interrompida pelo usuario: {0}", ex.InnerException.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("A contagem foi interrompida: {0}", ex.InnerException.Message);
    }
}
Console.ReadLine();


void ContagemRegressiva(CancellationToken token)
{
    int i = 0;
    while (i <= 7 && !token.IsCancellationRequested)
    {
        Console.WriteLine($"Contagem {i}");
        Thread.Sleep(500);
        i++;
    }

    token.ThrowIfCancellationRequested();
}
