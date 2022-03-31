using System.Diagnostics;
using System.Threading.Tasks;



/* cada corredor vai correr dentro de uma task no array, somente depois que todos terminarem será exibida a mensagem de término */
Console.WriteLine($"numero de threads: {Process.GetCurrentProcess().Threads.Count} ");
var tasks = new Task[10]; 

for (int i = 0; i < 10; i++)
{
    int nmr = i;
    var mytask = Task.Run(() => 
    { 
        Correr(nmr); 
    });
    tasks[i] = mytask;

   //Console.WriteLine($"numero de threads: {Process.GetCurrentProcess().Threads.Count}");
}

Task.WaitAll(tasks);
Console.WriteLine($"numero de threads: {Process.GetCurrentProcess().Threads.Count} ");

Console.WriteLine("Término do processamento tecle [ENTER] para fechar");
Console.ReadKey();

//var tarefa1 = new Task(() =>
//{
//    ExecutaTrabalho(1);
//});
//tarefa1.Start();
//tarefa1.Wait();

//var tarefa2 = Task.Run(() => 
//{
//    ExecutaTrabalho(2);
//});
//tarefa2.Wait();

//Task<int> tarefa3 = Task.Run(() =>
//{
//    return CalcularResultado(2,8);
//});

//Console.WriteLine($"resultado  = {tarefa3.Result}");
//Console.WriteLine("Término do processamento tecle [ENTER] para fechar");


void ExecutaTrabalho(int item)
{
    Console.WriteLine($"Trabalho iniciando {item}");
    Thread.Sleep(2000);
    Console.WriteLine($"Trabalho terminado {item}\n");
}

int CalcularResultado(int n1, int n2)
{
    Console.WriteLine($"calculo iniciado");
    Thread.Sleep(2000);
    Console.WriteLine($"calculo terminado\n");
    return n1 + n2;
}

void Correr(int corredor)
{
    Console.WriteLine($"{corredor} largou");
    Thread.Sleep(1300);
    Console.WriteLine($"{corredor} terminou");
}