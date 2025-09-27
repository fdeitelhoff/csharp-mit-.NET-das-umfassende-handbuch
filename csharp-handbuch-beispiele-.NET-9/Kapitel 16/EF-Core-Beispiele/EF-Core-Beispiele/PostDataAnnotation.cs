using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Beispiele
{
    public class PostDataAnnotation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; set; }

        public Blog? Blog { get; set; }
    }

}
