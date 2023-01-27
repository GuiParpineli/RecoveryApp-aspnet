using System.ComponentModel.DataAnnotations;

namespace RecoveryApp_ASPNET.Models.UserModel
{
    public class UserApp
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastNmae { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
