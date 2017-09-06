using System;
using System.Threading;

using CircuitBreakerSample.MongoDatabase;
namespace CircuitBreakerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a circuit breaker repository
            IPersonRepository repository = new CircuitBreakerRepository(DatabaseConnectionFactory.Connection);
            for (int i = 0 ; i < 100; i++) 
            {
                try 
                {
                    ReadOrWrite(repository, i);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.GetType().FullName}: {e.Message}");
                }
                Thread.Sleep(800);
            }
        }
        static void ReadOrWrite(IPersonRepository repository, int i) 
        {
            var random = new Random(50);
            if (random.Next() > 25) 
            {
                // make a write
                var person = new Person 
                {
                    Id = i,
                    Name = $"Baby Roy {i}"
                };
                repository.Write(person);
                Console.WriteLine($"Written: {person}");
            }
            else 
            {
                // make a read
                Console.WriteLine(string.Join(", ", repository.Read()));
            }
        }
    }
}
