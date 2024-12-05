using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpLogging;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class Api : Controller
{
    [HttpGet("/login")]
    public IActionResult loginPage()
    {
        //TODO: send login html
        return Ok();
    }
    
    [HttpGet("/login/{username}")]
    public IActionResult loginUser(string username)
    {
        //TODO: log the user in
        return Ok();
    }
    
    [HttpGet("/images/{imageName}")]
    public IActionResult getImage(string imageName)
    {
        if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "images", imageName)))
        {
            Stream fileStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageName), FileMode.Open, FileAccess.Read);
            string contentType = "image/png";

            return File(fileStream, contentType);
        }
        return BadRequest();
    }
    
    
    
    
}