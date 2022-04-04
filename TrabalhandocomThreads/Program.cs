Thread.CurrentThread.Name = "Thread Principal";
ExibirThread(Thread.CurrentThread);
Console.WriteLine("\n\n");

var myThread = new Thread(Execute);
myThread.Name = "Thread 1";
myThread.Start();
myThread.Join();
Console.WriteLine("\n\n");

var myThread2 = new Thread(() =>
{
    Execute();
});
myThread2.Name = "Thread 2 - lambda";
myThread2.Start();
myThread2.Join();
Console.WriteLine("\n\n");

var param = new ParameterizedThreadStart((p) => Execute2(p));
var myThread3 = new Thread(param);
myThread3.Name = "Thread 3 - com parametro";
myThread3.Start(123);
myThread3.Join();
Console.WriteLine("\n\n");

// interompendo um relógio \\
//bool funciona = true;
var tokenSource = new CancellationTokenSource();
var myThread4 = new Thread(() =>
{
   int count = 0;

   while (!tokenSource.IsCancellationRequested)
   {
       Console.WriteLine("tik  " + count);
       Thread.Sleep(1000);
       count++;
       Console.WriteLine("tak  " + count);
       count++;
       Thread.Sleep(1000);
   }
});

myThread4.Name = "Thread 4 - Interrompendo um relógio";
myThread4.Start();

Console.ReadKey();
//funciona = false;
tokenSource.Cancel();
myThread4.Join();
Console.WriteLine("\n\n");

for (int i = 0; i < 50; i++)
{
    var estadoItem = i;
    ThreadPool.QueueUserWorkItem((estado)
   => Execute2(estadoItem));
}

void Execute()
{
    ExibirThread(Thread.CurrentThread);
    Console.WriteLine("inicio de execução");
    Thread.Sleep(1000);
    Console.WriteLine("término de execução");
}

void Execute2(object param)
{
    ExibirThread(Thread.CurrentThread);
    Console.WriteLine($"inicio de execução {param}");
    Thread.Sleep(1000);
    Console.WriteLine($"término de execução {param}");
}

//exibir nome, culture, prioridade, contextp, background, pool
static void ExibirThread(Thread t)
{
    Console.WriteLine($"Nome: {t.Name}");
    Console.WriteLine($"Culture: {t.CurrentCulture.Name}");
    Console.WriteLine($"Prioridade: {t.Priority}");
    Console.WriteLine($"Contexto: {t.ExecutionContext}");
    Console.WriteLine($"Background: {t.IsBackground}");
    Console.WriteLine($"Pool?: {t.IsThreadPoolThread}");
}