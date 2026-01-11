using System.ComponentModel.DataAnnotations;


namespace MyApp.Backend.Models
{
    /// <summary>
    /// Helyszínek adatait tároló osztály.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Helyszín id
        /// </summary>
        [Key, Required]
        public int Id { get; set; }

        /// <summary>
        /// Helyszín neve
        /// </summary>
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Issue> Issues { get; set; } = new List<Issue>();


        public Location()
        {
            Name = string.Empty;
        }


        public Location(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => $"";
    }
}
