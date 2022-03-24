using RestWithASPNETUdemy.HyperMedia.Interfaces;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.HyperMedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
