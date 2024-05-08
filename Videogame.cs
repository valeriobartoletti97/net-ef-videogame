using net_ef_videogame;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_ef_videogame
{
[Table("videogames")]
[Index("VideogameId")]
public class Videogame
{
    [Key]
    [Column("id")]
    public int VideogameId { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("overview")]
    public string Overview { get; set; }
    [Column("release_date")]
    public string ReleaseDate { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
    [Column("software_house_id")]
    public int SoftwareHouseId { get; set; }
    public SoftwareHouse SoftwareHouse { get; set; }


    public Videogame(string name, string overview, string releaseDate, DateTime createdAt, DateTime updatedAt, int softwareHouseId)
    {
        Name = name;
        Overview = overview;
        ReleaseDate = releaseDate;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        SoftwareHouseId = softwareHouseId;
    }
        public Videogame()
        {

        }
}

public static class VideogameManager
{
    public static string CONNECTION_STRING = "Data Source=localhost;Initial Catalog=db-videogames-query;Integrated Security=True";
    public static void InsertVideogame(Videogame videogame)
    {
            using VideogameContext db = new VideogameContext();
            try
            {
               db.Add(videogame);
               db.SaveChanges();
               Console.WriteLine($"Il gioco {videogame.Name} è stato aggiunto.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    public static void SearchGameId(int id)
    {
        using VideogameContext db = new VideogameContext();
        try
        {
            Videogame videogame = db.Videogames.Where(x => x.VideogameId == id).FirstOrDefault();
                if (videogame != null)
                {
                    Console.Write("Il gioco che stavi cercando è: ");
                    Console.WriteLine(videogame.Name);
                }
                else
                {
                    Console.WriteLine("Il gioco che cerchi non è presente.");
                }
            }
        catch (Exception e)
        {
                Console.WriteLine(e.ToString());
        }
        
    }

    public static void SearchGameName(string name)
    {
            using VideogameContext db = new VideogameContext();
            try
            {
                List<Videogame> videogame = db.Videogames.Where(x => x.Name.Contains(name)).ToList<Videogame>();
                if(videogame.Count > 0)
                {
                    Console.WriteLine("Ecco i tuoi risultati:");
                    videogame.ToList().ForEach(x => Console.WriteLine(x.Name));
                }
                else
                {
                    Console.WriteLine("Non è stato trovato alcun videogioco");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        
    }

    public static void DeleteGameById(int id)
    {
        using (SqlConnection connectionSql = new SqlConnection(CONNECTION_STRING))
        {
                using VideogameContext db = new VideogameContext();
                try
                {
                    var videogame = db.Videogames.Where(x => x.VideogameId == id).ExecuteDelete();
                    if (videogame != null)
                    {
                        Console.Write($"Il gioco è stato eliminato ");
                    }
                    else
                    {
                        Console.WriteLine("Il gioco che cerchi non è presente.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
        }
    }
}

}
