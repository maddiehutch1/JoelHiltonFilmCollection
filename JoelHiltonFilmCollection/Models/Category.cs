using System.ComponentModel.DataAnnotations;

namespace Mission06_MadHutchings.Models
{
    // meet this friendly subtable... created the key and the other columns for it
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
