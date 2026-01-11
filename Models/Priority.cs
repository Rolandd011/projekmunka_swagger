using System.ComponentModel.DataAnnotations;


namespace MyApp.Backend.Models
{
    public class Priority
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        [Key, Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the entity.
        /// </summary>
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Issue> issues { get; set; } = new List<Issue>();
        
        public Priority()
        {
            Name = string.Empty;
        }

        public Priority(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
