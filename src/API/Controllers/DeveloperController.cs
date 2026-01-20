using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Context;
using System;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeveloperController : ControllerBase
{
    private readonly AppDbContext _context;
    public DeveloperController(AppDbContext context)
    {
        _context = context;
    }
    // GET
    [HttpGet]
    public IActionResult Get()
    {
        var developers = _context.Developers.ToList();
        return Ok(developers);
    }

    // GETBYID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var developer = _context.Developers.FirstOrDefault(d => d.Id == id);

        if (developer == null)
            return NotFound("Developer tapılmadı");

        return Ok(developer);
    }

    // POST
    [HttpPost]
    public IActionResult Create(Developer developer)
    {
        _context.Developers.Add(developer);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById),
            new { id = developer.Id },
            developer);
    }

    // UPDATE 
    [HttpPut("{id}")]
    public IActionResult Update(int id, Developer updatedDeveloper)
    {
        var developer = _context.Developers.FirstOrDefault(d => d.Id == id);

        if (developer == null)
            return NotFound("Developer tapılmadı");

        developer.Name = updatedDeveloper.Name;
        developer.Email = updatedDeveloper.Email;

        _context.SaveChanges();

        return Ok(developer);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var developer = _context.Developers.FirstOrDefault(d => d.Id == id);

        if (developer == null)
            return NotFound("Developer tapılmadı");

        _context.Developers.Remove(developer);
        _context.SaveChanges();

        return NoContent();
    }
}



