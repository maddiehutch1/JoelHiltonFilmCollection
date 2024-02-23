using System.ComponentModel.DataAnnotations;

namespace Mission06_MadHutchings.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
