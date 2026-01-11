using System.ComponentModel.DataAnnotations;

namespace MyApp.Backend.Models
{
    /// <summary>
    /// Felhasználó osztály
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        [Required, MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// User Email
        /// </summary>

        [Required]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }


        // Üres konstruktor
        public User()
        {
            Name = String.Empty;
            Email = String.Empty;
            PasswordHash = String.Empty;
        }

        // Paraméteres konstruktor
        public User(int id, string name, string email, string passwordhash, Role role)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordhash;
            Role = role;
        }

        // Barátságos megjelenítés
        public override string ToString()
        {
            return $"";
        }
    }
}
