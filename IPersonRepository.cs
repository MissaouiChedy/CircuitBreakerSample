using System.Collections.Generic;
namespace CircuitBreakerSample 
{
    public interface IPersonRepository
    {
        List<Person> Read();

        void Write(Person person);
    }
}