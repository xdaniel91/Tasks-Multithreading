
Task tarefa = Task.Run(() => Hello());
tarefa.ContinueWith( (previousTask) => World(), TaskContinuationOptions.NotOnFaulted);

tarefa.ContinueWith((previosTask) =>
{
    Erro(previosTask);
}, TaskContinuationOptions.OnlyOnFaulted);


Console.ReadLine();

void Erro(Task mytask)
{
    var exs = mytask.Exception.InnerExceptions;
    foreach (var item in exs)
    {
        Console.WriteLine("\n" + exs);
    }
}

void Hello()
{
    Console.Write(" Hello ");
    throw new ApplicationException("Opa! Ocorreu erro no método Olá");
}

void World()
{
    Console.Write(" World ");
}