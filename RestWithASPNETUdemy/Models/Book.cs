using RestWithASPNETUdemy.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Models
{
    [Table("book")]
    public class Book : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }

        [Column("price")]
        public double Price { get; set; }
    }
}
