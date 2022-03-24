using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.HyperMedia.Utils;
using RestWithASPNETUdemy.Repositories.Interfaces;
using RestWithASPNETUdemy.UseCases.Interfaces;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.UseCases
{
    public class PersonUseCase : IPersonUseCase
    {
        private readonly IPersonRepository _repository;

        private readonly PersonConverter _converter;

        public PersonUseCase(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        public PersonVO Create(PersonVO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public PersonVO Update(PersonVO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }

        public PersonVO Disable(long id)
        {
            var entity = _repository.Disable(id);
            return _converter.Parse(entity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(
            string name, string sortDirection, int pageSize, int currentPage)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = currentPage > 0 ? (currentPage - 1) * size : 0;

            string query = @"SELECT * FROM person p WHERE 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) query += $" AND p.first_name LIKE '%{name}%' ";
            query += $" ORDER BY p.first_name {sort} LIMIT {size} OFFSET {offset}";

            string countQuery = @"SELECT COUNT(*) FROM person p WHERE 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) countQuery += $" AND p.first_name LIKE '%{name}%' ";

            var people = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO>
            {
                CurrentPage = currentPage,
                List = _converter.Parse(people),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }
    }
}
