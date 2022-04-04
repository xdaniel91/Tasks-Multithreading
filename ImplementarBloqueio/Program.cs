long somaGeral;
var lockObj = new object();
int[] items = Enumerable.Range(0, 100001).ToArray();


while (true)
{
    Executar();
    Thread.Sleep(1000);
}

void AdicionaFaixaDeValores(int inicial, int final)
{
    long subtotal = 0;

    while (inicial < final)
    {
        subtotal += items[inicial];
        inicial++;
    }
    Monitor.Enter(lockObj);
    try
    {
        somaGeral += subtotal;
    }
    finally
    {
        Monitor.Exit(lockObj);
    }
}

void Executar()
{
    somaGeral = 0;
    List<Task> tarefas = new List<Task>();
    int tamanhoFaixa = 1000;
    int inicioFaixa = 0;

    while (inicioFaixa < items.Length)
    {
        int fimFaixa = inicioFaixa + tamanhoFaixa;
        if (fimFaixa > items.Length)
            fimFaixa = items.Length;

        // cria uma cópia local dos parâmetros
        int i = inicioFaixa;
        int f = fimFaixa;
        tarefas.Add(Task.Run(() => AdicionaFaixaDeValores(i, f)));
        inicioFaixa = fimFaixa;
    }
    Task.WaitAll(tarefas.ToArray());
    Console.WriteLine("A soma geral é: {0}", somaGeral);
}