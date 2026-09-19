using BackendAPI.Models;
using BackendAPI.Utils.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Controllers;
/// <summary>
/// Provides CRUD API endpoints for managing Ctest records.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class cTestController : ControllerBase {

    private readonly AppDbContext _db;                  // Database
    private readonly ILogger<cTestController> _logger;  // Logger
    private readonly IEmailSender _emailSender;         // Email
    /// <summary>
    /// Initializes a new instance of the cTestController.
    /// </summary>
    /// <param name="db">The application database context.</param>
    /// <param name="logger">The logger used to record controller activities and errors.</param>
    public cTestController(AppDbContext db, ILogger<cTestController> logger, IEmailSender email) {
        _db = db;
        _logger = logger;
        _emailSender = email;
    }

    /// <summary>
    /// Retrieves all Ctest records from the database.
    /// </summary>
    /// <returns>
    /// A list containing all Ctest records.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> Get() {
        var users = await _db.cTest.ToListAsync();

        return Ok(users);
    }

    /// <summary>
    /// Retrieves all Ctest records whose Int value is within the specified range.
    /// </summary>
    /// <param name="a">The minimum Int value, inclusive.</param>
    /// <param name="b">The maximum Int value, inclusive.</param>
    /// <returns>
    /// A list of Ctest records with Int values between the specified minimum and maximum values.
    /// </returns>
    [HttpGet("range")]
    public async Task<IActionResult> Get(int a, int b) {
        var users = await _db.cTest
            .Where(x => x.Int >= a && x.Int<= b)
            .ToListAsync();

        return Ok(users);
    }

    /// <summary>
    /// Retrieves a specific Ctest record by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the Ctest record.</param>
    /// <returns>
    /// The requested Ctest record if found; otherwise, a 404 Not Found response.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        var user = await _db.cTest.FindAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    /// <summary>
    /// Creates a new Ctest record in the database.
    /// </summary>
    /// <param name="ctest">The Ctest record to create.</param>
    /// <returns>
    /// The created Ctest record if the operation succeeds.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Create(Ctest ctest) {
        try {
            await _db.cTest.AddAsync(ctest);
            await _db.SaveChangesAsync();

            return Ok(ctest);
        }
        catch (DbUpdateException) {
            return NotFound();
        }
    }

    /// <summary>
    /// Updates an existing Ctest record by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the Ctest record to update.</param>
    /// <param name="ctest">The new data used to update the record.</param>
    /// <returns>
    /// The updated Ctest record if successful; otherwise, a 404 Not Found response.
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Ctest ctest) {
        var user = await _db.cTest.FindAsync(id);

        if (user == null)
            return NotFound();

        user.String = ctest.String;
        user.Date = ctest.Date;

        try {
            await _db.SaveChangesAsync();
            return Ok(user);
        }
        catch (DbUpdateException) {
            return NotFound();
        }
    }

    /// <summary>
    /// Deletes a Ctest record from the database by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the Ctest record to delete.</param>
    /// <returns>
    /// The deleted Ctest record if successful; otherwise, a 404 Not Found response.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        var user = await _db.cTest.FindAsync(id);

        if (user == null)
            return NotFound();

        try {
            _db.cTest.Remove(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }
        catch (DbUpdateException) {
            return NotFound();
        }
    }
}
