using MVC.Models;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Data.Dto;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace MVC.Controllers;

/// <summary>
/// Controller for managing user-related operations such as creation, retrieval, updating, and deletion.
/// </summary>
[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private MVCContext _context;
    private IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="context">The database context for accessing user data.</param>
    /// <param name="mapper">The mapper for mapping between DTOs and User entities.</param>
    public UserController(MVCContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="userDto">The DTO containing user details.</param>
    /// <returns>The action result indicating the outcome of the operation.</returns>
    /// <response code="201">Returned when the user is successfully created.</response>
    /// <response code="400">Returned when the request contains invalid data.</response>
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        _context.User.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListById), new { id = user.Id }, user);
    }

    /// <summary>
    /// Retrieves a list of users.
    /// </summary>
    /// <param name="skip">The number of users to skip.</param>
    /// <param name="take">The maximum number of users to return.</param>
    /// <returns>A list of users.</returns>
    /// <response code="200">Returned when the list of users is successfully retrieved.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReadUserDto>), StatusCodes.Status200OK)]
    public IEnumerable<ReadUserDto> ListAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadUserDto>>(_context.User.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retrieves a user by their identifier.
    /// </summary>
    /// <param name="id">The identifier of the user to retrieve.</param>
    /// <returns>The action result containing the user if found; otherwise, NotFound.</returns>
    /// <response code="200">Returned when the user is successfully retrieved.</response>
    /// <response code="404">Returned when the user with the specified identifier is not found.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReadUserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult ListById(int id)
    {
        var user = _context.User.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound();
        var userDto = _mapper.Map<ReadUserDto>(user);
        return Ok(userDto);
    }

    /// <summary>
    /// Updates a user by their identifier.
    /// </summary>
    /// <param name="id">The identifier of the user to update.</param>
    /// <param name="userDto">The DTO containing updated user details.</param>
    /// <returns>The action result indicating the outcome of the operation.</returns>
    /// <response code="204">Returned when the user is successfully updated.</response>
    /// <response code="404">Returned when the user with the specified identifier is not found.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] UpdateUserDto userDto)
    {
        var user = _context.User.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound();
        _mapper.Map(userDto, user);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Partially updates a user by their identifier.
    /// </summary>
    /// <param name="id">The identifier of the user to update.</param>
    /// <param name="patch">The JSON patch document containing the update instructions.</param>
    /// <returns>The action result indicating the outcome of the operation.</returns>
    /// <response code="204">Returned when the user is successfully updated.</response>
    /// <response code="400">Returned when the request contains invalid data.</response>
    /// <response code="404">Returned when the user with the specified identifier is not found.</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PartialUpdate(int id, JsonPatchDocument<UpdateUserDto> patch)
    {
        var user = _context.User.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound();
        var userToUpdate = _mapper.Map<UpdateUserDto>(user);
        patch.ApplyTo(userToUpdate, ModelState);
        if (!TryValidateModel(userToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(userToUpdate, user);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deletes a user by their identifier.
    /// </summary>
    /// <param name="id">The identifier of the user to delete.</param>
    /// <returns>The action result indicating the outcome of the operation.</returns>
    /// <response code="204">Returned when the user is successfully deleted.</response>
    /// <response code="404">Returned when the user with the specified identifier is not found.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var user = _context.User.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound();
        _context.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }

}
