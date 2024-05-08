namespace net_ef_videogame
{
    public class Program
    {
        static void Main(string[] args)
        {

            using VideogameContext db = new VideogameContext();
            /*Videogame videogame = new Videogame("Ciao", "Ciao", "22/01/1997", DateTime.Now, DateTime.Now, 1);
            db.Add(videogame);
            db.SaveChanges();*/
            int ProgramOn = 1;
            while (ProgramOn != 0)
            {
                Console.WriteLine("\r\nInserisci un'opzione:");
                Console.WriteLine("1. Inserisci nuovo videogioco");
                Console.WriteLine("2. Cerca gioco per id:");
                Console.WriteLine("3. Cerca gioco per nome:");
                Console.WriteLine("4. Cancella videogioco:");
                Console.WriteLine("4. Cancella videogioco:");
                Console.WriteLine("5. Inserisci nuova Software House:");
                Console.WriteLine("6. Termina programma:");
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
                        Console.WriteLine("Inserisci il nome del videogioco da cercare:");
                        string videogameName = Console.ReadLine();
                        VideogameManager.SearchGameName(videogameName);
                        break;
                    case "4":
                        VideogameManager.DeleteGameById();
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine("Inserisci nome della Software House:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Inserisci la nazionalità della software house:");
                            string country = Console.ReadLine();
                            Console.WriteLine("Inserisci la sede della software house:");
                            string city = Console.ReadLine();
                            SoftwareHouse softwareHouse = new SoftwareHouse(name, country, city);
                            SoftwareHouseManager.InserisciSoftwareHouse(softwareHouse);
                        }
                        catch (Exception e) 
                        {  
                            Console.WriteLine(e.ToString()); 
                        }
                        break;
                    case "6":
                        ProgramOn = 0;
                        break;
                }

            }
        }
    }
}
