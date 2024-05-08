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
    }
}
