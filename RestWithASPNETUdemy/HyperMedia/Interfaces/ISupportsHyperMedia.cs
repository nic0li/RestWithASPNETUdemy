using System.Collections.Generic;

namespace RestWithASPNETUdemy.HyperMedia.Interfaces
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
