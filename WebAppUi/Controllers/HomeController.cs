using DataAcces.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppUi.Models;

namespace WebAppUi.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Member);
    }
}