using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Example13
{
    class Program
    {
        static void List()
        {
            Console.WriteLine("List all");

            using(var connection = new MySqlConnection
            {
                ConnectionString = "server=127.0.0.1;user id=root;password=123456;persistsecurityinfo=True;database=School;"
            })
            {
                connection.Open();

                var command = new MySqlCommand("SELECT FirstName, LastName FROM Students", connection);
 
                using (var reader =  command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["FirstName"]}\t\t{reader["LastName"]}");
                    }
                }
    
                connection.Close();
            }
        }

        static void AddStudent(string firstName, string lastName, int englishScore, int mathScore)
        {
            using(var connection = new MySqlConnection
            {
                ConnectionString = "server=127.0.0.1;user id=root;password=123456;persistsecurityinfo=True;database=School;"
            })
            {
                connection.Open();

                var command = new MySqlCommand("insert into Students (FirstName, LastName, EnglishScore, MathScore) values (@FirstName, @LastName, @EnglishScore, @MathScore)", connection);

                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@EnglishScore", englishScore);
                command.Parameters.AddWithValue("@MathScore", mathScore);
 
                command.ExecuteNonQuery();
    
                connection.Close();
            }
        }

        static void Main(string[] args)
        {
            List();
            
            AddStudent("Debao", "Wang", 88, 99);
            AddStudent("Philips", "Zhang", 77, 98);

            List();

            Console.ReadKey();
        }
    }
}
