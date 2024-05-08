using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace net_ef_videogame
{
    [Table("software_houses")]
    [Index ("SoftwareHouseId")]
    public class SoftwareHouse
    {
        [Key]
        public int SoftwareHouseId { get; set; }
        public string Name { get; set; }
        public string tax_Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Videogame> Videogames { get; set; }

        public SoftwareHouse( string name, string city, string country)
        { 
            Name = name;
            tax_Id = "tax-id-test";
            City = city;
            Country = country;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public SoftwareHouse() { }
    }

    public static class SoftwareHouseManager 
    { 
        public static void InserisciSoftwareHouse( SoftwareHouse softwareHouse )
        {
            try
            {
                using VideogameContext db = new VideogameContext();
                db.Add(softwareHouse);
                db.SaveChanges();
                Console.WriteLine($"{softwareHouse.Name} è stato inserito!");
            }
            catch (Exception e)
            {
                Console.WriteLine( e.ToString() );
            }
        }
    }

}
