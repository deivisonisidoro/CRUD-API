namespace MVC.Data.Dto;

/// <summary>
/// Data transfer object (DTO) for reading user information.
/// </summary>
public class ReadUserDto
{
    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string Email { get; set; }
}
