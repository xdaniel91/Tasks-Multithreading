
/* problema: Criar e executar uma terafa-mãe e 10 tarefas-filhas que levam 1s cada uma para terminar */

var mae
    = Task.Factory.StartNew(() =>
         {
             Console.WriteLine("Tarefa-mãe iniciada");


             for (int i = 0; i < 10; i++)
             {
                 var index = i;
                 var filha = Task.Factory.StartNew((index) =>
                 {
                     Console.WriteLine($"\ttarefa-filha iniciou {index}");
                     Thread.Sleep(1000);
                     Console.WriteLine($"\ttarerfa-filha terminou {index}");
                 },index, TaskCreationOptions.AttachedToParent);
             }
         });
mae.Wait();
Console.WriteLine("tarefa-mãe terminou");
Console.ReadLine();