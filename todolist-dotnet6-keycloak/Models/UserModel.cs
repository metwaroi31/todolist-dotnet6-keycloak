using System.ComponentModel.DataAnnotations;

namespace todolist_dotnet6_keycloak.Models
{
    public class UserModel
    {
        public UserModel(string Username, string Password) 
        {
            this.Username = Username;
            this.Password = Password;
            this.CreatedAt = DateTime.Now;
        }

        [Required]
        [Key]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
