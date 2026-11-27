using IdentityRoleSystem.Data;
using IdentityRoleSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityRoleSystem.Controllers;

[Authorize]
public class StudentsController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public StudentsController(AppDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _context.Users
            .AsNoTracking()
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .ToListAsync();

        var students = new List<ApplicationUser>();
        foreach (var user in users)
        {
            if (await _userManager.IsInRoleAsync(user, "Student"))
            {
                students.Add(user);
            }
        }

        ViewData["IsAdmin"] = await _userManager.IsInRoleAsync(
            await _userManager.GetUserAsync(User),
            "Admin");
        return View(students);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        if (!await _userManager.IsInRoleAsync(user, "Student"))
        {
            return Forbid();
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            TempData["Error"] = "Пайдаланушыны жою мүмкін болмады.";
        }
        else
        {
            TempData["Success"] = "Студент сәтті жойылды.";
        }
        return RedirectToAction(nameof(Index));
    }
}
