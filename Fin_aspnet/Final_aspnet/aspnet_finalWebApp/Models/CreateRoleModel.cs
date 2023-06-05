using Microsoft.Build.Framework;


namespace aspnet_final.Models
{
    public class CreateRoleModel
    {
        [Required]

        public string RoleName { get; set; }  // Admin, User, Manager
    }
}
