using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Api.Data
{
    public static class DataSeeder
    {
    public static void SeedData(MyDBContext context , IConfiguration configuration)
    {
         if (!context.Categories.Any())
        {
            var categories = new List<Category>
            {
               new Category { Name = "GEO COLLECTION", Description = "Geometrically inspired rugs with modern patterns." },
                new Category { Name = "CLASSIC", Description = "Timeless and traditional rug designs." },
                new Category { Name = "MODERN", Description = "Contemporary rugs for modern interiors." },
                new Category { Name = "INDOOR-OUTDOOR", Description = "Rugs suitable for both indoor and outdoor use." },
                new Category { Name = "KIDS RUGS", Description = "Fun and colorful rugs for children's rooms." },
                new Category { Name = "HAND TUFT", Description = "Handcrafted tufted rugs." },
                new Category { Name = "SHAG", Description = "Soft and cozy shag rugs." },
                new Category { Name = "GOBELIN", Description = "Elegantly designed gobelin rugs." },
                new Category { Name = "BATHROOM MAT", Description = "Soft and absorbent mats for bathrooms." },
                new Category { Name = "MAC COLLECTION", Description = "Exclusive Mac Collection rugs." },
                new Category { Name = "ROUND AREA RUG", Description = "Stylish round area rugs." },
                new Category { Name = "GOBELIN TABLEAU", Description = "Artistic gobelin tableau rugs." },
                new Category { Name = "GEO COLLECTION", Description = "Geometrically inspired rugs with modern patterns." },
                new Category { Name = "CLASSIC", Description = "Timeless and traditional rug designs." },
                new Category { Name = "MODERN", Description = "Contemporary rugs for modern interiors." },
                new Category { Name = "INDOOR-OUTDOOR", Description = "Rugs suitable for both indoor and outdoor use." },
                new Category { Name = "KIDS RUGS", Description = "Fun and colorful rugs for children's rooms." },
                new Category { Name = "HAND TUFT", Description = "Handcrafted tufted rugs." },
                new Category { Name = "SHAG", Description = "Soft and cozy shag rugs." },
                new Category { Name = "GOBELIN", Description = "Elegantly designed gobelin rugs." },
                new Category { Name = "BATHROOM MAT", Description = "Soft and absorbent mats for bathrooms." },
                new Category { Name = "MAC COLLECTION", Description = "Exclusive Mac Collection rugs." },
                new Category { Name = "ROUND AREA RUG", Description = "Stylish round area rugs." },
                new Category { Name = "GOBELIN TABLEAU", Description = "Artistic gobelin tableau rugs." }
          
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        // Seed Products
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product { Name = "Geo Pattern Rug", Description = "Geometrically inspired rug with modern patterns.", Price = 120.99M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "GEO COLLECTION".ToLower()).CategoryID, ImageURL = "images/geo_pattern_rug.png" },
                new Product { Name = "Classic Oriental Rug", Description = "Traditional oriental rug with timeless appeal.", Price = 200.50M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "CLASSIC".ToLower()).CategoryID, ImageURL = "images/classic_oriental_rug.png" },
                new Product { Name = "Contemporary Art Rug", Description = "A modern rug inspired by contemporary art.", Price = 180.75M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "MODERN".ToLower()).CategoryID, ImageURL = "images/contemporary_art_rug.png" },
                new Product { Name = "Versatile Indoor-Outdoor Rug", Description = "Perfect for both indoor and outdoor settings.", Price = 150.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "INDOOR-OUTDOOR".ToLower()).CategoryID, ImageURL = "images/indoor_outdoor_rug.png" },
                new Product { Name = "Colorful Kids Rug", Description = "Bright and playful rug for children's rooms.", Price = 85.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "KIDS RUGS".ToLower()).CategoryID, ImageURL = "images/colorful_kids_rug.png" },
                new Product { Name = "Hand Tufted Wool Rug", Description = "Handcrafted tufted rug made from the finest wool.", Price = 220.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "HAND TUFT".ToLower()).CategoryID, ImageURL = "images/hand_tufted_wool_rug.png" },
                new Product { Name = "Luxury Shag Rug", Description = "Ultra-soft shag rug for a cozy feel.", Price = 250.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "SHAG".ToLower()).CategoryID, ImageURL = "images/luxury_shag_rug.png" },
                new Product { Name = "Gobelin Style Rug", Description = "Elegant gobelin rug with intricate designs.", Price = 300.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "GOBELIN".ToLower()).CategoryID, ImageURL = "images/gobelin_style_rug.png" },
                new Product { Name = "Soft Bathroom Mat", Description = "Comfortable and absorbent mat for bathrooms.", Price = 50.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "BATHROOM MAT".ToLower()).CategoryID, ImageURL = "images/soft_bathroom_mat.png" },
                new Product { Name = "Geometric Abstract Rug", Description = "A rug featuring bold geometric patterns for a modern look.", Price = 210.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "GEO COLLECTION".ToLower()).CategoryID, ImageURL = "images/geometric_abstract_rug.png" },
                new Product { Name = "Minimalist Geo Rug", Description = "Sleek and minimalist design with subtle geometric shapes.", Price = 190.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "GEO COLLECTION".ToLower()).CategoryID, ImageURL = "images/minimalist_geo_rug.png" },
                new Product { Name = "Vintage Classic Rug", Description = "A classic rug with a vintage feel, perfect for elegant spaces.", Price = 250.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "CLASSIC".ToLower()).CategoryID, ImageURL = "images/vintage_classic_rug.png" },
                new Product { Name = "Royal Classic Carpet", Description = "A carpet that exudes classic elegance and royal charm.", Price = 300.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "CLASSIC".ToLower()).CategoryID, ImageURL = "images/royal_classic_carpet.png" },
                new Product { Name = "Urban Chic Rug", Description = "A rug that embodies the essence of modern urban design.", Price = 220.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "MODERN".ToLower()).CategoryID, ImageURL = "images/urban_chic_rug.png" },
                new Product { Name = "Modern Artistic Rug", Description = "A creatively designed rug, perfect for modern art lovers.", Price = 245.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "MODERN".ToLower()).CategoryID, ImageURL = "images/modern_artistic_rug.png" },
                new Product { Name = "Versatile All-Weather Rug", Description = "Designed for both indoor and outdoor use, resilient in all weather conditions.", Price = 180.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "INDOOR-OUTDOOR".ToLower()).CategoryID, ImageURL = "images/all_weather_rug.png" },
                new Product { Name = "Patio-Friendly Rug", Description = "A perfect addition to your patio, blending durability with style.", Price = 160.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "INDOOR-OUTDOOR".ToLower()).CategoryID, ImageURL = "images/patio_friendly_rug.png" },
                new Product { Name = "Mac Collection Elegant Rug", Description = "Part of the exclusive Mac Collection, offering sophistication and style.", Price = 345.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "MAC COLLECTION".ToLower()).CategoryID, ImageURL = "images/mac_collection_elegant_rug.png" },
                new Product { Name = "Round Area Rug", Description = "A beautifully designed round rug, perfect for any area.", Price = 180.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "ROUND AREA RUG".ToLower()).CategoryID, ImageURL = "images/round_area_rug.png" },
                new Product { Name = "Gobelin Tableau Rug", Description = "Artistic and ornate, a masterpiece for your floor.", Price = 375.00M, CategoryID = context.Categories.FirstOrDefault(c => c.Name.ToLower() == "GOBELIN TABLEAU".ToLower()).CategoryID, ImageURL = "images/gobelin_tableau_rug.png" }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
        var adminEmail = configuration["AdminUser:Username"];
        var adminPassword = configuration["AdminUser:Password"];

        if (!context.users.Any(u => u.Email == adminEmail))
        {
            var adminUser = new User
            {
                Username = "Admin",
                Email = adminEmail,
                PasswordHash = HashPassword(adminPassword), // Replace with a real hash function
                // Set other required fields as necessary
            };

            context.users.Add(adminUser);
            context.SaveChanges();
        }
    }
    private static string HashPassword(string password)
    {
       var passwordHasher = new PasswordHasher<User>();
        return passwordHasher.HashPassword(null, password);
    }
    }

}