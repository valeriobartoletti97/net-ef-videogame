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
    public static void InsertVideogame()
    {
        Console.WriteLine("Inserisci nome del videogioco:");
        string name = Console.ReadLine();
        Console.WriteLine("Inserisci descrizione del videogioco:");
        string overview = Console.ReadLine();
        Console.WriteLine("Inserisci la data di rilascio del videogioco in formato GG/MM/AAAA:");
        string releaseDate = Console.ReadLine();
        DateTime createdAt = DateTime.Now;
        DateTime updatedAt = DateTime.Now;
        Random r = new Random();
        int softwareHouseId = r.Next(1, 7);


        Videogame newGame = new Videogame(name, overview, releaseDate, createdAt, updatedAt, softwareHouseId);
        using (SqlConnection connectionSql = new SqlConnection(CONNECTION_STRING))
        {
            try
            {
                connectionSql.Open();
                string query = "INSERT INTO videogames (name,overview,release_date,created_at,updated_at,software_house_id) VALUES (@name, @overview, @release_date, @created_at, @updated_at, @softwarehouseId)";
                SqlCommand cmd = new SqlCommand(query, connectionSql);
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@overview", overview));
                cmd.Parameters.Add(new SqlParameter("@release_date", releaseDate));
                cmd.Parameters.Add(new SqlParameter("@created_at", createdAt));
                cmd.Parameters.Add(new SqlParameter("@updated_at", updatedAt));
                cmd.Parameters.Add(new SqlParameter("@softwarehouseid", softwareHouseId));

                int affectedRows = cmd.ExecuteNonQuery();
                Console.WriteLine($"Il videogame {name} è stato aggiunto!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
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

    public static void DeleteGameById()
    {
        using (SqlConnection connectionSql = new SqlConnection(CONNECTION_STRING))
        {
            try
            {
                connectionSql.Open();
                Console.Write("Inserisci l'Id del gioco che vuoi eliminare:");
                string dataId = Console.ReadLine();
                string query = $"DELETE FROM videogames where id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connectionSql))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", dataId));
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        Console.WriteLine($"Il gioco con id uguale a {dataId} è stato eliminato");
                    }
                    else
                    {
                        Console.WriteLine("Si è verificato un errore");
                    }
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
