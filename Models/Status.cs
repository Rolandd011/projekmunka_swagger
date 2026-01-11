using System.ComponentModel.DataAnnotations;

namespace MyApp.Backend.Models
{
    public class Status
    {
        /// <summary>
        /// Status Id
        /// </summary>
        [Key, Required]
        public int StatusId { get; set; }

        /// <summary>
        /// Status Name
        /// </summary>
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        public Status()
        {
            Name = string.Empty;
        }

        public Status(int id, string name)
        {
            StatusId = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
