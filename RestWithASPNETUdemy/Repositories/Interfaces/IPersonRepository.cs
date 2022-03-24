using RestWithASPNETUdemy.Models;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repositories.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string secondName);
    }
}
