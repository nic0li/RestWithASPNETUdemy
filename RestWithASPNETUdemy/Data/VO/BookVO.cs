﻿using RestWithASPNETUdemy.HyperMedia;
using RestWithASPNETUdemy.HyperMedia.Interfaces;
using System;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LaunchDate { get; set; }
        public double Price { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
