namespace net_ef_videogame
{
    public class Program
    {
        static void Main(string[] args)
        {

            using VideogameContext db = new VideogameContext();
            SoftwareHouse softwareHouse = new SoftwareHouse()
            {
                Name = "Test",
                tax_Id = "test",
                City = "test",
                Country = "test",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            Videogame videogame = new Videogame("Ciao", "Ciao", "22/01/1997", DateTime.Now, DateTime.Now, 1);
            db.Add(videogame);
            db.SaveChanges();
            int ProgramOn = 1;
            while (ProgramOn != 0)
            {
                Console.WriteLine("\r\nInserisci un'opzione:");
                Console.WriteLine("1. Inserisci nuovo videogioco");
                Console.WriteLine("2. Cerca gioco per id:");
                Console.WriteLine("3. Cerca gioco per nome:");
                Console.WriteLine("4. Cancella videogioco:");
                Console.WriteLine("5. Termina programma:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        VideogameManager.InsertVideogame();
                        break;
                    case "2":
                        VideogameManager.SearchGameId();
                        break;
                    case "3":
                        VideogameManager.SearchGameName();
                        break;
                    case "4":
                        VideogameManager.DeleteGameById();
                        break;
                    case "5":
                        ProgramOn = 0;
                        break;
                }

            }
        }
    }
}
