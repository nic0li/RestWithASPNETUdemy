using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.HyperMedia.Utils;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.UseCases.Interfaces
{
    public interface IPersonUseCase
    {
        List<PersonVO> FindAll();
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO Disable(long id);
        void Delete(long id);
        PagedSearchVO<PersonVO> FindWithPagedSearch(
            string name, string sortDirection, int pageSize, int currentPage);
    }
}
