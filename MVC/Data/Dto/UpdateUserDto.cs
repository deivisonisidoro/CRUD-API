using System.ComponentModel.DataAnnotations;

namespace MVC.Data.Dto;

/// <summary>
/// Data transfer object (DTO) for updating user information.
/// </summary>
public class UpdateUserDto
{
    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    [Required(ErrorMessage = "Please provide the user's name.")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [Required(ErrorMessage = "Please provide the user's email address.")]
    [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    [Required(ErrorMessage = "Please provide the user's password.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "The password must be exactly 8 characters long.")]
    public string Password { get; set; }
}
