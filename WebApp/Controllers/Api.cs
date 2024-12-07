using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpLogging;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class Api : Controller
{

    [HttpGet("/")]
    public IActionResult landingPage()
    {
        //TODO: this should check if the user is already logged in, right now it just sends you to the login page
        string pageName = "login";
        string path = Path.Combine(Directory.GetCurrentDirectory(), "frontend", pageName + ".html");
        Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        string contentType = "text/html";

        return File(fileStream, contentType);
    }
    
    [HttpGet("/{pageName}")]
    public IActionResult getPage(String pageName)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "frontend", pageName + ".html");
            Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            string contentType = "text/html";

            return File(fileStream, contentType);
    }
    
    [HttpPost("/login")]
    public IActionResult loginUser(string username)
    {
        //TODO: log the user in
        return Ok();
    }

    [HttpPost("/signup")]
    public IActionResult signupUser()
    {
        
        return Ok();
    }
    
    [HttpGet("/images/{imageName}")]
    public IActionResult getImage(string imageName)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "resources", imageName);
        if (System.IO.File.Exists(path))
        {
            Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            string contentType = "image/png";

            return File(fileStream, contentType);
        }
        return BadRequest();
    }
}