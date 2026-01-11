using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyApp.Backend.Models
{
    public class UserAction
    {

        [Key, Required]
        public int Id { get; set; }


        [ForeignKey(nameof(Issue)), Required]
        public int IssueId { get; set; }

        public Issue Issue { get; set; }

        /// <summary>
        /// Issue Date
        /// </summary>

        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// UserId
        /// </summary>

        [ForeignKey (nameof (User)), Required]
        public int UserId { get; set; }

        public User User { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        [Required, MaxLength(200)]
        public string ActionText { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }



        public UserAction()
        {

        }

        public UserAction(int id, DateTime date, int issueid, int userid, string actiontext, string message)
        {
            IssueId = id;
            Date = date;
            UserId = userid;
            ActionText = actiontext;
            Message = message;
        }
    }
}
