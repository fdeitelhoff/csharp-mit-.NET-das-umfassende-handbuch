// See https://aka.ms/new-console-template for more information
using EF_Core_Beispiele;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// Geht auch. Ansprechen!
//var options = new DbContextOptionsBuilder<BloggingContext>()
//    .UseInMemoryDatabase("TestDb")
//    .Options;

//using var context = new BloggingContext();

//var blog = context.Blogs.First();
//blog.Url = "https://neue-url.de";

//context.SaveChanges();

//using var context = new BloggingContext();

//var posts = context.Posts
//    .Where(p => p.Title!.Contains("EF Core"))
//    .OrderByDescending(p => p.Id)
//    .ToList();

using var context = new BloggingContext();

// Datenbank erstellen, falls sie noch nicht existiert
context.Database.EnsureCreated();

// Neuen Blog anlegen und speichern
var blog = new Blog { Url = "https://example.com" };
context.Blogs.Add(blog);
context.SaveChanges();

// Beiträge hinzufügen
context.Posts.Add(new Post
{
    Title = "Einführung in EF Core",
    Content = "EF Core macht Datenzugriff einfacher.",
    BlogId = blog.Id
});

context.SaveChanges();

//Console.WriteLine("Daten gespeichert");

//// Blogs samt Beiträgen abfragen
//var blogs = context.Blogs
//    .Include(b => b.Posts)
//    .ToList();

//foreach (var b in blogs)
//{
//    Console.WriteLine($"Blog: {b.Url}");
//    foreach (var post in b.Posts)
//    {
//        Console.WriteLine($"  Beitrag: {post.Title}");
//    }
//}

var posts = context.Posts
    .Where(p => p.BlogId == 1)
    .OrderByDescending(p => p.Id)
    .ToList();

foreach (var post in posts)
{
    Console.WriteLine($"{post.Title} – {post.Content}");
}

//var posts2 = context.Posts
//    .Where(p => p.BlogId == 1 && p.Title!.Contains("EF"))
//    .ToList();

//var titles = context.Posts
//    .Select(p => p.Title)
//    .ToList();

//var summaries = context.Posts
//    .Select(p => new { p.Title, p.Content })
//    .ToList();

//var posts3 = context.Posts
//    .OrderBy(p => p.Title)
//    .ThenByDescending(p => p.Id)
//    .ToList();

int count = context.Posts.Count();
double avgLength = context.Posts.Average(p => p.Content!.Length);

var grouped = context.Posts
    .GroupBy(p => p.BlogId)
    .Select(g => new
    {
        BlogId = g.Key,
        Count = g.Count()
    })
    .ToList();

// NOch einmal prüfen!
//var posts4 = context.Posts
//    .FromSql($"SELECT * FROM Posts WHERE Title LIKE '%EF%'");
//    //.ToList();

var blog3 = context.Blogs.First();

context.Entry(blog3)
    .Collection(b => b.Posts)
    .Load();

var posts5 = context.Posts
    .AsNoTracking()
    .Where(p => p.Title!.Contains("EF"))
    .ToList();

var student = new Student { Name = "Anna" };
var course = new Course { Title = "EF Core Grundlagen" };

student.Courses.Add(course);
context.Students.Add(student);
context.SaveChanges();


Console.ReadLine();