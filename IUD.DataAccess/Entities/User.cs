using System;
using System.ComponentModel.DataAnnotations;

namespace IUD.DataAccess.Entities
{
    public class User : IEntity
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }

        [Key]
        public int Id { get; set; }
    }
}