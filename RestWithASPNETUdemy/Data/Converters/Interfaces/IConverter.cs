using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.Converters.Interfaces
{
    public interface IConverter<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
