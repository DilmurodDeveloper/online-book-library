using OnlineBookLibrary.Server.Data;
using OnlineBookLibrary.Server.Models;

public static class SeedData
{
    public static void Initialize(BookDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Books!.Any())
        {
            return;
        }

        context.Books!.AddRange(
            new Book { Title = "Epics", Author = "Alisher Navoiy", CategoryId = 1 },
            new Book { Title = "Days Gone", Author = "Abdulla Qodiriy", CategoryId = 2 }
        );

        context.SaveChanges();
    }
}
