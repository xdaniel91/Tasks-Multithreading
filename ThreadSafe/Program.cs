var contador = new Contador();

var t1 = new Thread(() =>
{
    for (int i = 0; i < 50; i++)
    {
        contador.Incrementar();
        Thread.Sleep(i);
    }
});
t1.Start();

var t2 = new Thread(() => 
{
    for (int i = 0; i < 50; i++)
    {
        contador.Incrementar();
        Thread.Sleep(i);
    }
});
t2.Start();

t1.Join();
t2.Join();

Console.WriteLine($"contador: {contador.Numero}");

public class Contador
{
    Object objLock = new object();
    public int Numero { get; private set; } = 0;

    public void Incrementar()
    {
        lock (objLock)
        {
            Numero++;
        }
    }
}