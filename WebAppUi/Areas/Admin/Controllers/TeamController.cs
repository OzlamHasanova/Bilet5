using Core.Entities;
using DataAcces.Context;
using Microsoft.AspNetCore.Mvc;

namespace WebAppUi.Areas.Admin.Controllers;
[Area("Admin")]
public class TeamController : Controller
{
    private readonly AppDbContext _appDbContext;

    public TeamController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
        return View(_appDbContext.Member);
    }

    public async Task<IActionResult> Detail(int id)
    {
        if(id == null)return NotFound();
        var member = await _appDbContext.Member.FindAsync(id);
        if (member == null) return BadRequest();
        return View(member);    

    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TeamMember person)
    {
        if (!ModelState.IsValid)return View(person);
        var member = await _appDbContext.Member.AddAsync(person);
        await _appDbContext.SaveChangesAsync();
        if (member == null) return BadRequest();
        return RedirectToAction(nameof(Index));

    }
    public async Task<IActionResult> Update(int? id)
    {
        if (id == null) return NotFound();
        var member = await _appDbContext.Member.FindAsync(id);
        if (member == null) return BadRequest();
        return View(member);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(TeamMember person,int? id)
    {
        if (!ModelState.IsValid) return View(person);
        var memberdb = await _appDbContext.Member.FindAsync(id);
        memberdb.Image=person.Image;
        memberdb.Name=person.Name;
        memberdb.Description=person.Description;
        memberdb.Position=person.Position;
        await _appDbContext.SaveChangesAsync();
        if (person == null) return BadRequest();
        return RedirectToAction(nameof(Index));

    }
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null) return NotFound();
        var member = await _appDbContext.Member.FindAsync(id);
        if (member == null) return BadRequest();
        return View(member);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int id)
    {
        if (id == null) return NotFound();
        var member = await _appDbContext.Member.FindAsync(id);
        _appDbContext.Remove(member);
        await _appDbContext.SaveChangesAsync();
        if (member == null) return BadRequest();
        return RedirectToAction(nameof(Index));
    }
}
