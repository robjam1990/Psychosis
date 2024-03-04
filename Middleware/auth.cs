using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using BCrypt.Net;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public static class AuthMiddleware
{
    private static readonly string FilePath = "users.json";

    public static List<User> LoadUsers()
    {
        try
        {
            var usersData = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<User>>(usersData);
        }
        catch (FileNotFoundException)
        {
            return new List<User>();
        }
        catch (JsonException)
        {
            return new List<User>();
        }
    }

    public static void SaveUsers(List<User> users)
    {
        var usersData = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(FilePath, usersData);
    }

    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool ValidatePassword(string password)
    {
        // Password strength requirements
        if (password.Length < 8 ||
            !password.Any(char.IsUpper) ||
            !password.Any(char.IsLower) ||
            !password.Any(char.IsDigit) ||
            !Regex.IsMatch(password, @"[!@#$%^&*(),.?"":{}|<>]"))
        {
            return false;
        }
        return true;
    }

    public static bool RegisterUser(string username, string password)
    {
        var users = LoadUsers();
        if (users.Any(user => user.Username == username))
        {
            Console.WriteLine("Username already exists. Please choose a different one.");
            return false;
        }

        if (!ValidatePassword(password))
        {
            Console.WriteLine("Password does not meet the requirements.");
            return false;
        }

        var hashedPassword = HashPassword(password);
        var newUser = new User { Username = username, Password = hashedPassword };
        users.Add(newUser);
        SaveUsers(users);
        Console.WriteLine("Registration successful.");
        return true;
    }

    public static bool VerifyPassword(string inputPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
    }

    public static bool LoginUser(string username, string password)
    {
        var users = LoadUsers();
        var user = users.FirstOrDefault(u => u.Username == username && VerifyPassword(password, u.Password));
        if (user != null)
        {
            Console.WriteLine("Login successful.");
            return true;
        }
        Console.WriteLine("Invalid username or password. Please try again.");
        return false;
    }

    // Additional functions for session management, password reset, etc. can be added here

    // Example usage:
    // RegisterUser("exampleUser", "StrongPassword123");
    // LoginUser("exampleUser", "StrongPassword123");
}
