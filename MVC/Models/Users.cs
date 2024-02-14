using System.ComponentModel.DataAnnotations;

namespace MVC.Models;

/// <summary>
/// Represents a user in the system.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    /// <remarks>
    /// This property is optional. It may not be provided when creating a new user.
    /// </remarks>
    [Key]
    [Required(ErrorMessage = "Please provide the user's id.")]
    public int Id { get; set; }


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
    [MinLength(8, ErrorMessage = "The password must be at least 8 characters long.")]
    public string Password { get; set; }
}
