using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connString = @"Data Source=ZBC-S-jona993p;Initial Catalog=cinema;User ID=cinema;Password=cinema1;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);
            try
            {
                Console.WriteLine("Tjekker forbindelsen");
                Thread.Sleep(2000);
                conn.Open();
                Console.WriteLine("Forbindelse oprettet");
                Thread.Sleep(2000);
                Console.Clear();

                Console.WriteLine("Du har følgende valgmuligheder:");
                Console.WriteLine("1. Tilføj \n 2. Ændrer \n 3. Slet \n 4. Gennemse (Af Database)");
                string answer = Console.ReadLine();
                
                if (answer == "gennemse")
                {
                    Console.Clear();

                    // SQL query to select all data from the table
                    string query = "SELECT * FROM Films";

                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        // Open the connection to the database
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Execute the SQL command and retrieve the data
                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                // Loop through the rows and print the data
                                while (reader.Read())
                                {
                                    int filmID = (int)reader["Film_ID"];
                                    string title = (string)reader["Title"];
                                    int cinemaHallID = (int)reader["Cinema_Hall_ID"];
                                    DateTime releaseDate = (DateTime)reader["Release_Date"];
                                    string genre = (string)reader["Genre"];
                                    int filmLength = (int)reader["Film_Length"];
                                    int ticketsID = (int)reader["Tickets_ID"];

                                    Console.WriteLine("Film_ID: {0}\t\nTitle: {1}\t\nCinema_Hall_ID: {2}\t\nRelease_Date: {3:yyyy-MM-dd}\t\nGenre: {4}\t\nFilm_Length: {5}\t\nTickets_ID: {6}\n", filmID, title, cinemaHallID, releaseDate, genre, filmLength, ticketsID);
                                    //Console.WriteLine("{0}\t{1}\t{2}\t{3:yyyy-MM-dd}\t{4}\t{5}\t{6}", filmID, title, cinemaHallID, releaseDate, genre, filmLength, ticketsID);
                                }
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fejl ved læsning af data: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
