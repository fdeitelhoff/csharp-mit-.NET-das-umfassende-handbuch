using EFCoreToPostgreSQL.Context;
using EFCoreToPostgreSQL.Models;
using Microsoft.EntityFrameworkCore;

//using (var db = new BloggingContext())
//{
//    var blog = new Blog { Url = "https://example.com" };
//    db.Blogs.Add(blog);

//    var post1 = new Post { Title = "First Post", Content = "This is the first post.", Blog = blog };
//    db.Posts.Add(post1);

//    var post2 = new Post { Title = "Second Post", Content = "This is the second post.", Blog = blog };
//    db.Posts.Add(post2);

//    db.SaveChanges();
//}

//using (var db = new BloggingContext())
//{
//    var blogs = db.Blogs
//                  .Include(b => b.Posts)
//                  .ToList();

//    foreach (var blog in blogs)
//    {
//        Console.WriteLine($"Blog: {blog.Url}");
//        foreach (var post in blog.Posts)
//        {
//            Console.WriteLine($"  Post: {post.Title}");
//        }
//    }
//}

var dbContext = new BloggingContext();

var posts = dbContext.Posts
    .FromSqlRaw("SELECT * FROM public.\"Posts\" WHERE \"Title\" LIKE '%First%'")
    .ToList();


Console.ReadLine();