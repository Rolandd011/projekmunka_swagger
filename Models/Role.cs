using System.ComponentModel.DataAnnotations;

namespace MyApp.Backend.Models
{
    /// <summary>
    /// Szerepkörök adatait tároló osztály.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Role id
        /// </summary>

        [Key, Required]
        public int RoleId { get; set; }

        /// <summary>
        ///  Szerepkör neve.
        /// </summary>

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection <User> Users { get; set; } = new List<User> ();

        public Role()
        {
            Name = string.Empty;
        }

        public Role(int roleid, string name)
        {
            Name = name;
            RoleId = roleid;
        }

        public override string ToString() => $"";
    }
}
