using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Repositories.Interfaces;
using RestWithASPNETUdemy.UseCases.Interfaces;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.UseCases
{
    public class BookUseCase : IBookUseCase
    {
        private readonly IGenericRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookUseCase(IGenericRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Create(BookVO book)
        {
            var entity = _converter.Parse(book);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public BookVO Update(BookVO book)
        {
            var entity = _converter.Parse(book);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
