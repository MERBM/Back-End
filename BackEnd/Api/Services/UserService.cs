using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.AspNetCore.Identity;

namespace Api.Services
{
    public class UserService
{
    private readonly MyDBContext _context;

    public UserService(MyDBContext context)
    {
        _context = context;
    }

    // Sign up a new user
    public bool SignUp(User newUser)
    {
        var existingUser = _context.users.Any(u => u.Email == newUser.Email);
        if (existingUser)
        {
            // User already exists
            return false;
        }

        // Here, you should hash the password before saving
        newUser.PasswordHash = HashPassword(newUser.PasswordHash);

        _context.users.Add(newUser);
        _context.SaveChanges();
        return true;
    }

    // Login a user
    public User Login(string email, string password)
    {
        var user = _context.users.FirstOrDefault(u => u.Email == email);
        if (user != null && VerifyPassword(password, user.PasswordHash))
        {
            // Authentication successful
            return user;
        }

        // Authentication failed
        return null;
    }

    private string HashPassword(string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        return passwordHasher.HashPassword(null, password);
        // Implement password hashing
      
    }

    private bool VerifyPassword(string enteredPassword, string storedHash)
    {
        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(null, storedHash, enteredPassword);
        return result == PasswordVerificationResult.Success;
    }
}

}