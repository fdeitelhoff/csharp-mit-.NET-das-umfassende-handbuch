namespace EF_Core_Beispiele
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public UserProfile? Profile { get; set; }
    }

}
