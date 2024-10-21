using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            // Implementar o acesso a BD para incluir
            return person;
        }

        public void Delete(long id)
        {
            // Implementar o acesso a BD para incluir
        }

        public List<Person> FindAll()
        {
            //Por enquanto Mock
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindByID(long id)
        {
            //Por enquanto Mock
            return new Person
            {
                Id = IncrementAndGet(),,
                FirstName = "Antonio",
                LastName = "Silva",
                Address = "Guarulhos - SP, Brazil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            // Implementar o acesso a BD para alterar
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + 1,
                LastName = "Person LastName " + 1,
                Address = "Aome Address " + 1,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
