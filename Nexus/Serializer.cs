using System;
using System.Text.Json;

namespace Serializer
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Person object
            Person person = new Person
            {
                FirstName = "Robert",
                LastName = "Newell",
                Username = "robjam1990",
                Age = 34
            };

            // Serialize the Person object to a JSON string
            string json = JsonSerializer.Serialize(person);
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(json);
            Console.ReadLine();

            // Deserialize the JSON string back to a Person object
            Person deserializedPerson = JsonSerializer.Deserialize<Person>(json);

            // Print the deserialized Person object's properties
            Console.WriteLine("\nDeserialized Person:");
            Console.WriteLine($"First Name: {deserializedPerson.FirstName}");
            Console.WriteLine($"Last Name: {deserializedPerson.LastName}");
            Console.WriteLine($"Username: {deserializedPerson.Username}");
            Console.WriteLine($"Age: {deserializedPerson.Age}");
            Console.ReadLine();
        }
    }
}
