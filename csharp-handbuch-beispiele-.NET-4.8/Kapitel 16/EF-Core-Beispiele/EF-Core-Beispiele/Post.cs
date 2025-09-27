namespace EF_Core_Beispiele
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public string? Description { get; set; }

        public int BlogId { get; set; }
        public virtual Blog? Blog { get; set; }
    }
}
