using System.ComponentModel.DataAnnotations;

namespace IdentityRoleSystem.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email енгізу міндетті.")]
    [EmailAddress(ErrorMessage = "Email пішімі дұрыс емес.")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Құпиясөз міндетті.")]
    [DataType(DataType.Password)]
    [Display(Name = "Құпиясөз")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Мені есте сақта")]
    public bool RememberMe { get; set; }
}
