using System.ComponentModel.DataAnnotations;


namespace MyApp.Backend.Models
{
    /// <summary>
    /// Kategóriák adatait tároló osztály.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Kategória id
        /// </summary> 
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// A kategória neve.
        /// </summary>
        /// 
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        public Category()
        {
            Name = string.Empty;
        }

        public Category(int id, string name)
        {
            Name = name;
            Id = id;
        }

        

        public override string ToString() => $"";
    }
}
