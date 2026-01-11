using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyApp.Backend.Models
{

    /// <summary>
    /// Issues adatait tároló osztály.
    /// </summary>
    public class Issue
    {
        /// <summary>
        /// ID.
        /// </summary>
        [Key, Required]
        public int Id { get; set; }

        /// <summary>
        /// A title neve.
        /// </summary>
        [Required, MaxLength(150)]
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [ForeignKey(nameof(Status)), Required]
        public int Statusid { get; set; }

        public Status Status { get; set; }

        /// <summary>
        /// Priority
        /// </summary>
        [ForeignKey(nameof(Priority)), Required]
        public int Priorityid { get; set; }
        public Priority Priority { get; set; }

        /// <summary>
        /// LocationId
        /// </summary>

        [ForeignKey(nameof(Location)), Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        [ForeignKey(nameof(Category)), Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        /// <summary>
        /// Comment
        /// </summary>

        [ForeignKey("Comment")]
        public int Commentid { get; set; }




        public Issue()
        {
            Title = string.Empty;
            Description = string.Empty;
        }

        public Issue(int id, string title, string description, int statusid, int priorityid, int locationid, int categoryid, int commentid)
        {
            Id = id;
            Title = title;
            Description = description;
            Statusid = statusid;
            Priorityid = priorityid;
            LocationId = locationid;
            CategoryId = categoryid;
            Commentid = commentid;
        }

        public override string ToString() => $"";
    }
}
