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
        [Column("id")]
        public int SoftwareHouseId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("tax_id")]
        public string tax_Id { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("country")]
        public string Country { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
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
        public static void InsertSoftwareHouse( SoftwareHouse softwareHouse )
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
