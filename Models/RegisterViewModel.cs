using System.ComponentModel.DataAnnotations;

namespace IdentityRoleSystem.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Email енгізу міндетті.")]
    [EmailAddress(ErrorMessage = "Email пішімі дұрыс емес.")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Аты міндетті.")]
    [StringLength(50, ErrorMessage = "Аты 50 таңбадан аспауы керек.")]
    [Display(Name = "Аты")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Тегі міндетті.")]
    [StringLength(50, ErrorMessage = "Тегі 50 таңбадан аспауы керек.")]
    [Display(Name = "Тегі")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Құпиясөз міндетті.")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Құпиясөз кемінде 6 таңба болуы керек.")]
    [Display(Name = "Құпиясөз")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Құпиясөзді растау міндетті.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Құпиясөздер сәйкес емес.")]
    [Display(Name = "Құпиясөзді растау")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
