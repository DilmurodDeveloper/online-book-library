using OnlineBookLibrary.Server.Data;
using OnlineBookLibrary.Server.Models;
using OnlineBookLibrary.Shared.Enums;

public static class SeedData
{
    public static void Initialize(BookDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Categories!.Any())
        {
            context.Categories!.AddRange(
                new Category { Name = CategoryEnum.Fiction.ToString() },
                new Category { Name = CategoryEnum.NonFiction.ToString() },
                new Category { Name = CategoryEnum.Science.ToString() },
                new Category { Name = CategoryEnum.History.ToString() },
                new Category { Name = CategoryEnum.Technology.ToString() }
            );
            context.SaveChanges();
        }

        if (!context.Books!.Any())
        {
            var fiction = context.Categories!.FirstOrDefault(c => c.Name == CategoryEnum.Fiction.ToString())!;
            var science = context.Categories!.FirstOrDefault(c => c.Name == CategoryEnum.Science.ToString())!;
            var history = context.Categories!.FirstOrDefault(c => c.Name == CategoryEnum.History.ToString())!;
            var tech = context.Categories!.FirstOrDefault(c => c.Name == CategoryEnum.Technology.ToString())!;

            context.Books!.AddRange(
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    Description = "A dystopian novel set in a totalitarian society.",
                    CategoryId = fiction.Id
                },
                new Book
                {
                    Title = "A Brief History of Time",
                    Author = "Stephen Hawking",
                    Description = "An overview of cosmology for the general public.",
                    CategoryId = science.Id
                },
                new Book
                {
                    Title = "Sapiens",
                    Author = "Yuval Noah Harari",
                    Description = "A history of humankind.",
                    CategoryId = history.Id
                },
                new Book
                {
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    Description = "A handbook of agile software craftsmanship.",
                    CategoryId = tech.Id
                }
            );
            context.SaveChanges();
        }
    }
}