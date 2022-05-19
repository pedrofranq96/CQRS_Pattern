using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_read_Infrastructure.Persistence.People
{
    public class PersonRespository : IPersonRepository
    {
        private static List<Person> listPersonMemory = new List<Person>();

        public void Delete(Person entity)
        {
            listPersonMemory.Remove(entity);
        }

        public void Delete(object id)
        {
            listPersonMemory.Remove(Find(id));
        }

        public Person Find(object id)
        {
            return listPersonMemory.AsQueryable().FirstOrDefault(p => p.Id.Equals(id));
        }

        public IQueryable<Person> Get(Expression<Func<Person, bool>> predicate = null)
        {
            return predicate != null ?
                listPersonMemory.AsQueryable().Where(predicate)
                : listPersonMemory.AsQueryable();
        }

        public void Insert(Person entity)
        {
            if (entity.Id == -1)
            {
                entity = new Person
                (listPersonMemory.Count + 1, entity.PersonClass, entity.Name, entity.Age);
                listPersonMemory.Add(entity);
            }
        }

        public void Update(Person entity)
        {
            var person = Find(entity.Id);
            person.PersonClass = entity.PersonClass;
            person.Name = entity.Name;
            person.Age = entity.Age;
        }
    }
}
