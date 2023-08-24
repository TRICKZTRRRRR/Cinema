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
            string connectionString = @"Data Source=ZBC-S-jona993p;Initial Catalog=cinema;User ID=cinema;Password=cinema1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    Console.WriteLine("Forbindelse oprettet");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl ved læsning af data: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
