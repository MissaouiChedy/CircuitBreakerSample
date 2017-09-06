using System;
using System.Threading;

using CircuitBreakerSample.MongoDatabase;
namespace CircuitBreakerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersonRepository repository = new CircuitBreakerRepository(DatabaseConnectionFactory.Connection);
            for (int i = 0 ; i < 100; i++) 
            {
                try 
                {
                    repository.Write( new Person 
                    {
                        Id = i,
                        Name = $"Roy {i}"
                    });
                    Console.WriteLine($"Written {i}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.GetType().FullName}: {e.Message}");
                }
                Thread.Sleep(800);
            }
        }
    }
}
